using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopGameClient.Controllers;
using DesktopGameClient.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesktopGameClient.DesktopClientTest {
    [TestClass]
    public class GameTableControllerTest {
        [TestMethod]
        public void GetAllTest() {
            //Arrange
            GameTableController gameTableController = new GameTableController();

            //Act
            List<GameTableModel> gameTables = gameTableController.GetAll();

            //Assert
            Assert.IsTrue(gameTables.Count > 0);
        }
        [TestMethod]
        public void GetByIdTest() {
            //Arrange
            GameTableController gameTableController = new GameTableController();
            GameTableModel gameTable1 = new GameTableModel("MortensTable");

            //Act
            GameTableModel gameTable2 = gameTableController.GetById(88);

            //Assert
            Assert.AreEqual(gameTable1.TableName, gameTable2.TableName);
        }
        [TestMethod]
        public void DeleteTest() {
            //Arrange
            GameTableController gameTableController = new GameTableController();
            GameTableModel gameTable1 = gameTableController.GetById(91);

            //Act
            gameTableController.Delete(gameTable1.Id);
            gameTable1 = gameTableController.GetById(gameTable1.Id);

            //Assert
            Assert.IsNull(gameTable1);
        }
    }
}
