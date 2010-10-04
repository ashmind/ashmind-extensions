using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace AshMind.Net.Caching {
    public interface IWebRequestCacheManager {
        WebRequest PrepareRequest(WebRequest request);
    }
}
