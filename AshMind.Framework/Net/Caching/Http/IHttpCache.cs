using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Net;

namespace AshMind.Net.Caching.Http {
    [ContractClass(typeof(HttpCacheContract))]
    public interface IHttpCache {
        HttpCacheEntry GetEntry(HttpWebRequest request);
        void AddEntry(HttpWebRequest request, HttpCacheEntry entry);
    }
}
