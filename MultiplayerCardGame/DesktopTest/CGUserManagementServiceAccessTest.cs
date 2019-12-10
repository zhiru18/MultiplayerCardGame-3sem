using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopGameClient.Models;
using DesktopGameClient.ServiceAcces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Data.Data;

namespace Tests.DesktopTest {
    [TestClass]
    public class CGUserManagementServiceAccessTest {
        [TestMethod]
        public void GetAllTest() {
            //Arrange
            CGUserManagementServiceAccess cGUserServiceAccess = new CGUserManagementServiceAccess();

            //Act
            List<CGUserModel> users = cGUserServiceAccess.GetAll();

            //Assert
            Assert.IsTrue(users.Count > 0);
        }
        [TestMethod]
        public void GetUserByUserNameTest() {
            //Arrange
            CGUserManagementServiceAccess cGUserServiceAccess = new CGUserManagementServiceAccess();
            CGUserModel user1 = null, user2 = null;
            List<CGUserModel> users = cGUserServiceAccess.GetAll();
            if (users.Count > 0) {
                user1 = users[0];
            }

            //Act
            user2 = cGUserServiceAccess.GetUserByUserName(user1.UserName);

            //Assert
            Assert.AreEqual(user1.Email, user2.Email);
        }

        [TestMethod]
        public void DeleteTest() {
            //Arrange
            CGUserManagementServiceAccess cGUserServiceAccess = new CGUserManagementServiceAccess();
            CGUserModel userModel = new CGUserModel {
                Id = "Test2",
                Email = "test2@email.com",
                UserName = "TestUser"
            };
            cGUserServiceAccess.CreateUser("Test2", "test2@email.com", "TestUser");
            List<CGUserModel> users = cGUserServiceAccess.GetAll();
            foreach (var user in users) {
                if (user.UserName == "TestUser") {
                    userModel = user;
                }
            }
            bool res = false;

            //Act
            res = cGUserServiceAccess.DeleteCGUser(userModel);

            //Assert
            Assert.IsTrue(res);
        }
    }
}
