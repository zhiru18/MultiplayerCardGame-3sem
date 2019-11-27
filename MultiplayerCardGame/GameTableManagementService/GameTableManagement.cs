using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.Data.Data;
using Server.Model.Model;
using Server.Services.GameTableManagementService.Contracts;
using Server.Services.UserManagementService;

namespace Server.Services.GameTableManagementService {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class GameTableManagement : IGameTableManagementService {
        IGameTableDBIF gameTableDB = new GameTableDB();
        UserManagement userManagement = new UserManagement();
        public GameTable CreateGameTable(CGUser user, string tableName) {
            GameTable table = new GameTable(tableName);
            table.Users.Add(user);
            gameTableDB.Insert(table);
            return table;
        }

        public bool DeleteGameTable(int id) {
            bool res = false;
            GameTable table = gameTableDB.GetById(id);
            if (table != null) {
                gameTableDB.Delete(table);
                res = true;
            }
            return res;
        }

        public GameTable GetGameTableById(int id) {
            return gameTableDB.GetById(id);
        }

        public GameTable JoinGameTable(CGUser user, GameTable table) {
            userManagement.UpdateUserTableId(user, table.Id);
            table.Users.Add(user);
            if (table.Users.Count == 4) {
                table.IsFull = true;
            }
            return table;
        }
    }
}
