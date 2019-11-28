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
        private string conString;
        public GameTableDB() {
              //conString = "data Source=.; dataBase= CardGameDB; integrated security= true";
              conString = "Server=tcp:cardgameucn.database.windows.net,1433;Initial Catalog=CardGameDB;Persist Security Info=False;User ID=gameadmin;Password=Bamsesjul1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //conString = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        }

        public void Delete(GameTable table) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                var sql = "DELETE FROM GameTable WHERE id = @id;";
                connection.Execute(sql, table);
            }
        }

        //deck og users vil være tomme i alle GameTables
        public IEnumerable<GameTable> GetAll() {
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                return connection.Query<GameTable>("SELECT Id, tableName, isFull, deckId FROM GameTable").ToList();
            }
        }

        public GameTable GetById(int id) {
            IDeckDBIF deckDB = new DeckDB();
            ICGUserDBIF userDB = new CGUserDB();
            GameTable table = new GameTable();
            try {
                using (TransactionScope scope = new TransactionScope()) { 
                using (SqlConnection connection = new SqlConnection(conString)) {
                    connection.Open();
                    table = connection.Query<GameTable>("SELECT Id, tableName, isFull,deckId FROM GameTable WHERE id = @id", new { id }).SingleOrDefault();
                    table.Deck = deckDB.GetById(table.deckId);
                    table.Users = userDB.GetUserByTableId(id);
                        scope.Complete();
                }
            }
            }catch(TransactionAbortedException tae) {
                //maybe throw our own exception here to catch further up 
            }
            return table;
        }

        public GameTable GetGameTableByTableName(string tableName) {
            IDeckDBIF deckDB = new DeckDB();
            ICGUserDBIF userDB = new CGUserDB();
            GameTable table = new GameTable();
            try {
                using (TransactionScope scope = new TransactionScope()) {
                    using (SqlConnection connection = new SqlConnection(conString)) {
                        connection.Open();
                        table = connection.Query<GameTable>("SELECT Id, tableName, isFull,deckId FROM GameTable WHERE tableName = @tableName", new { tableName }).SingleOrDefault();
                        table.Deck = deckDB.GetById(table.deckId);
                        table.Users = userDB.GetUserByTableId(table.Id);
                        scope.Complete();
                        
                    }
                }
            }catch(TransactionAbortedException tae) {
                //maybe thorw our own exception
            }
            return table;
        }

        //insert the gametable without Deck
        //public void Insert(GameTable table) {
        //    using (SqlConnection connection = new SqlConnection(conString)) {
        //        connection.Open();
        //        var sql = "INSERT INTO GameTable (tableName, isFull) VALUES (@tableName, @isFull);";
        //        connection.Execute(sql, table);
        //    }
        //}

        //insert the gametable with Deck
        public void Insert(GameTable table) {
            string insertString = "INSERT INTO GameTable (tableName, isFull, deckId) VALUES (@TableName, @IsFull, @DeckId)";
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand createCommand = new SqlCommand(insertString, connection)) {
                SqlParameter tableNameParam = new SqlParameter("@TableName", table.TableName);
                createCommand.Parameters.Add(tableNameParam);
                SqlParameter isFullParam = new SqlParameter("@IsFull", table.IsFull);
                createCommand.Parameters.Add(isFullParam);
                SqlParameter deckIdParam = new SqlParameter("@DeckId", table.Deck.Id);
                createCommand.Parameters.Add(deckIdParam);
                connection.Open();
                createCommand.ExecuteNonQuery();
            }
        }

        public void Update(GameTable table) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                var sql = "UPDATE GameTable SET tableName = @tableName, isFull = @isFull  WHERE id = @id;";
                connection.Execute(sql, table);
            }
        }       
    }
}
