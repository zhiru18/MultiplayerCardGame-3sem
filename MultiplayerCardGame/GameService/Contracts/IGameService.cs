using Server.DataContracts.DataContracts;
using Server.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server.Services.GameService.Contracts {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGameService" in both code and config file together.
    [ServiceContract]
    public interface IGameService {
        [OperationContract]
        Game StartGame(GameTable gameTable);

        [OperationContract]
        void CreateGame(Game game);

        [OperationContract]
        Game GetByTableId(int tableId);
    }
}
