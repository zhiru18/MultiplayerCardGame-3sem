using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGameClient.ServiceAcces;
using WebGameClient.Models;

namespace WebGameClient.Controllers {
    [Authorize]
    public class GameController : Controller {
        // GET: Game

        public ActionResult Index(int id) {
            GameTableServiceAccess gameTableServiceAcces = new GameTableServiceAccess();
            GameServiceAcces gameServiceAccess = new GameServiceAcces();
            Game game = null;
            try {
                GameTable gameTable = gameTableServiceAcces.GetGameTable(id);
                game = gameServiceAccess.StartGame(gameTable);
            } catch (Exception e) {
                return RedirectToAction("Error", "ErrorHandler", new { id = 2 });
            }
            return View(game);
        }

    }
}