using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace bc_awareness.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Content"] = "Welcome to the SGA Breast Cancer Awareness Trivia Game.  This is filler content...";
            return View();
        }
        
        public string Welcome()
        {
            return "This is my Welcome action.";
        }
    }
}