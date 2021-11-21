using Model;
using System.Data.SQLite;

using System.Data.SqlClient;

namespace DAL.Log_User
{
    public class DAL_Log_Last_Used : DAL_Sqlite
    {
        public DAL_Log_Last_Used()
        {
            createTable();
        }
        public void createTable()
        {
            createConection();
            
            string sql =
            "CREATE TABLE IF NOT EXISTS log_UI" +
            "(" +
            "name_db_e varchar(50)," +
            "namespace_e varchar(50)," +
            "url_project_e nvarchar(500)," +
            "name_api_ varchar(50)" +
            ")";
            SQLiteCommand command = new SQLiteCommand(sql, _con);
            command.ExecuteNonQuery();
            closeConnection();
        }
        public void Save(Log_Last_Used log_Last)
        {
            string strInsert = string.Format("INSERT INTO log_UI" +
                                            " VALUES('{0}','{1}','{2}','{3}')", log_Last.name_db_e, log_Last.namespace_e, log_Last.url_project_e, log_Last.name_api_e
                                            );
            using (SQLiteConnection connect = new SQLiteConnection("Data Source=ConfigUser.sqlite;Version=3;"))
            {
                connect.Open();
                SQLiteCommand cmd = new SQLiteCommand(strInsert, connect);
                cmd.ExecuteNonQuery();
            }
        }
        public Log_Last_Used Load_Data()
        {
            Log_Last_Used log = new Log_Last_Used();
            using (SQLiteConnection connect = new SQLiteConnection("Data Source=ConfigUser.sqlite;Version=3;"))
            {
                connect.Open();
                string query = "select * from log_UI";
                SQLiteCommand cmd = new SQLiteCommand(query, connect);
                using (SQLiteDataReader da = cmd.ExecuteReader())
                {
                    if (!da.HasRows)
                    {
                        //closeConnection();
                        return log;
                    }
                    while (da.Read())
                    {
                        log.name_db_e = da.GetString(0);
                        log.namespace_e = da.GetString(1);
                        log.url_project_e = da.GetString(2);
                        log.name_api_e = da.GetString(3);
                    }
                   da.Close();
                };
                
                //closeConnection();
                return log;
            }
        }
    }
}
