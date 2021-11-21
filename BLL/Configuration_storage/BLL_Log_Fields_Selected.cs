using DAL.Log_User;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Configuration_storage
{
    public class BLL_Log_Fields_Selected
    {
        DAL_Log_Fields_Selected _Log_Fields_Selected;
        
        public BLL_Log_Fields_Selected()
        {
            _Log_Fields_Selected = new DAL_Log_Fields_Selected();
            _getTable = _Log_Fields_Selected.loadData();
        }
        DataTable _getTable;
        /// <summary>
        /// return dataset of Log_Fields_Selected
        /// </summary>
        /// <returns></returns>

        public List<DataRow> Table(string db, string tb)
        {
            string filter = string.Format("database_e='{0}' and table_e='{1}'", db, tb);
            List<DataRow> table = _getTable.Select(filter).ToList();
            return table;
        }
        public void Save(List<Log_Fields_Selected> lst)
        {
            if (lst.Count == 0)
            {
                return;
            }
            string filter = string.Format("database_e='{0}' and table_e='{1}'", lst[0].database_e, lst[0].table_e);
            DataTable table = _getTable;
            
            bool flag = true;
            int start = 0;
            int end = 0;
            // for tìm vị trí row có database và tên bảng trùng.
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i]["database_e"].Equals(lst[0].database_e) && table.Rows[i]["table_e"].Equals(lst[0].table_e) && start==0)
                {
                    start = i;
                }
                else if (table.Rows[i]["database_e"].Equals(lst[lst.Count - 1].database_e) && table.Rows[i]["table_e"].Equals(lst[lst.Count - 1].table_e) && table.Rows[i]["fields_e"].Equals(lst[lst.Count - 1].fields_e))
                {
                    end = i;
                    break;
                }
            }
            if (start > 0)
            {
                start = start - 1;
            }

            for (int i = 0; i < lst.Count; i++)
            {
                flag = true;
                if (table.Rows.Count > 0)
                {
                for (int j = start; j <= end; j++)
                {
                    string a = table.Rows[j]["fields_e"].ToString();
                    string b = lst[i].fields_e.ToString();
                    if (string.Compare(table.Rows[j]["fields_e"].ToString(), lst[i].fields_e.ToString(), true) == 0)
                    {
                        table.Rows[j]["database_e"] = lst[i].database_e;
                        table.Rows[j]["table_e"] = lst[i].table_e;
                        table.Rows[j]["fields_e"] = lst[i].fields_e;
                        table.Rows[j]["models_e"] = lst[i].models_e;
                        table.Rows[j]["delete_e"] = lst[i].delete_e;
                        table.Rows[j]["insert_e"] = lst[i].insert_e;
                        table.Rows[j]["getAll_e"] = lst[i].getAll_e;
                        table.Rows[j]["update_e"] = lst[i].update_e;
                        table.Rows[j]["search_e"] = lst[i].search_e;
                        table.Rows[j]["saveFromList_e"] = lst[i].saveFromList_e;
                        table.Rows[j]["dropdown_e"] = lst[i].dropdown_e;
                        table.Rows[j]["getById_e"] = lst[i].getById_e;
                        flag = false;
                    }

                }

                }
                if (flag)
                {
                    DataRow newRow = table.NewRow();
                    newRow["database_e"] = lst[i].database_e;
                    newRow["table_e"] = lst[i].table_e;
                    newRow["fields_e"] = lst[i].fields_e;
                    newRow["models_e"] = lst[i].models_e;
                    newRow["delete_e"] = lst[i].delete_e;
                    newRow["insert_e"] = lst[i].insert_e;
                    newRow["getAll_e"] = lst[i].getAll_e;
                    newRow["update_e"] = lst[i].update_e;
                    newRow["search_e"] = lst[i].search_e;
                    newRow["dropdown_e"] = lst[i].dropdown_e;
                    newRow["getById_e"] = lst[i].getById_e;
                    table.Rows.Add(newRow);
                }
            }

            _Log_Fields_Selected.Save(_getTable);
        }
    }
}
