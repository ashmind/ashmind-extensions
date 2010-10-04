using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;

namespace AshMind.Net.Caching.Http {
    [ContractClassFor(typeof(IHttpCache))]
    internal abstract class HttpCacheContract : IHttpCache {
        public HttpCacheEntry GetEntry(HttpWebRequest request) {
            Contract.Requires<ArgumentNullException>(request != null);

            throw new NotSupportedException();
        }

        public void AddEntry(HttpWebRequest request, HttpCacheEntry entry) {
            Contract.Requires<ArgumentNullException>(request != null);
            Contract.Requires<ArgumentNullException>(entry != null);

            throw new NotSupportedException();
        }
    }
}
