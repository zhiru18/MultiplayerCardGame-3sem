using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Controllers.Controller;
using Server.Converters.DataContractConverters;
using Server.Data.Data;
using Server.DataContracts.DataContracts;
using Server.Model.Model;
using Server.Services.UserManagementService;

namespace Tests.GameControllerTest {
    [TestClass]
    public class GameControllerTest {
        [TestMethod]
        public void ShuffleDeckTest() {
            //Arrange
            GameController gameController = new GameController();
            Deck deck = new Deck();
            Card card1 = new Card(Card.CardType.ATTACK, "Attack", "Attack", 10);
            Card card2 = new Card(Card.CardType.ATTACK, "Attack", "Attack", 10);
            Card card3 = new Card(Card.CardType.ATTACK, "Attack", "Attack", 10);
            Card card4 = new Card(Card.CardType.ATTACK, "Attack", "Attack", 10);
            Card card5 = new Card(Card.CardType.ATTACK, "Attack", "Attack", 10);
            Card card6 = new Card(Card.CardType.ATTACK, "Attack", "Attack", 10);
            Card card7 = new Card(Card.CardType.ATTACK, "Attack", "Attack", 10);
            Card card8 = new Card(Card.CardType.ATTACK, "Attack", "Attack", 10);
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
            //Act
            testDeck = gameController.ShuffleDeck(deck);
            //Assert
            foreach(Card c1 in deck.cards) {
                foreach(Card c2 in testDeck.cards) {
                    Assert.AreNotEqual(c2, c1);
                }
            }
        }

        [TestMethod]
        public void DealCardsTest() {
            //Arrange
            GameController gameController = new GameController();
            ICGUserDBIF cGUserDB = new CGUserDB();
            IDeckDBIF deckDB = new DeckDB();
            ICardDBIF cardDB = new CardDB();
            UserManagement userManagement = new UserManagement();
            List<CardModel> cardModels = (List<CardModel>)cardDB.GetAll();
            List<Card> cards = CardConverter.ConvertFromListOfCardModelToListOfCard(cardModels);
            Deck deck = DeckConverter.ConvertFromDeckModelToDeck(deckDB.GetById(2));
            List<CGUser> users = new List<CGUser>();
            CGUser user = CGUserConverter.convertFromCGUserModelToCGUser(cGUserDB.GetById("Test"));
            users.Add(user);
            userManagement.DeleteHand(user);
            //Act
            gameController.DealCards(deck, users);
            List<Card> userCards = user.cards;
            //Assert
            Assert.IsTrue(userCards.Count >0);
            //Cleanup
            userManagement.DeleteHand(user);
        }

        [TestMethod]
        public void CreateGameTest() {
            //Arrange
            GameController gameController = new GameController();
            IGameDBIF gameDB = new GameDB();
            IGameTableDBIF gameTableDB = new GameTableDB();
            List<GameTableModel> gameTables = (List<GameTableModel>)gameTableDB.GetAll();
            GameTableModel gameTable = null;
            bool found = false;
            Game game = new Game();
            //Act
            if (gameTables.Count > 0) {
                for (int i = 0; i < gameTables.Count && !found; i++) {
                    if (gameController.GetByTableId(gameTables[i].Id) == null) {
                        gameTable = gameTables[i];
                        found = true;
                    }
                }
                game.gameTable = GameTableConverter.ConvertFromGameTableModelToGameTable(gameTable);
                gameController.CreateGame(game);
            }
            GameModel gameModel = gameController.GetByTableId(gameTable.Id);
            //Assert
            Assert.IsNotNull(gameModel);
            //Cleanup
            gameDB.Delete(gameModel);
        }
        [TestMethod]
        public void StartGameTest() {
            //Arrange
            GameController gameController = new GameController();
            IGameDBIF gameDB = new GameDB();
            IDeckDBIF deckDb = new DeckDB();
            ICGUserDBIF userDB = new CGUserDB();
            IGameTableDBIF gameTableDB = new GameTableDB();
            List<GameModel> games = (List<GameModel>)gameDB.GetAll();
            List<CGUser> users = CGUserConverter.ConvertFromListOfCGUserModelToListOfCGUser((List<CGUserModel>)userDB.GetAll());
            GameTable gameTable = new GameTable {
                Deck = DeckConverter.ConvertFromDeckModelToDeck(deckDb.GetById(2)),
                seats = 4,
                TableName = "TestTable",
            };
            if (users.Count > 4) {
                for (int i = 0; i < 4; i++) {
                    gameTable.Users.Add(users[i]);
                }
            }
            gameTableDB.Insert(GameTableConverter.ConvertFromGameTableToGameTableModel(gameTable));
            gameTable = GameTableConverter.ConvertFromGameTableModelToGameTable(gameTableDB.GetGameTableByTableName("TestTable"));

            //Act
            gameController.StartGame(gameTable);
            List<GameModel> games2 = (List<GameModel>)gameDB.GetAll();
            //Assert
            Assert.AreNotEqual(games.Count, games2.Count);
            //Cleanup
            gameDB.Delete(gameDB.GetByTableId(gameTable.Id));
            gameTableDB.Delete(GameTableConverter.ConvertFromGameTableToGameTableModel(gameTable));
        }
    }
}
