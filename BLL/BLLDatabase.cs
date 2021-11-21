using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLDatabase
    {
        DAL.DAL_get_db_tb_fields get_db_tb;
        public BLLDatabase()
        {

        }
        public List<string> GetDB(string connection)
        {
            get_db_tb = new DAL.DAL_get_db_tb_fields(connection);
            return get_db_tb.GetDB();
        }
        public bool CheckConnect()
        {
            return get_db_tb.checkConnect();
        }
        public List<string> GetTB(string db)
        {
            return get_db_tb.GetTB(db);
        }
        public DataTable GetField(string tb)
        {
            return get_db_tb.get_fields(tb);
        }
        public void ExecuteQuery(string query, out string msgEr)
        {
            msgEr = string.Empty;
            get_db_tb.ExecuteQuery(query, out msgEr);
        }
        public List<string> GetListStoreProcedure(string db)
        {
           return get_db_tb.GetListStoreProcedure(db);
        }
        public string GetStoreProcedureText(int id)
        {
          return  get_db_tb.GetStoreProcedureText(id);
        }
        public DataTable GetStoreProcedureParameter(int id)
        {
          return  get_db_tb.GetStoreProcedureParameter(id);
        }
        public DataSet ExcuteQuery(out string msg, string query)
        {
            msg = "";
            return get_db_tb.ExcuteQuery(out msg,query);
        }
    }
}
