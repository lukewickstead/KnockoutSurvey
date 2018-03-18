using Microsoft.AspNetCore.Mvc;
using KnockoutSurvey.Models;
    
namespace KnockoutSurvey.Controllers
{
    public class SurveyController : Controller
    {
        [HttpGet]
        public IActionResult Get() => View("Index");

        [HttpPost]
        public IActionResult Submit([FromBody] SurveyViewModel viewModel)
        {
            return !ModelState.IsValid ? (IActionResult) BadRequest(ModelState) : Ok(viewModel);
        }
    }
}