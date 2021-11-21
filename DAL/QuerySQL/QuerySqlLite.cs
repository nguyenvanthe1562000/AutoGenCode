using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.QuerySQL
{
    class QuerySqlLite
    {

        public string CreateTable_log_UI()
        {
            return "CREATE TABLE IF NOT EXISTS log_UI" +
            "(" +
            "name_db_e varchar(50)," +
            "namespace_e varchar(50)," +
            "url_project_e nvarchar(500)," +
            "name_api_ varchar(50)" +
            ")";
        }
        public string CreateTable_Log_StringFilter()
        {
            return "CREATE TABLE IF NOT EXISTS Log_StringFilter" +
                    "(" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "Language     VARCHAR(50)," +
                    "Layer        VARCHAR(50)," +
                    "StringFilter NVARCHAR(500)" +
                    ")";
        }
        public string CreateTable_Log_Fields_Selected()
        {
            return @"CREATE TABLE IF NOT EXISTS Log_Fields_Selected
                        (
                        id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                        database_e       varchar(50),
                        table_e          varchar(50),
                        fields_e         char(10),
                        models_e         char(10),
                        delete_e         char(10),
                        insert_e         char(10),
                        getAll_e         char(10),
                        update_e         char(10),
                        search_e         char(10),
                        saveFromList_e char(10),
                        dropdown_e       char(10),
                        getById_e        char(10)
                         )";
        }
        public string CreateTable_Log_DataBase_Connection()
        {
            return "CREATE TABLE IF NOT EXISTS Log_DataBase_Connection" +
            "(" +
            "servername_e varchar(50)," +
            "username_e varchar(50), " +
            "password_e varchar(50)" +
            " )";
        }

        public string CreateDefaultValue_Log_StringFilter()
        {
            string str = string.Empty;
            str += string.Format("INSERT INTO Log_StringFilter(Language, Layer, StringFilter) VALUES");
            str += string.Format("('{0}', '{1}', '{2}'),", "CSHARP", "API", "Api");
            str += string.Format("('{0}', '{1}', '{2}'),", "CSHARP", "SERVICE", "Service#Interface#BLL#Business");
            str += string.Format("('{0}', '{1}', '{2}'),", "CSHARP", "DATAACCESS", "DAO#DAL#Dal#DataAccess#Reponsitory");
            str += string.Format("('{0}', '{1}', '{2}'),", "CSHARP", "INTERFACE", "Service#Interface");
            str += string.Format("('{0}', '{1}', '{2}'),", "CSHARP", "MODEL", "Model");
            str += string.Format("('{0}', '{1}', '{2}'),", "CSHARP", "DROPDOWNOPTION", "DROPDOWNOPTION");
            str += string.Format("('{0}', '{1}', '{2}'),", "ANGULAR", "VIEW", "");
            str += string.Format("('{0}', '{1}', '{2}'),", "ANGULAR", "COMPONENT", "");
            str += string.Format("('{0}', '{1}', '{2}'),", "ANGULAR", "MODEL", "Shared");
            str += string.Format("('{0}', '{1}', '{2}'),", "ANGULAR", "SERVICE", "Shared");
            str += string.Format("('{0}', '{1}', '{2}')", "SQL", "STOREPROCEDURE", "");
            return str;

        }
        public string UpDateTable_Log_StringFilter(string language, string layer, string stringFilter)
        {
            return string.Format("UPDATE Log_StringFilter SET StringFilter='{0}' \t" +
                                  "WHERE Language='{1}' AND Layer='{2}'", stringFilter, language, layer);
        }
        public string GetStringFilter_Log_StringFilter(string language, string layer)
        {
            return string.Format("SELECT  StringFilter\t" +
                                  "FROM Log_StringFilter\t" +
                                  "WHERE Language= '{0}' AND Layer= '{1}'", language, layer);
        }

    }
}
