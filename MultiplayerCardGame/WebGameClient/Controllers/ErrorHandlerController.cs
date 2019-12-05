using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebGameClient.Controllers
{
    public class ErrorHandlerController : Controller
    {
        // GET: ErrorHandler
        public ActionResult Index()
        {
            return RedirectToAction("Error", new { id = 1});
        }

        public ActionResult Error(int? id) {
            int errorId = (int)id;
            switch (errorId) {
                case 2:
                    ViewBag.Message = "Sorry an error ocurred while trying to start your game";
                    break;
                default:
                    ViewBag.Message = "Sorry an error ocurred";
                    break;
            }
            return View();
        }
    }
}