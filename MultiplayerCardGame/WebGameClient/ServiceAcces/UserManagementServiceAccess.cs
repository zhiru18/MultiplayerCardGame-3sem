using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGameClient.UserManagementServiceReference;

namespace WebGameClient.ServiceAcces {
    public class UserManagementServiceAccess {

        public void CreateUser(string id, string email, string username) {
            using(UserManagementServiceClient proxy = new UserManagementServiceClient()) {
                proxy.CreateUser(id, email, username);
            }
        }
    }
}