using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Data.Data;
using Server.Model.Model;

namespace Tests.DataTest {
    [TestClass]
    public class DeckDBTest {
        DeckDB deckDB;
        [TestMethod]
        public void DeleteTest() {
            //Arrange
            deckDB = new DeckDB();
            DeckModel deck = new DeckModel { 
                DeckName = "TestDeck" 
            };
            deck.Id = deckDB.InsertWithIdentity(deck);
            //Act
            deckDB.Delete(deck);
            deck = deckDB.GetById(deck.Id);       
            //Assert
            Assert.IsNull(deck);
        }

        [TestMethod]
        public void InsertTest() {
            // Arrange
            bool found = false;
            deckDB = new DeckDB();
            List<DeckModel> beforeDecks = (List<DeckModel>)deckDB.GetAll();    
            var testDeck = new DeckModel() {
                DeckName = "TestDeck"
            };
            //Act
            deckDB.Insert(testDeck);
            List<DeckModel> afterDecks = (List<DeckModel>)deckDB.GetAll();
            //Assert
            Assert.IsTrue(beforeDecks.Count < afterDecks.Count);

            //Cleanup
            for (int i = 0; i < afterDecks.Count && !found; i++) {
                if (afterDecks[i].DeckName == testDeck.DeckName) {
                    testDeck.Id = afterDecks[i].Id;
                    found = true;
                }
            }
            deckDB.Delete(testDeck);
        }

        [TestMethod]
        public void GetbyIdTest() {
            // Arrange
            deckDB = new DeckDB();
            //Act
            DeckModel deck3 = deckDB.GetById(3);
            //Assert
            Assert.AreEqual(3, deck3.Id);
        }

        [TestMethod]
        public void GetAllTest() {
            // Arrange
            deckDB = new DeckDB();
            //Act
            List<DeckModel> decks = (List<DeckModel>)deckDB.GetAll();
            //Assert
            Assert.IsTrue(decks.Count > 0);
        }

        [TestMethod]
        public void UpdateTest() {
            //Arrange
            deckDB = new DeckDB();
            var deck3 = deckDB.GetById(3);
            //Act
            deck3.DeckName = "DeckUpdate";
            deckDB.Update(deck3);
            var deckU = deckDB.GetById(3);
            //Assert
            Assert.AreEqual("DeckUpdate", deckU.DeckName);
        }

    }
}
