using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ConvertTypeSqlToCSharp
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
                dataType = "bool";
            }
            else if (dataType.ToLower().Contains("float"))
            {
                dataType = "double";
            }
            else if (dataType.ToLower().Contains("bigint"))
            {
                dataType = "int";
            }
	else if (  dataType.ToLower().Contains("numeric") || dataType.ToLower().Contains("decimal"))
            {
                dataType = "decimal";
            }
            else if (dataType.ToLower().Contains("date") || dataType.ToLower().Contains("datetime"))
            {
                dataType = "DateTime";
            }
            return dataType;
        }
    }
}
