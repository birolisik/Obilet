using Microsoft.AspNetCore.Mvc;
using Obilet.Application.Repositories;
using Obilet.Application.Repositories.BusJourney;
using Obilet.Application.ViewModels;
using System.Globalization;

namespace Obilet.Web.Controllers
{
    public class JourneyController : Controller
    {
        private readonly ICookieManager _cookieManager;
        private readonly IBusJourneyRepository _busJourney;

        public JourneyController(ICookieManager cookieManager, IBusJourneyRepository busJourney)
        {
            _cookieManager = cookieManager;
            _busJourney = busJourney;
        }

        public async Task<IActionResult> Index(VM_BusLocation busLocation)
        {
            if (ModelState.IsValid)
            {
                _cookieManager.Set(busLocation);
                var result = await _busJourney.Get(new() { DepartureDate = busLocation.DepartureDate.ToString("yyyy-MM-dd"), DestinationId = busLocation.DestinationId, OriginId = busLocation.OriginId });
                ViewBag.Origin = busLocation.Origin;
                ViewBag.Destination = busLocation.Destination;
                ViewBag.HeaderDate = busLocation.DepartureDate.ToString("dd MMMM dddd", new CultureInfo("tr-TR"));
                return View(result);
            }

            return RedirectToAction("GetLocation", "home", busLocation);
        }
    }
}
