using Newtonsoft.Json;
using SISPUN.Api.Aplication.Interface.ApiCaller;
using SISPUN.Api.Aplication.Interface.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SISPUN.Api.Aplication.ApiCaller
{
    public class ApiCaller : IApiCaller
    {
        private readonly HttpClient _httpClient;

        public ApiCaller(IAppConfig appConfig)
        {

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(appConfig.ServiceUrl)
            };

            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<T> GetServiceResponseById<T>(string controller, int id)
        {

            var response = await _httpClient.GetAsync(string.Format("/{0}/{1}", controller, id));

            if (!response.IsSuccessStatusCode)
                return default(T);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
