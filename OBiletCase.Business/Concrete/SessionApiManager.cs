using Newtonsoft.Json;
using OBiletCase.Business.Concrete.Base;
using OBiletCase.Business.Interfaces;
using OBiletCase.Model.Models.Response;
using OBiletCase.Business.StringInfos;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OBiletCase.Model.Models.Request;

namespace OBiletCase.Business.Concrete
{
    public class SessionApiManager : ApiManager, ISessionApiService
    {
        private readonly HttpClient _httpClient;

        public SessionApiManager(HttpClient httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SessionData> GetSession(SessionBody sessionBody)
        {
            var jsonStr = JsonConvert.SerializeObject(sessionBody);

            var stringContent = new StringContent(jsonStr, Encoding.UTF8, "application/json");

            var responseMessage = await _httpClient.PostAsync(Api.SessionEndpoint, stringContent);

            if (!responseMessage.IsSuccessStatusCode) return null;

            var sessionInfo = JsonConvert.DeserializeObject<SessionData>(await responseMessage.Content.ReadAsStringAsync());

            return sessionInfo;
        }
    }
}