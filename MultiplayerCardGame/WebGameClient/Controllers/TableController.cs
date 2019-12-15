using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGameClient.Models;
using WebGameClient.ServiceAcces;
using Microsoft.AspNet.Identity;
using System.Web.Routing;

namespace WebGameClient.Controllers {
    [Authorize]
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
        public ActionResult Create() {

            return View();
        }
        [HttpPost]
        public ActionResult Create(string tableName) {
            GameTable foundGt = null;
            GameTableServiceAccess gameTableServiceAcces = new GameTableServiceAccess();
            if (tableName != null ) {       
              string userId = User.Identity.GetUserId();
                try {
                    foundGt = gameTableServiceAcces.CreateGameTable(userId, tableName);
                }catch(Exception e) {
                    return RedirectToAction("Error", "ErrorHandler", new { id = 4 });
                }
            }
            ViewBag.Situation = 3;
            return RedirectToAction("Lobby", new { tableId = foundGt.Id });

        }        
        public ActionResult JoinTable() {
            return View();
        }
        
       [HttpPost]
        public ActionResult JoinTable(string gameTableID) {
            GameTable foundGt = null;
            bool userFound = false;
            GameTableServiceAccess gameTableServiceAcces = new GameTableServiceAccess();
            if (gameTableID != null) {
                string userId = User.Identity.GetUserId();
                int tableId = Int32.Parse(gameTableID);
                foundGt = gameTableServiceAcces.GetGameTable(tableId);
                foreach (var user in foundGt.Users) {
                    if(user.Id == userId) {
                        userFound = true;
                    }
                }
                if (foundGt.Users.Count == 4 && !userFound) {
                    return View("JoinTable");
                }
                try {
                    foundGt = gameTableServiceAcces.JoinGameTable(userId, tableId);
                } catch (Exception e) {
                    return RedirectToAction("Error", "ErrorHandler", new { id = 3 });
                }
            }
            List<GameTable> tables = new List<GameTable>() { foundGt };

            return RedirectToAction("Lobby", new { tableId = foundGt.Id});
        }
        
        public ActionResult Lobby(int? tableId) {
            GameTable foundGt = null;
            GameTableServiceAccess gameTableServiceAcces = new GameTableServiceAccess();
            foundGt = gameTableServiceAcces.GetGameTable((int)tableId);
            return View(foundGt);
        }
    }
}