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

namespace Server.Data.Data {
    public class CGUserDB : ICGUserDBIF {
        private string conString;

        public CGUserDB() {
            //conString = "Server=tcp:cardgameucn.database.windows.net,1433;Initial Catalog=CardGameDB;Persist Security Info=False;User ID=gameadmin;Password=Bamsesjul1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            conString = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        }
        public void Delete(CGUserModel user) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "DELETE FROM CGUser WHERE id = @id;";
                connection.Execute(sql, user);
            }
        }

        public IEnumerable<CGUserModel> GetAll() {
            using (SqlConnection connection = new SqlConnection(conString)) {
                return connection.Query<CGUserModel>("SELECT Id, userName, email, userType, UserStatus FROM CGUser").ToList();
            }
        }

        public CGUserModel GetById(string id) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                return connection.Query<CGUserModel>("SELECT Id, userName, email, userType, UserStatus FROM CGUser WHERE id = @id", new { id }).SingleOrDefault();
            }
        }

        public CGUserModel GetUserByEmail(string email) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                return connection.Query<CGUserModel>("SELECT Id, userName, email, userType, UserStatus FROM CGUser WHERE email = @email", new { email }).SingleOrDefault();
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
                return (List<CGUserModel>)connection.Query<CGUserModel>("SELECT Id, userName, email, userType, UserStatus FROM CGUser WHERE tableId = @id", new { id });
            }
        }

        public void UpdateUserTableId(CGUserModel user, int tableId) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "UPDATE CGUser SET tableId = @tableId WHERE id = @id;";
                connection.Execute(sql, new { id = user.Id, tableId });
            }
        }

        /*
        public void UpdateUserTableId(CGUserModel user, int tableId) {
            string sql = "UPDATE CGUser SET tableId = @tableId WHERE id = @id;";
            using (SqlConnection connection = new SqlConnection(conString)) {
                using(SqlCommand command = connection.CreateCommand()) {
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@tableId", tableId);
                    command.Parameters.AddWithValue("@id", user.Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }*/

        public int GetUserTableId(string id) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                return connection.Query<int>("SELECT tableId FROM CGUser WHERE id = @id", new { id }).SingleOrDefault();
            }
        }

    }
}
