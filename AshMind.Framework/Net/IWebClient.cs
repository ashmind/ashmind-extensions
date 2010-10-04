using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;

namespace AshMind.Net {
    public interface IWebClient {
        string DownloadString(string address);
        string DownloadString(Uri address);
        byte[] DownloadData(Uri address);

        byte[] UploadData(Uri address, string method, byte[] data);
        byte[] UploadValues(Uri address, string method, NameValueCollection data);

        WebHeaderCollection Headers { get; set; }
        WebHeaderCollection ResponseHeaders { get; }
    }
}
