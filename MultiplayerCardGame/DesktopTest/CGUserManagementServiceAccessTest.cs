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
            CGUserModel user1 = new CGUserModel() {
                UserName = "test12",
                Email = "mail@mail.com"
            };

            //Act
           CGUserModel user2 = cGUserServiceAccess.GetUserByUserName("test12");

            //Assert
            Assert.AreEqual(user1.Email, user2.Email);
        }

        [TestMethod]
        public void DeleteTest() {
            //Arrange
            CGUserManagementServiceAccess cGUserServiceAccess = new CGUserManagementServiceAccess();
            CGUserDB cgUserDB = new CGUserDB();
            var bob2 = new Server.Model.Model.CGUserModel("bob2", "Bob@bob.com", Server.Model.Model.CGUserModel.UserType.PLAYER, Server.Model.Model.CGUserModel.UserStatus.INGAME);
            bob2.Id = "asdfg098761";
            cgUserDB.Insert(bob2);
            CGUserModel user = cGUserServiceAccess.GetUserByUserName("bob2");
            bool res = false;

            //Act
            res = cGUserServiceAccess.DeleteCGUser(user);

            //Assert
            Assert.IsTrue(res);
        }
    }
}
