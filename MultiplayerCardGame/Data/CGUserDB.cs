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
            conString = "Data Source=.\\SQLExpress;Initial Catalog=CardGameDB;Integrated Security=True";
            //conString = ConfigurationManager.ConnectionStrings["con"].ConnectionString; 
        }
        public void Delete(CGUser user) {
            throw new NotImplementedException();
        }

        public IEnumerable<CGUser> GetAll() {
            using (SqlConnection connection = new SqlConnection(conString)) {
                return connection.Query<CGUser>("SELECT Id, userName, email, UserPassword, userType, UserStatus FROM CGUser").ToList();
            }
        }

        public CGUser GetById(string id) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                return connection.Query<CGUser>("SELECT Id, userName, email, UserPassword, userType, UserStatus FROM CGUser WHERE id = @id", new { id }).SingleOrDefault();
            }
        }

        public CGUser GetUserByUsername(string userName) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                return connection.Query<CGUser>("SELECT Id, userName, email, UserPassword, userType, UserStatus FROM CGUser WHERE userName = @userName", new { userName }).SingleOrDefault();
            }
        }

        public void Insert(CGUser user) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "INSERT INTO CGUser (id, userName, email, userPassword, userType, userStatus) VALUES (@id, @userName, @email, @userPassword, @userType, @userStatus);";
                connection.Execute(sql, user);
            }
        }

        public void Update(CGUser user) {
            using (SqlConnection connection = new SqlConnection(conString)) {
                var sql = "UPDATE CGUser SET userName = @userName, email = @email, userPassword = @userPassword, userType = @userType, userStatus = @userStatus WHERE id = @id;";
                connection.Execute(sql, user);
            }
        }
    }
}
