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
                    return View("Error");
                case 3:
                    ViewBag.Message = "The table is busy try again or find another table";
                    return View("Error");
                case 4:
                    ViewBag.Message = "Sorry an error ocurred while trying to create the table";
                    return View("Error");
                default:
                    ViewBag.Message = "Sorry an error ocurred";
                    return View("Error");
            }
            
        }
    }
}