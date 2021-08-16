using Microsoft.AspNetCore.Http;
using OBiletCase.Business.StringInfos;
using OBiletCase.Model.Models.Request;
using OBiletCase.Web.Facade.Interfaces;
using OBiletCase.Web.Tools.Session;
using System.Threading.Tasks;
using UAParser;

namespace OBiletCase.Web.Middlewares
{
    public class SessionMw
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly IApiFacade _apiFacade;
        private readonly IClientData _clientData;

        public SessionMw(RequestDelegate requestDelegate, IApiFacade apiFacade, IClientData clientData)
        {
            _requestDelegate = requestDelegate;
            _apiFacade = apiFacade;
            _clientData = clientData;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Session.TryGetValue(Api.SessionKey, out _))
            {
                var uaString = context.Request.Headers["User-Agent"];

                var uaParser = Parser.GetDefault();
                var clientInfo = uaParser.Parse(uaString);

                var browser = clientInfo.UA.Family;
                var version = $"{clientInfo.UA.Major}.{clientInfo.UA.Minor}.{clientInfo.UA.Patch}";

                var sessionBody = new SessionBody()
                {
                    Type = 1,
                    Connection = { IpAddress = context.Connection.RemoteIpAddress?.ToString(), Port = context.Connection.RemotePort.ToString() },
                    Browser = { Name = browser, Version = version }
                };

                _clientData.SetSession(await _apiFacade.SessionApiService.GetSession(sessionBody));
            }

            await _requestDelegate.Invoke(context);
        }
    }
}
