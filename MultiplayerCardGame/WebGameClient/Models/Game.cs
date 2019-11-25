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

        public Game(int id, GameTable gameTable)
        {
            this.Id = id;
            this.gameTable = gameTable;
        }
    }
}