using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGameClient.GameServiceReference;
using WebGameClient.Models;

namespace WebGameClient.ServiceAcces {
    public class GameServiceAcces {
        
        public Models.Game StartGame(Models.GameTable clientGameTable) {
            using (GameServiceClient proxy = new GameServiceClient()) {
                GameServiceReference.GameTable serviceGameTable = GameModelConverter.ConvertFromClientGameTableToServiceGameTable(clientGameTable);
                GameServiceReference.Game serviceGame = proxy.StartGame(serviceGameTable);
                Models.Game clientGame = GameModelConverter.ConvertFromServiceGameToClientGame(serviceGame);
                return clientGame;
            }
        }

       public void CreateGAme(Models.Game game) {
            using(GameServiceClient proxy = new GameServiceClient()) {
                GameServiceReference.Game serviceGame = GameModelConverter.ConvertFromClientGameToServiceGame(game);
                proxy.CreateGame(serviceGame);
            }
        }

        public Models.Game GetByTableId(int tableId) {
            using (GameServiceClient proxy = new GameServiceClient()) {
                GameServiceReference.Game game = proxy.GetByTableId(tableId);
                return GameModelConverter.ConvertFromServiceGameToClientGame(game);
            }
        }
    }
}