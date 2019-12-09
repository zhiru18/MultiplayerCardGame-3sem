using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Data.Data;
using Server.Model.Model;

namespace Tests.DataTest
{
    [TestClass]
    public class CardDBTest
    {
        CardDB cardDB;

        [TestMethod]
        public void GetAllTest()
        {
            cardDB = new CardDB();
            List<CardModel> cards = (List<CardModel>)cardDB.GetAll();
            Assert.IsTrue(cards.Count > 0);
        }
        [TestMethod]
        public void InsertTest()
        {
            cardDB = new CardDB();
            List<CardModel> cardList = (List<CardModel>)cardDB.GetAll();
            var testCard = new CardModel(CardModel.CardType.ATTACK, "Attack card", "It can attack", 10);
            cardDB.Insert(testCard);
            List<CardModel> updatedCardList = (List<CardModel>)cardDB.GetAll();
            Assert.IsTrue(cardList.Count < updatedCardList.Count);
        }
        [TestMethod]
        public void DeleteTest()
        {
            cardDB = new CardDB();
            var testCard = new CardModel(CardModel.CardType.ATTACK, "Attack DeleteTest card", "It can attack", 10);
            testCard.Id = cardDB.InsertWithIdentity(testCard);
            List<CardModel> cardList = (List<CardModel>)cardDB.GetAll();
            cardDB.Delete(testCard);
            List<CardModel> updatedCardList = (List<CardModel>)cardDB.GetAll();
            Assert.IsTrue(cardList.Count > updatedCardList.Count);
        }

        [TestMethod]
        public void GetCardsByDeckIdTest() {
           cardDB = new CardDB();
           List<CardModel> cardList = (List<CardModel>)cardDB.GetCardsByDeckId(2);
            Assert.IsTrue(cardList.Count > 0);
        }

        [TestMethod]
        public void GetCardsByUserIdTest() {
            cardDB = new CardDB();
            var testCard1 = new CardModel(CardModel.CardType.DEFENSE, "Attack UpdateTest card", "It can attack", 2);
            var testCard2 = new CardModel(CardModel.CardType.DEFENSE, "Attack UpdateTest card", "It can attack", 2);
            var testCard3 = new CardModel(CardModel.CardType.DEFENSE, "Attack UpdateTest card", "It can attack", 2);
            var testCard4 = new CardModel(CardModel.CardType.DEFENSE, "Attack UpdateTest card", "It can attack", 2);
            var testCard5 = new CardModel(CardModel.CardType.DEFENSE, "Attack UpdateTest card", "It can attack", 2);
            testCard1.Id = cardDB.InsertWithIdentity(testCard1);
            testCard2.Id = cardDB.InsertWithIdentity(testCard2);
            testCard3.Id = cardDB.InsertWithIdentity(testCard3);
            testCard4.Id = cardDB.InsertWithIdentity(testCard4);
            testCard5.Id = cardDB.InsertWithIdentity(testCard5);
            List<CardModel> cards = new List<CardModel>() { testCard1, testCard2, testCard3, testCard4, testCard5};
            ICGUserDBIF userDB = new CGUserDB();
            CGUserModel user = userDB.GetById("Test");
            userDB.InsertHand(cards, user);
            List<CardModel> cardList = (List<CardModel>)cardDB.GetCardsByUserId("Test");
            Assert.IsTrue(cardList.Count > 0);
            userDB.DeleteHand(user);
            cardDB.Delete(testCard1);
            cardDB.Delete(testCard2);
            cardDB.Delete(testCard3);
            cardDB.Delete(testCard4);
            cardDB.Delete(testCard5);
        }

       [TestMethod]
        public void UpdateTest() {
            cardDB = new CardDB();
            var testCard = new CardModel(CardModel.CardType.DEFENSE, "Attack UpdateTest card", "It can attack", 2);
            CardModel compareCard = null;
            testCard.Id = cardDB.InsertWithIdentity(testCard);
            testCard.Name = "Hans";
            cardDB.Update(testCard);
            List<CardModel> updatedCardList = (List<CardModel>)cardDB.GetAll();
            foreach (var card in updatedCardList) {
                if (card.Name == testCard.Name) {
                    compareCard = card;
                }
            }
            Assert.AreEqual(testCard.Name, compareCard.Name);
        }
    }
}
