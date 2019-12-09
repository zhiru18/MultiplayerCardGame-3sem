using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopGameClient.GameTableServiceReference;
using DesktopGameClient.Models;

namespace DesktopGameClient.ServiceAcces {
    public class GameTableServiceAccess {
        public List<GameTableModel> GetAll() {
            using (GameTableManagementServiceClient proxy = new GameTableManagementServiceClient()) {
                var serviceGameTables = proxy.GetAll();
                List<Models.GameTableModel> clientGameTables = GameTableModelConverter.ConvertFromServiceGameTablesToClientGameTables(serviceGameTables);
                return clientGameTables;
            }
        }

        public  GameTableModel GetById(int tableId) {
            using (GameTableManagementServiceClient proxy = new GameTableManagementServiceClient()) {
                var serviceGameTable = proxy.GetGameTableById(tableId);
                Models.GameTableModel clientGameTable = GameTableModelConverter.ConvertFromServiceGameTableToClientGameTable(serviceGameTable);
                return clientGameTable;
            }
        }

        public bool Delete(int tableId) {
            using (GameTableManagementServiceClient proxy = new GameTableManagementServiceClient()) {
                return proxy.DeleteGameTable(tableId);
            }
        }
        public GameTableModel CreateGameTable(CGUserModel userModel, string tableName) {
            using (GameTableManagementServiceClient proxy = new GameTableManagementServiceClient()) {
                GameTableModel tableModel = null;
                CGUser user = GameTableModelConverter. ConvertFromClientUserToServiceUser(userModel);
                tableModel = GameTableModelConverter.ConvertFromServiceGameTableToClientGameTable(proxy.CreateGameTable(user, tableName));
                return tableModel;
            }
        }
    }
}
