using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace AshMind.Net.Caching.Http.Behaviors {
    public class EndUserHttpCacheBehavior : AbstractHttpCacheBehavior {
        public override DateTimeOffset? GetExpiration(DateTimeOffset now, DateTimeOffset? expires, CacheControl cacheControl) {
            if (cacheControl != null && cacheControl.MustRevalidate)
                return null;

            if (cacheControl != null && cacheControl.MaxAge != null)
                return now + cacheControl.MaxAge.Value;

            return expires;
        }
    }
}
