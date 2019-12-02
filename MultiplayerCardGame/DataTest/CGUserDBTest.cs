using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Data.Data;
using Server.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Data.Tests {
    [TestClass()]
    public class CGUserDBTest {
        [TestMethod()]
        public void UpdateUserTableIdTest() {
            ICGUserDBIF cgUserDB = new CGUserDB();
            CGUserModel user = cgUserDB.GetById("3e0cd506-d7d6-431d-9f25-afc70d6ce993");
            cgUserDB.UpdateUserTableId(user, 10);
        }
    }
}