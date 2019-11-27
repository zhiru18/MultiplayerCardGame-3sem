﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGameClient.Models;
using WebGameClient.ServiceAcces;

namespace WebGameClient.Controllers {
    public class TableController : Controller {
        // GET: Table
        public ActionResult Index() {
            List<GameTable> gameTables;
            GameTableServiceAccess gameTableServiceAcces = new GameTableServiceAccess();
             ViewBag.Situation = 0;
             gameTables = gameTableServiceAcces.GetAll();                      
             return View(gameTables);
        }
        [HttpPost]
        public ActionResult Index(string InputTableName) {
            GameTable foundGt = null;
            GameTableServiceAccess gameTableServiceAcces = new GameTableServiceAccess();
            if (InputTableName != null) {
                foundGt = gameTableServiceAcces.GetTableByName(InputTableName);
            }
            List<GameTable> tables = new List<GameTable>() {foundGt };
            ViewBag.Situation = 2;
            return View(tables);
        }
        //public ActionResult Index() {
        //    GameTableServiceAccess gameTableServiceAcces = new GameTableServiceAccess();
        //    List<GameTable> gameTables = gameTableServiceAcces.GetAll();
        //    return View(gameTables);

        //}
    }
}