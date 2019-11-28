using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGameClient.Models
{
    public class CGUser
    {
        public enum UserType { PLAYER, ADMIN };
        public enum UserStatus { UNATTACKABLE, ATTACKABLE, STUNNED, INGAME };

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public UserType userType { get; set; }
        public UserStatus userStatus { get; set; }
        public int Health { get; set; }
        public List<Card> cards { get; set; }

        public CGUser(string userName, string email, UserType userType, UserStatus userStatus)
        {
            this.UserName = userName;
            this.Email = email;
            this.userType = userType;
            this.userStatus = userStatus;
            cards = new List<Card>();
        }
        public CGUser()
        {

        }
    }
}