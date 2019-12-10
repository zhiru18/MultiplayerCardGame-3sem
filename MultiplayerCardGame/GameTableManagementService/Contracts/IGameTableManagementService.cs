using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.Model.Model;
using Server.DataContracts.DataContracts;

namespace Server.Services.GameTableManagementService.Contracts {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IGameTableManagementService {
        [OperationContract]
        GameTable CreateGameTable(CGUser user, string tableName);

        [OperationContract]
        bool DeleteGameTable(int id);
        [OperationContract]
        GameTable GetGameTableById(int id);
        [OperationContract]
        IEnumerable<GameTable> GetAll();
        [OperationContract]
        GameTable GetGameTableByTableName(string name);
        [OperationContract]
        GameTable JoinGameTable(CGUser user, GameTable table);
        [OperationContract]
        void UpdateGameTableSeats(GameTable gameTable, int amount);
    }
}
