using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using bc_awareness.Models;
using bc_awareness.Services;
using Microsoft.AspNetCore.Http;

namespace bc_awareness.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public const string SessionScore = "_Score";
        public const string SessionIndex = "_Index";
        public const string SessionAnswer = "_Answer";
        public const string ShuffledIndex = "_ShuffledIndex";
        public const string StartTime = "_StartTime";
        public JsonCreatorService CreatorService;
        public JsonFileTriviaService TriviaService;

        public HomeController(ILogger<HomeController> logger, JsonCreatorService creatorService, JsonFileTriviaService triviaService)
        {
            _logger = logger;
            CreatorService = creatorService;
            TriviaService = triviaService;
        }

        public IActionResult Index()
        {

            HttpContext.Session.SetInt32(SessionIndex, 0);
            HttpContext.Session.SetInt32(SessionScore, 0);
            // list to store indexes that have already been saved in the session
            List<int> usedIndexes = new List<int>();
            int numberOfQuestions = TriviaService.GetQuestions().Count();
            for (int i = 0; i < 10; i++)
            {
                Random rnd = new Random();
                int randomIndex = rnd.Next(0, numberOfQuestions);
                while (usedIndexes.Contains(randomIndex))
                {
                    randomIndex = rnd.Next(0, numberOfQuestions);
                }
                usedIndexes.Add(randomIndex);
                HttpContext.Session.SetInt32(ShuffledIndex + i, randomIndex);
            }
            CreatorService.CreateJson();
            return View();
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
