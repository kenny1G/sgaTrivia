using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bc_awareness.Models;
using bc_awareness.Services;
using Microsoft.AspNetCore.Mvc;

namespace bc_awareness.Controllers
{
    public class LeaderboardController : Controller
    {
        public JsonFileLeaderboardService LeaderboardService;
        public IEnumerable<Leaderboard> Players { get; private set; }

        public LeaderboardController(JsonFileLeaderboardService leaderboardService)
        {
            LeaderboardService = leaderboardService;
        }

        public IActionResult Index()
        {
            Players = LeaderboardService.GetPlayers();
            return View(Players);
        }
    }
}