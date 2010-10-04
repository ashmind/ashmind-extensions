using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net;
using System.Linq;
using System.Text;

namespace AshMind.Net.Caching.Http {
    [Serializable]
    public class HttpCacheEntry {
        [NonSerialized]
        private WebResponse response;

        public HttpCacheEntry(
            HttpWebResponse response,
            DateTimeOffset? lastModified,
            string etag,
            DateTimeOffset? expires
        ) {
            Contract.Requires<ArgumentNullException>(response != null);

            this.Response = response;
            this.LastModified = lastModified;
            this.ETag = etag;
            this.Expires = expires;
        }
        
        public DateTimeOffset? LastModified { get; private set; }
        public string ETag { get; private set; }
        public DateTimeOffset? Expires { get; private set; }

        public WebResponse Response {
            get { return this.response; }
            set { this.response = value; }
        }
    }
}
