using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Model
{
    public class ConfigMethod 
    {
        public string Insert { get; set; }
        public string Update { get; set; }
        public string Delete { get; set; }
        public string GetById { get; set; }
        public string GetAll { get; set; }
        public string Search { get; set; }
        public string DropDown { get; set; }
        public string saveFromList { get; set; }
        public string Main { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
