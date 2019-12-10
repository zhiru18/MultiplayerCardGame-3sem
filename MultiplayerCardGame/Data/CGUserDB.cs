using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Model.Model;
using System.Configuration;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace Server.Data.Data {
    public class CGUserDB : ICGUserDBIF {
        /* This class is used to access the database,
         * in particular it takes care of everything that has to do with with the CGUser table
         */
        private string conString;
        private string clientConString;

        public CGUserDB() {
            conString = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
            clientConString = ConfigurationManager.ConnectionStrings["ClientConnection"].ConnectionString;
        }
        public void Delete(CGUserModel user) {
            using (TransactionScope scope = new TransactionScope()) {
                using (SqlConnection connection1 = new SqlConnection(conString)) {
                    var sql = "DELETE FROM CGUser WHERE id = @id;";
                    connection1.Execute(sql, user);

                    using (SqlConnection connection2 = new SqlConnection(clientConString)) {
                        var sqlClient = "Delete FROM AspNetUsers WHERE id = @id;";
                        connection2.Execute(sqlClient, user);
                    }
                }
                scope.Complete();
            }
        }

        public IEnumerable<CGUserModel> GetAll() {
            using (SqlConnection connection = new SqlConnection(conString)) {
                return connection.Query<CGUserModel>("SELECT Id, userName, email, userType, tableId, UserStatus FROM CGUser").ToList();
            }
        }

        public CGUserModel GetById(string id) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                return connection.Query<CGUserModel>("SELECT Id, userName, email, userType, tableId, UserStatus FROM CGUser WHERE id = @id", new { id }).SingleOrDefault();
            }
        }

        public CGUserModel GetUserByEmail(string email) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                return connection.Query<CGUserModel>("SELECT Id, userName, email, userType, tableId, UserStatus FROM CGUser WHERE email = @email", new { email }).SingleOrDefault();
            }
        }

        public void Insert(CGUserModel user) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "INSERT INTO CGUser (id, userName, email, userType, userStatus) VALUES (@id, @userName, @email, @userType, @userStatus);";
                connection.Execute(sql, user);
            }
        }

        public void Update(CGUserModel user) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "UPDATE CGUser SET userName = @userName, email = @email, userType = @userType, userStatus = @userStatus WHERE id = @id;";
                connection.Execute(sql, user);
            }
        }

        public List<CGUserModel> GetUserByTableId(int id) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                return (List<CGUserModel>)connection.Query<CGUserModel>("SELECT Id, userName, email, userType, tableId, UserStatus FROM CGUser WHERE tableId = @id", new { id });
            }
        }

        public void UpdateUserTableId(CGUserModel user, int tableId) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "UPDATE CGUser SET tableId = @tableId WHERE id = @id;";
                connection.Execute(sql, new { id = user.Id, tableId });
            }
        }
        public int GetUserTableId(string id) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                return connection.Query<int>("SELECT tableId FROM CGUser WHERE id = @id", new { id }).SingleOrDefault();
            }
        }
        public void InsertHand(List<CardModel> cards, CGUserModel user) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "Insert into CardUser (cgUser_id , card_id) VALUES (@id, @cardId)";
                foreach (var card in cards) {
                    connection.Execute(sql, new { id = user.Id, cardId = card.Id });
                }
            }
        }
        public void DeleteHand(CGUserModel userModel) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "DELETE FROM CardUser WHERE cguser_id = @id";
                    connection.Execute(sql, userModel);
            }
        }

        public CGUserModel GetByUserName(string userName) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                return connection.Query<CGUserModel>("SELECT Id, userName, email, userType, tableId, UserStatus FROM CGUser WHERE userName = @userName", new { userName }).SingleOrDefault();
            }
        }

        public void UpdateTableSeats(CGUserModel user, int amount) {
            IGameTableDBIF gameTableDB = new GameTableDB();
            GameTableModel gameTable = gameTableDB.GetById(user.TableID);
            if (gameTable != null) {
                gameTableDB.UpdateGameTableSeats(gameTable, amount);
            }
        }
    }
}
