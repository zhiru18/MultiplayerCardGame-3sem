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
        /* This class is used to access the database,
         * in particular it takes care of everything that has to do with with the Game table
         */
        private string conString;

        public GameDB() {
            conString = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        }

        public void Delete(GameModel gameModel) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                var sql = "Delete FROM Game where GameTableId = @GameTableid;";
                connection.Execute(sql, gameModel);
            };
        }

        public IEnumerable<GameModel> GetAll() {
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                return connection.Query<GameModel>("SELECT Id, GameTableId FROM Game");
            }
        }
        public void Insert(GameModel game) {
            using(SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                var sql = "Insert INTO Game (GameTableId) VALUES (@GameTableId);";
                connection.Execute(sql, game);
            }
        }

        public void Update(GameModel t) {
            throw new NotImplementedException();
        }

        public GameModel GetById(int id) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                return connection.Query<GameModel>("SELECT Id, GameTableId FROM Game WHERE id = @id", new { id }).SingleOrDefault();
            }
        }

        public GameModel GetByTableId(int tableId) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                return connection.Query<GameModel>("SELECT Id, GameTableId FROM Game WHERE GameTableId = @tableId", new { tableId }).SingleOrDefault();
            }
        }
    }
}
