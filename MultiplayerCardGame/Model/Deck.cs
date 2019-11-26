using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model.Model {
    [DataContract]
    public class Deck {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string DeckName { get; set; }
        [DataMember]
        public List<Card> cards { get; set; }

        public Deck() {
            cards = new List<Card>();
        }
        public Deck(int id, string deckName, List<Card> cards) {
            this.Id = id;
            this.DeckName = deckName;
            this.cards = cards;
        }
    }
}
