using DAL.GenerationCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GenarationCode
{
    public class BLLGenerateApi
    {
        DALGenCode _dALGenCode;
        public BLLGenerateApi()
        {
            _dALGenCode = new DALGenCode();
        }
        public string Generate(string nameSpace, string nameTable, Dictionary<string, List<string>> model,string layer)
        {
            return _dALGenCode.Generate(nameSpace, nameTable, model, layer);
        }
     
    }
}
