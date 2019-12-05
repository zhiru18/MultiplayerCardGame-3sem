using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Converters.DataContractConverters;
using Server.Data.Data;
using Server.DataContracts.DataContracts;
using Server.Model.Model;
using Server.Services.GameTableManagementService;

namespace GameTableManagementServiceTest {
    public class GameTableManagementTest {
        GameTableManagement gameTableManagement;
        [TestMethod]
        public void CreateGameTableTest() {
            // arrange
            gameTableManagement = new GameTableManagement();
            var user1 = new CGUser();

            //Act
            var table2 = gameTableManagement.CreateGameTable(user1, "GameTable");

            //Assert
            Assert.AreEqual(table2.TableName, "GameTable");
        }

        [TestMethod]
        public void DeleteGameTableTest() {
            // arrange
            gameTableManagement = new GameTableManagement();

            //Act
            bool res = gameTableManagement.DeleteGameTable(1);

            //Assert
            Assert.IsTrue(res);
        }

        public class GameTableManagementServiceTest {
            [TestMethod]
            public void JoinGameTableTest() {
                GameTableManagement gameTableManagement = new GameTableManagement();
                ICGUserDBIF userDB = new CGUserDB();
                GameTable table = gameTableManagement.GetGameTableById(2);
                CGUser cGUser = CGUserConverter.convertFromCGUserModelToCGUser(userDB.GetById("ce2b4942-69bc-4423-a2c0-2b28f53e7817"));
                gameTableManagement.JoinGameTable(cGUser, table);
                // TODO: Fix this test.
                //Assert.IsFalse(succeeded);

            }
        }
    }
}
