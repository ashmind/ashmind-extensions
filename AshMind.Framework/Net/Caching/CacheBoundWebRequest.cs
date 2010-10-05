using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace AshMind.Net.Caching {
    public class CacheBoundWebRequest : DelegatingWebRequest {
        private Func<WebResponse> getResponseAsync;
        private Func<WebRequest, WebResponse> getImmediateResponse;
        private Func<WebRequest, Func<WebResponse>, WebResponse> getFinalResponse;

        public CacheBoundWebRequest(
            WebRequest request,
            Func<WebRequest, WebResponse> getImmediateResponse,
            Func<WebRequest, Func<WebResponse>, WebResponse> getFinalResponse
        )
            : base(request)
        {
            this.getImmediateResponse = getImmediateResponse;
            this.getFinalResponse = getFinalResponse;

            this.getResponseAsync = () => {
                var immediate = this.getImmediateResponse(this);
                if (immediate != null)
                    return immediate;

                var final = (WebResponse)null;
                var asyncResult = (IAsyncResult)null;
                asyncResult = base.BeginGetResponse(state => {
                    final = this.getFinalResponse(this, () => base.EndGetResponse(asyncResult));
                }, null);

                return final;
            };
        }

        public override WebResponse GetResponse() {
            var immediate = this.getImmediateResponse(this);
            if (immediate != null)
                return immediate;

             return this.getFinalResponse(this, () => base.GetResponse());
        }

        public override IAsyncResult BeginGetResponse(AsyncCallback callback, object state) {
            return this.getResponseAsync.BeginInvoke(callback, state);
        }

        public override WebResponse EndGetResponse(IAsyncResult asyncResult) {
            return this.getResponseAsync.EndInvoke(asyncResult);
        }
    }
}
