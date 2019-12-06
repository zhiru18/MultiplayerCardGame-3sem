using System;
using System.Collections.Generic;
using DesktopGameClient.Controllers;
using DesktopGameClient.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.DesktopTest {
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
            GameTableModel gameTable1 = gameTableController.GetById(103);
            bool res = false;

            //Act
            res = gameTableController.Delete(gameTable1.Id);
          

            //Assert
            Assert.IsTrue(res);
        }
    }
}
