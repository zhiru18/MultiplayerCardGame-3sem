using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Converters.DataContractConverters;
using Server.Data.Data;
using Server.DataContracts.DataContracts;
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
        [TestMethod]
        public void GetUserTableIdTest()
        {
            cgUserDB = new CGUserDB();
            CGUserModel testUser = cgUserDB.GetById("Test");
            var attempt = cgUserDB.GetUserTableId("Test");
            Assert.AreEqual(attempt, testUser.TableID);
        }
        [TestMethod]
        public void GetByUserNameTest() 
        {
            cgUserDB = new CGUserDB();
            CGUserModel testUser = cgUserDB.GetByUserName("Test");
            Assert.AreEqual("Test", testUser.UserName);
        }
        [TestMethod]
        public void InsertHandTest()
        {
            //Arrange
            cgUserDB = new CGUserDB();
            CardDB cardDB = new CardDB();
            //Act
            var userModel = cgUserDB.GetById("Test");
            List<CardModel> cardsOnHand = cardDB.GetCardsByDeckId(2);
            List<CardModel> filteredCardsOnHand = new List<CardModel>();
            for (int i = 0; i < 5; i++)
            {
                CardModel card = cardsOnHand[i];
                filteredCardsOnHand.Add(card);
            }
            cgUserDB.InsertHand(filteredCardsOnHand, userModel);
            CGUser user = CGUserConverter.convertFromCGUserModelToCGUser(cgUserDB.GetById("Test"));
            //Assert
            Assert.IsTrue(user.cards.Count > 0);
            //CleanUp
            CGUserModel revertedUser = CGUserConverter.ConvertFromCGUserToCGUserModel(user);
            cgUserDB.DeleteHand(revertedUser);
        }

        [TestMethod]
        public void DeleteHandTest() 
        {
            //Arrange
            cgUserDB = new CGUserDB();
            CardDB cardDB = new CardDB();
            //Act
            var userModel = cgUserDB.GetById("Test");
            List<CardModel> cardsOnHand = cardDB.GetCardsByDeckId(2);
            List<CardModel> filteredCardsOnHand = new List<CardModel>();
            for (int i = 0; i < 5; i++)
            {
                CardModel card = cardsOnHand[i];
                filteredCardsOnHand.Add(card);
            }
            cgUserDB.InsertHand(filteredCardsOnHand, userModel);
            cgUserDB.DeleteHand(userModel);
            CGUser user = CGUserConverter.convertFromCGUserModelToCGUser(cgUserDB.GetById("Test"));
            //Assert
            Assert.IsTrue(user.cards.Count == 0);
        }
        
        [TestMethod]
        public void GetUserByTableIdTest()
        {
            //Arrange
            cgUserDB = new CGUserDB();
            GameTableDB gameTableDB = new GameTableDB();
            var table = new GameTableModel("TestTable");
            table.DeckId = 2;
            table.seats = 4;
            //Act
            gameTableDB.Insert(table);
            table = gameTableDB.GetGameTableByTableName("TestTable");
            GameTable gameTable = GameTableConverter.ConvertFromGameTableModelToGameTable(table);
            gameTable.Users.Add(CGUserConverter.convertFromCGUserModelToCGUser(cgUserDB.GetById("Test")));
            CGUserModel testUser = cgUserDB.GetById("Test");
            cgUserDB.UpdateUserTableId(testUser, table.Id);
            List<CGUserModel> foundUser = cgUserDB.GetUserByTableId(table.Id);
            Assert.AreEqual(testUser.UserName, foundUser[0].UserName);
            gameTableDB.Delete(table);
                
        }
        
    }
}