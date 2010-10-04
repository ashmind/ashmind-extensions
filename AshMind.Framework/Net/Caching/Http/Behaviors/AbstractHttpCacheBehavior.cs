using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace AshMind.Net.Caching.Http.Behaviors {
    public abstract class AbstractHttpCacheBehavior : IHttpCacheBehavior {
        public abstract DateTimeOffset? GetExpiration(DateTimeOffset now, DateTimeOffset? expires, CacheControl cacheControl);

        public virtual bool ShouldCache(HttpWebResponse response, CacheControl cacheControl) {
            if (cacheControl == null)
                return true;

            if (cacheControl.NoCache && cacheControl.NoCacheHeaderNames.Count == 0 && !this.OverrideNoCache)
                return false;

            if (cacheControl.NoStore && !this.OverrideNoStore)
                return false;

            return true;
        }

        public virtual HashSet<string> GetNoCacheHeaderNames(HttpWebResponse response, CacheControl cacheControl) {
            if (this.OverrideNoCache)
                return new HashSet<string>();

            return cacheControl.NoCacheHeaderNames;
        }

        public virtual bool OverrideNoCache { get; set; }
        public virtual bool OverrideNoStore { get; set; }
    }
}
