using Microsoft.AspNetCore.Http;
using OBiletCase.Business.StringInfos;
using OBiletCase.Model.Models.Response;
using OBiletCase.Web.Extentions;
using OBiletCase.Web.Tools.Session;

namespace OBiletCase.Web.Tools
{
    public class ClientData : IClientData
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClientData(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetSession(SessionData session)
        {
            _httpContextAccessor.HttpContext?.Session.SetObject(Api.SessionKey, session);
        }

        public SessionData GetSession()
        {
            var sessionData = _httpContextAccessor.HttpContext?.Session.GetObject<SessionData>(Api.SessionKey);

            return sessionData;
        }
    }
}
