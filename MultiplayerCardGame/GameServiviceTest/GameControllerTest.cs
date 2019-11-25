using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Controllers.Controller;
using Server.Model.Model;

namespace Tests.GameControllerTest {
    [TestClass]
    public class GameControllerTest {
        [TestMethod]
        public void ShuffleDeckTest() {
            GameController gameController = new GameController();
            Deck deck = new Deck();
            Card card1 = new Card(Card.CardType.ATTACK, 1, "Attack", "Attack", 10);
            Card card2 = new Card(Card.CardType.ATTACK, 2, "Attack", "Attack", 10);
            Card card3 = new Card(Card.CardType.ATTACK, 3, "Attack", "Attack", 10);
            Card card4 = new Card(Card.CardType.ATTACK, 4, "Attack", "Attack", 10);
            Card card5 = new Card(Card.CardType.ATTACK, 5, "Attack", "Attack", 10);
            Card card6 = new Card(Card.CardType.ATTACK, 6, "Attack", "Attack", 10);
            Card card7 = new Card(Card.CardType.ATTACK, 7, "Attack", "Attack", 10);
            Card card8 = new Card(Card.CardType.ATTACK, 8, "Attack", "Attack", 10);
            deck.cards.Add(card1);
            deck.cards.Add(card2);
            deck.cards.Add(card3);
            deck.cards.Add(card4);
            deck.cards.Add(card5);
            deck.cards.Add(card6);
            deck.cards.Add(card7);
            deck.cards.Add(card8);
            List<Card> TestCards = new List<Card>();
            TestCards.Add(card1);
            TestCards.Add(card2);
            TestCards.Add(card3);
            TestCards.Add(card4);
            TestCards.Add(card5);
            TestCards.Add(card6);
            TestCards.Add(card7);
            TestCards.Add(card8);
            Deck testDeck = new Deck();

            testDeck = gameController.ShuffleDeck(deck);

            foreach(Card c1 in deck.cards) {
                foreach(Card c2 in testDeck.cards) {
                    Assert.AreNotEqual(c2, c1);
                }
            }
        }
    }
}
