using Server.DataContracts.DataContracts;
using Server.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Converters.DataContractConverters {
    class DeckConverter {
        public static DeckModel ConvertFromDeckToDeckModel(Deck deck) {
            DeckModel deckModel = new DeckModel() {
                Id = deck.Id,
                DeckName = deck.DeckName
            };
            return deckModel;
        }
    }
}
