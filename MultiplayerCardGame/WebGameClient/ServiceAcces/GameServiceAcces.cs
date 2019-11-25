using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGameClient.GameServiceReference;

namespace WebGameClient.ServiceAcces {
    public class GameServiceAcces {
        //der mangler en reference til gameservice som jeg ikke kan tilføje på nuværende tidpunkt
        public Game StartGame(GameTable gameTable) {
            using (GameServiceClient proxy = new GameServiceClient()) {
                Game serviceGame = proxy.StartGame(gameTable);
                Game clientGame = ConvertFromServiceToClient(serviceGame);
                return clientGame;
            }
        }

        private Game ConvertFromServiceToClient(Game serviceGame) {
            throw new NotImplementedException();
        }
    }
}