using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGameClient.Models
{
    public class Card
    {

        public enum CardType { ATTACK, DEFENSE, EFFECT };
        public CardType cardtype { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }

        public Card(CardType cardType,string name, string description, int value)
        {
            this.cardtype = cardType;
            this.Name = name;
            this.Description = description;
            this.Value = value;
        }

        public Card() {
        }
    }
}