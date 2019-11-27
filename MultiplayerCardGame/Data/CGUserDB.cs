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
            conString = "Server=tcp:cardgameucn.database.windows.net,1433;Initial Catalog=CardGameDB;Persist Security Info=False;User ID=gameadmin;Password=Bamsesjul1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //conString = ConfigurationManager.ConnectionStrings["Con"].ConnectionString; 
        }
        public void Delete(CGUser user) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "DELETE FROM CGUser WHERE id = @id;";
                connection.Execute(sql, user);
            }
        }

        public IEnumerable<CGUser> GetAll() {
            using (SqlConnection connection = new SqlConnection(conString)) {
                return connection.Query<CGUser>("SELECT Id, userName, email, userType, UserStatus FROM CGUser").ToList();
            }
        }

        public CGUser GetById(string id) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                return connection.Query<CGUser>("SELECT Id, userName, email, userType, UserStatus FROM CGUser WHERE id = @id", new { id }).SingleOrDefault();
            }
        }

        public CGUser GetUserByEmail(string email) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                return connection.Query<CGUser>("SELECT Id, userName, email, userType, UserStatus FROM CGUser WHERE email = @email", new { email }).SingleOrDefault();
            }
        }

        public void Insert(CGUser user) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "INSERT INTO CGUser (id, userName, email, userType, userStatus) VALUES (@id, @userName, @email, @userType, @userStatus);";
                connection.Execute(sql, user);
            }
        }

        public void Update(CGUser user) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "UPDATE CGUser SET userName = @userName, email = @email, userType = @userType, userStatus = @userStatus WHERE id = @id;";
                connection.Execute(sql, user);
            }
        }
        public List<CGUser> GetUserByTableId(int id) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                return (List<CGUser>)connection.Query<CGUser>("SELECT Id, userName, email, userType, UserStatus FROM CGUser WHERE tableId = @id", new { id });
            }
        }
        public void UpdateUserTableId(CGUser user, int tableId) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "UPDATE CGUser SET tableId = @tableId WHERE id = @id;";
                connection.Execute(sql, user);
            }
        }
    }
}
