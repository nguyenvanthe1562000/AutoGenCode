using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_AccessDb
    {
        DAL_AccessDb DAL;
        public BLL_AccessDb()
        {
            DAL = new DAL_AccessDb();
        }
        public string ConnectDb(string str)
        {
            return DAL.ConnectDb(str);
        }
     
    }
}
