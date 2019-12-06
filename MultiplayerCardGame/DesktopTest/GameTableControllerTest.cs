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
    }
}
