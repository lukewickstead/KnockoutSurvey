using KnockoutSurvey.Infrastructure;
using KnockoutSurvey.Models;
using Microsoft.AspNetCore.Mvc;

namespace KnockoutSurvey.Controllers
{
    public class LocationController  : Controller
    {
        private readonly IGoogleApisServiceAdapter _serviceAdapter;

        public LocationController(IGoogleApisServiceAdapter serviceAdapter)
        {
            _serviceAdapter = serviceAdapter;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] decimal latitude, [FromQuery]decimal longitude)
        {
            try
            {
                var address = _serviceAdapter.GetAddress(latitude, longitude);
                return Json(new Address() {Result = address});
            }
            catch
            {
                return BadRequest("Failed getting address");
            }
        }
    }
}