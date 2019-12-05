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
    }
}
