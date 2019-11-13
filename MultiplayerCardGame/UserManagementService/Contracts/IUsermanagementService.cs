using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server.Services.UserManagementService.Contracts
{
   
    [ServiceContract]
    public interface IUserManagementService {

       [OperationContract]
        void CreateUser(string id);

    }
}
