using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGameClient.GameTableServiceReference;
using WebGameClient.Models;

namespace WebGameClient.ServiceAcces {
    public class GameTableServiceAccess {

        public Models.GameTable GetGameTable(int id) {
            using(GameTableManagementServiceClient proxy = new GameTableManagementServiceClient()) {
                GameTableServiceReference.GameTable serviceGameTable = proxy.GetGameTableById(id);
                Models.GameTable clientGameTable = GameTableModelConverter.ConvertFromServiceGameTableToClientGameTable(serviceGameTable);
                return clientGameTable;
            }
        }

        public List<Models.GameTable> GetAll() {
            using (GameTableManagementServiceClient proxy = new GameTableManagementServiceClient()) {
                var serviceGameTables = proxy.GetAll();
                List<Models.GameTable> clientGameTables = GameTableModelConverter.ConvertFromServiceGameTablesToClientGameTables(serviceGameTables);
                return clientGameTables;
            }

        }

        public Models.GameTable GetTableByName(string tableName) {
            using (GameTableManagementServiceClient proxy = new GameTableManagementServiceClient()) {
                GameTableServiceReference.GameTable serviceGameTable = proxy.GetGameTableByTableName(tableName);
                Models.GameTable clientGameTable = GameTableModelConverter.ConvertFromServiceGameTableToClientGameTable(serviceGameTable);
                return clientGameTable;
            }
        }

        public Models.GameTable CreateGameTable(string userId, string tableName) {
            UserManagementServiceAccess userManagement = new UserManagementServiceAccess();
            Models.GameTable clientGameTable = null;
            using (GameTableManagementServiceClient proxy = new GameTableManagementServiceClient()) {
                Models.CGUser user = userManagement.GetUserByUserId(userId);
                GameTableServiceReference.CGUser serviceUser = GameTableModelConverter.ConvertFromClientUserToServiceUser(user);
                GameTableServiceReference.GameTable serviceGameTable = proxy.CreateGameTable(serviceUser, tableName);
                if (serviceGameTable != null) {
                   clientGameTable = GameTableModelConverter.ConvertFromServiceGameTableToClientGameTable(serviceGameTable);
                }
                return clientGameTable;
            }
        }

        public bool DeleteGameTable(int id) {
            using(GameTableManagementServiceClient proxy = new GameTableManagementServiceClient()) {
                return proxy.DeleteGameTable(id);
            }
        }

        public Models.GameTable JoinGameTable(string userId, int tableId) {
            UserManagementServiceAccess userManagement = new UserManagementServiceAccess();
            using (GameTableManagementServiceClient proxy = new GameTableManagementServiceClient()) {
                Models.CGUser user = userManagement.GetUserByUserId(userId);
                GameTableServiceReference.CGUser serviceUser = GameTableModelConverter.ConvertFromClientUserToServiceUser(user);
                GameTableServiceReference.GameTable serviceTable1 = proxy.GetGameTableById(tableId);
                GameTableServiceReference.GameTable serviceGameTable = proxy.JoinGameTable(serviceUser, serviceTable1);
                Models.GameTable clientGameTable = GameTableModelConverter.ConvertFromServiceGameTableToClientGameTable(serviceGameTable);
                return clientGameTable;
            }
            
        }
    }
}