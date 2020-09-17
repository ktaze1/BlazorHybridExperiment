using BlazorHybridApp.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Xamarin.Forms;
using static BlazorHybridApp.WebUI.Pages.Index;

namespace BlazorHybridApp
{
    class AppState
    {

        HttpClient _http;
        public List<WeatherForecast> weatherForecasts { get; set; }


        public AppState()
        {
            _http = new HttpClient() { BaseAddress = new Uri("http://192.168.1.22:3000/") };
            //DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler()
        }
        //public async Task<List<WeatherForecast>> GetForecastsAsync()
        //{
        //    weatherForecasts = new List<WeatherForecast>();

        //    Uri uri = new Uri("http://192.168.1.22:3000/weatherforecast");
        //    try
        //    {
        //        //HttpResponseMessage responseMessage = await client.GetAsync(uri);
        //        //if (responseMessage.IsSuccessStatusCode)
        //        //{
        //        //    string content = await responseMessage.Content.ReadAsStringAsync();
        //        //    weatherForecasts = JsonConvert.DeserializeObject<List<WeatherForecast>> (content);
        //        //}

        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(@"\tERROR {0}", ex.Message);
        //    }

        //    return weatherForecasts;
        //}


        // public HttpClient _http = new HttpClient() { BaseAddress = new Uri("https://10.0.2.2:3004/") };

        public async Task<List<WeatherForecast>> GetForecastAsync()
        {
            try
            {
                return await _http.GetFromJsonAsync<List<WeatherForecast>>("weatherforecast");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return new List<WeatherForecast>();
            // return await _http.GetFromJsonAsync<List<Todo>>("https://jsonplaceholder.typicode.com/todos");
        }

        public event Func<Task> OnChange;
        private async Task NotifyStateChanged() => await OnChange?.Invoke();

    }
}
