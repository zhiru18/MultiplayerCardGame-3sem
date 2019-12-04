using System;
using System.Collections.Generic;
using Server.Model.Model;
using Server.Data.Data;
using Server.DataContracts.DataContracts;
using Server.Converters.DataContractConverters;
using System.Transactions;
using Server.Services.UserManagementService;

namespace Server.Controllers.Controller {
    public class GameController {
        IGameDBIF gameDB = new GameDB();
        UserManagement userManagement = new UserManagement(); 
        public Game StartGame(GameTable gameTable) {
            Game game = null;
            //foreach (CGUser user in gameTable.Users) {
            //    if (user.cards.Count > 0)
            //        userManagement.DeleteHand(user);
            //}
           GameModel gameModel = gameDB.GetByTableId(gameTable.Id);
            if (gameModel != null) {
                game = GameConverter.ConvertFromGameModelToGame(gameModel);
            }
            if (game == null) {
                    gameTable.Deck = ShuffleDeck(gameTable.Deck);
                    DealCards(gameTable.Deck, gameTable.Users);
                    game = new Game(gameTable);
                    CreateGame(game);
            }
            return game;
        }

        public Deck ShuffleDeck(Deck inputDeck) {
            Deck outputDeck = new Deck();
            Random random = new Random();
            int randomIndex = 0;
            while (inputDeck.cards.Count > 0) {
                //random tager et tilfældigt index som ligger imellem start og slut af listen cards. Altså den vælger et random object i listen. 
                randomIndex = random.Next(0, inputDeck.cards.Count);
                //Objektet randomIndex bliver tilføjet til outputDecket. 
                outputDeck.cards.Add(inputDeck.cards[randomIndex]);
                //fjerner objektet igen fra inputlisten. 
                inputDeck.cards.RemoveAt(randomIndex);
            }
            return outputDeck;
        }

        public void DealCards(Deck deck, List<CGUser> users) {
            List<Card> dealtCards = new List<Card>();
            foreach (CGUser user in users) {
                for (int i = 0; i < 5; i++) {
                    Card card = deck.cards[0];
                    dealtCards.Add(card);
                    deck.cards.Remove(card);
                }
                user.cards.AddRange(dealtCards);
                userManagement.SaveHand(user.cards, user);
                dealtCards.Clear();
            }

        }
        public void CreateGame(Game game) {
            GameModel gameModel = new GameModel() {
                GameTableId = game.gameTable.Id
            };
            gameDB.Insert(gameModel);
        }

        public GameModel GetByTableId(int tableId) {
            IGameDBIF gameDB = new GameDB();
            return gameDB.GetByTableId(tableId);
        }
        //Update deck method??

        //update game method??
    }
}
