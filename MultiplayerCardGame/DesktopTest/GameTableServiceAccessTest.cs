using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopGameClient.Models;
using DesktopGameClient.ServiceAcces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesktopTest.GameTableServiceReference;

namespace DesktopTest {
    [TestClass]
    public class GameTableServiceAccessTest {
        [TestMethod]
        public void GetAllTest() {
            //Arrange
            GameTableServiceAccess gameTableServiceAccess = new GameTableServiceAccess();

            //Act
            List<GameTableModel> gameTables = gameTableServiceAccess.GetAll();

            //Assert
            Assert.IsTrue(gameTables.Count > 0);
        }
    }
}
