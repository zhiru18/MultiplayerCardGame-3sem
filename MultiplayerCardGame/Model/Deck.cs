using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model.Model {
    public class Deck {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Card> cards { get; set; }

        public Deck() {
            cards = new List<Card>();
        }
    }
}
