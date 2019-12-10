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
            GameTableModel gameTable = null, gameTable2 = null;
            List<GameTableModel> tables = gameTableServiceAccess.GetAll();
            if (tables.Count > 0) {
                gameTable = tables[0];
            }
            //Act
            gameTable2 = gameTableServiceAccess.GetById(gameTable.Id);

            //Assert
            Assert.AreEqual(gameTable.TableName, gameTable2.TableName);
        }
        [TestMethod]
        public void DeleteTest() {
            //Arrange
            GameTableServiceAccess gameTableServiceAccess = new GameTableServiceAccess();
            CGUserModel userModel = new CGUserModel {
                Id = "Test",
                Email = "test@email.com",
                UserName = "Test"
            };
            GameTableModel tableModel = null;
            gameTableServiceAccess.CreateGameTable(userModel, "TestTable");
            List<GameTableModel> tables = gameTableServiceAccess.GetAll();
            foreach (var table in tables) {
                if (table.TableName == "TestTable") {
                    tableModel = table;
                }
            }
            bool res = false;

            //Act
            res = gameTableServiceAccess.Delete(tableModel.Id);


            //Assert
            Assert.IsTrue(res);
        }
    }
}
