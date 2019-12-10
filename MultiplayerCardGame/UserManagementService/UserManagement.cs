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
    /* This service takes care of creating, updating deleting and getting CGUsers out of the database.
     * Furthermore it has methods to inserting ad deleting the cards that a user has on its hand when playing
     */
    public class UserManagement : IUserManagementService {
        ICGUserDBIF cGUserDB = new CGUserDB();
        public void CreateUser(string id, string email, string userName) {
            if (id == null || email == null || userName == null) {
                throw new ArgumentNullException();
            } else {
                CGUserModel user = new CGUserModel();
                user.Email = email;
                user.Id = id;
                user.UserName = userName;
                cGUserDB.Insert(user);
            }
        }

        public CGUser GetUserByUserId(string id) {
            if (id == null) {
                throw new ArgumentNullException();
            } else {
                CGUserModel userModel = cGUserDB.GetById(id);
                return CGUserConverter.convertFromCGUserModelToCGUser(userModel);
            }
        }

        public void UpdateUser(CGUser user) {
            if (user == null) {
                throw new ArgumentNullException();
            } else {
                CGUserModel userModel = CGUserConverter.ConvertFromCGUserToCGUserModel(user);
                cGUserDB.Update(userModel);
            }
        }

        public void UpdateUserTableId(CGUser user, int tableId) {
            if (user == null || tableId == 0) {
                throw new ArgumentNullException();
            } else {
                CGUserModel userModel = CGUserConverter.ConvertFromCGUserToCGUserModel(user);
                cGUserDB.UpdateUserTableId(userModel, tableId);
            }
        }
        public List<CGUser> GetUserByTableId(int id) {
            if (id == 0) {
                throw new ArgumentException();
            } else {
                return CGUserConverter.ConvertFromListOfCGUserModelToListOfCGUser(cGUserDB.GetUserByTableId(id));
            }
        }
        public void SaveHand(List<Card> cards, CGUser user) {
            if (cards == null || user == null) {
                throw new ArgumentNullException();
            } else {
                List<CardModel> cardModels = CardConverter.ConvertFromListOfCardToListOfCardModel(cards);
                CGUserModel userModel = CGUserConverter.ConvertFromCGUserToCGUserModel(user);
                cGUserDB.InsertHand(cardModels, userModel);
            }
        }
        public void DeleteHand(CGUser user) {
            if (user == null) {
                throw new ArgumentNullException();
            } else {
                CGUserModel userModel = CGUserConverter.ConvertFromCGUserToCGUserModel(user);
                cGUserDB.DeleteHand(userModel);
            }
        }

        public bool DeleteCGUser(CGUser user) {
            if (user == null) {
                throw new ArgumentNullException();
            } else {
                bool res = false;
                CGUserModel userModel = CGUserConverter.ConvertFromCGUserToCGUserModel(user);
                if (userModel != null) {
                    cGUserDB.UpdateTableSeats(userModel, -1);
                    cGUserDB.Delete(userModel);
                    res = true;
                }
                return res;              
            }
        }

        public IEnumerable<CGUser> GetAll() {
            var data = cGUserDB.GetAll();
            List<CGUser> cgUsers = CGUserConverter.ConvertFromListOfCGUserModelToListOfCGUser((List<CGUserModel>)cGUserDB.GetAll());
            return cgUsers;
        }
    
        public CGUser GetCGUserByUserName(string userName) {
            if (userName == null) {
                throw new ArgumentNullException();
            } else {
                CGUserModel userModel = cGUserDB.GetByUserName(userName);
                return CGUserConverter.convertFromCGUserModelToCGUser(userModel);
            }
        }
    }
}
