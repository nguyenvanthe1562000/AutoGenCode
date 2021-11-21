using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Log_User;
using Model;
namespace BLL.Configuration_storage
{
    public class BLL_Log_Database_Connection
    {
        DAL_Log_Database_Connection _DAL;
        public BLL_Log_Database_Connection()
        {
            _DAL = new DAL_Log_Database_Connection();
        }
        public void Save(string server, string username, string pass, bool _rememberpass)
        {
            Log_DataBase_Connection db = new Log_DataBase_Connection();
            db.servername_e = server;
            db.username_e = string.IsNullOrWhiteSpace(username) ? " " : username;
            db.password_e = _rememberpass == true ? pass : "";
            _DAL.Save(db);
        }
        public List<Log_DataBase_Connection> Load()
        {
            return _DAL.loadData();
        }
    }
}
