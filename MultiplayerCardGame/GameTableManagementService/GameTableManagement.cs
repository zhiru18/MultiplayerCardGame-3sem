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
            Deck deck = new Deck();
            deck.Id = 2;
            table.Deck = deck;
            table.Users.Add(user);
            gameTableDB.Insert(table);
            GameTable table2 = gameTableDB.GetGameTableByTableName(tableName);
            return table2;
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

        public IEnumerable<GameTable> GetAll() {
            return gameTableDB.GetAll();
        }

        public GameTable GetGameTableById(int id) {
            return gameTableDB.GetById(id);
        }

        public GameTable JoinGameTable(CGUser user, GameTable chosenTable) {

                GameTable databaseTable = gameTableDB.GetById(chosenTable.Id);
                if (chosenTable.IsFull == databaseTable.IsFull && databaseTable.Users.Count < 4) {
                    userManagement.UpdateUserTableId(user, databaseTable.Id);
                    chosenTable.Users.Add(user);
                    if (databaseTable.Users.Count == 4) {
                        databaseTable.IsFull = true;
                        gameTableDB.Update(databaseTable);
                    }
                    gameTableDB.UpdateGameTableSeats(databaseTable, 1);
                } 
            return databaseTable;
        }

        public GameTable GetGameTableByTableName(string name) {
            return gameTableDB.GetGameTableByTableName(name);
        }
    }
}
