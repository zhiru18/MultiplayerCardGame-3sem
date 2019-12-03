using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGameClient.Models
{
    public class GameTable
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public List<CGUser> Users { get; set; }
        public Deck Deck { get; internal set; }

        //public Deck Deck { get; set; }

        public GameTable(string tableName)
        {
            this.TableName = tableName;
            this.Users = new List<CGUser>();
        }

        public GameTable() {
        }
    }
}