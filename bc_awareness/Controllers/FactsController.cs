using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bc_awareness.Models;
using bc_awareness.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bc_awareness.Controllers
{
    public class FactsController : Controller
    {
        public IEnumerable<Trivia> Questions { get; private set; }
        public JsonFileTriviaService TriviaService;
        public FactsController(JsonFileTriviaService triviaService)
        {
            TriviaService = triviaService;
        }
        public IActionResult Index()
        {
            Questions = TriviaService.GetQuestions();
            var Index = HttpContext.Session.GetInt32(HomeController.SessionIndex);
            if (Index <= 9)
            {
                ViewBag.fact = Questions.ElementAt((int)Index).Fact;
            }
            else
            {
                ViewBag.fact = "Hmm I seem to have lost my bag of wisdom";
            }
            HttpContext.Session.SetInt32(HomeController.SessionIndex, (int)Index + 1);

            return View();
        }
    }
}