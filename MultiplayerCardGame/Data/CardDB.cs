using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Data {
    public class CardDB {
        private string conString;

        public CardDB() {
            conString = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        }
    }
}
