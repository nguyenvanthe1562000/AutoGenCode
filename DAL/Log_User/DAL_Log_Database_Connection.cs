using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SQLite;
namespace DAL.Log_User
{
    public class DAL_Log_Database_Connection : DAL_Sqlite
    {
        public DAL_Log_Database_Connection()
        {
            createTable();
        }
        public void createTable()
        {
            createConection();
            
            string sql =
            "CREATE TABLE IF NOT EXISTS Log_DataBase_Connection" +
            "(" +
            "servername_e varchar(50)," +
            "username_e varchar(50), " +
            "password_e varchar(50)" +
            " )";
            
            SQLiteCommand command = new SQLiteCommand(sql, _con);
            command.ExecuteNonQuery();
            closeConnection();
        }
        public void Save(Log_DataBase_Connection db)
        {
            createConection();
            if (!Check_exist(db.servername_e)) { Update(db); closeConnection(); return; }
            string strInsert = string.Format("INSERT INTO Log_DataBase_Connection(servername_e, username_e, password_e) VALUES('{0}','{1}','{2}')", db.servername_e, db.username_e, db.password_e);
            SQLiteCommand cmd = new SQLiteCommand(strInsert, _con);
            cmd.ExecuteNonQuery();
            closeConnection();
        }
        public List<Log_DataBase_Connection> loadData()
        {
            List<Log_DataBase_Connection> lst = new List<Log_DataBase_Connection>();
            createConection();
            string query = "select servername_e,username_e,password_e from Log_DataBase_Connection";
            var cmd = new SQLiteCommand(query, _con);
            SQLiteDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                Log_DataBase_Connection db = new Log_DataBase_Connection();
                db.servername_e = da.GetString(0);
                db.username_e = da.GetString(1);
                db.password_e = string.IsNullOrWhiteSpace(da.GetString(2)) ? "" : da.GetString(2);
                lst.Add(db);
            }
            closeConnection();
            return lst;
        }
        bool Check_exist(string name)
        {
            string query = string.Format("select servername_e from Log_DataBase_Connection where servername_e='{0}'", name);
            var cmd = new SQLiteCommand(query, _con);
            using (SQLiteDataReader da = cmd.ExecuteReader())
            {
                if (da.Read())
                { return false; }

            };
            return true;
        }
        bool Update(Log_DataBase_Connection db)
        {
            try
            {
                string strInsert = string.Format("UPDATE Log_DataBase_Connection set servername_e='{0}', username_e='{1}', password_e='{2}' where servername_e='{3}'", db.servername_e, db.username_e, db.password_e, db.servername_e);
                SQLiteCommand cmd = new SQLiteCommand(strInsert, _con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
