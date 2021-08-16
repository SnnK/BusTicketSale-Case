using OBiletCase.Model.Models.Request;
using OBiletCase.Model.Models.Response;
using System.Threading.Tasks;

namespace OBiletCase.Business.Interfaces
{
    public interface IBusLocationApiService
    {
        /// <summary>
        /// Lokasyonları Getirir.
        /// </summary>
        /// <returns></returns>
        Task<BusLocation> GetLocations(LocationBody locationBody);
    }
}
