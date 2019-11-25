using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.Data.Data;
using Server.Model.Model;
using Server.Services.GameTableManagementService.Contracts;

namespace Server.Services.GameTableManagementService {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class GameTableManagement : IGameTableManagementService {
        IGameTableDBIF gameTablerDB = new GameTableDB();
        public GameTable CreateGameTable(CGUser user, string tableName) {
            GameTable table = new GameTable(tableName);
            table.Users.Add(user);
            gameTablerDB.Insert(table);
            return table;
        }

        public void DeleteGameTable(int id) {
            GameTable table = gameTablerDB.GetById(id);
            gameTablerDB.Delete(table);
        }
    }
}
