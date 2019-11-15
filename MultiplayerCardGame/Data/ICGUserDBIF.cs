using Server.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Data {
    interface ICGUserDBIF : IGeneralDBIF<CGUser> {
        CGUser GetUserByUsername(string userName);
        CGUser GetById(string id);
    }
}
