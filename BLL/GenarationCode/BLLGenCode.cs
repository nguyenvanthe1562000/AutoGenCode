using DAL.GenerationCode;
using System.Collections.Generic;

namespace BLL.GenarationCode
{
    public  class BLLGenCode
    {
        DALGenCode _dALGenCode;
        public BLLGenCode()
        {
            _dALGenCode = new DALGenCode();
        }
        public string Generate(string nameSpace, string nameTable, Dictionary<string, List<string>> model,string language, string layer,List<string> listTable,out string msgError)
        {
            msgError = "";
            return _dALGenCode.Generate(nameSpace, nameTable, model, language, layer, listTable, out msgError);
        }
        //entitycsharp
       

    }
}
