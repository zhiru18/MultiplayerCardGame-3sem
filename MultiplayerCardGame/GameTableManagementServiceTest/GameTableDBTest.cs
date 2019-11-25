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
            var table1 = new GameTable("Game1");
            table1.Id = 1;
            gameTableDB.Delete(table1);
            table1 = gameTableDB.GetById(1);
            Assert.IsNull(table1);
        }

        [TestMethod]
        public void InsertTest() {
            gameTableDB = new GameTableDB();
            var table5 = new GameTable("Game5");
            gameTableDB.Insert(table5);
            gameTableDB.Insert(table5);
            var tableT = gameTableDB.GetById(table5.Id);
            Assert.AreEqual(table5.TableName, tableT.TableName);
        }
    }
}
