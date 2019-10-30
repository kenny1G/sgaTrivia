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
            String timeStamp = DateTime.Now.ToString("HHmmss");
            HttpContext.Session.SetString(HomeController.EndTime, timeStamp.Substring(0,2)+":"+timeStamp.Substring(2,2)+":"+timeStamp.Substring(4,2));
            ViewBag.startTime = HttpContext.Session.GetString(HomeController.StartTime);
            ViewBag.endTime = HttpContext.Session.GetString(HomeController.EndTime);
            return View();
        }
    }
}