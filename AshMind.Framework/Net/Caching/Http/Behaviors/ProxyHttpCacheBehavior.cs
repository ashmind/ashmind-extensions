using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using AshMind.Extensions;

namespace AshMind.Net.Caching.Http.Behaviors {
    public class ProxyHttpCacheBehavior : AbstractHttpCacheBehavior {
        public override DateTimeOffset? GetExpiration(DateTimeOffset now, DateTimeOffset? expires, CacheControl cacheControl) {
            if (cacheControl.ProxyRevalidate)
                return null;

            if (cacheControl.SharedMaxAge != null)
                return now + cacheControl.SharedMaxAge.Value;

            return expires;
        }

        public override bool ShouldCache(HttpWebResponse response, CacheControl cacheControl) {
            if (cacheControl.Private && cacheControl.PrivateHeaderNames.Count == 0)
                return false;

            return base.ShouldCache(response, cacheControl);
        }

        public override HashSet<string> GetNoCacheHeaderNames(HttpWebResponse response, CacheControl cacheControl) {
            var headerNames = base.GetNoCacheHeaderNames(response, cacheControl);
            if (cacheControl.PrivateHeaderNames.Count == 0)
                return headerNames;

            headerNames = headerNames.ToSet(); // copy
            headerNames.UnionWith(cacheControl.PrivateHeaderNames);

            return headerNames;
        }
    }
}
