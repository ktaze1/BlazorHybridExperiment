using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHybridApp
{
    class AppState
    {
        public static HttpClient _http;


        public AppState()
        {
            _http = new HttpClient() { BaseAddress = new Uri("http://192.168.1.22:3000/") };
        }
        
        public event Func<Task> OnChange;
        private async Task NotifyStateChanged() => await OnChange?.Invoke();

    }
}
