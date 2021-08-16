using OBiletCase.Model.Models.Request;
using OBiletCase.Model.Models.Response;
using System.Threading.Tasks;

namespace OBiletCase.Business.Interfaces
{
    public interface IBusJourneyApiService
    {
        /// <summary>
        /// Ulaşım seçeneklerini getirir.
        /// </summary>
        /// <returns></returns>
        Task<BusJourney> GetJourneys(BusJourneyBody journeyBody);
    }
}
