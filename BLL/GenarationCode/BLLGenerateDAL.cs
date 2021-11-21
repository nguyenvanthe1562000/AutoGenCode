using DAL.ConfigCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GenarationCode
{
    public class BLLGenerateDAL
    {
        DALDataAccess _dALDataAccess;
        public BLLGenerateDAL()
        {
            _dALDataAccess = new DALDataAccess();
        }
        public string GenerateDAL(string nameSpace, string nameTable, Dictionary<string, List<string>> model)
        {

            return _dALDataAccess.GenerateDAL(nameSpace, nameTable, model);
        }
    
    }
}
