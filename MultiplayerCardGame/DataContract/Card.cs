using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server.DataContracts.DataContracts {
    [DataContract]
    public class Card {
        [DataContract]
        public enum CardType {
            [EnumMember]
            ATTACK, 
            [EnumMember]
            DEFENSE, 
            [EnumMember]
            EFFECT}; 
        [DataMember]
        public CardType cardtype { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int Value { get; set; }

        public Card(CardType cardType, string name, string description, int value) {
            this.cardtype = cardType;
            this.Name = name;
            this.Description = description;
            this.Value = value;
        }

        public Card() {
        }
    }
}
