using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GenerationCode.CustomExtension
{
    class EntityCsharp
    {
        public string GenEntity(List<string> tableName)
        {
            string entity = string.Empty;
            
                for (int i = 0; i < tableName.Count; i++)
                {
                    entity += string.Format("\n\tpublic virtual DbSet<{0}Model> {0}s {{ get; set; }}", tableName[i]);
                }

            return  entity;
        }
      
    }
}
