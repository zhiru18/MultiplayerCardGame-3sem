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
            //conString = "Server=tcp:cardgameucn.database.windows.net,1433;Initial Catalog=CardGameDB;Persist Security Info=False;User ID=gameadmin;Password=Bamsesjul1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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
                return connection.Query<CardModel>("SELECT cardType, name, description, value FROM CARD").ToList();
            }
        }

        public void Insert(CardModel card)
        {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "INSERT INTO Card (cardType, name, description, value) VALUES (@cardType, @name, @description, @value);";
                connection.Execute(sql, card);
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
