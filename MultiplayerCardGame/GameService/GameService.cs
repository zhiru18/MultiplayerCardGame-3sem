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

    public class GameService : IGameService {
        GameController gameCtrl = new GameController();

        public void CreateGame(Game game) {
            gameCtrl.CreateGame(game);
        }

        public Game StartGame(GameTable gameTable) {
           return gameCtrl.StartGame(gameTable);
        }

        public Game GetByTableId(int tableId) {
            Game game = GameConverter.ConvertFromGameModelToGame(gameCtrl.GetByTableId(tableId));
            return game;
        }
        
    }
}
