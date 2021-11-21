using DAL.ConfigCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GenarationCode
{
    public class BLLGenerateBLL
    {
       
        public BLLGenerateBLL()
        {
            _dALBusiness = new DALBusiness();
        }
        public string GenerateBLL(string nameSpace, string className, Dictionary<string, List<string>> model)
        {

            return _dALBusiness.GenerateBLL(nameSpace, className, model);
        } 
      
    }
}
