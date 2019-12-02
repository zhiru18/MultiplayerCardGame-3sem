using Server.Data.Data;
using Server.DataContracts.DataContracts;
using Server.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Converters.DataContractConverters {
    public class GameTableConverter {
 
        public static GameTableModel ConvertFromGameTableToGameTableModel(GameTable gameTable) {
            GameTableModel gameTableModel = new GameTableModel() {
                DeckId = gameTable.Deck.Id,
                Id = gameTable.Id,
                IsFull = gameTable.IsFull,
                TableName = gameTable.TableName
            };
            return gameTableModel;
        }
        public static GameTable ConvertFromGameTableModelToGameTable(GameTableModel tableModel) {
            CGUserDB cGUserDB = new CGUserDB();
            DeckDB deckDB = new DeckDB();
            GameTable gameTable = new GameTable() {
                Id = tableModel.Id,
                IsFull = tableModel.IsFull,
                TableName = tableModel.TableName,
                Users = CGUserConverter.ConvertFromListOfCGUserModelToListOfCGUser(cGUserDB.GetUserByTableId(tableModel.Id)),
                Deck = DeckConverter.ConvertFromDeckModelToDeck(deckDB.GetById(tableModel.DeckId))
            };
            return gameTable;
        }
    }
}
