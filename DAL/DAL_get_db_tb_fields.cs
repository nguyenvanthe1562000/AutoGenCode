using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_get_db_tb_fields : DAL_AccessDb
    {
        public string Database;
        string _strConnection;
        public DAL_get_db_tb_fields(string str)
        {
            _strConnection = str;
        }
        public bool checkConnect()
        {
            if (!string.IsNullOrEmpty(_strConnection))
            {
                return true;
            }
            return false;
        }
        public List<string> GetDB()
        {
            List<string> lst = new List<string>();

            using (SqlConnection sql = new SqlConnection(_strConnection))
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT name FROM master.dbo.sysdatabases where dbid>4";
                cmd.CommandTimeout = 15;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lst.Add(reader.GetString(0));
                }
            }
            return lst;
        }
        public List<string> GetTB(string db)
        {
            Database = db;
            List<string> lst = new List<string>();
            //SqlDataReader reader = SqlHelper.ExecuteReader(, CommandType.Text, "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES");
            //while (reader.Read())
            //{
            //    lst.Add(reader.GetString(0));
            //}
            //List<string> lst = new List<string>();
          
            using (SqlConnection sql = new SqlConnection(conect_query(db)))
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";
                cmd.CommandTimeout = 15;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lst.Add(reader.GetString(0));
                }
            }
            return lst;
            
        }
        public DataTable get_fields(string tb)
        {
            try
            {
                QuerySql querySql = new QuerySql();
                using (SqlConnection sql = new SqlConnection(conect_query(Database)))
                {
                    sql.Open();
                    SqlCommand cmd = new SqlCommand(querySql.text, sql);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@tb", SqlDbType.VarChar).Value = tb;
                    cmd.CommandTimeout = 0;
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    return dataTable;

                }
            }
            catch (Exception)
            {
                DataTable dataTable = new DataTable();
                return dataTable;
            }

        }
        private string conect_query(string db)
        {
            return _strConnection.Replace("master", db);
        }
        //tạo store
        public void ExecuteQuery(string query, out string msgEr)
        {
            try
            {
                msgEr = string.Empty;
                using (SqlConnection sql = new SqlConnection(conect_query(Database)))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = sql;
                    command.Connection.Open();
                    command.CommandType = CommandType.Text;
                    string[] store = query.Replace("GO", "/").Split('/');
                    foreach (var item in store)
                    {
                        command.CommandText = item;
                        command.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                msgEr = ex.Message;
                throw;
            }

        }

        public List<string> GetListStoreProcedure(string db)
        {
            Database = db;
            List<string> lst = new List<string>();
            //SqlDataReader reader = SqlHelper.ExecuteReader(, CommandType.Text, "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES");
            //while (reader.Read())
            //{
            //    lst.Add(reader.GetString(0));
            //}
            //List<string> lst = new List<string>();

            using (SqlConnection sql = new SqlConnection(conect_query(db)))
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT name, object_id FROM sys.procedures";
                cmd.CommandTimeout = 15;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lst.Add(reader.GetString(0)+"-"+ reader.GetInt32(1));
                }
            }
            return lst;

        }
        public string GetStoreProcedureText(int id)
        {
            

            //SqlDataReader reader = SqlHelper.ExecuteReader(, CommandType.Text, "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES");
            //while (reader.Read())
            //{
            //    lst.Add(reader.GetString(0));
            //}
            //List<string> lst = new List<string>();
            string text = "";
            using (SqlConnection sql = new SqlConnection(conect_query(Database)))
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  object_definition("+id+")";
                cmd.CommandTimeout = 15;
                text = cmd.ExecuteScalar().ToString();
                
            }
            return text;

        } 
        public DataTable GetStoreProcedureParameter(int id)
        {


            //SqlDataReader reader = SqlHelper.ExecuteReader(, CommandType.Text, "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES");
            //while (reader.Read())
            //{
            //    lst.Add(reader.GetString(0));
            //}
            //List<string> lst = new List<string>();
            QuerySql querySql = new QuerySql();
            using (SqlConnection sql = new SqlConnection(conect_query(Database)))
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand(querySql.StoreProcedureParameter, sql);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                cmd.CommandTimeout = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
         

        } 
        public DataSet ExcuteQuery(out string msg,string query)
        {

             msg = "";
           

            try
            {
             
                using (SqlConnection sql = new SqlConnection(conect_query(Database)))
                {
                    sql.Open();
                    DataSet dataset = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand(query,sql);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.Fill(dataset);
                    return dataset;
                }
               
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return null;
            }
         

        }
    }
}
