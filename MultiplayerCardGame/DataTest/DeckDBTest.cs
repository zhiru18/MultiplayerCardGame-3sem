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
            var deck1 = deckDB.GetById(1);
            //Act
            deckDB.Delete(deck1);
            deck1 = deckDB.GetById(1);       
            //Assert
            Assert.IsNull(deck1);
        }

        [TestMethod]
        public void InsertTest() {
            // Arrange
            deckDB = new DeckDB();
            var deck5 = new Deck() {
                DeckName = "GameDeck5"
            };
            //Act
            deckDB.Insert(deck5);
            var deckT = deckDB.GetById(5);
            //Assert
            Assert.AreEqual(deck5.DeckName, deckT.DeckName);
        }

        [TestMethod]
        public void GetbyIdTest() {
            // Arrange
            deckDB = new DeckDB();
            //Act
            Deck deck3 = deckDB.GetById(3);
            //Assert
            Assert.AreEqual(3, deck3.Id);
        }

        [TestMethod]
        public void GetAllTest() {
            // Arrange
            deckDB = new DeckDB();
            //Act
            List<Deck> decks = (List<Deck>)deckDB.GetAll();
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
