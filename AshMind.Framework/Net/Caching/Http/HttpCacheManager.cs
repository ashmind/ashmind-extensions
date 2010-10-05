using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Net;
using System.Text;

using AshMind.Extensions;
using AshMind.Net;

namespace AshMind.Net.Caching.Http {
    public class HttpCacheManager : WebRequestCacheManager<HttpWebRequest> {
        private readonly IHttpCache cache;
        private readonly IHttpCacheBehavior behavior;

        public HttpCacheManager(IHttpCache cache, IHttpCacheBehavior behavior) {
            Contract.Requires<ArgumentNullException>(cache != null);
            Contract.Requires<ArgumentNullException>(behavior != null);

            this.cache = cache;
            this.behavior = behavior;
        }

        public override WebRequest PrepareRequest(HttpWebRequest request) {
            Contract.Requires<ArgumentNullException>(request != null);
            
            if (!CanCache(request.Method))
                return request;

            var entry = this.cache.GetEntry(request);
            if (entry != null && entry.LastModified != null)
                request.IfModifiedSince = entry.LastModified.Value.UtcDateTime;

            if (entry != null && !string.IsNullOrEmpty(entry.ETag))
                request.Headers[HttpRequestHeader.IfNoneMatch] = entry.ETag;

            return new CacheBoundWebRequest(
                request,
                r => GetImmediateResponse((HttpWebRequest)r),
                (r, getResponse) => GetFinalResponse((HttpWebRequest)r, getResponse)
            );
        }

        public virtual bool CanCache(string requestMethod) {
            return requestMethod.Equals("GET", StringComparison.InvariantCultureIgnoreCase); 
        }

        public WebResponse GetImmediateResponse(HttpWebRequest request) {
            Contract.Requires<ArgumentNullException>(request != null);

            var entry = this.cache.GetEntry(request);
            if (entry != null && entry.Expires != null && entry.Expires > DateTimeOffset.Now)
                return entry.Response;

            return null;
        }

        public WebResponse GetFinalResponse(HttpWebRequest request, Func<WebResponse> getResponse) {
            Contract.Requires<ArgumentNullException>(request != null);
            Contract.Ensures(Contract.Result<WebResponse>() != null);

            var entry = this.cache.GetEntry(request);
            if (entry != null && entry.Expires != null && entry.Expires > DateTimeOffset.Now)
                return entry.Response;

            var response = (HttpWebResponse)null;
            try {
                response = (HttpWebResponse)getResponse();
            }
            catch (WebException ex) { // BCL designers should have known better, I think
                response = ((HttpWebResponse)ex.Response);
                if (response == null)
                    throw;

                if (response.StatusCode == HttpStatusCode.NotModified) {
                    if (entry == null)
                        throw new InvalidOperationException("NotModified was received for request that is not cached.", ex);

                    return entry.Response;
                }

                throw;
            }

            entry = this.CreateEntry(response);
            if (entry != null)
                cache.AddEntry(request, entry);

            return entry != null ? entry.Response : response;
        }

        private HttpCacheEntry CreateEntry(HttpWebResponse response) {
            var lastModified = GetDate(response, HttpResponseHeader.LastModified);
            var etag = response.Headers[HttpResponseHeader.ETag];

            var expires = GetDate(response, HttpResponseHeader.Expires);
            var date = GetDate(response, HttpResponseHeader.Date) ?? DateTimeOffset.Now;
            var cacheControlValue = response.Headers[HttpResponseHeader.CacheControl];
            var cacheControl = cacheControlValue.IsNotNullOrEmpty()
                             ? CacheControl.Parse(cacheControlValue)
                             : null;            

            if (!behavior.ShouldCache(response, cacheControl))
                return null;

            expires = behavior.GetExpiration(date, expires, cacheControl);

            if (etag.IsNullOrEmpty() && lastModified == null && (expires == null || expires.Value <= date))
                return null;

            return new HttpCacheEntry(
                response,
                lastModified,
                etag,
                expires
            );
        }

        private DateTimeOffset? GetDate(WebResponse response, HttpResponseHeader header) {
            var dateString = response.Headers[header];
            if (string.IsNullOrEmpty(dateString))
                return null;

            DateTimeOffset date;
            var parsed = DateTimeOffset.TryParseExact(
                dateString, "R", CultureInfo.InvariantCulture, DateTimeStyles.None, out date
            );

            if (!parsed)
                return null;

            return date;
        }
    }
}