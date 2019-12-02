using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
