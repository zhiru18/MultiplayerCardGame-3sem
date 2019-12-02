using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Data.Data;
using Server.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Data.Tests {
    [TestClass()]
    public class GameTableDBTest {
        [TestMethod()]
        public void GetGameTableSeatsTest() {
            GameTableDB gameTableDB = new GameTableDB();
            GameTableModel table = gameTableDB.GetById(15);
            int seats = gameTableDB.GetGameTableSeats(table);
            Assert.AreEqual(seats, 4);
            //TODO: Make this test actually useful.
        }
    }
}