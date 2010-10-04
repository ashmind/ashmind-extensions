using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace AshMind.Net.Caching.Http {
    // This is NOT! thread safe
    public class HttpMemoryCache : IHttpCache {
        private readonly IDictionary<Uri, HttpCacheEntry> entries = new Dictionary<Uri, HttpCacheEntry>();

        public HttpCacheEntry GetEntry(HttpWebRequest request) {
            return entries[request.RequestUri];
        }

        public void AddEntry(HttpWebRequest request, HttpCacheEntry entry) {
            entries[request.RequestUri] = entry;
        }
    }
}
