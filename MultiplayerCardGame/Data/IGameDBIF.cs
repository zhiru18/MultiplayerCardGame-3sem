using Server.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Data {
    public interface IGameDBIF : IGeneralDBIF<GameModel>{

        GameModel GetByTableId(int tableId);
    }
}
