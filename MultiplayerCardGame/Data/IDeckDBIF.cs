using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Model.Model;

namespace Server.Data.Data {
    public interface IDeckDBIF : IGeneralDBIF<DeckModel> {
       DeckModel GetById(int id);
    }
}
