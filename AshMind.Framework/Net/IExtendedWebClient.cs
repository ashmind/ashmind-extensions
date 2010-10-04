using System;
using System.Collections.Generic;

using AshMind.Net.Caching;

namespace AshMind.Net {
    public interface IExtendedWebClient : IWebClient {
        bool AllowAutoRedirect { get; set; }
        bool IsResponseCached { get; }

        IWebRequestCacheManager Cache { get; set; }
    }
}
