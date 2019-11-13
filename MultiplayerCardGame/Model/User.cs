using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class User {
        public enum UserType { PLAYER, ADMIN };
        public enum UserStatus { UNATTACKABLE, ATTACKABLE, STUNNED, INGAME };

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType userType { get; set; }
        public UserStatus userStatus { get; set; }

        public User(string id, string userName, string email, string password, UserType userType, UserStatus userStatus) {
            this.Id = id;
            this.UserName = UserName;
            this.Email = email;
            this.Password = password;
            this.userType = userType;
            this.userStatus = userStatus;
        }
        public User() {

        }
    }
}
