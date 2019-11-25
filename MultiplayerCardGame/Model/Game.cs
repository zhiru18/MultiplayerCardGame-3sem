using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model.Model {
    [DataContract]
    public class Game {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public GameTable gameTable { get; set; }

        public Game(int id, GameTable gameTable) {
            this.Id = id;
            this.gameTable = gameTable; 
        }

        public Game(GameTable gameTable) {
            this.gameTable = gameTable;
        }
    }
}
