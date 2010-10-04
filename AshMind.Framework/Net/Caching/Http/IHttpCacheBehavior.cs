using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace AshMind.Net.Caching.Http {
    public interface IHttpCacheBehavior {
        DateTimeOffset? GetExpiration(DateTimeOffset now, DateTimeOffset? expires, CacheControl cacheControl);

        bool ShouldCache(HttpWebResponse response, CacheControl cacheControl);

        HashSet<string> GetNoCacheHeaderNames(HttpWebResponse response, CacheControl cacheControl);
    }
}
