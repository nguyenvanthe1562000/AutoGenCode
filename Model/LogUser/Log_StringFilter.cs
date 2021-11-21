using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.LogUser
{
    public class Log_StringFilter
    {
        public string StringFilter { get; set; }
        public string Language { get; set; }
        public string Layer { get; set; }
        public Log_StringFilter(string language, string layer, string stringFIlter)
        {
            this.Language = language;
            this.Layer = layer;
            this.StringFilter = stringFIlter;
        }

    }
}
