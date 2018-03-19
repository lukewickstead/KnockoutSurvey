using System;
using KnockoutSurvey.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using KnockoutSurvey.Models;
    
namespace KnockoutSurvey.Controllers
{
    public class SurveyController : Controller
    {
        private readonly IConsoleAdapter _consoleAdapter;

        public SurveyController(IConsoleAdapter consoleAdapter)
        {
            _consoleAdapter = consoleAdapter;
        }

        [HttpGet]
        public IActionResult Get() => View("Index");

        [HttpPost]
        public IActionResult Submit([FromBody] SurveyViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _consoleAdapter.WriteLine("Survey Received:");
            _consoleAdapter.WriteLine("  Title: " + viewModel.Title);
            _consoleAdapter.WriteLine("  Name: " + viewModel.Name);
            _consoleAdapter.WriteLine("  Date Of Birth: " + viewModel.DateOfBirth);
            _consoleAdapter.WriteLine("  Location: " + viewModel.Location);
            _consoleAdapter.WriteLine("  Now: " + viewModel.Now);
            _consoleAdapter.WriteLine("  Feedback: " + viewModel.Feedback);
            
            return Ok(viewModel);
        }
    }
}