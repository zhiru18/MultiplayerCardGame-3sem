using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Data.Data;
using Server.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.DataTest {
    [TestClass()]
    public class CGUserDBTest {
        CGUserDB cgUserDB;
        [TestMethod()]
        public void UpdateUserTableIdTest() {
            ICGUserDBIF cgUserDB = new CGUserDB();
            CGUserModel user = cgUserDB.GetById("Test");
            if (user.TableID == 999) {
                cgUserDB.UpdateUserTableId(user, 998);
            } else {
                cgUserDB.UpdateUserTableId(user, 999);
            }
            CGUserModel user2 = cgUserDB.GetById("Test");
            Assert.AreNotEqual(user.TableID, user2.TableID);

        }

        [TestMethod]
        public void GetAllTest() {
            cgUserDB = new CGUserDB();
            List<CGUserModel> cgUsers = (List<CGUserModel>)cgUserDB.GetAll();
            Assert.IsTrue(cgUsers.Count > 0);
        }
        [TestMethod]
        public void GetByIdTest() {
            cgUserDB = new CGUserDB();
            CGUserModel test = cgUserDB.GetById("Test");
            Assert.AreEqual("Test", test.Id);
        }
        [TestMethod]
        public void GetUserByEmailTest() {
            cgUserDB = new CGUserDB();
            CGUserModel test = cgUserDB.GetUserByEmail("test@email.com");
            Assert.AreEqual("test@email.com", test.Email);
        }
        [TestMethod]
        public void InsertTest() {
            cgUserDB = new CGUserDB();
            var bob = new CGUserModel("bob", "bob@bob.com", CGUserModel.UserType.PLAYER, CGUserModel.UserStatus.STUNNED);
            bob.Id = "qwerty12345678";
            cgUserDB.Insert(bob);
            var anders2 = cgUserDB.GetById("qwerty12345678");
            Assert.AreEqual(bob.UserName, anders2.UserName);
            cgUserDB.Delete(bob);
        }
        [TestMethod]
        public void UpdateTest() {
            //Arrange
            cgUserDB = new CGUserDB();
            var test = cgUserDB.GetById("Test");
            var name = test.UserName;
            test.UserName = "Updated";
            //Act
            cgUserDB.Update(test);
            var test2 = cgUserDB.GetById("Test");
            Assert.AreNotEqual(name, test2.UserName);
            //Cleanup
            test.UserName = "Test";
            cgUserDB.Update(test);
        }
        [TestMethod]
        public void DeleteTest() {
            cgUserDB = new CGUserDB();
            var bob = new CGUserModel("bob", "Bob@bob.com", CGUserModel.UserType.PLAYER, CGUserModel.UserStatus.INGAME);
            bob.Id = "asdfg09876";
            cgUserDB.Insert(bob);
            cgUserDB.Delete(bob);
            bob = cgUserDB.GetById("asdfg09876");
            Assert.IsNull(bob);
        }
    }
}