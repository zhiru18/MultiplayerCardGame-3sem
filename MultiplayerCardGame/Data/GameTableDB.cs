﻿using System;
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
        private string conString;
        public GameTableDB() {
              //conString = "data Source=.; dataBase= CardGameDB; integrated security= true";
            //conString = "Server=tcp:cardgameucn.database.windows.net,1433;Initial Catalog=CardGameDB;Persist Security Info=False;User ID=gameadmin;Password=Bamsesjul1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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

        //public int GetGameTableSeats(GameTableModel table) {
        //    var updateString = "SELECT seats FROM GameTable WHERE id = @id;";
        //    using (SqlConnection connection = new SqlConnection(conString)) {
        //        using (SqlCommand updateCommand = new SqlCommand(updateString, connection)) {
        //            updateCommand.Parameters.AddWithValue("@id", table.Id);
        //            connection.Open();
        //            return (int)updateCommand.ExecuteScalar();
        //        }
        //    }
        //}
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
        //public void UpdateGameTableSeats(GameTableModel table, int seats) {
        //    var updateString = "UPDATE GameTable SET seats = seats - @seats WHERE id = @id;";
        //    using (SqlConnection connection = new SqlConnection(conString)) {
        //        using (SqlCommand updateCommand = new SqlCommand(updateString, connection)) {
        //            updateCommand.Parameters.AddWithValue("@seats", seats);
        //            updateCommand.Parameters.AddWithValue("@id", table.Id);
        //            connection.Open();
        //            updateCommand.ExecuteNonQuery();
        //        }
        //    }
        //}
        public void UpdateGameTableSeats(GameTableModel table, int seats) {
            var sql = "UPDATE GameTable SET seats = seats - @seats WHERE id = @id;";
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Execute(sql, new { id = table.Id, seats = seats });
            }
        }
    }
}
