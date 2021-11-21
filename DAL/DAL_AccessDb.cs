using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Permissions;

namespace DAL
{
    public class DAL_AccessDb
    {
        protected string Connect;
       
        public string  ConnectDb( string str)
        {
            Connect = str;
            try
            {
                SqlConnection sql = new SqlConnection(Connect);
                sql.Open();
                sql.Close();
                
                return "Success";
            }
            catch (Exception e)
            {
                return  e.Message;
            }
        }

    }
}
