using OBiletCase.Business.Interfaces;
using OBiletCase.Web.Facade.Interfaces;

namespace OBiletCase.Web.Tools.Facade.Concrete
{
    //facade design pattern

    public class ApiFacade : IApiFacade
    {
        public IBusLocationApiService BusLocationApiService { get; set; }
        public ISessionApiService SessionApiService { get; set; }
        public IBusJourneyApiService BusJourneyApiService { get; set; }

        public ApiFacade(IBusLocationApiService busLocationApiService, ISessionApiService sessionApiService, IBusJourneyApiService busJourneyApiService)
        {
            BusLocationApiService = busLocationApiService;
            SessionApiService = sessionApiService;
            BusJourneyApiService = busJourneyApiService;
        }
    }
}
