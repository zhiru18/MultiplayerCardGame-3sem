﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.Model.Model;

namespace Server.Services.GameTableManagementService.Contracts {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IGameTableManagementService {
        [OperationContract]
        GameTable CreateGameTable(CGUser user, string tableName);

        [OperationContract]
        void DeleteGameTable(int id);
    }
}