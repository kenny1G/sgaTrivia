using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bc_awareness.Controllers
{
    public class FinaleController : Controller
    {
        public IActionResult Thanks()
        {
            ViewBag.score = HttpContext.Session.GetInt32(HomeController.SessionScore);
            return View();
        }
    }
}