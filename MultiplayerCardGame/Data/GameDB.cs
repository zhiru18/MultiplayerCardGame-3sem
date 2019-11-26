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
    public class GameDB : IGameDBIF{
        private string conString;

        public GameDB() {

            conString = "Server=tcp:cardgameucn.database.windows.net,1433;Initial Catalog=CardGameDB;Persist Security Info=False;User ID=gameadmin;Password=Bamsesjul1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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

        public Game GetById(int id) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                return connection.Query<Game>("SELECT Id, GameTableId FROM Game WHERE id = @id", new { id }).SingleOrDefault();
            }
        }
    }
}
