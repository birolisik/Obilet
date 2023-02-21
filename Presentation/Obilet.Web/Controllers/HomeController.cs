using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Obilet.Application.Models.BusLocations;
using Obilet.Application.Models.Sessions;
using Obilet.Application.Repositories;
using Obilet.Application.Repositories.BusLocation;
using Obilet.Application.Repositories.Session;
using Obilet.Application.Validations;
using Obilet.Application.ViewModels;
using Obilet.Infrastructure;
using Obilet.Web.Models;
using System.Diagnostics;

namespace Obilet.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBusLocationRepository _busLocation;
        private readonly ICookieManager _cookieManager;
        public HomeController(ILogger<HomeController> logger, IBusLocationRepository busLocation, ICookieManager cookieManager)
        {
            _logger = logger;
            _busLocation = busLocation;
            _cookieManager = cookieManager;
        }

        public async Task<IActionResult> Index()
        {
                  var GetBusLocation = _cookieManager.Get<VM_BusLocation>();
                  VM_BusLocation viewModel = new()
                    {
                        Destination = GetBusLocation?.Destination,
                        Origin = GetBusLocation?.Origin,
                        DepartureDate = GetBusLocation?.DepartureDate ?? DateTime.Now,
                        DestinationId = GetBusLocation?.DestinationId ?? 0,
                        OriginId = GetBusLocation?.OriginId ?? 0
                    };
               
            return View(viewModel);
        }
       
        public IActionResult GetLocation(VM_BusLocation vM_BusLocation)
        {
            return View("Index", vM_BusLocation);
        }
       
        public async Task<IEnumerable<SelectListItem>> GetBusLocation(string search)
        {
            BusLocationResponse result = await _busLocation.Get(search);
            return result.BusLocationData.Take(10).Select(x => new SelectListItem(x.Name, x.Id.ToString()));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}