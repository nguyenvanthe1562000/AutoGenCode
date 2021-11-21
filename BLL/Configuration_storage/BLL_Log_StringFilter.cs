
using DAL.Log_User;
using Model;
using Model.LogUser;

namespace BLL.Configuration_storage
{
    public class BLL_Log_StringFilter
    {
        DAL_Log_StringFilter _DAL_Log;
        public BLL_Log_StringFilter()
        {
            _DAL_Log = new DAL_Log_StringFilter();
        }
        public string Load_Data(string language,string layer)
        {
            return _DAL_Log.Load_Data(language, layer);
        } 
        //public string Get_Language()
        //{
        //    return _DAL_Log.Load_Data(language, layer);
        //}
        public void Save(Log_StringFilter log_StringFilter)
        {
            _DAL_Log.Save(log_StringFilter);
        }
    }
}
