using Server.Data.Data;
using Server.DataContracts.DataContracts;
using Server.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Converters.DataContractConverters {
    /*This class converts CGUserModel objects to the equivalent datacontract
     * and vice versa 
     */
    public class CGUserConverter {
        public static CGUserModel ConvertFromCGUserToCGUserModel(CGUser cGUser) {
            ICGUserDBIF userDB = new CGUserDB();
            CGUserModel cGUserModel = new CGUserModel() {
                Id= cGUser.Id,
                UserName = cGUser.UserName,
                Email = cGUser.Email,
                userType = (CGUserModel.UserType)cGUser.userType,
                userStatus = (CGUserModel.UserStatus)cGUser.userStatus,
                Health = cGUser.Health
            };
            if (userDB.GetUserTableId(cGUser.Id) != 0) {
                cGUserModel.TableID = userDB.GetUserTableId(cGUser.Id);
            }
            
            return cGUserModel;
        }

        public static CGUser convertFromCGUserModelToCGUser(CGUserModel cGUserModel) {
            ICardDBIF cardDB = new CardDB();
            List<CardModel> userCards = cardDB.GetCardsByUserId(cGUserModel.Id);
            CGUser cGUser = new CGUser() {
                Id = cGUserModel.Id,
                UserName = cGUserModel.UserName,
                Email = cGUserModel.Email,
                userType = (CGUser.UserType)cGUserModel.userType,
                userStatus = (CGUser.UserStatus)cGUserModel.userStatus,
                Health = cGUserModel.Health,
                cards = CardConverter.ConvertFromListOfCardModelToListOfCard(userCards)
            };
            return cGUser;
        }
        public static List<CGUser> ConvertFromListOfCGUserModelToListOfCGUser(List<CGUserModel> cGUserModels) {
            List<CGUser> cGUsers = new List<CGUser>();
            foreach (CGUserModel cGUserModel in cGUserModels) {
                CGUser cGUser = convertFromCGUserModelToCGUser(cGUserModel);
                cGUsers.Add(cGUser);
            }
            return cGUsers;
        }
    }
}
