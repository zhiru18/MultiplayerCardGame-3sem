using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Data.Data;
using Server.DataContracts.DataContracts;

namespace GameServiceTest {

    [TestClass]
    public class GameDBTest {
        private GameDB gameDB;
        private GameTableDB gameTableDB;

        //TODO
        //[TestMethod]
        //public void InsertTest() {
        //    gameDB = new GameDB();
        //    gameTableDB = new GameTableDB();
        //    GameTable table1 = gameTableDB.GetById(2);
        //    Game game1 = new Game(table1);
        //    gameDB.Insert(game1);
        //    Game game2 = gameDB.GetById(14);
        //    Assert.AreEqual(game1.Id, game2.Id);
        //}

    }
}
