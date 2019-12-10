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
                Id = "Test2",
                Email = "test2@email.com",
                UserName = "TestUser"
            };
            cGUserController.CreateUser("Test2", "test2@email.com", "TestUser");
            List<CGUserModel> users = cGUserController.GetAll();
            foreach (var user in users) {
                if (user.UserName == "TestUser") {
                    userModel = user;
                }
            }
            bool res = false;

            //Act
            res = cGUserController.DeleteCGUser(userModel);

            //Assert
            Assert.IsTrue(res);

        }
    }
}
