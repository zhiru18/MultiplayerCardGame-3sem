using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;
using Server.Model.Model;

namespace Server.Data.Data {
    public class GameTableDB : IGameTableDBIF {
        /* This class is used to access the database,
         * in particular it takes care of everything that has to do with with the GameTable table
         */
        private string conString;
        public GameTableDB() {
            conString = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        }

        public void Delete(GameTableModel table) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                var sql = "DELETE FROM GameTable WHERE id = @id;";
                connection.Execute(sql, table);
            }
        }


        public IEnumerable<GameTableModel> GetAll() {
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                return connection.Query<GameTableModel>("SELECT Id, tableName, seats, deckId FROM GameTable").ToList();
            }
        }

        public GameTableModel GetById(int id) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                return connection.Query<GameTableModel>("SELECT Id, tableName, seats,deckId FROM GameTable WHERE id = @id", new { id }).SingleOrDefault();
            }
        }

        public GameTableModel GetGameTableByTableName(string tableName) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                return connection.Query<GameTableModel>("select Id, tableName, seats, deckId from GameTable where tableName = @tableName", new { tableName }).SingleOrDefault();
            }
        }

        public int GetGameTableSeats(GameTableModel table) {
            var sql = "SELECT seats FROM GameTable WHERE id = @id;";
            using (SqlConnection connection = new SqlConnection(conString)) {
                return connection.Query<int>(sql, table).SingleOrDefault();
            }
        }
        public void Insert(GameTableModel gameTable) {
        using(SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                var sql = "INSERT INTO GameTable (tableName, seats, deckId) VALUES (@TableName, @seats, @DeckId)";
                connection.Execute(sql, gameTable);
            }
    }
        public void Update(GameTableModel table) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                var sql = "UPDATE GameTable SET tableName = @tableName, seats = @seats  WHERE id = @id;";
                connection.Execute(sql, table);
            }
        }
        public void UpdateGameTableSeats(GameTableModel table, int seats) {
            var sql = "UPDATE GameTable SET seats = seats - @seats WHERE id = @id;";
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Execute(sql, new { id = table.Id, seats = seats });
            }
        }
    }
}
