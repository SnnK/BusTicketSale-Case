using OBiletCase.Model.Models.Response;

namespace OBiletCase.Web.Tools.Session
{
    public interface IClientData
    {
        void SetSession(SessionData session);
        SessionData GetSession();
    }
}
