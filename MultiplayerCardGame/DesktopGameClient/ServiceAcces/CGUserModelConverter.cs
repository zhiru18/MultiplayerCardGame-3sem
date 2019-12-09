using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopGameClient.ServiceAcces {
    public class CGUserModelConverter {
        
        internal static Models.CGUserModel ConvertFromServiceUserToClientUser(UserManagementServiceReference.CGUser serviceCGUser) {
            Models.CGUserModel clientCGUser = new Models.CGUserModel() {
                Id = serviceCGUser.Id,
                UserName = serviceCGUser.UserName,
                Email = serviceCGUser.Email,
                Health = serviceCGUser.Health,
                userType = (Models.CGUserModel.UserType)serviceCGUser.userType,
                userStatus = (Models.CGUserModel.UserStatus)serviceCGUser.userStatus,
            };
            return clientCGUser;
        }

        internal static List<Models.CGUserModel> ConvertFromServiceListOfUsersToClientListOfUsers(UserManagementServiceReference.CGUser[] serviceCGUsers) {
            List<Models.CGUserModel> clientCGUsers = new List<Models.CGUserModel>();
            foreach(UserManagementServiceReference.CGUser sCGU in serviceCGUsers) {
                Models.CGUserModel cgU = ConvertFromServiceUserToClientUser(sCGU);
                clientCGUsers.Add(cgU);
            }
            return clientCGUsers;
        }

        internal static UserManagementServiceReference.CGUser ConvertFromClientUserToServiceUser(Models.CGUserModel clientCGUser) {
            UserManagementServiceReference.CGUser serviceUser = new UserManagementServiceReference.CGUser() {
                Id = clientCGUser.Id,
                UserName = clientCGUser.UserName,
                Email = clientCGUser.Email,
                Health = clientCGUser.Health,
                userType = (UserManagementServiceReference.CGUser.UserType)clientCGUser.userType,
                userStatus = (UserManagementServiceReference.CGUser.UserStatus)clientCGUser.userStatus,
            };
            return serviceUser;
        }
        internal static UserManagementServiceReference.CGUser[] ConvertFromClientListOfUsersToServiceListOfUsers(List<Models.CGUserModel> clientCGUsers) {
            UserManagementServiceReference.CGUser[] serviceCGUsers = new UserManagementServiceReference.CGUser[clientCGUsers.Count];
            for(int i = 0; i < clientCGUsers.Count; i++) {
                UserManagementServiceReference.CGUser cgU = ConvertFromClientUserToServiceUser(clientCGUsers[i]);
                serviceCGUsers[i] = cgU;
            }
            return serviceCGUsers;
        }
    }
}
