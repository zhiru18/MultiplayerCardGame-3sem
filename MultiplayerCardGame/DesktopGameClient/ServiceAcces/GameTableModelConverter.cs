using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopGameClient.GameTableServiceReference;
using DesktopGameClient.Models;

namespace DesktopGameClient.ServiceAcces
{
    public class GameTableModelConverter
    {
        internal static Models.GameTableModel ConvertFromServiceGameTableToClientGameTable(GameTableServiceReference.GameTable serviceGameTable)
        {
            Models.GameTableModel clientGameTable = new Models.GameTableModel() {
                Id = serviceGameTable.Id,
                TableName = serviceGameTable.TableName,
                Users = ConvertFromServiceListOfUsersToClientListOfUsers(serviceGameTable.Users),              
            };
            return clientGameTable;
        }

        private static List<Models.CGUserModel> ConvertFromServiceListOfUsersToClientListOfUsers(GameTableServiceReference.CGUser[] serviceUsers) {
            List<Models.CGUserModel> clientUsers = new List<Models.CGUserModel>();
            for (int i = 0; i < serviceUsers.Length; i++) {
                Models.CGUserModel clientUser = ConvertFromServiceUserToClientUser(serviceUsers[i]);
                clientUsers.Add(clientUser);
            }
            return clientUsers;
        }

        public static Models.CGUserModel ConvertFromServiceUserToClientUser(GameTableServiceReference.CGUser serviceUser) {
            Models.CGUserModel clientUser = new Models.CGUserModel() {
                Id = serviceUser.Id,
                UserName = serviceUser.UserName,
                //Email = serviceUser.Email,
                //userType = (Models.CGUserModel.UserType)serviceUser.userType,
                //userStatus = (Models.CGUserModel.UserStatus)serviceUser.userStatus,
                //Health = serviceUser.Health,              
            };
            return clientUser;
        }
        public static List<Models.GameTableModel> ConvertFromServiceGameTablesToClientGameTables(IEnumerable<GameTableServiceReference.GameTable> serviceGameTables)
        {
            List<Models.GameTableModel> clientGameTables = new List<Models.GameTableModel>();
            foreach (GameTableServiceReference.GameTable sgt in serviceGameTables) {
                Models.GameTableModel mgt = ConvertFromServiceGameTableToClientGameTable(sgt);
                clientGameTables.Add(mgt);
            }
            return clientGameTables;
        }
        public static GameTableServiceReference.CGUser ConvertFromClientUserToServiceUser(CGUserModel modelUser) {
            CGUser serviceUser = new CGUser() {
                Id = modelUser.Id,
                UserName = modelUser.UserName,
                Email = modelUser.Email,
                //userType = (Models.CGUserModel.UserType)serviceUser.userType,
                //userStatus = (Models.CGUserModel.UserStatus)serviceUser.userStatus,
                //Health = serviceUser.Health,              
            };
            return serviceUser;
        }
    }
}
