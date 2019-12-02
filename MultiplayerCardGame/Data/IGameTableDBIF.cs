using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Model.Model;

namespace Server.Data.Data {
    public interface IGameTableDBIF : IGeneralDBIF<GameTableModel> {
        GameTableModel GetById(int id);
        GameTableModel GetGameTableByTableName(string name);

        void UpdateGameTableSeats(GameTableModel table, int seats);
        int GetGameTableSeats(GameTableModel table);
    }
}
