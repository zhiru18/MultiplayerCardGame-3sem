using Server.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Data {
    public interface ICGUserDBIF : IGeneralDBIF<CGUserModel> {
        CGUserModel GetUserByEmail(string useremail);
        CGUserModel GetById(string id);
        List<CGUserModel> GetUserByTableId(int id);
        void UpdateUserTableId(CGUserModel user, int tableId);
        int GetUserTableId(string id);

        void InsertHand(List<CardModel> cards, CGUserModel user);
        void DeleteHand(CGUserModel userModel);
        CGUserModel GetByUserName(string userName);

        void UpdateTableSeats(CGUserModel user, int amount);
    }
}
