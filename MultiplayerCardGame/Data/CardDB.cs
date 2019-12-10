using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Server.Model.Model;

namespace Server.Data.Data {
    public class CardDB:ICardDBIF {
        /* This class is used to access the database,
         * in particular it takes care of everything that has to do with with the card table
         */
        private string conString;

        public CardDB() {
            conString = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        }

        public void Delete(CardModel card){
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "DELETE FROM Card WHERE id = @id;";
                connection.Execute(sql, card);
            }
        }

        public IEnumerable<CardModel> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(conString)) {
                return connection.Query<CardModel>("SELECT card.id, cardType, name, description, value FROM CARD").ToList();
            }
        }

        public List<CardModel> GetCardsByDeckId(int id) {
            using(SqlConnection connection = new SqlConnection(conString)) {
                return connection.Query<CardModel>("Select card.id, cardType, name, description, value from card join CardDeck on card.id = card_id join Deck on deck_id = Deck.id where deck_id = @id", new { id }).ToList();
            }
        }

        public List<CardModel> GetCardsByUserId(string id) {
            using(SqlConnection connection = new SqlConnection(conString)) {
                return connection.Query<CardModel>("Select card.id, cardType, name, description, value from card join CardUser on card.id = card_id join CGUser on CGUser_id = CGUser.id where CGUser_id = @id", new { id }).ToList();
            }
           
        }

        public void Insert(CardModel card)
        {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "INSERT INTO Card (cardType, name, description, value) VALUES (@cardType, @name, @description, @value);";
                connection.Execute(sql, card);
            }
        }
        public int InsertWithIdentity(CardModel card) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "INSERT INTO Card (cardType, name, description, value) VALUES (@cardType, @name, @description, @value); SELECT CAST(SCOPE_IDENTITY() as int)";
                var id = connection.Query<int>(sql, card).SingleOrDefault();
                return id;
            }
        }

        public void Update(CardModel card)
        {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "UPDATE CARD SET cardType = @cardType, name = @name, description = @description, value = @value WHERE id = @id;";
                connection.Execute(sql, card);
            }
        }
    }
}
