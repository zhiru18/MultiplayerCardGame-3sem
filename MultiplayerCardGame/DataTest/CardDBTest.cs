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
            List<Card> cards = (List<Card>)cardDB.GetAll();
            Assert.IsTrue(cards.Count > 0);
        }
        [TestMethod]
        public void InsertTest()
        {
            cardDB = new CardDB();
            List<Card> cardList = (List<Card>)cardDB.GetAll();
            var testCard = new Card(Card.CardType.ATTACK, "Attack card", "It can attack", 10);
            cardDB.Insert(testCard);
            List<Card> updatedCardList = (List<Card>)cardDB.GetAll();
            Assert.IsTrue(cardList.Count < updatedCardList.Count);
        }
        [TestMethod]
        public void DeleteTest()
        {
            cardDB = new CardDB();
            List<Card> cardList = (List<Card>)cardDB.GetAll();
            var testCard = new Card(Card.CardType.ATTACK, "Attack DeleteTest card", "It can attack", 10);
            cardDB.Delete(testCard);
            List<Card> updatedCardList = (List<Card>)cardDB.GetAll();
            Assert.IsTrue(cardList.Count > updatedCardList.Count);
        }
        [TestMethod]
        public void UpdateTest()
        {
            cardDB = new CardDB();
            var testCard = new Card(Card.CardType.DEFENSE, "Attack UpdateTest card", "It can attack", 2);
            cardDB.Update(testCard);
            List<Card> updatedCardList = (List<Card>)cardDB.GetAll();
            Assert.AreNotEqual(testCard.cardtype, updatedCardList[updatedCardList.IndexOf(testCard)].cardtype);
        }
    }
}
