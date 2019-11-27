using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGameClient.Models;
using WebGameClient.ServiceAcces;

namespace WebGameClient.Controllers
{
    public class TableController : Controller
    {
        // GET: Table
        public ActionResult Index()
        {
            GameTableServiceAccess gameTableServiceAcces = new GameTableServiceAccess();
            List<GameTable> gameTables = gameTableServiceAcces.GetAll();
            return View(gameTables);
        }
    }
}