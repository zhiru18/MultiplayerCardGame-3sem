using Server.Controllers.Controller;
using Server.Converters.DataContractConverters;
using Server.DataContracts.DataContracts;
using Server.Model.Model;
using Server.Services.GameService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server.Services.GameService {
    /* This service takes care of creating, starting and getting games out of the database
     */
    public class GameService : IGameService {
        GameController gameCtrl = new GameController();

        public void CreateGame(Game game) {
            if (game == null) {
                throw new ArgumentNullException();
            } else {
                gameCtrl.CreateGame(game);
            }
        }

        public Game StartGame(GameTable gameTable) {
            if (gameTable == null) {
                throw new ArgumentNullException();
            } else {
                return gameCtrl.StartGame(gameTable);
            }
        }

        public Game GetByTableId(int tableId) {
            if (tableId == 0) {
                throw new ArgumentException();
            } else {
                Game game = GameConverter.ConvertFromGameModelToGame(gameCtrl.GetByTableId(tableId));
                return game;
            }
        }
        
    }
}
