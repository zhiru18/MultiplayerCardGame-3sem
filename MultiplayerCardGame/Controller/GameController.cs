using System;
using System.Collections.Generic;
using Server.Model.Model;
using Server.Data.Data;

namespace Server.Controllers.Controller {
    public class GameController {

        public Game StartGame(GameTable gameTable) {
            gameTable.Deck = ShuffleDeck(gameTable.Deck);
            DealCards(gameTable.Deck, gameTable.Users);
            Game game = new Game(gameTable);
            CreateGame(game);
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
            int cardindex = 0;
            for (int i = 0; i < 5; i++) {
                foreach (CGUser user in users) {
                    if (i == 0 && cardindex == 0) {
                        Card card = deck.cards[cardindex];
                        user.cards.Add(card);
                        deck.cards.Remove(card);
                        cardindex++;
                    } else {
                        Card card = deck.cards[cardindex];
                        user.cards.Add(card);
                        deck.cards.Remove(card);
                        cardindex++;
                    }
                }
            }
        }
        public void CreateGame(Game game) {
            IGameDBIF gameDB = new GameDB();
            gameDB.Insert(game);
        }

        //Update deck method??

        //update game method??
    }
}
