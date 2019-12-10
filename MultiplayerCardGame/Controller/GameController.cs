using System;
using System.Collections.Generic;
using Server.Model.Model;
using Server.Data.Data;
using Server.DataContracts.DataContracts;
using Server.Converters.DataContractConverters;
using System.Transactions;
using Server.Services.UserManagementService;

namespace Server.Controllers.Controller {
    /* This class implements the logic for the GameService,
     * such as shuffling the deck and dealing cards to the players
     * when a game is started
     */
    public class GameController {
        IGameDBIF gameDB = new GameDB();
        UserManagement userManagement = new UserManagement(); 
        public Game StartGame(GameTable gameTable) {
            Game game = null;

           GameModel gameModel = gameDB.GetByTableId(gameTable.Id);
            if (gameModel != null) {
                game = GameConverter.ConvertFromGameModelToGame(gameModel);
            }
            if (game == null) {
                foreach (CGUser user in gameTable.Users) {
                    userManagement.DeleteHand(user);
                    user.cards.Clear();
                }
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
                randomIndex = random.Next(0, inputDeck.cards.Count); 
                outputDeck.cards.Add(inputDeck.cards[randomIndex]); 
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
    }
}
