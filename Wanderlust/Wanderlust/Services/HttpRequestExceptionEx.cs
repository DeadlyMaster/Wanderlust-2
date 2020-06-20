using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Wanderlust.Services
{
    public class HttpRequestExceptionEx : HttpRequestException
    {
        public HttpStatusCode HttpCode { get; }

        public HttpRequestExceptionEx(HttpStatusCode code, string message) : this(code, message, null)
        {
        }

        public HttpRequestExceptionEx(HttpStatusCode code, string message, Exception inner) : base(message, inner)
        {
            HttpCode = code;
        }
    }
}
