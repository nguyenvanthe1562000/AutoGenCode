using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.extension
{
    class EntityCsharp
    {
        public async Task<string> GenEntity(List<string> tableName)
        {
            string entity = string.Empty;
            await Task.Run(() => {
                for (int i = 0; i <= tableName.Count; i++)
                {
                    entity += string.Format("\n\tpublic virtual DbSet<{0}Model> {0}s {{ get; set; }}", tableName);
                }

            });
            return  entity;
        }
      
    }
}
