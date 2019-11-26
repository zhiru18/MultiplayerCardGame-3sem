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
            GameTableServiceAccess gameTableServiceAcces = new GameTableServiceAccess();
            GameServiceAcces gameServiceAccess = new GameServiceAcces();
            GameTable gameTable = gameTableServiceAcces.GetGameTable(gameTableId);
            Game game= gameServiceAccess.StartGame(gameTable);
            return View(game);
        }
    }
}