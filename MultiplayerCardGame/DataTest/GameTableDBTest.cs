using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Data.Data;
using Server.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.DataTest {
    [TestClass]
    public class GameTableDBTest {
        GameTableDB gameTableDB = new GameTableDB();
        [TestMethod]
        public void GetGameTableSeatsTest() {
            List<GameTableModel> gameTables = gameTableDB.GetAll().ToList();
            GameTableModel table = null;
            if (gameTables.Count > 0) {
                table = gameTables[0];
            }
            
            int seats = gameTableDB.GetGameTableSeats(table);
            Assert.IsTrue(0 <= seats && seats <= 4);
        }
        [TestMethod]
        public void DeleteTest() {
            gameTableDB = new GameTableDB();
            List<GameTableModel> gameTables = gameTableDB.GetAll().ToList();
            bool found = false;
            GameTableModel table = new GameTableModel { 
                DeckId = 2, 
                TableName = "TestTable" 
            };
            for (int i = 0; i < gameTables.Count && !found; i++) {
                if (gameTables[i].TableName == table.TableName) {
                    table.Id = gameTables[i].Id;
                }
                
            }
            var table1 = gameTableDB.GetById(table.Id);
            gameTableDB.Delete(table);
            table = gameTableDB.GetById(table.Id);
            Assert.IsNull(table);
        }
        [TestMethod]
        public void InsertTest() {
            //Arrange
            gameTableDB = new GameTableDB();
            bool found = false;
            var table = new GameTableModel("TestTable");
            table.DeckId = 2;
            //Act
            gameTableDB.Insert(table);
            List<GameTableModel> gameTables = gameTableDB.GetAll().ToList();
            for (int i = 0; i < gameTables.Count && !found; i++) {
                if (gameTables[i].TableName == table.TableName) {
                    table.Id = gameTables[i].Id;
                }
            }
            var tableT = gameTableDB.GetById(table.Id);
            //Assert
            Assert.AreEqual(table.TableName, tableT.TableName);
            //Cleanup
            gameTableDB.Delete(table);
        }
        [TestMethod]
        public void GetbyIdTest() {
            gameTableDB = new GameTableDB();
            GameTableModel table = null, table2 = null;
            List<GameTableModel> gameTables = gameTableDB.GetAll().ToList();
            if (gameTables.Count > 0) {
                table = gameTables[0];
            }
            table2 = gameTableDB.GetById(table.Id);
            Assert.AreEqual(table2.Id, table.Id);
        }
        [TestMethod]
        public void GetAllTest() {
            gameTableDB = new GameTableDB();
            List<GameTableModel> gameTables = gameTableDB.GetAll().ToList();
            Assert.IsTrue(gameTables.Count > 0);
        }
        [TestMethod]
        public void UpdateTest() {
            //Arrange
            gameTableDB = new GameTableDB();
            List<GameTableModel> gameTables = gameTableDB.GetAll().ToList();
            GameTableModel table = null;
            if (gameTables.Count > 0) {
                table = gameTables[0];
            }
            var name = table.TableName;
            //Act
            table.TableName = "GameTableUpdate";
            gameTableDB.Update(table);
            var table2 = gameTableDB.GetGameTableByTableName("GameTableUpdate");
            //Assert
            Assert.AreNotEqual(name, table2.TableName);
            //Cleanup
            table.TableName = name;
            gameTableDB.Update(table);
        }
    }
}