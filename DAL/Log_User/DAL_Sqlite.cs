using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Log_User
{
    public class DAL_Sqlite
    {
        public DAL_Sqlite()
        {

        }
        public SQLiteConnection _con = new SQLiteConnection();
        public string _strConnect = "Data Source=ConfigUser.sqlite;Version=3;";
        public void createConection()
        {
            if (_con.State == ConnectionState.Closed)
            {
                _con.ConnectionString = _strConnect;
                _con.Open();
            }
        }
        public void closeConnection()
        {
            if (_con.State == ConnectionState.Open)
            {
                _con.Close();
            }
        }


    }

}
