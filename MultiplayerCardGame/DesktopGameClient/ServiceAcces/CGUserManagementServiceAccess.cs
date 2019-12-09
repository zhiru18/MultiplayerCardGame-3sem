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

        public void DeleteCGUser(CGUserModel user) {
            using (UserManagementServiceClient proxy = new UserManagementServiceClient()) {
                CGUser cgU = CGUserModelConverter.ConvertFromClientUserToServiceUser(user);
                proxy.DeleteCGUser(cgU);
            }
        }
    }
}
