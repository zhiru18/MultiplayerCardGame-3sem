using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Model.Model;

namespace Server.Data.Data {
    public class GameDB : IGameDBIF{
        private string conString;

        public GameDB() {

            conString = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        }

        public void Delete(Game t) {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> GetAll() {
            throw new NotImplementedException();
        }

        public void Insert(Game t) {
            string queryString = "INSERT INTO Game (GameTableId) VALUES (@GametableId);";
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand insertCommand = new SqlCommand(queryString, connection)) {
                SqlParameter GameTableIDParam = new SqlParameter("@GameTableId", t.gameTable.Id);
                insertCommand.Parameters.Add(GameTableIDParam);
                connection.Open();

                SqlDataReader reader = insertCommand.ExecuteReader();
            }
        }

        public void Update(Game t) {
            throw new NotImplementedException();
        }
    }
}
