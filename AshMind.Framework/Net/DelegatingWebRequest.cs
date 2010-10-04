using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace AshMind.Net {
    public class DelegatingWebRequest : WebRequest {
        public WebRequest InnerRequest { get; private set; }

        public DelegatingWebRequest(WebRequest request) {
            this.InnerRequest = request;
        }

        public override void Abort() {
            this.InnerRequest.Abort();
        }

        public override IAsyncResult BeginGetRequestStream(AsyncCallback callback, object state) {
            return this.InnerRequest.BeginGetRequestStream(callback, state);
        }

        public override IAsyncResult BeginGetResponse(AsyncCallback callback, object state) {
            return this.InnerRequest.BeginGetResponse(callback, state);
        }

        public override System.Net.Cache.RequestCachePolicy CachePolicy {
            get { return this.InnerRequest.CachePolicy; }
            set { this.InnerRequest.CachePolicy = value; }
        }

        public override string ConnectionGroupName {
            get { return this.InnerRequest.ConnectionGroupName; }
            set { this.InnerRequest.ConnectionGroupName = value; }
        }

        public override long ContentLength {
            get { return this.InnerRequest.ContentLength; }
            set { this.InnerRequest.ContentLength = value; }
        }

        public override string ContentType {
            get { return this.InnerRequest.ContentType; }
            set { this.InnerRequest.ContentType = value; }
        }

        public override ICredentials Credentials {
            get { return this.InnerRequest.Credentials; }
            set { this.InnerRequest.Credentials = value; }
        }

        public override System.IO.Stream EndGetRequestStream(IAsyncResult asyncResult) {
            return this.InnerRequest.EndGetRequestStream(asyncResult);
        }

        public override WebResponse EndGetResponse(IAsyncResult asyncResult) {
            return this.InnerRequest.EndGetResponse(asyncResult);
        }

        public override System.IO.Stream GetRequestStream() {
            return this.InnerRequest.GetRequestStream();
        }

        public override WebResponse GetResponse() {
            return this.InnerRequest.GetResponse();
        }

        public override WebHeaderCollection Headers {
            get { return this.InnerRequest.Headers; }
            set { this.InnerRequest.Headers = value; }
        }

        public override string Method {
            get { return this.InnerRequest.Method; }
            set { this.InnerRequest.Method = value; }
        }

        public override bool PreAuthenticate {
            get { return this.InnerRequest.PreAuthenticate; }
            set { this.InnerRequest.PreAuthenticate = value; }
        }

        public override IWebProxy Proxy {
            get { return this.InnerRequest.Proxy; }
            set { this.InnerRequest.Proxy = value; }
        }

        public override Uri RequestUri {
            get { return this.InnerRequest.RequestUri; }
        }

        public override int Timeout {
            get { return this.InnerRequest.Timeout; }
            set { this.InnerRequest.Timeout = value; }
        }

        public override bool UseDefaultCredentials {
            get { return this.InnerRequest.UseDefaultCredentials; }
            set { this.InnerRequest.UseDefaultCredentials = value; }
        }
    }
}