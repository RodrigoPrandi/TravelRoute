using System;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace TravelRouteConsole.Business.Impl
{
    class TravelRouteApi : ITravelRouteApi
    {
        private HttpClient httpClient;

        public TravelRouteApi()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var urlEndpoint = config["urlTravelRouteApi"];

            var uri = new Uri(urlEndpoint);


            httpClient = new HttpClient();
            httpClient.BaseAddress = uri;
        }

        public TResponse GetSync<TResponse>(string requestUri)
        {
            var response = httpClient.GetAsync(requestUri).Result;


            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<TResponse>(jsonString);
            }

            throw new HttpRequestException(response.ToString());
        }


        public  void PostSync<TRequest>(string requestUri, TRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");


            var response = httpClient.PostAsync(requestUri, content).Result;

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException(response.ToString());
        }
    }
}
