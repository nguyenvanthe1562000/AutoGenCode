using DAL.GenerationCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GenarationCode
{
    public class BLLGenerateBusinessInterface
    {
        DALBusinessInterface _dALBusinessInterface;
        public BLLGenerateBusinessInterface()
        {
            _dALBusinessInterface = new DALBusinessInterface();
        }
        public string GenerateBLLInterface(string nameSpace, string nameTable, Dictionary<string, List<string>> model)
        {

            return _dALBusinessInterface.GenerateBLLInterface(nameSpace, nameTable, model);
        }
     
    }
}
