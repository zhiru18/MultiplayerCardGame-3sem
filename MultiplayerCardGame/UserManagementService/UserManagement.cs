using Server.Data.Data;
using Server.Model.Model;
using Server.Services.UserManagementService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server.Services.UserManagementService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class UserManagement : IUserManagementService {
        ICGUserDBIF cGUserDB = new CGUserDB();
        public void CreateUser(string id, string email, string userName) {
            CGUser user = new CGUser();
            user.Email = email;
            user.Id = id;
            user.UserName = userName;
            cGUserDB.Insert(user);
        }

        public CGUser GetUserByUserId(string id) {
            return cGUserDB.GetById(id);
        }

        public void UpdateUser(CGUser user) {
            cGUserDB.Update(user);
        }
    }
}
