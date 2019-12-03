using System;
using System.Collections.Generic;
using WebGameClient.GameServiceReference;

namespace WebGameClient.ServiceAcces {
    internal class GameModelConverter {
        internal static GameServiceReference.GameTable ConvertFromClientGameTableToServiceGameTable(Models.GameTable clientGameTable) {
            GameServiceReference.GameTable serviceGameTable = new GameServiceReference.GameTable() {
                Id = clientGameTable.Id,
                TableName = clientGameTable.TableName,
                Users = ConvertFromClientListOfUsersToServiceListOfUsers(clientGameTable.Users),
                Deck = ConvertFromClientDeckToServiceDeck(clientGameTable.Deck)
            };
            return serviceGameTable;
        }

        private static GameServiceReference.Deck ConvertFromClientDeckToServiceDeck(Models.Deck clientDeck) {
            GameServiceReference.Deck serviceDeck = new GameServiceReference.Deck() {
                Id = clientDeck.Id,
                DeckName = clientDeck.Name,
                cards = ConvertFromListOfClientCardsToListOfServiceCards(clientDeck.cards)
            };
            return serviceDeck;
        }

        internal static Models.Game ConvertFromServiceGameToClientGame(GameServiceReference.Game serviceGame) {
            Models.Game clientGame = new Models.Game() {
                Id = serviceGame.Id,
                gameTable = ConvertFromServiceGameTableToClientGameTable(serviceGame.gameTable)
            };
            return clientGame;
        }

        internal static GameServiceReference.Game ConvertFromClientGameToServiceGame(Models.Game clientGame) {
            GameServiceReference.Game serviceGame = new GameServiceReference.Game() {
                Id = clientGame.Id,
                gameTable = ConvertFromClientGameTableToServiceGameTable(clientGame.gameTable)
            };
            return serviceGame;
        }

        private static Models.GameTable ConvertFromServiceGameTableToClientGameTable(GameServiceReference.GameTable serviceGameTable) {
            Models.GameTable clientGameTable = new Models.GameTable() {
                Id = serviceGameTable.Id,
                TableName = serviceGameTable.TableName,
                Users = ConvertFromServiceListOfUsersToClientListOfUsers(serviceGameTable.Users),
                Deck = (Models.Deck)ConvertFromServiceDeckToClientDeck(serviceGameTable.Deck)
            };
            return clientGameTable;
        }

        private static object ConvertFromServiceDeckToClientDeck(Deck serviceDeck) {
            Models.Deck clientDeck = new Models.Deck() {
                Id = serviceDeck.Id,
                Name = serviceDeck.DeckName,
                cards = ConvertFromListOfServiceCardsToListOfClientCards(serviceDeck.cards)
            };
            return clientDeck;
        }

        private static List<Models.CGUser> ConvertFromServiceListOfUsersToClientListOfUsers(GameServiceReference.CGUser[] serviceUsers) {
            List<Models.CGUser> clientUsers = new List<Models.CGUser>();
            for(int i = 0; i < serviceUsers.Length; i++) {
                Models.CGUser clientUser = ConvertFromServiceUserToClientUser(serviceUsers[i]);
                clientUsers.Add(clientUser);
            }
            return clientUsers;
        }

        private static Models.CGUser ConvertFromServiceUserToClientUser(GameServiceReference.CGUser serviceUser) {
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

        private static List<Models.Card> ConvertFromListOfServiceCardsToListOfClientCards(GameServiceReference.Card[] serviceCards) {
            List<Models.Card> clientCards = new List<Models.Card>();
            for(int i = 0; i < serviceCards.Length; i++) {
                Models.Card clientCard = ConvertFromServiceCardToClientCard(serviceCards[i]);
                clientCards.Add(clientCard);
            }
            return clientCards;
        }

        private static Models.Card ConvertFromServiceCardToClientCard(GameServiceReference.Card serviceCard) {
            Models.Card clientCard = new Models.Card() {
                Id = serviceCard.Id,
                cardtype = (Models.Card.CardType)serviceCard.cardtype,
                Name = serviceCard.Name,
                Description = serviceCard.Description,
                Value = serviceCard.Value
            };
            return clientCard;
        }

        internal static GameServiceReference.CGUser[] ConvertFromClientListOfUsersToServiceListOfUsers(List<Models.CGUser> clientUsers) {
            GameServiceReference.CGUser[] serviceUsers = new GameServiceReference.CGUser[clientUsers.Count];
            for(int i=0; i < clientUsers.Count;i++) {
                GameServiceReference.CGUser serviceUser = ConvertFromClientUserToServiceUser(clientUsers[i]);
                serviceUsers[i] = serviceUser;
            }
            return serviceUsers;
        }

        private static GameServiceReference.CGUser ConvertFromClientUserToServiceUser(Models.CGUser clientUser) {
            GameServiceReference.CGUser serviceUser = new GameServiceReference.CGUser() {
                Id = clientUser.Id,
                UserName = clientUser.UserName,
                Email = clientUser.Email,
                userType = (GameServiceReference.CGUser.UserType)clientUser.userType,
                userStatus = (GameServiceReference.CGUser.UserStatus)clientUser.userStatus,
                Health = clientUser.Health,
                cards = ConvertFromListOfClientCardsToListOfServiceCards(clientUser.cards)
            };
            return serviceUser;
        }

        private static GameServiceReference.Card[] ConvertFromListOfClientCardsToListOfServiceCards(List<Models.Card> clientCards) {
            GameServiceReference.Card[] serviceCards = new GameServiceReference.Card[clientCards.Count];
            for(int i = 0; i < clientCards.Count; i++) {
                GameServiceReference.Card serviceCard = ConvertFromClientCardToServiceCard(clientCards[i]);
                serviceCards[i] = serviceCard;
            }
            return serviceCards;
        }

        private static GameServiceReference.Card ConvertFromClientCardToServiceCard(Models.Card clientCard) {
            GameServiceReference.Card serviceCard = new GameServiceReference.Card() {
                Id = clientCard.Id,
                cardtype = (GameServiceReference.Card.CardType)clientCard.cardtype,
                Name = clientCard.Name,
                Description = clientCard.Description,
                Value = clientCard.Value
            };
            return serviceCard;
        }
    }
}