using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server.DataContracts.DataContracts {
    [DataContract]
    public class CGUser {
        [DataContract]
        public enum UserType {
            [EnumMember]
            PLAYER, 
            [EnumMember]
            ADMIN };
        [DataContract]
        public enum UserStatus {
            [EnumMember]
            UNATTACKABLE, 
            [EnumMember]
            ATTACKABLE, 
            [EnumMember]
            STUNNED, 
            [EnumMember]
            INGAME };
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public UserType userType { get; set; }
        [DataMember]
        public UserStatus userStatus { get; set; }
        [DataMember]
        public int Health { get; set; } 
        [DataMember]
        public List<Card> cards { get; set; }

        public CGUser(string userName, string email, UserType userType, UserStatus userStatus) {
            this.UserName = userName;
            this.Email = email;
            this.userType = userType;
            this.userStatus = userStatus;
            cards = new List<Card>();
        }
        public CGUser() {
            cards = new List<Card>();
        }
    }
}
