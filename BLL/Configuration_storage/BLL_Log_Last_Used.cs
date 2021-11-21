using DAL.Log_User;
using Model;

namespace BLL.Configuration_storage
{
    public class BLL_Log_Last_Used
    {
        DAL_Log_Last_Used _DAL_Log;
        public BLL_Log_Last_Used()
        {
            _DAL_Log = new DAL_Log_Last_Used();
        }
        public Log_Last_Used Load_Data()
        {
            return _DAL_Log.Load_Data();
        }
        public void Save(string database, string Namespace, string nameapi, string UrlProject, string codeModel)
        {
            Log_Last_Used log = new Log_Last_Used();
            log.name_db_e = database;
            log.namespace_e = Namespace;
            log.name_api_e = nameapi;
            log.url_project_e = UrlProject;
            log.codeModel_e = codeModel;
            _DAL_Log.Save(log);
        }
    }
}
