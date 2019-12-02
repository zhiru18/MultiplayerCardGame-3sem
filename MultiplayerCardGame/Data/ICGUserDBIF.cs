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
    }
}
