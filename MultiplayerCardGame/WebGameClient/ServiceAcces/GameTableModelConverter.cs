using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGameClient.GameTableServiceReference;
using WebGameClient.Models;

namespace WebGameClient.ServiceAcces {
    public class GameTableModelConverter {
        internal static Models.GameTable ConvertFromServiceGameTableToClientGameTable(GameTableServiceReference.GameTable serviceGameTable) {
            Models.GameTable clientGameTable = new Models.GameTable() {
                Id = serviceGameTable.Id,
                TableName = serviceGameTable.TableName,
                Users = ConvertFromServiceListOfUsersToClientListOfUsers(serviceGameTable.Users),
                Deck = (Models.Deck)ConvertFromServiceDeckToClientDeck(serviceGameTable.Deck)
            };
            return clientGameTable;
        }

        public static List<Models.GameTable> ConvertFromServiceGameTablesToClientGameTables(IEnumerable<GameTableServiceReference.GameTable> serviceGameTables) {
            List<Models.GameTable> clientGameTables = new List<Models.GameTable>();
            foreach (GameTableServiceReference.GameTable sgt in serviceGameTables) {
                Models.GameTable mgt = ConvertFromServiceGameTableToClientGameTable(sgt);
                clientGameTables.Add(mgt);
            }
            return clientGameTables;
        }
        private static Models.Deck ConvertFromServiceDeckToClientDeck(GameTableServiceReference.Deck serviceDeck) {
            Models.Deck clientDeck = new Models.Deck() {
                Id = serviceDeck.Id,
                Name = serviceDeck.DeckName,
                cards = ConvertFromListOfServiceCardsToListOfClientCards(serviceDeck.cards)
            };
            return clientDeck;
        }

        private static List<Models.CGUser> ConvertFromServiceListOfUsersToClientListOfUsers(GameTableServiceReference.CGUser[] serviceUsers) {
            List<Models.CGUser> clientUsers = new List<Models.CGUser>();
            for (int i = 0; i < serviceUsers.Length; i++) {
                Models.CGUser clientUser = ConvertFromServiceUserToClientUser(serviceUsers[i]);
                clientUsers.Add(clientUser);
            }
            return clientUsers;
        }

        public static Models.CGUser ConvertFromServiceUserToClientUser(GameTableServiceReference.CGUser serviceUser) {
            Models.CGUser clientUser = new Models.CGUser() {
                Id = serviceUser.Id,
                UserName = serviceUser.UserName,
                Email = serviceUser.Email,
                userType = (Models.CGUser.UserType)serviceUser.userType,
                userStatus = (Models.CGUser.UserStatus)serviceUser.userStatus,
                Health = serviceUser.Health,
                cards = ConvertFromListOfServiceCardsToListOfClientCards(serviceUser.cards)
            };
            return clientUser;
        }

        private static List<Models.Card> ConvertFromListOfServiceCardsToListOfClientCards(GameTableServiceReference.Card[] serviceCards) {
            List<Models.Card> clientCards = new List<Models.Card>();
            for (int i = 0; i < serviceCards.Length; i++) {
                Models.Card clientCard = ConvertFromServiceCardToClientCard(serviceCards[i]);
                clientCards.Add(clientCard);
            }
            return clientCards;
        }

        private static Models.Card ConvertFromServiceCardToClientCard(GameTableServiceReference.Card serviceCard) {
            Models.Card clientCard = new Models.Card() {
                Id = serviceCard.Id,
                cardtype = (Models.Card.CardType)serviceCard.cardtype,
                Name = serviceCard.Name,
                Description = serviceCard.Description,
                Value = serviceCard.Value
            };
            return clientCard;
        }

        internal static GameTableServiceReference.GameTable ConvertFromClientGameTableToServiceGameTable(Models.GameTable clientGameTable) {
            GameTableServiceReference.GameTable serviceGameTable = new GameTableServiceReference.GameTable() {
                Id = clientGameTable.Id,
                TableName = clientGameTable.TableName,
                Users = ConvertFromClientListOfUsersToServiceListOfUsers(clientGameTable.Users),
                Deck = ConvertFromClientDeckToServiceDeck(clientGameTable.Deck)
            };
            return serviceGameTable;
        }

        private static GameTableServiceReference.Deck ConvertFromClientDeckToServiceDeck(Models.Deck clientDeck) {
            GameTableServiceReference.Deck serviceDeck = new GameTableServiceReference.Deck() {
                Id = clientDeck.Id,
                DeckName = clientDeck.Name,
                cards = ConvertFromListOfClientCardsToListOfServiceCards(clientDeck.cards)
            };
            return serviceDeck;
        }

        private static GameTableServiceReference.CGUser[] ConvertFromClientListOfUsersToServiceListOfUsers(List<Models.CGUser> clientUsers) {
            GameTableServiceReference.CGUser[] serviceUsers = new GameTableServiceReference.CGUser[clientUsers.Count];
            for (int i = 0; i < clientUsers.Count; i++) {
                GameTableServiceReference.CGUser serviceUser = ConvertFromClientUserToServiceUser(clientUsers[i]);
                serviceUsers[i] = serviceUser;
            }
            return serviceUsers;
        }

        internal static GameTableServiceReference.CGUser ConvertFromClientUserToServiceUser(Models.CGUser clientUser) {
            GameTableServiceReference.CGUser serviceUser = new GameTableServiceReference.CGUser() {
                Id = clientUser.Id,
                UserName = clientUser.UserName,
                Email = clientUser.Email,
                userType = (GameTableServiceReference.CGUser.UserType)clientUser.userType,
                userStatus = (GameTableServiceReference.CGUser.UserStatus)clientUser.userStatus,
                Health = clientUser.Health,
                cards = ConvertFromListOfClientCardsToListOfServiceCards(clientUser.cards)
            };
            return serviceUser;
        }

        private static GameTableServiceReference.Card[] ConvertFromListOfClientCardsToListOfServiceCards(List<Models.Card> clientCards) {
            GameTableServiceReference.Card[] serviceCards = null;
            if (clientCards != null) {
                serviceCards = new GameTableServiceReference.Card[clientCards.Count];
                for (int i = 0; i < clientCards.Count; i++) {
                    GameTableServiceReference.Card serviceCard = ConvertFromClientCardToServiceCard(clientCards[i]);
                    serviceCards[i] = serviceCard;
                }
            }
            
            return serviceCards;
        }

        private static GameTableServiceReference.Card ConvertFromClientCardToServiceCard(Models.Card clientCard) {
            GameTableServiceReference.Card serviceCard = new GameTableServiceReference.Card() {
                Id = clientCard.Id,
                cardtype = (GameTableServiceReference.Card.CardType)clientCard.cardtype,
                Name = clientCard.Name,
                Description = clientCard.Description,
                Value = clientCard.Value
            };
            return serviceCard;
        }
    }
}