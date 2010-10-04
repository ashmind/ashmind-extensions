using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace AshMind.Net.Caching {
    public abstract class WebRequestCacheManager<TWebRequest> : IWebRequestCacheManager
        where TWebRequest : WebRequest
    {
        public abstract WebRequest PrepareRequest(TWebRequest request);

        #region IWebRequestCacheManager Members

        WebRequest IWebRequestCacheManager.PrepareRequest(WebRequest request) {
            if (!(request is TWebRequest))
                return request;

            return this.PrepareRequest(request as TWebRequest);
        }

        #endregion
    }
}
