using System;

namespace Server.Controllers.Controller {
    public class GameController {
    }

    public Deck ShuffleDeck(Deck inputDeck) {
        Deck outputDeck = new Deck();
        Random random = new Random();
        int randomIndex = 0;
        while(inputDeck.cards.count > 0) {
            //random tager et tilfældigt index som ligger imellem start og slut af listen cards. Altså den vælger et random object i listen. 
            randomIndex = random.Next(0.inputDeck.cards.count);
            //Objektet randomIndex bliver tilføjet til outputDecket. 
            outputDeck.cards.Add(inputDeck.cards[randomIndex]);
            //fjerner objektet igen fra inputlisten. 
            inputDeck.cards.RemoveAdd(randomIndex);
        }

    }
}
