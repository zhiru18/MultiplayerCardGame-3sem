using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGameClient.Models {
    public class Deck {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Card> cards { get; set; }

        public Deck(string name) {
            this.Name = name;
            cards = new List<Card>();
        }

        public Deck() {
        }
    }
}