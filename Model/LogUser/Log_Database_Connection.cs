using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Log_DataBase_Connection
    {
        public string password_e { get; set; }
        public string username_e { get; set; }
        public string servername_e { get; set; }
        public override string ToString()
        {
            return servername_e;
        }
    }
}
