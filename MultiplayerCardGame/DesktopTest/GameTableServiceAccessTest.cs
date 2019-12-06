using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopGameClient.GameTableServiceReference;
using DesktopGameClient.Models;
using DesktopGameClient.ServiceAcces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.DesktopTest {
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
        [TestMethod]
        public void GetByIdTest() {
            //Arrange
            GameTableServiceAccess gameTableServiceAccess = new GameTableServiceAccess();
            GameTableModel gameTable1 = new GameTableModel("MortensTable");

            //Act
            GameTableModel gameTable2 = gameTableServiceAccess.GetById(88);

            //Assert
            Assert.AreEqual(gameTable1.TableName, gameTable2.TableName);
        }
        [TestMethod]
        public void DeleteTest() {
            //Arrange
            GameTableServiceAccess gameTableServiceAccess = new GameTableServiceAccess();
            GameTableModel gameTable1 = gameTableServiceAccess.GetById(102);
            bool res = false;

            //Act
            res = gameTableServiceAccess.Delete(gameTable1.Id);


            //Assert
            Assert.IsTrue(res);
        }
    }
}
