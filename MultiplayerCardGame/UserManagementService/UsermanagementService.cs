using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UserManagementService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class UserManagementService : IUserManagementService
    {
        public UserManagementService() {

        }
        public UserManagementService(IUserRepository userRepository) {
            _UserRepository = userRepository;
        }
        IUserRepository _UserRepository = null;
        string userToken = string.Empty;
        public string Login(string userName, string password) {
            IUserRepository userRepository = _UserRepository ?? new UserRepository();
            User user = userRepository.GetUserByUserName(userName);
            if (user != null) {
                if (password.Equals(user.Password)) {
                    userToken = OperationContext.Current.SessionId;
                } else {
                    userToken = "";
                } 
            } else {
                userToken = "";
            }
            return userToken;
        }

        public bool IsValidUser() {
            bool isValid = false;
            if (OperationContext.Current.IncomingMessageHeaders.FindHeader("TokenHeader", "TokenNameSpace") == -1) {
                isValid = false;
            } else {
                string userIdentityToken = Convert.ToString(OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("TokenHeader", "TokenNameSpace"));
                if (userIdentityToken == userToken) {
                    isValid = true;
                } else {
                    isValid = false;
                }
            }
            return isValid;
        }
    }
}
