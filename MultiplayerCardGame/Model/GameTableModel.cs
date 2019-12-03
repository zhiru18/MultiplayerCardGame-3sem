using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model.Model {
    public class GameTableModel {
        public int Id { get; set; }
        public int seats { get; set; }
        public string TableName { get; set; }
        public int DeckId { get; set; }

        public GameTableModel(string tableName) {
            this.TableName = tableName;
        }

        public GameTableModel(string tableName, int deckId) {
            this.TableName = tableName;
            this.DeckId = deckId;
        }

        public GameTableModel() {
        }
    }
}
