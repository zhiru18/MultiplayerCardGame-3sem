using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data.Data {
    interface IGeneralDBIF<T> {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        IEnumerable<T> GetAll();
    }
}
