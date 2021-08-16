using OBiletCase.Business.StringInfos;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OBiletCase.Business.Concrete.Base
{
    public class ApiManager
    {
        private readonly HttpClient _httpClient;

        public ApiManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(Api.ApiUrl);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Api.Token);
        }
    }
}