using System;
using System.Net;

using AshMind.Net.Caching;

namespace AshMind.Net.Implementations {
    public class ExtendedWebClient : WebClient, IExtendedWebClient {
        private WebResponse response;

        public ExtendedWebClient() {
            this.AllowAutoRedirect = true;
        }

        public virtual bool AllowAutoRedirect { get; set; }
        public virtual IWebRequestCacheManager Cache { get; set; }

        public virtual Uri ResponseUri {
            get { return this.response.ResponseUri; }
        }

        public virtual bool IsResponseCached {
            get { return this.response.IsFromCache; }
        }

        protected override WebRequest GetWebRequest(Uri uri) {
            var request =  base.GetWebRequest(uri);
            if (request is HttpWebRequest) {
                (request as HttpWebRequest).AllowAutoRedirect = this.AllowAutoRedirect;
            }

            if (this.Cache != null) {
                request = this.Cache.PrepareRequest(request);
            }

            return request;
        }

        protected override WebResponse GetWebResponse(WebRequest request) {
            this.response = base.GetWebResponse(request);
            return this.response;
        }

        protected override WebResponse GetWebResponse(WebRequest request, IAsyncResult result) {
            this.response = base.GetWebResponse(request, result);
            return this.response;
        }
    }
}


