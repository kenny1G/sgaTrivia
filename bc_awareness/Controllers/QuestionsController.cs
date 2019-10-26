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
        public IEnumerable<Trivia> Questions { get; private set; }
        const string SessionIndex = "_Index";
        public QuestionsController(JsonFileTriviaService triviaService)
        {
            TriviaService = triviaService;
        }

       
        public IActionResult Index()
        {
            Questions = TriviaService.GetQuestions();
            var Index = HttpContext.Session.GetInt32(SessionIndex);
            var question = Questions.ElementAt((int) Index);
            QuestionViewModel model = new QuestionViewModel(question);
            HttpContext.Session.SetInt32(SessionIndex,(int) Index + 1);
            return View(model);
        }
    }
}