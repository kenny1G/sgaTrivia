using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using bc_awareness.Services;
using bc_awareness.Models;
using Microsoft.AspNetCore.Http;

namespace bc_awareness.Controllers
{
    public class QuestionsController : Controller
    {

        public JsonFileTriviaService TriviaService;
        public  IEnumerable<Trivia> Questions { get; private set; }

        public QuestionsController(JsonFileTriviaService triviaService)
        {
            TriviaService = triviaService;
        }

       
        public IActionResult Index()
        {
            Questions = TriviaService.GetQuestions();
            var Index = HttpContext.Session.GetInt32(HomeController.SessionIndex);
            Trivia question = null;
            if (Index <= 9)
            {
                question = Questions.ElementAt((int)Index);
            }
            else
            {
                return RedirectToAction("Thanks", "Finale");
            }
            
            
            HttpContext.Session.SetString(HomeController.SessionAnswer, question.Answer);
            QuestionViewModel model = new QuestionViewModel(question);
            
            return View(model);
        }
    }
}