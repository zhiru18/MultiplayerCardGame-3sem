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
                CGUserModel userModel = cGUserDB.GetById("0dba05c5-ffcd-47d9-b9a9-6657d47f7bcc");
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

        public List<CGUser> GetAll1() {
            CGUserModel userModel = cGUserDB.GetById("0dba05c5-ffcd-47d9-b9a9-6657d47f7bcc");
            CGUser cg = CGUserConverter.convertFromCGUserModelToCGUser(userModel);
            List<CGUser> data = new List<CGUser>() { cg };
            return data;
            
        }

        public List<CGUser> GetAll2() {
            var data = cGUserDB.GetAll();
            List<CGUser> data2 = new List<CGUser>();
            CGUser tempCGUser = null;
            int propesize = 20, loopNo = 0;
            foreach(CGUserModel user in data) {
                tempCGUser = CGUserConverter.convertFromCGUserModelToCGUser(user);
                if (loopNo < propesize) {
                    data2.Add(tempCGUser);
                    loopNo++;
                }
            }
            return data2;
        }
    }
}
