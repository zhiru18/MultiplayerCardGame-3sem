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

        internal Models.GameTable GetGameTable(int gameTableId) {
            throw new NotImplementedException();
        }
    }
}