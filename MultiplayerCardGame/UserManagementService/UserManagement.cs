using Server.Data.Data;
using Server.Model.Model;
using Server.Services.UserManagementService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.DataContracts.DataContracts;
using Server.Converters.DataContractConverters;

namespace Server.Services.UserManagementService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class UserManagement : IUserManagementService {
        ICGUserDBIF cGUserDB = new CGUserDB();
        public void CreateUser(string id, string email, string userName) {
            CGUserModel user = new CGUserModel();
            user.Email = email;
            user.Id = id;
            user.UserName = userName;
            cGUserDB.Insert(user);
        }

        public CGUser GetUserByUserId(string id) {
            CGUserModel userModel = cGUserDB.GetById(id);
            return CGUserConverter.convertFromCGUserModelToCGUser(userModel);
        }

        public void UpdateUser(CGUser user) {
            CGUserModel userModel = CGUserConverter.ConvertFromCGUserToCGUserModel(user);
            cGUserDB.Update(userModel);
        }

        public void UpdateUserTableId(CGUser user, int tableId) {
            CGUserModel userModel = CGUserConverter.ConvertFromCGUserToCGUserModel(user);
            cGUserDB.UpdateUserTableId(userModel, tableId);
        }
        public List<CGUser> GetUserByTableId(int id) {
            return CGUserConverter.ConvertFromListOfCGUserModelToListOfCGUser(cGUserDB.GetUserByTableId(id));
        }
        public void SaveHand(List<Card> cards, CGUser user) {
            List<CardModel> cardModels = CardConverter.ConvertFromListOfCardToListOfCardModel(cards);
            CGUserModel userModel = CGUserConverter.ConvertFromCGUserToCGUserModel(user);
            cGUserDB.InsertHand(cardModels, userModel);
        }
        public void DeleteHand(CGUser user) {
            CGUserModel userModel = CGUserConverter.ConvertFromCGUserToCGUserModel(user);
            cGUserDB.DeleteHand(userModel);
        }
    }
}
