using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model.Model {
    public class GameModel {
        public int Id { get; set; }
        public int GameTableId { get; set; }

        public GameModel(int gameTableId) {
            this.GameTableId = gameTableId;
        }
        public GameModel() {

        }
    }
}
