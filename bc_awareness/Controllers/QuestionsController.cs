using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using bc_awareness.Services;
using bc_awareness.Models;

namespace bc_awareness.Controllers
{
    public class QuestionsController : Controller
    {

        public JsonFileTriviaService TriviaService;
        public IEnumerable<Trivia> Questions { get; private set; }
        public QuestionsController(JsonFileTriviaService triviaService)
        {
            TriviaService = triviaService;
        }
        
        public IActionResult Index(int? id)
        {
            Questions = TriviaService.GetQuestions();
            int index = 0;
            if (id != null)
            {
                index = (int) id;
            }
            else
            {
                Console.WriteLine("oops");
                return NotFound();
            }

            var question = Questions.ElementAt(index);
            return View(question);
        }
    }
}