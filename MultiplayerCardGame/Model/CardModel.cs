using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model.Model {
    public class CardModel {
        public enum CardType { ATTACK, DEFENSE, EFFECT };
        public CardType cardType { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }

        public CardModel(CardType cardType, string name, string description, int value) {
            this.cardType = cardType;
            this.Name = name;
            this.Description = description;
            this.Value = value;
        }

        public CardModel() {
        }
    }
}
