using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;
using Server.Model.Model;

namespace Server.Data.Data {
    public class DeckDB : IDeckDBIF {
        private string conString;

        public DeckDB() {
            conString = "Server=tcp:cardgameucn.database.windows.net,1433;Initial Catalog=CardGameDB;Persist Security Info=False;User ID=gameadmin;Password=Bamsesjul1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //conString = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        }

        public void Delete(Deck deck) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                var sql = "DELETE FROM Deck WHERE id = @id;";
                connection.Execute(sql, deck);
            }
        }

        public IEnumerable<Deck> GetAll() {
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                return connection.Query<Deck>("SELECT Id, deckName FROM Deck").ToList();
            }
        }

        public Deck GetById(int id) {
            ICardDBIF cardDB = new CardDB();
            Deck deck = new Deck();
            try {
                using (TransactionScope scope = new TransactionScope()) {
                    using (SqlConnection connection = new SqlConnection(conString)) {
                        connection.Open();
                        deck = connection.Query<Deck>("SELECT Id, deckName FROM Deck WHERE id = @id", new { id }).SingleOrDefault();
                        // TODO: Change so it only gets cards that are linked to the deck. Must also add table CardDeck to the db and add column to card.
                        deck.cards = (List<Card>)cardDB.GetAll();
                        scope.Complete(); 
                    }
                }
            }catch(TransactionAbortedException tae) {
                //maybe throw our own exception
            }
            return deck;
        }

        public void Insert(Deck deck) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                       connection.Open();
                       var sql = "INSERT INTO Deck (deckName) VALUES (@deckName);";
                       connection.Execute(sql, deck);
                }
            }

        public void Update(Deck deck) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                var sql = "UPDATE Deck SET deckName = @deckName WHERE id = @id;";
                connection.Execute(sql, deck);
            }
        }
    }    
}
