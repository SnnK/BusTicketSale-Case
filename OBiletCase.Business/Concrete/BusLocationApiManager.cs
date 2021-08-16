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
    public class BusLocationApiManager : ApiManager, IBusLocationApiService
    {
        private readonly HttpClient _httpClient;

        public BusLocationApiManager(HttpClient httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BusLocation> GetLocations(LocationBody locationBody)
        {
            var jsonStr = JsonConvert.SerializeObject(locationBody);

            var stringContent = new StringContent(jsonStr, Encoding.UTF8, "application/json");

            var responseMessage = await _httpClient.PostAsync(Api.BusLocationEndpoint, stringContent);

            if (!responseMessage.IsSuccessStatusCode) return null;

            var busLocationInfo = JsonConvert.DeserializeObject<BusLocation>(await responseMessage.Content.ReadAsStringAsync());

            return busLocationInfo;
        }
    }
}
