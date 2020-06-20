using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Wanderlust.Services
{
    public interface IHttpClientHandlerService
    {
        HttpClientHandler GetInsecureHandler();
    }
}
