using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BlazorHybridApp.Data
{
    public interface IHttpClientHandlerService
    {
        HttpClientHandler GetInsecureHandler();
    }
}
