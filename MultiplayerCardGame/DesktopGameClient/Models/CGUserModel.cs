using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopGameClient.Models
{
    public class CGUserModel
    {
        public enum UserType
        {
            PLAYER,
            ADMIN
        };
        public enum UserStatus
        {
            UNATTACKABLE,
            ATTACKABLE,
            STUNNED,
            INGAME
        };
        public  String Id { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public int Health { get; set; }
        public UserType userType { get; set; }
        public UserStatus userStatus { get; set; }

        public CGUserModel(string userName, string email, UserType userType, UserStatus userStatus)
        {
            this.UserName = userName;
            this.Email = email;
            this.userType = userType;
            this.userStatus = userStatus;
        }
        public CGUserModel()
        {
        }

        public override string ToString()
        {
            return $"{UserName}";
        }

    }
}
