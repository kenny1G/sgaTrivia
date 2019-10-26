using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bc_awareness.Controllers
{
    
    public class ValidateController : Controller
    {
        public IActionResult Index(string userAnswer)
        {
            if (userAnswer == HttpContext.Session.GetString(QuestionsController.SessionAnswer))
            {
                ViewBag.result = true;
            }
            else
            {
                ViewBag.result = false;
            }
            return View();
        }
    }
}