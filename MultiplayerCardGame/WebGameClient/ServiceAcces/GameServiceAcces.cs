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
                GameServiceReference.GameTable serviceGameTable = DataConverter.ConvertFromClientGameTableToServiceGameTable(clientGameTable);
                GameServiceReference.Game serviceGame = proxy.StartGame(serviceGameTable);
                Models.Game clientGame = DataConverter.ConvertFromServiceGameToClientGame(serviceGame);
                return clientGame;
            }
        }

        internal Models.GameTable GetGameTable(int gameTableId) {
            throw new NotImplementedException();
        }
    }
}