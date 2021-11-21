using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class GetFieldSql
    {
        public static string Convert(string dataType, string dataLength, string fieldName, char keyWord, string language)
        {
            if (language.Equals(Layer.LANGUAGESQL))
            {
                if (string.IsNullOrEmpty(dataLength))
                {
                    return string.Format("{0}#{1}#{2}", dataType, fieldName, keyWord);
                }
                return string.Format("{0}({1})#{2}#{3}", dataType, dataLength.Equals("-1") ? "MAX" : dataLength, fieldName, keyWord);
            }
            else if (language.Equals(Layer.LANGUAGEANGULAR))
            {
                return string.Format("{0}#{1}#{2}", ConvertTypeSqlToAngular.Convert(dataType), fieldName, keyWord);
            }
            else // (language.Equals(Layer.LANGUAGECSHARP))
            {
                return string.Format("{0}#{1}#{2}", ConvertTypeSqlToCSharp.Convert(dataType), fieldName, keyWord);
            }
        }
    }
}
