using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace ReuseProject.IntegrationTests.Caching {
    public class CachedWebResponse : WebResponse {
        private readonly Uri cachedResponseUri;
        private readonly Stream cachedStream;
        private readonly WebHeaderCollection cachedHeaders;

        public CachedWebResponse(
            Uri cachedResponseUri,
            Stream cachedStream,
            WebHeaderCollection cachedHeaders 
        ) {
            this.cachedResponseUri = cachedResponseUri;
            this.cachedStream = cachedStream;
            this.cachedHeaders = cachedHeaders;
        }

        public override Stream GetResponseStream() {
            return this.cachedStream;
        }

        public override long ContentLength {
            get { return this.cachedStream.Length; }
            set { throw new NotSupportedException(); }
        }

        public override string ContentType {
            get { return this.cachedHeaders[HttpResponseHeader.ContentType]; }
            set { throw new NotSupportedException(); }
        }

        public override WebHeaderCollection Headers {
            get { return this.cachedHeaders; }
        }

        public override Uri ResponseUri {
            get { return this.cachedResponseUri; }
        }

        public override bool IsFromCache {
            get { return true; }
        }

        public override void Close() {
            this.cachedStream.Dispose();
        }
    }
}
