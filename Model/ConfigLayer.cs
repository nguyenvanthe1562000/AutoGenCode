using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ConfigLayer
    {
        public string Language { get; set; }//ngôn ngữ lập trình
        public string Layer { get; set; }//các tầng của mô hình
        public ConfigMethod Method { get; set; }

        public override string ToString()//để hiển thị ở combobox config
        {
            return Language + "-" + Layer;
        }
    }

}
