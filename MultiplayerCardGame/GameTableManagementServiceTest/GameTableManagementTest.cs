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
    [TestClass]
    public class GameTableManagementServiceTest {
        GameTableManagement gameTableManagement;
        [TestMethod]
        public void CreateGameTableTest() {
            // arrange
            gameTableManagement = new GameTableManagement();
            IGameTableDBIF tableDB = new GameTableDB();
            var user1 = new CGUser();

            //Act
            var table = gameTableManagement.CreateGameTable(user1, "GameTable");
            var tableModel = tableDB.GetGameTableByTableName("GameTable");

            //Assert
            Assert.AreEqual(tableModel.TableName, "GameTable");

            //Cleanup
            tableDB.Delete(tableModel);
        }

        [TestMethod]
        public void DeleteGameTableTest() {
            // arrange
            gameTableManagement = new GameTableManagement();
            IGameTableDBIF tableDB = new GameTableDB();
            ICGUserDBIF userDB = new CGUserDB();
            CGUser user = CGUserConverter.convertFromCGUserModelToCGUser(userDB.GetById("Test"));
            gameTableManagement.CreateGameTable(user, "TestTable");
            GameTable table = gameTableManagement.GetGameTableByTableName("TestTable");

            //Act
            gameTableManagement.DeleteGameTable(table.Id);

            //Assert
            Assert.IsNull(tableDB.GetById(table.Id));
        }

        [TestMethod]
        public void JoinGameTableTest() {
            //Assert
            gameTableManagement = new GameTableManagement();
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
