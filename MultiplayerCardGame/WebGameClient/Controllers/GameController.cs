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
        public ActionResult Index(int id) 
        {
            GameTableServiceAccess gameTableServiceAcces = new GameTableServiceAccess();
            GameServiceAcces gameServiceAccess = new GameServiceAcces();
            GameTable gameTable = gameTableServiceAcces.GetGameTable(id);
            Game game= gameServiceAccess.StartGame(gameTable);
            return View(game);
        }

        protected override void OnException(ExceptionContext filterContext) {
            filterContext.ExceptionHandled = true;
            filterContext.Result = RedirectToAction("Error", "ErrorHandler", new { id = 2});

        }
    }
}