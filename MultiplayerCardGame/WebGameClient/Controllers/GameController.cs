using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGameClient.ServiceAcces;
using WebGameClient.Models;

namespace WebGameClient.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index(int gameTableId) 
        {
            GameServiceAcces gameServiceAcces = new GameServiceAcces();
            GameTable gameTable = gameServiceAcces.GetGameTable(gameTableId);
            Game game= gameServiceAcces.StartGame(gameTable);
            return View(game);
        }
    }
}