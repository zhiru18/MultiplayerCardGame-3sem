using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGameClient.Models
{
    public class Game
    {
        public int Id { get; set; }
        public GameTable gameTable { get; set; }

        public Game(GameTable gameTable)
        {
            this.gameTable = gameTable;
        }

        public Game() {
        }
    }
}