using OBiletCase.Business.Interfaces;

namespace OBiletCase.Web.Facade.Interfaces
{
    //facade design pattern

    public interface IApiFacade
    {
        public IBusLocationApiService BusLocationApiService { get; set; }
        public ISessionApiService SessionApiService { get; set; }
        public IBusJourneyApiService BusJourneyApiService { get; set; }
    }
}
