using Server.Data.Data;
using Server.DataContracts.DataContracts;
using Server.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Converters.DataContractConverters {
    class GameConverter {
        public static GameModel ConvertFromGameToGameModel(Game game) {
            GameModel gameModel = new GameModel() {
                Id = game.Id,
                GameTableId = game.gameTable.Id
            };
            return gameModel;
        }

        public Game ConvertFromGameModelToGame(GameModel gameModel) {
            IGameTableDBIF gameTableDB = new GameTableDB();
            GameTableModel gameTableModel = gameTableDB.GetById(gameModel.GameTableId);
            Game game = new Game() {
                Id = gameModel.Id,
                gameTable = GameTableConverter.ConvertFromGameTableModelToGameTable(gameTableModel)
            };
            return game;
        }
    }
}
