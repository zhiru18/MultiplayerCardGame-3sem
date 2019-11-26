using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model.Model{
    [DataContract]
    public class GameTable {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public bool IsFull { get; set;}
        [DataMember]
        public string TableName { get; set;}
        [DataMember]
        public List<CGUser> Users { get; set; }

        public int deckId { get; set; }
        [DataMember]

        public Deck Deck { get; set; }
     

        public GameTable(string tableName) {
            this.TableName = tableName;
            this.Users = new List<CGUser>();
            this.Deck = new Deck();
        }

        public GameTable(int id, string tableName, bool isfull, int deckId) {
            this.Id = id;
            this.TableName = tableName;
            this.IsFull = isfull;
            this.Users = new List<CGUser>();
            this.Deck = new Deck();
            this.Deck.Id = deckId;
        }

        public GameTable() {
            this.Users = new List<CGUser>();
            this.Deck = new Deck();
        }
    }
}
