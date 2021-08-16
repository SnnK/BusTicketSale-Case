using OBiletCase.Model.Models.Request;
using OBiletCase.Model.Models.Response;
using System.Threading.Tasks;

namespace OBiletCase.Business.Interfaces
{
    public interface ISessionApiService
    {
        /// <summary>
        /// Session verilerini getirir.
        /// </summary>
        /// <returns></returns>
        Task<SessionData> GetSession(SessionBody sessionBody);
    }
}
