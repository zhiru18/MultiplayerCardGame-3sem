using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopGameClient.Controllers;
using DesktopGameClient.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Data.Data;

namespace Tests.DesktopTest {
    [TestClass]
    public class CGUserControllerTest {
        [TestMethod]
        public void GetAllTest() {
            //Arrange
            CGUserController cGUserController = new CGUserController();

            //Act
            List<CGUserModel> users = cGUserController.GetAll();

            //Assert
            Assert.IsTrue(users.Count > 0);
        }
        [TestMethod]
        public void GetUserByUserNameTest() {
            //Arrange
            CGUserController cGUserController = new CGUserController();
            CGUserModel user1 = null, user2 = null;
            List<CGUserModel> users = cGUserController.GetAll();
            if (users.Count > 0) {
                user1 = users[0];
            }

            //Act
            user2 = cGUserController.GetUserByUserName(user1.UserName);

            //Assert
            Assert.AreEqual(user1.Email, user2.Email);
        }

        [TestMethod]
        public void DeleteTest() {
            //Arrange
            CGUserController cGUserController = new CGUserController();
            CGUserModel userModel = new CGUserModel {
                Id = "Test",
                Email = "test@email.com",
                UserName = "Test"
            };
            GameTableModel tableModel = null;
            gameTableController.CreateGameTable(userModel, "TestTable");
            List<GameTableModel> tables = gameTableController.GetAll();
            foreach (var table in tables) {
                if (table.TableName == "TestTable") {
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
