using DesktopGameClient.Models;
using DesktopGameClient.UserManagementServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopGameClient.ServiceAcces {
    public class CGUserManagementServiceAccess {
        public List<CGUserModel> GetAll() {
            using (UserManagementServiceClient proxy = new UserManagementServiceClient()) {
                var serviceCGUsers = proxy.GetAll();
                List<Models.CGUserModel> clientCGUsers = CGUserModelConverter.ConvertFromServiceListOfUsersToClientListOfUsers(serviceCGUsers);
                return clientCGUsers;
            }
        }

        public bool DeleteCGUser(CGUserModel user) {
            using (UserManagementServiceClient proxy = new UserManagementServiceClient()) {
                CGUser cgU = CGUserModelConverter.ConvertFromClientUserToServiceUser(user);
                proxy.DeleteHand(cgU);
                return proxy.DeleteCGUser(cgU);
            }
        }

        public void CreateUser(string id, string email, string userName) {
            using (UserManagementServiceClient proxy = new UserManagementServiceClient()) {
                proxy.CreateUser(id, email, userName);
            }
        }

        public CGUserModel GetUserByUserName(string userName) {
            using (UserManagementServiceClient proxy = new UserManagementServiceClient()) {
                UserManagementServiceReference.CGUser serviceUser = proxy.GetCGUserByUserName(userName);
                Models.CGUserModel clientUser = CGUserModelConverter.ConvertFromServiceUserToClientUser(serviceUser);
                return clientUser;
            }
        }
    }
}
