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
        private string conString;

        public CardDB() {
            conString = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        }

        public void Delete(Card card){
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "DELETE FROM Card WHERE id = @id;";
                connection.Execute(sql, card);
            }
        }

        public IEnumerable<Card> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(conString)) {
                return connection.Query<Card>("SELECT cardType, Id, name, description, value FROM CARD").ToList();
            }
        }

        public void Insert(Card card)
        {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "INSERT INTO Card (cardType, Id, name, description, value) VALUES (@cardType, @id, @name, @description, @value);";
                connection.Execute(sql, card);
            }
        }

        public void Update(Card card)
        {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "UPDATE CARD SET cardType = @cardType, name = @name, email = @email, userType = @userType, userStatus = @userStatus WHERE id = @id;";
                connection.Execute(sql, card);
            }
        }
    }
}
