using AutoMapper;
using OBiletCase.Model.DTOs;
using OBiletCase.Model.Models.Response;
using System;

namespace OBiletCase.Web.Mapping
{
    public class ApiMapProfile : Profile
    {
        public ApiMapProfile()
        {
            CreateMap<BusLocation, BusLocationDto>().ReverseMap();
            CreateMap<BLData, BLDataDto>().ReverseMap();

            CreateMap<Journey, JourneyDto>()
                .ForMember(x => x.Currency, opt => opt.MapFrom(o => "TL"))
                .ReverseMap();

            CreateMap<BJData, BJDataDto>().ReverseMap();
            CreateMap<BusJourney, BusJourneyDto>().ReverseMap();
        }
    }

    //singleton design pattern

    public class ConfigureMappings
    {
        private static IMapper _mapper;
        private static Object _lockObject = new();

        public static IMapper Mapper
        {
            get
            {
                lock (_lockObject)
                {
                    if (_mapper == null)
                        _mapper = ConfigureMaps();

                    return _mapper;
                }
            }
        }

        public static IMapper ConfigureMaps()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApiMapProfile>();
            });

            return mapperConfig.CreateMapper();
        }
    }
}
