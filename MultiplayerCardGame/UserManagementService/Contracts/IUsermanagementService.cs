using Server.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.DataContracts.DataContracts;

namespace Server.Services.UserManagementService.Contracts
{
   
    [ServiceContract]
    public interface IUserManagementService {

       [OperationContract]
        void CreateUser(string id, string email, string userName);
        [OperationContract]
        CGUser GetUserByUserId(string id);
        [OperationContract]
        void UpdateUser(CGUser cguser);

        void UpdateUserTableId(CGUser cgUser, int tableId);

        void SaveHand(List<Card> cards, CGUser user);

        [OperationContract]
        bool DeleteCGUser(CGUser user);

        [OperationContract]
        IEnumerable<CGUser> GetAll();
        [OperationContract]
        void DeleteHand(CGUser user);
        [OperationContract]
        CGUser GetCGUserByUserName(string userName);
    }
}
