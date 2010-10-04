using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using AshMind.Extensions;

namespace AshMind.Net.Caching.Http {
    public class CacheControl {
        private static readonly IDictionary<string, Action<CacheControl, string>> parseValueSetters =
            new Dictionary<string, Action<CacheControl, string>>(StringComparer.InvariantCultureIgnoreCase) {
                { "max-age",  (c, value) => c.MaxAge = ParseAsSeconds(value) },
                { "s-maxage", (c, value) => c.SharedMaxAge = ParseAsSeconds(value) },
                { "no-cache",  (c, value) => {
                    c.NoCache = true;
                    if (value.IsNotNullOrEmpty())
                        c.NoCacheHeaderNames.AddRange(AbnfSplit(value, ','));
                } },
                { "no-store",  (c, value) => c.NoStore = true },
                { "private",  (c, value) => {
                    c.Private = true;
                    if (value.IsNotNullOrEmpty())
                        c.PrivateHeaderNames.AddRange(AbnfSplit(value, ','));
                } },
                { "public",   (c, value) => c.Public = true },

                { "no-transform",     (c, value) => c.NoTransform = true },
                { "must-revalidate",  (c, value) => c.MustRevalidate = true },
                { "proxy-revalidate", (c, value) => c.ProxyRevalidate = true },
            };
        
        public TimeSpan? MaxAge { get; set; }
        public TimeSpan? SharedMaxAge { get; set; }

        public bool Public { get; set; }

        public bool Private { get; set; }
        public HashSet<string> PrivateHeaderNames { get; private set; }

        public bool NoCache { get; set; }
        public HashSet<string> NoCacheHeaderNames { get; private set; }
        
        public bool NoStore { get; set; }
        public bool NoTransform { get; set; }
        public bool MustRevalidate { get; set; }
        public bool ProxyRevalidate { get; set; }

        public CacheControl() {
            this.PrivateHeaderNames = new HashSet<string>();
            this.NoCacheHeaderNames = new HashSet<string>();
        }

        public static CacheControl Parse(string value) {
            // TODO: strict parsing

            var cacheControl = new CacheControl();
            var parts = AbnfSplit(value, ',');
            foreach (var part in parts) {
                var subparts = AbnfSplit(part, '=').ToArray();
                if (subparts.Length == 0)
                    continue;

                var set = parseValueSetters.GetValueOrDefault(subparts[0]);
                if (set == null)
                    continue;
                
                var partValue = subparts.ElementAtOrDefault(1);
                if (partValue != null)
                    partValue = partValue.Trim('"');

                set(cacheControl, partValue);
            }
            
            return cacheControl;
        }
        
        private static TimeSpan? ParseAsSeconds(string value) {
            if (value.IsNullOrEmpty())
                return null;

            int seconds;
            var parsed = int.TryParse(value, out seconds);
            if (!parsed || seconds < 0)
                return null;

            return TimeSpan.FromSeconds(seconds);
        }

        // splits ABNF values, for example, 1# (basically, can contain quoted separators)
        // see http://tools.ietf.org/html/rfc2616#section-2.1 for details
        private static IEnumerable<string> AbnfSplit(string value, char separator) {
            var quoted = false;
            var currentPartStart = 0;
            var currentPartEnd = 0;
            var currentWhitespaceRange = 0;
            
            for (var i = 0; i < value.Length; i++) {
                var @char = value[i];
                if (@char == '"') {
                    quoted = !quoted;
                    currentPartEnd += 1;
                    currentWhitespaceRange = 0;
                    continue;
                }

                if (quoted) {
                    currentPartEnd += 1;
                    currentWhitespaceRange = 0;
                    continue;
                }

                if (@char == separator) {
                    var currentPartLength = currentPartEnd - currentPartStart - currentWhitespaceRange;
                    if (currentPartLength > 0) 
                        yield return value.Substring(currentPartStart, currentPartLength);

                    currentPartStart = i + 1;
                    currentPartEnd = currentPartStart;
                    currentWhitespaceRange = 0;
                }
                else if (Char.IsWhiteSpace(@char)) {
                    if (currentPartStart == i && currentPartStart == currentPartEnd) {
                        currentPartStart += 1;
                        currentPartEnd = currentPartStart;
                        currentWhitespaceRange = 0;
                    }
                    else {
                        currentWhitespaceRange += 1;
                    }
                }
                else {
                    currentPartEnd += 1;
                    currentWhitespaceRange = 0;
                }
            }

            if (currentPartEnd != currentPartStart)
                yield return value.Substring(currentPartStart, currentPartEnd - currentPartStart);
        }
    }
}
