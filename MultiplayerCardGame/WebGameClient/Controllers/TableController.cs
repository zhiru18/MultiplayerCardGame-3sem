using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGameClient.Models;
using WebGameClient.ServiceAcces;
using Microsoft.AspNet.Identity;

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
        public ActionResult Create() {

            return View();
        }
        [HttpPost]
        public ActionResult Create(string tableName) {
            GameTable foundGt = null;
            Game createdGame = null;
            GameTableServiceAccess gameTableServiceAcces = new GameTableServiceAccess();
            GameServiceAcces gameServiceAcces = new GameServiceAcces();
            if (tableName != null ) {       
              string userId = User.Identity.GetUserId();
              foundGt = gameTableServiceAcces.CreateGameTable(userId,tableName);
                createdGame = new Game(foundGt);
                gameServiceAcces.CreateGAme(createdGame);
            }
           // List<GameTable> tables = new List<GameTable>() { foundGt };
            ViewBag.Situation = 3;
            return View(tables);
        }

        public ActionResult Succes() {
            return View();
        }
        public ActionResult JoinTable() {
            return View();
        }
       [HttpPost]
        public ActionResult JoinTable(string gameTableID) {
            GameTable foundGt = null;
            Game foundGame = null;
            GameTableServiceAccess gameTableServiceAcces = new GameTableServiceAccess();
            GameServiceAcces gameServiceAcces = new GameServiceAcces();
            if (gameTableID != null) {
                string userId = User.Identity.GetUserId();
                int tableId = Int32.Parse(gameTableID);
                foundGt = gameTableServiceAcces.JoinGameTable(userId, tableId);
                foundGame = gameServiceAcces.GetByTableId(tableId);
            }
           // List<GameTable> tables = new List<GameTable>() { foundGt };
            if (foundGt!=null) {
                ViewBag.Situation = 4;
            } else {
                ViewBag.Situation = 5;
            }
            return View(tables);
        }
    }
}