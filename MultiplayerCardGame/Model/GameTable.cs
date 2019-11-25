using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model.Model{
    public class GameTable {
        public int Id { get; set; }
        public bool IsFull { get; set;}
        public string TableName { get; set;}
        public List<CGUser> Users { get; set; }
        //public Deck Deck { get; set; }

        public GameTable(string tableName) {
            this.TableName = tableName;
            this.Users = new List<CGUser>();
        }

    }
}
