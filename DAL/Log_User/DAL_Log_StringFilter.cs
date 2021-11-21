using System;
using System.Collections.Generic;
using Model;
using System.Data.SQLite;

using System.Data.SqlClient;
using DAL.QuerySQL;
using Model.LogUser;

namespace DAL.Log_User
{
    public class DAL_Log_StringFilter : DAL_Sqlite
    {
        QuerySqlLite _querySqlLite;
        public DAL_Log_StringFilter()
        {
            _querySqlLite = new QuerySqlLite();
            createTable();
        }
        public void createTable()
        {
            createConection();
            string sql = _querySqlLite.CreateTable_Log_StringFilter();
            SQLiteCommand command = new SQLiteCommand(sql, _con);
            command.ExecuteNonQuery();
            command.CommandText    = "SELECT count(*) FROM Log_StringFilter";
            int count = Convert.ToInt32(command.ExecuteScalar());
            if (count == 0)
            {
                command.CommandText = _querySqlLite.CreateDefaultValue_Log_StringFilter();
                command.ExecuteNonQuery();
            }
            closeConnection();
        }
        public void Save(Log_StringFilter log_StringFilter)
        {
            string strInsert = _querySqlLite.UpDateTable_Log_StringFilter(log_StringFilter.Language, log_StringFilter.Layer, log_StringFilter.StringFilter);
            using (SQLiteConnection connect = new SQLiteConnection(_strConnect))
            {
                connect.Open();
                SQLiteCommand cmd = new SQLiteCommand(strInsert, connect);
                cmd.ExecuteNonQuery();
            }
        }
        public string Load_Data(string language,string layer)
        {
            string filter = string.Empty;
            
            using (SQLiteConnection connect = new SQLiteConnection(_strConnect))
            {
                connect.Open();
                string query = _querySqlLite.GetStringFilter_Log_StringFilter(language,layer);
                SQLiteCommand cmd = new SQLiteCommand(query, connect);
                using (SQLiteDataReader da = cmd.ExecuteReader())
                {
                    if (!da.HasRows)
                    {
                    
                        return filter;
                    }
                    while (da.Read())
                    {
                        filter = da.GetString(0);//col
                    }
                    da.Close();
                };


                return filter;
            }

        } 
        //public string Get_Language()
        //{
        //    string filter = string.Empty;
            
        //    using (SQLiteConnection connect = new SQLiteConnection(_strConnect))
        //    {
        //        connect.Open();
        //        string query = _querySqlLite.GetStringFilter_Log_StringFilter(language,layer);
        //        SQLiteCommand cmd = new SQLiteCommand(query, connect);
        //        using (SQLiteDataReader da = cmd.ExecuteReader())
        //        {
        //            if (!da.HasRows)
        //            {
                    
        //                return filter;
        //            }
        //            while (da.Read())
        //            {
        //                filter = da.GetString(0);//col
        //            }
        //            da.Close();
        //        };


        //        return filter;
        //    }

        //}
    }
}
