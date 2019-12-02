using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Data.Data;
using Server.Model.Model;

namespace UserManagementServiceTest {
    [TestClass]
    public class CGUserDBTest {
        CGUserDB cgUserDB;
        [TestMethod]
        public void GetAllTest() {
            cgUserDB = new CGUserDB();
            List<CGUserModel> cgUsers = (List<CGUserModel>)cgUserDB.GetAll();
            Assert.IsTrue(cgUsers.Count > 0);
        }
        [TestMethod]
        public void GetByIdTest() {
            cgUserDB = new CGUserDB();
            CGUserModel manny = cgUserDB.GetById("12345678qwerty");
            Assert.AreEqual("12345678qwerty", manny.Id);
        }
        [TestMethod]
        public void GetUserByUserNameTest() {
            cgUserDB = new CGUserDB();
            CGUserModel manny = cgUserDB.GetUserByEmail("Manny@manny.com");
            Assert.AreEqual("Manny@manny.com", manny.Email);
        }
        [TestMethod]
        public void InsertTest() {
            cgUserDB = new CGUserDB();
            var anders = new CGUserModel("qwerty12345678", "Anders@anders.com", CGUserModel.UserType.PLAYER, CGUserModel.UserStatus.STUNNED);
            cgUserDB.Insert(anders);
            var anders2 = cgUserDB.GetById("qwerty12345678");
            Assert.AreEqual(anders.UserName, anders2.UserName);
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
            var anders = new CGUserModel("qwerty12345678", "Anders@anders.com", CGUserModel.UserType.PLAYER, CGUserModel.UserStatus.INGAME);
            cgUserDB.Delete(anders);
            anders = cgUserDB.GetById("qwerty12345678");
            Assert.IsNull(anders);
        }
    }
}
