using Server.Data.Data;
using Server.DataContracts.DataContracts;
using Server.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Converters.DataContractConverters {
    /*This class converts GameTableModel objects to the equivalent datacontract
     * and vice versa
       */
    public class GameTableConverter {
 
        public static GameTableModel ConvertFromGameTableToGameTableModel(GameTable gameTable) {
            GameTableModel gameTableModel = new GameTableModel() {
                DeckId = gameTable.Deck.Id,
                Id = gameTable.Id,
                seats = gameTable.seats,
                TableName = gameTable.TableName
            };
            return gameTableModel;
        }
        public static GameTable ConvertFromGameTableModelToGameTable(GameTableModel tableModel) {
            CGUserDB cGUserDB = new CGUserDB();
            DeckDB deckDB = new DeckDB();
            GameTable gameTable = new GameTable() {
                Id = tableModel.Id,
                seats = tableModel.seats,
                TableName = tableModel.TableName,
                Users = CGUserConverter.ConvertFromListOfCGUserModelToListOfCGUser(cGUserDB.GetUserByTableId(tableModel.Id)),
                Deck = DeckConverter.ConvertFromDeckModelToDeck(deckDB.GetById(tableModel.DeckId))
            };
            return gameTable;
        }
        public static List<GameTable> ConvertFromListOfGameTableModelToListOfGameTable(List<GameTableModel> gameTableModels) {
            List<GameTable> gameTables = new List<GameTable>();
            foreach (GameTableModel gameTableModel in gameTableModels) {
                GameTable gameTable = GameTableConverter.ConvertFromGameTableModelToGameTable(gameTableModel);
                gameTables.Add(gameTable);
            }
            return gameTables;
        }
    }
}
