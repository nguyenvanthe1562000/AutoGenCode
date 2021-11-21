using DAL.ConfigCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GenarationCode
{
    public class BLLGenerateModel
    {
        DALModel _model;
        public BLLGenerateModel()
        {
            _model = new DALModel();
        }
        public string GenerateModel(string nameSpace, string nameTable, Dictionary<string,List<string>> model)
        {
            return _model.GenerateModel(nameSpace, nameTable, model);
        }
    }
}
