using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.LogUser
{
    class Log_PostFixFileName
    {
        public string PostFixFileName { get; set; }
        public string Language { get; set; }
        public string Layer { get; set; }
        public Log_PostFixFileName(string language, string layer, string postFixFileName)
        {
            this.Language = language;
            this.Layer = layer;
            this.PostFixFileName = postFixFileName;
        }
    }
}
