using System;
using System.Data;
using System.Data.SQLite;
using System.Runtime.Remoting.Proxies;

namespace DAL.Log_User
{

    public class DAL_Log_Fields_Selected : DAL_Sqlite
    {

        public DAL_Log_Fields_Selected()
        {
            CreateTable();

        }
        private void CreateTable()
        {
            createConection();
            string sql = @"CREATE TABLE IF NOT EXISTS Log_Fields_Selected
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
            SQLiteCommand command = new SQLiteCommand(sql, _con);
            command.ExecuteNonQuery();
            closeConnection();
        }

        public void Save(DataTable ds)
        {
            try
            {
                createConection();
                SQLiteDataAdapter _adapter = new SQLiteDataAdapter("select * from Log_Fields_Selected", _con);
                SQLiteCommandBuilder command = new SQLiteCommandBuilder(_adapter);
                command.ConflictOption = ConflictOption.OverwriteChanges;
                // ds.AcceptChanges();
                int si = _adapter.Update(ds);
                closeConnection();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public DataTable loadData()
        {
            DataTable ds = new DataTable();
            SQLiteDataAdapter _adapter = new SQLiteDataAdapter("select * from Log_Fields_Selected", _con);
            _adapter.Fill(ds);
            return ds;
        }
    }
}
