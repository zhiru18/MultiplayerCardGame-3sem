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
            CGUserModel user = cgUserDB.GetById("3e0cd506-d7d6-431d-9f25-afc70d6ce993");
            cgUserDB.UpdateUserTableId(user, 10);
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
            var anders = new CGUserModel("bob", "Anders@anders.com", CGUserModel.UserType.PLAYER, CGUserModel.UserStatus.STUNNED);
            anders.Id = "qwerty12345678";
            cgUserDB.Insert(anders);
            var anders2 = cgUserDB.GetById("qwerty12345678");
            Assert.AreEqual(anders.UserName, anders2.UserName);
            cgUserDB.Delete(anders);
        }
        [TestMethod]
        public void UpdateTest() {
            cgUserDB = new CGUserDB();
            var anders = new CGUserModel("qwerty12345678", "Anders@anders.com", CGUserModel.UserType.PLAYER, CGUserModel.UserStatus.INGAME);
            cgUserDB.Update(anders);
            var anders2 = cgUserDB.GetById("qwerty12345678");
            Assert.AreEqual(anders.userStatus, anders2.userStatus);
        }
        [TestMethod]
        public void DeleteTest() {
            cgUserDB = new CGUserDB();
            var anders = new CGUserModel("bob", "Anders@anders.com", CGUserModel.UserType.PLAYER, CGUserModel.UserStatus.INGAME);
            anders.Id = "asdfg09876";
            cgUserDB.Insert(anders);
            cgUserDB.Delete(anders);
            anders = cgUserDB.GetById("asdfg09876");
            Assert.IsNull(anders);
        }
    }
}