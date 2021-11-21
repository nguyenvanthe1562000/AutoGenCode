using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public  class ConvertTypeSqlToAngular
    { 
        public static string Convert(string dataType)
        {
            if (dataType.ToLower().Contains("varchar")
               || dataType.ToLower().Contains("nvarchar")
               || dataType.ToLower().Contains("char")
               || dataType.ToLower().Contains("nchar")
               || dataType.ToLower().Contains("varbinary")
               || dataType.ToLower().Contains("text")
               || dataType.ToLower().Contains("xml"))
            {
                dataType = "string";
            }
            else if (dataType.ToLower().Contains("bit"))
            {
                dataType = "boolean ";
            }
            else if (dataType.ToLower().Contains("float"))
            {
                dataType = "string";
            }
            else if (dataType.ToLower().Contains("bigint")|| dataType.ToLower().Contains("int"))
            {
                dataType = "number";
            }
            else if (dataType.ToLower().Contains("date") || dataType.ToLower().Contains("datetime"))
            {
                dataType = "DateTime";
            }
            return dataType;
        }
    }
}
