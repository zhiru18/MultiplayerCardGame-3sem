using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;
using Server.Model.Model;
using System.Configuration;

namespace Server.Data.Data {
    public class DeckDB : IDeckDBIF {
        /* This class is used to access the database,
         * in particular it takes care of everything that has to do with with the Deck table
         */
        private string conString;

        public DeckDB() {
            conString = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        }

        public void Delete(DeckModel deck) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                var sql = "DELETE FROM Deck WHERE id = @id;";
                connection.Execute(sql, deck);
            }
        }

        public IEnumerable<DeckModel> GetAll() {
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                return connection.Query<DeckModel>("SELECT Id, deckName FROM Deck").ToList();
            }
        }

        public DeckModel GetById(int id) {
                    using (SqlConnection connection = new SqlConnection(conString)) {
                        connection.Open();
                        return connection.Query<DeckModel>("SELECT Id, deckName FROM Deck WHERE id = @id", new { id }).SingleOrDefault();
 
                    }
        }

        public void Insert(DeckModel deck) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                       connection.Open();
                       var sql = "INSERT INTO Deck (deckName) VALUES (@deckName);";
                       connection.Execute(sql, deck);
                }
            }
        public int InsertWithIdentity(DeckModel deck) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "INSERT INTO Deck (deckName) VALUES (@deckName); SELECT CAST(SCOPE_IDENTITY() as int)";
                var id = connection.Query<int>(sql, deck).SingleOrDefault();
                return id;
            }
        }

        public void Update(DeckModel deck) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                var sql = "UPDATE Deck SET deckName = @deckName WHERE id = @id;";
                connection.Execute(sql, deck);
            }
        }
    }    
}
