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

        public void Delete(GameDB t) {
            throw new NotImplementedException();
        }

        public IEnumerable<GameDB> GetAll() {
            throw new NotImplementedException();
        }

        public void insert(Game game) {
            string queryString ="INSERT INTO Game (GameTableId) VALUES (@GametableId);";
            using (SqlConnection connection = new SqlConnection(conString)) 
            using (SqlCommand insertCommand = new SqlCommand(queryString, connection)) {
                SqlParameter GameTableIDParam = new SqlParameter("@GameTableId", game.gameTable.Id);
                insertCommand.Parameters.Add(GameTableIDParam);
                connection.Open();

                SqlDataReader reader = insertCommand.ExecuteReader();
            }   
            
        }

        public void Insert(GameDB t) {
            throw new NotImplementedException();
        }

        public void Update(GameDB t) {
            throw new NotImplementedException();
        }
    }
}
