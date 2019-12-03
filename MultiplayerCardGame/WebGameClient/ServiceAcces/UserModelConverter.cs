using System;
using System.Collections.Generic;
using WebGameClient.UserManagementServiceReference;
using WebGameClient.Models;

namespace WebGameClient.ServiceAcces {
    internal class UserModelModelConverter {
       

        internal static Models.CGUser ConvertFromServiceUserToClientUser(UserManagementServiceReference.CGUser serviceUser) {
            Models.CGUser clientUser = new Models.CGUser() {
                Id = serviceUser.Id,
                UserName = serviceUser.UserName,
                Email = serviceUser.Email,
                userType = (Models.CGUser.UserType)serviceUser.userType,
                userStatus = (Models.CGUser.UserStatus)serviceUser.userStatus,
                Health = serviceUser.Health,
            };
            if (serviceUser.cards != null) {
                clientUser.cards = ConvertFromListOfServiceCardsToListOfClientCards(serviceUser.cards);
            }
            return clientUser;
        }

        private static List<Models.Card> ConvertFromListOfServiceCardsToListOfClientCards(UserManagementServiceReference.Card[] serviceCards) {
            List<Models.Card> clientCards = new List<Models.Card>();
            for (int i = 0; i < serviceCards.Length; i++) {
                Models.Card clientCard = ConvertFromServiceCardToClientCard(serviceCards[i]);
                clientCards.Add(clientCard);
            }
            return clientCards;
        }

        private static Models.Card ConvertFromServiceCardToClientCard(UserManagementServiceReference.Card serviceCard) {
            Models.Card clientCard = new Models.Card() {
                Id = serviceCard.Id,
                cardtype = (Models.Card.CardType)serviceCard.cardtype,
                Name = serviceCard.Name,
                Description = serviceCard.Description,
                Value = serviceCard.Value
            };
            return clientCard;
        }

        
        private static UserManagementServiceReference.CGUser ConvertFromClientUserToServiceUser(Models.CGUser clientUser) {
            UserManagementServiceReference.CGUser serviceUser = new UserManagementServiceReference.CGUser() {
                Id = clientUser.Id,
                UserName = clientUser.UserName,
                Email = clientUser.Email,
                userType = (UserManagementServiceReference.CGUser.UserType)clientUser.userType,
                userStatus = (UserManagementServiceReference.CGUser.UserStatus)clientUser.userStatus,
                Health = clientUser.Health,
                cards = ConvertFromListOfClientCardsToListOfServiceCards(clientUser.cards)
            };
            return serviceUser;
        }

        private static UserManagementServiceReference.Card[] ConvertFromListOfClientCardsToListOfServiceCards(List<Models.Card> clientCards) {
            UserManagementServiceReference.Card[] serviceCards = new UserManagementServiceReference.Card[clientCards.Count];
            for (int i = 0; i < clientCards.Count; i++) {
                UserManagementServiceReference.Card serviceCard = ConvertFromClientCardToServiceCard(clientCards[i]);
                serviceCards[i] = serviceCard;
            }
            return serviceCards;
        }

        private static UserManagementServiceReference.Card ConvertFromClientCardToServiceCard(Models.Card clientCard) {
            UserManagementServiceReference.Card serviceCard = new UserManagementServiceReference.Card() {
                Id = clientCard.Id,
                cardtype = (UserManagementServiceReference.Card.CardType)clientCard.cardtype,
                Name = clientCard.Name,
                Description = clientCard.Description,
                Value = clientCard.Value
            };
            return serviceCard;
        }
    }
}