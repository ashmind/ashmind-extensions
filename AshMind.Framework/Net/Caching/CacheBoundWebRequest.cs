using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace AshMind.Net.Caching {
    public class CacheBoundWebRequest : DelegatingWebRequest {
        private Func<WebRequest, WebResponse> getResponse;

        public CacheBoundWebRequest(WebRequest request, Func<WebRequest, WebResponse> getResponse)
            : base(request)
        {
            this.getResponse = getResponse;
        }

        public override WebResponse GetResponse() {
            return this.getResponse(this.InnerRequest);
        }
    }
}
