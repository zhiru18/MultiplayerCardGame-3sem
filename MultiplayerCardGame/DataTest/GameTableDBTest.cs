using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Data.Data;
using Server.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.DataTest {
    [TestClass()]
    public class GameTableDBTest {
        GameTableDB gameTableDB = new GameTableDB();
        [TestMethod()]
        public void GetGameTableSeatsTest() {
            
            GameTableModel table = gameTableDB.GetById(15);
            int seats = gameTableDB.GetGameTableSeats(table);
            Assert.AreEqual(seats, 4);
            //TODO: Make this test actually useful.
        }
        [TestMethod]
        public void DeleteTest() {
            gameTableDB = new GameTableDB();
            var table1 = gameTableDB.GetById(1);
            gameTableDB.Delete(table1);
            table1 = gameTableDB.GetById(1);
            Assert.IsNull(table1);
        }
        [TestMethod]
        public void InsertTest() {
            gameTableDB = new GameTableDB();
            var table5 = new GameTableModel("Game5");
            DeckModel deck = new DeckModel();
            table5.DeckId = 1;
            table5.seats = 4;
            gameTableDB.Insert(table5);
            var tableT = gameTableDB.GetById(5);
            Assert.AreEqual(table5.TableName, tableT.TableName);
        }
        [TestMethod]
        public void GetbyIdTest() {
            gameTableDB = new GameTableDB();
            GameTableModel table1 = gameTableDB.GetById(2);
            Assert.AreEqual(2, table1.Id);
        }
        [TestMethod]
        public void GetAllTest() {
            gameTableDB = new GameTableDB();
            List<GameTableModel> gameTables = (List<GameTableModel>)gameTableDB.GetAll();
            Assert.IsTrue(gameTables.Count > 0);
        }
        [TestMethod]
        public void UpdateTest() {
            gameTableDB = new GameTableDB();
            var table3 = gameTableDB.GetById(3);
            table3.TableName = "GameTableUpdate";
            gameTableDB.Update(table3);
            var table2 = gameTableDB.GetById(3);
            Assert.AreEqual("GameTableUpdate", table2.TableName);
        }
    }
}