using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model.Model {
    public class CGUser {
        public enum UserType { PLAYER, ADMIN };
        public enum UserStatus { UNATTACKABLE, ATTACKABLE, STUNNED, INGAME };

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public UserType userType { get; set; }
        public UserStatus userStatus { get; set; }

        public CGUser(string id, string userName, string email, string password, UserType userType, UserStatus userStatus) {
            this.Id = id;
            this.UserName = userName;
            this.Email = email;
            this.UserPassword = password;
            this.userType = userType;
            this.userStatus = userStatus;
        }
        public CGUser() {

        }
    }
}
