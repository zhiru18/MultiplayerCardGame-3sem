using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopGameClient.Models
{
    public class GameTableModel
    {
        public int Id { get; set; }
        public int seats { get; set; }
        public string TableName { get; set; }
        public List<CGUserModel> Users { get; set; }    
        public GameTableModel(string tableName){
            this.TableName = tableName;
        }
  

        public GameTableModel(){
        }

        public override string ToString()
        {
            return $"{Id}  {TableName} Players:{Users.Count}"; 
        }
    }
}
