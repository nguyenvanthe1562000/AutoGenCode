using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Expression
{
    public abstract class ExpressionCommon
    {
        public string NameTable { get; }
        public string Csharp { get; }
        public string Angular { get; }
        public ExpressionCommon()
        {
            NameTable = "{{nametable}}";
            Csharp = "C#";
            Angular = "Angular";
        }

    }
}
