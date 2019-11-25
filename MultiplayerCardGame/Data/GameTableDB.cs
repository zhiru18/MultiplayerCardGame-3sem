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
    public class GameTableDB : IGameTableDBIF {
        private string conString;
        public GameTableDB() {
            conString = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        }

        public void Delete(GameTable table) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "DELETE FROM GameTable WHERE id = @id;";
                connection.Execute(sql, table);
            }
        }

        public IEnumerable<GameTable> GetAll() {
            using (SqlConnection connection = new SqlConnection(conString)) {
                return connection.Query<GameTable>("SELECT Id, tableName, isFull FROM GameTable").ToList();
            }
        }

        public GameTable GetById(int id) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                return connection.Query<GameTable>("SELECT Id, tableName, isFull FROM GameTable WHERE id = @id", new { id }).SingleOrDefault();
            }
        }

        public void Insert(GameTable table) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "INSERT INTO GameTable (id, tableName, isFull,) VALUES (@id, @tableName, @isFull);";
                connection.Execute(sql, table);
            }
        }

        public void Update(GameTable table) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "UPDATE GameTable SET tableName = @tableName, isFull = @isFull, WHERE id = @id;";
                connection.Execute(sql, table);
            }
        }
    }
}
