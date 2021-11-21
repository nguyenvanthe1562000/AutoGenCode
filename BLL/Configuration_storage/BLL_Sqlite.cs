using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Log_User;
namespace BLL.Configuration_storage
{
    public class BLL_Sqlite
    {
        DAL_Sqlite _DAL_Create;
        public void Create_Configuration()
        {
            _DAL_Create=new DAL_Sqlite();
        }
    } 
}
