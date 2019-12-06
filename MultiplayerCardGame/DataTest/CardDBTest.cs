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
            cardDB.Insert(testCard);
            List<CardModel> cardList = (List<CardModel>)cardDB.GetAll();
            cardDB.Delete(testCard);
            List<CardModel> updatedCardList = (List<CardModel>)cardDB.GetAll();
            Assert.IsTrue(cardList.Count > updatedCardList.Count);
        }

        //[TestMethod]
        //public void GetCardsByDeckIdTest() {
        //    cardDB = new CardDB();
        //    List<CardModel> cardList = (List<CardModel>)cardDB.GetCardsByDeckId(2);
        //}
        // TODO: Fix this method.
        //[TestMethod]
        //public void UpdateTest()
        //{
        //    cardDB = new CardDB();
        //    var testCard = new Card(Card.CardType.DEFENSE, "Attack UpdateTest card", "It can attack", 2);
        //    Card compareCard = null;
        //    cardDB.Insert(testCard);
        //    testCard.Name = "Hans";
        //    cardDB.Update(testCard);
        //    List<Card> updatedCardList = (List<Card>)cardDB.GetAll();
        //    foreach (var card in updatedCardList) {
        //        if (card.Name == testCard.Name) {
        //            compareCard = card;
        //        }
        //    }
        //    Assert.AreEqual(testCard.Name, compareCard.Name);
        //}
    }
}
