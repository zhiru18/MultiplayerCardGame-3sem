using Server.Data.Data;
using Server.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Data
{
    public interface ICardDBIF : IGeneralDBIF<CardModel> {
        List<CardModel> GetCardsByUserId(string id);
        List<CardModel> GetCardsByDeckId(int id);
    }
}
