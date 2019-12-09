using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopGameClient.Models;
using DesktopGameClient.ServiceAcces;

namespace DesktopGameClient.Controllers {
    public class GameTableController {

        GameTableServiceAccess gameTableAccess = new GameTableServiceAccess();

        public List<GameTableModel> GetAll() {
            return gameTableAccess.GetAll();
        }

        public GameTableModel GetById(int tableId) {
            return gameTableAccess.GetById(tableId);
        }

        public bool Delete(int tableId) {
            return gameTableAccess.Delete(tableId);
        }
        public GameTableModel CreateGameTable(CGUserModel userModel, string tableName) {
            return gameTableAccess.CreateGameTable(userModel, tableName);
        }
    }
}
