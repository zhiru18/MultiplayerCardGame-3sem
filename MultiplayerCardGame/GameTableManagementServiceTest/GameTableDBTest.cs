using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Data.Data;
using Server.Model.Model;

namespace GameTableManagementServiceTest {
    [TestClass]
    public class GameTableDBTest {
        GameTableDB gameTableDB;
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
            var table5 = new GameTable("Game5");
            gameTableDB.Insert(table5);
            var tableT = gameTableDB.GetById(5);
            Assert.AreEqual(table5.TableName, tableT.TableName);
        }
        [TestMethod]
        public void getbyidtest() {
            gameTableDB = new GameTableDB();
            GameTable table1 = gameTableDB.GetById(2);
            Assert.AreEqual(2, table1.Id);
        }
        [TestMethod]
        public void GetAllTest() {
            gameTableDB = new GameTableDB();
            List<GameTable> gameTables = (List<GameTable>)gameTableDB.GetAll();
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
