using DAL.GenerationCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GenarationCode
{
  public  class BLLGenerateStoreProcedure
    {
        DALStoreProcedure _dALStoreProcedure;
        public BLLGenerateStoreProcedure()
        {
            _dALStoreProcedure = new DALStoreProcedure();
        }
        public string GenerateStoreProcedure(string nameSpace, string nameTable, Dictionary<string, List<string>> model)
        {
            return _dALStoreProcedure.GenerateStoreProcedure(nameSpace, nameTable, model);
        }

    }
}
