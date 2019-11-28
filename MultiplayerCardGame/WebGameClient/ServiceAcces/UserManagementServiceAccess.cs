using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGameClient.Models;
using WebGameClient.UserManagementServiceReference;

namespace WebGameClient.ServiceAcces {
    public class UserManagementServiceAccess {

        public void CreateUser(string id, string email, string username) {
            using(UserManagementServiceClient proxy = new UserManagementServiceClient()) {
                proxy.CreateUser(id, email, username);
            }
        }

        public Models.CGUser GetUserByUserId(string userId) {

            using (UserManagementServiceClient proxy = new UserManagementServiceClient()) {
                UserManagementServiceReference.CGUser serviceUser = proxy.GetUserByUserId(userId);
                Models.CGUser clientUser = UserModelModelConverter.ConvertFromServiceUserToClientUser(serviceUser);
                return clientUser;
            }
        }
    }
}