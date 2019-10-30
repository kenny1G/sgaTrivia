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
            String timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            HttpContext.Session.SetString(HomeController.EndTime, timeStamp);
            ViewBag.startTime = HttpContext.Session.GetString(HomeController.StartTime);
            ViewBag.endTime = HttpContext.Session.GetString(HomeController.EndTime);
            return View();
        }
    }
}