using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Transactions;
using Server.Converters.DataContractConverters;
using Server.Data.Data;
using Server.DataContracts.DataContracts;
using Server.Model.Model;
using Server.Services.GameTableManagementService.Contracts;
using Server.Services.UserManagementService;

namespace Server.Services.GameTableManagementService {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class GameTableManagement : IGameTableManagementService {
        IGameTableDBIF gameTableDB = new GameTableDB();
        UserManagement userManagement = new UserManagement();
        public GameTable CreateGameTable(CGUser user, string tableName) {
            GameTableModel tableModel = new GameTableModel() {
                TableName = tableName,
                DeckId = 2, 
                IsFull = false
            };
            gameTableDB.Insert(tableModel);
            GameTable table = GameTableConverter.ConvertFromGameTableModelToGameTable(gameTableDB.GetGameTableByTableName(tableName));
            JoinGameTable(user, table);
            return table;
        }

        public bool DeleteGameTable(int id) {
            bool res = false;
            GameTable table = GameTableConverter.ConvertFromGameTableModelToGameTable(gameTableDB.GetById(id));
            if (table != null) {
                gameTableDB.Delete(GameTableConverter.ConvertFromGameTableToGameTableModel(table));
                res = true;
            }
            return res;
        }

        public IEnumerable<GameTable> GetAll() {
            return GameTableConverter.ConvertFromListOfGameTableModelToListOfGameTable((List<GameTableModel>)gameTableDB.GetAll());
        }

        public GameTable GetGameTableById(int id) {
            return GameTableConverter.ConvertFromGameTableModelToGameTable(gameTableDB.GetById(id));
        }

        public GameTable JoinGameTable(CGUser user, GameTable chosenTable) {
            GameTable databaseTable = null;
            //TODO: Add a check to see if a user is at another table, and then remove him form that table.
            try {
                using (TransactionScope scope = new TransactionScope()) {
                    databaseTable = GameTableConverter.ConvertFromGameTableModelToGameTable(gameTableDB.GetById(chosenTable.Id));
                    if (chosenTable.IsFull == databaseTable.IsFull && databaseTable.Users.Count < 4) {
                        userManagement.UpdateUserTableId(user, databaseTable.Id);
                        databaseTable.Users.Add(user);
                        if (databaseTable.Users.Count == 4) {
                            databaseTable.IsFull = true;
                            gameTableDB.Update(GameTableConverter.ConvertFromGameTableToGameTableModel(databaseTable));
                        }
                        gameTableDB.UpdateGameTableSeats(GameTableConverter.ConvertFromGameTableToGameTableModel(databaseTable), 1);
                    }
                    scope.Complete();
                }
            } catch (TransactionAbortedException tae) {

                throw;
            }
            return databaseTable;
        }

        public GameTable GetGameTableByTableName(string name) {
            return GameTableConverter.ConvertFromGameTableModelToGameTable(gameTableDB.GetGameTableByTableName(name));
        }
    }
}
