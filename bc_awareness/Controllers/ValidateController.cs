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
            if (userAnswer == HttpContext.Session.GetString(HomeController.SessionAnswer))
            {
                ViewBag.result = true;
                HttpContext.Session.SetInt32(HomeController.SessionScore, (int) HttpContext.Session.GetInt32(HomeController.SessionScore) + 1);
            }
            else
            {
                ViewBag.result = false;
            }
            return View();
        }
    }
}