using Server.Data.Data;
using Server.DataContracts.DataContracts;
using Server.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Converters.DataContractConverters {
    /*This class converts DeckModel objects to the equivalent datacontract 
     * and vice versa
     */
    public class DeckConverter {
        public static DeckModel ConvertFromDeckToDeckModel(Deck deck) {
            DeckModel deckModel = new DeckModel() {
                Id = deck.Id,
                DeckName = deck.DeckName
            };
            return deckModel;
        }

        public static Deck ConvertFromDeckModelToDeck(DeckModel deckModel) {
            ICardDBIF cardDB = new CardDB();
            List<CardModel> deckCards = cardDB.GetCardsByDeckId(deckModel.Id);
            Deck deck = new Deck() {
                Id = deckModel.Id,
                DeckName = deckModel.DeckName,
                cards = CardConverter.ConvertFromListOfCardModelToListOfCard(deckCards)
            };
            return deck;
        }
    }
}
