using Server.DataContracts.DataContracts;
using Server.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Converters.DataContractConverters {
    public class CardConverter {
        public static CardModel ConvertFromCardToCardModel(Card card) {
            CardModel cardModel = new CardModel() {
                cardType = (CardModel.CardType)card.cardtype,
                Id = card.Id,
                Name = card.Name,
                Description = card.Description,
                Value = card.Value,
            };
            return cardModel;
        }

        public static Card convertFromCardModelToCard(CardModel cardModel) {
            Card card = new Card() {
                cardtype = (Card.CardType)cardModel.cardType,
                Id = cardModel.Id,
                Name = cardModel.Name,
                Description = cardModel.Description,
                Value = cardModel.Value
            };
            return card;
        }

        public static List<Card> ConvertFromListOfCardModelToListOfCard(List<CardModel> userCardsModel) {
            List<Card> userCards = new List<Card>();
            foreach (CardModel cardModel in userCardsModel) {
                Card card = convertFromCardModelToCard(cardModel);
                userCards.Add(card);
            }
            return userCards;
        }
    }
}
