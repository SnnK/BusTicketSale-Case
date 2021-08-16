using Newtonsoft.Json;
using OBiletCase.Business.Concrete.Base;
using OBiletCase.Business.Interfaces;
using OBiletCase.Business.StringInfos;
using OBiletCase.Model.Models.Request;
using OBiletCase.Model.Models.Response;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.Business.Concrete
{
    public class BusJourneyApiManager : ApiManager, IBusJourneyApiService
    {
        private readonly HttpClient _httpClient;

        public BusJourneyApiManager(HttpClient httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BusJourney> GetJourneys(BusJourneyBody journeyBody)
        {
            var jsonStr = JsonConvert.SerializeObject(journeyBody);

            var stringContent = new StringContent(jsonStr, Encoding.UTF8, "application/json");

            var responseMessage = await _httpClient.PostAsync(Api.BusJourneyEndpoint, stringContent);

            if (!responseMessage.IsSuccessStatusCode) return null;

            var busJourneyInfo = JsonConvert.DeserializeObject<BusJourney>(await responseMessage.Content.ReadAsStringAsync());

            return busJourneyInfo;
        }
    }
}
