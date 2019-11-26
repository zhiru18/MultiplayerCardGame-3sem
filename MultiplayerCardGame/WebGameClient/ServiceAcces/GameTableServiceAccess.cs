using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGameClient.GameTableServiceReference;


namespace WebGameClient.ServiceAcces {
    public class GameTableServiceAccess {

        public Models.GameTable GetGameTable(int id) {
            using(GameTableManagementServiceClient proxy = new GameTableManagementServiceClient()) {
                GameTableServiceReference.GameTable serviceGameTable = proxy.GetGameTableById(id);
                Models.GameTable clientGameTable = GameTableModelConverter.ConvertFromServiceGameTableToClientGameTable(serviceGameTable);
                return clientGameTable;
            }
        }

        public Models.GameTable CreateGameTable(Models.CGUser user, string tableName) {
            using(GameTableManagementServiceClient proxy = new GameTableManagementServiceClient()) {
                GameTableServiceReference.CGUser serviceUser = GameTableModelConverter.ConvertFromClientUserToServiceUser(user);
                GameTableServiceReference.GameTable serviceGameTable = proxy.CreateGameTable(serviceUser, tableName);
                Models.GameTable clientGameTable = GameTableModelConverter.ConvertFromServiceGameTableToClientGameTable(serviceGameTable);
                return clientGameTable;
            }
        }

        public bool DeleteGameTable(int id) {
            using(GameTableManagementServiceClient proxy = new GameTableManagementServiceClient()) {
                return proxy.DeleteGameTable(id);
            }
        }
    }
}