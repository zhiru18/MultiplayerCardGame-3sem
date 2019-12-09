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
            GameTableModel gameTable = null, gameTable2 = null;
            List<GameTableModel> tables = gameTableController.GetAll();
            if(tables.Count > 0) {
                gameTable = tables[0];
            }
            //Act
            gameTable2 = gameTableController.GetById(gameTable.Id);

            //Assert
            Assert.AreEqual(gameTable.TableName, gameTable2.TableName);
        }
        [TestMethod]
        public void DeleteTest() {
            //Arrange
            GameTableController gameTableController = new GameTableController();
            CGUserModel userModel = new CGUserModel { 
                Id = "Test", 
                Email = "test@email.com", 
                UserName = "Test" 
            };
            GameTableModel tableModel = null;
            gameTableController.CreateGameTable(userModel, "TestTable");
            List<GameTableModel> tables = gameTableController.GetAll();
            foreach (var table in tables) {
                if(table.TableName == "TestTable") {
                    tableModel = table;
                }
            }
            bool res = false;

            //Act
            res = gameTableController.Delete(tableModel.Id);
          

            //Assert
            Assert.IsTrue(res);
        }
    }
}
