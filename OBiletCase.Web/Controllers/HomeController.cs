using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using OBiletCase.Business.StringInfos;
using OBiletCase.Model.DTOs;
using OBiletCase.Model.Models.Request;
using OBiletCase.Model.Models.Response;
using OBiletCase.Web.Facade.Interfaces;
using OBiletCase.Web.Mapping;
using OBiletCase.Web.Models;
using OBiletCase.Web.Models.ViewModel;
using OBiletCase.Web.Tools.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBiletCase.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiFacade _apiFacade;
        private readonly IClientData _clientData;
        private readonly SessionData sessionData;
        private readonly IMemoryCache _memoryCache;

        public HomeController(IApiFacade apiFacade, IClientData clientData, IMemoryCache memoryCache)
        {
            _apiFacade = apiFacade;
            _clientData = clientData;
            _memoryCache = memoryCache;
            sessionData = _clientData.GetSession();
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexViewModel();

            IEnumerable<string> errors = new List<string>();

            if (TempData["SearchErr"] != null)
            {
                errors = JsonConvert.DeserializeObject<IEnumerable<string>>((string)TempData["SearchErr"]);
            }

            viewModel.Errors = errors;

            var busLocations = new LocationBody
            {
                Date = DateTime.Now,
                Language = Api.Language,
                DeviceSession = { DeviceId = sessionData.Data.DeviceId, SessionId = sessionData.Data.SessionId }
            };

            if (_memoryCache.TryGetValue<BusLocationDto>(Api.LocationCacheKey, out var locationFromCache))
            {
                viewModel.BusLocationDto = locationFromCache;
            }
            else
            {
                var locations = ConfigureMappings.Mapper.Map<BusLocationDto>(await _apiFacade.BusLocationApiService.GetLocations(busLocations));

                viewModel.BusLocationDto = _memoryCache.GetOrCreate(Api.LocationCacheKey, _ =>
                {
                    _.SetValue(locations);
                    _.AbsoluteExpiration = DateTime.Now.AddHours(1);
                    return (BusLocationDto)_.Value;
                });
            }

            return View(viewModel);
        }

        [HttpPost("search")]
        public IActionResult Search(Search search)
        {
            if (search.From == search.To)
            {
                ModelState.AddModelError("", "Nereden ve Nereye seçenekleri farklı olmalıdır.");
            }

            if (search.Date <= DateTime.Now.AddDays(-1))
            {
                ModelState.AddModelError("", "Geçmiş bir tarih seçtiniz. Geçerli bir tarih olmalıdır.");
            }

            if (ModelState.IsValid)
            {
                var fromValue = search.From.Split(',');
                var toValue = search.To.Split(',');

                TempData["JourneyInfo"] = $"{fromValue[1]} - {toValue[1]}";
                TempData["Date"] = search.Date?.ToString("dd MMMM yyyy");
                return RedirectToAction(nameof(Journey), new { originId = fromValue[0], destionationId = toValue[0], date = search.Date?.ToString("yyyy-MM-dd") });
            }
            else
            {
                TempData["SearchErr"] = JsonConvert.SerializeObject(ModelState.Values.SelectMany(s => s.Errors.Select(I => I.ErrorMessage)).ToList());
                return RedirectToAction(nameof(Index));
            }
        }

        [Route("seferler/{originId:int}-{destionationId:int}/{date}")]
        public async Task<IActionResult> Journey([FromRoute] int originId, [FromRoute] int destionationId, [FromRoute] string date)
        {
            var busJourneys = new BusJourneyBody
            {
                Date = DateTime.Now,
                Language = Api.Language,
                DeviceSession = { DeviceId = sessionData.Data.DeviceId, SessionId = sessionData.Data.SessionId },
                Data = { OriginId = originId, DestinationId = destionationId, DepartureDate = Convert.ToDateTime(date) }
            };

            var journeys = ConfigureMappings.Mapper.Map<BusJourneyDto>(await _apiFacade.BusJourneyApiService.GetJourneys(busJourneys));

            return View(journeys);
        }
    }
}
