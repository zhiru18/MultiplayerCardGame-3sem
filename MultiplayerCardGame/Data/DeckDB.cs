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
        private string conString;

        public DeckDB() {
            //conString = "Server=tcp:cardgameucn.database.windows.net,1433;Initial Catalog=CardGameDB;Persist Security Info=False;User ID=gameadmin;Password=Bamsesjul1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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

        public void Update(DeckModel deck) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                var sql = "UPDATE Deck SET deckName = @deckName WHERE id = @id;";
                connection.Execute(sql, deck);
            }
        }
    }    
}
