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

namespace Tests.GameTableManagementServiceTest {
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
                //Assert
                GameTableManagement gameTableManagement = new GameTableManagement();
                ICGUserDBIF userDB = new CGUserDB();
                List<GameTable> tables = (List<GameTable>)gameTableManagement.GetAll();
                GameTable table = null;
                if (tables != null) {
                    table = tables[0];
                }
                CGUser user = CGUserConverter.convertFromCGUserModelToCGUser(userDB.GetById("Test"));
                //Act
                GameTable table2 = gameTableManagement.JoinGameTable(user, table);
                //Assert
                Assert.IsTrue(table.Users.Count < table2.Users.Count);
                //Cleanup
                gameTableManagement.UpdateGameTableSeats(table2, -1);
                userDB.UpdateUserTableId(CGUserConverter.ConvertFromCGUserToCGUserModel(user), 0);

            }
        }
    }
}
