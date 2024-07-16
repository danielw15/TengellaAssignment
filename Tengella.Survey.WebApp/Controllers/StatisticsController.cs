using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tengella.Survey.WebApp.Models;
using Tengella.Survey.WebApp.ServiceInterface;

namespace Tengella.Survey.WebApp.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }


        public async Task<IActionResult> Index()
        {
            try
            {
                var surveySummaries = await _statisticsService.GetSurveySummariesAsync();
                return View(surveySummaries);
            }
            catch (Exception ex)
            {
                // Log the exception and show an error view
                
                ViewBag.ErrorMessage = "An error occurred while retrieving the statistics. Please try again later.";
                return View("Error");
            }
        }
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var surveyStatistics = await _statisticsService.GetSurveyStatisticsViewModelAsync(id);
                return View(surveyStatistics);
            }
            catch (Exception ex)
            {
                // Log the exception and show an error view

                ViewBag.ErrorMessage = "An error occurred while retrieving the statistics. Please try again later.";
                return View("Error");
            }
        }
    }
}
