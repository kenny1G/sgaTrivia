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
        public JsonFileTriviaService TriviaService;
        public IEnumerable<Trivia> Questions { get; private set; }

        public HomeController( JsonFileTriviaService triviaService)
        {
            //_logger = logger;
            TriviaService = triviaService;
            Questions = TriviaService.GetQuestions().OrderBy(elem => Guid.NewGuid());
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetInt32(SessionIndex, 0);
            HttpContext.Session.SetInt32(SessionScore, 0);
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
