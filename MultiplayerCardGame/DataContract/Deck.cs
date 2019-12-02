using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server.DataContracts.DataContracts {
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
    }
}
