using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{//lớp ghi file cấu hình đường dẫn file code
    public class ConFig
    {
      
        static string Path = AppDomain.CurrentDomain.BaseDirectory + "Configuration Code\\config.json";
        public static ConfigLayer GetLayer(string language, string layer)
        {
            List<ConfigLayer> ConfigLayer = new List<ConfigLayer>();
            string json = ReadSaveFile.ReadFile(Path);
            ConfigLayer = JsonConvert.DeserializeObject<List<ConfigLayer>>(json);
            ConfigLayer c = ConfigLayer.FirstOrDefault(x => x.Language.ToLower().Contains(language.ToLower()) && x.Layer.ToLower().Contains(layer.ToLower()));
            return c;
        }


        public static bool SaveFileConfig(ConfigLayer layer)
        {
            try
            {
                List<ConfigLayer> Config = new List<ConfigLayer>();
                string json = ReadSaveFile.ReadFile(Path);
                Config = JsonConvert.DeserializeObject<List<ConfigLayer>>(json);
                var _layer = Config.FindIndex(x => x.Layer.ToLower().Contains(layer.Layer.ToLower()) && x.Language.Contains(layer.Language));
                Config[_layer] = layer;

                ReadSaveFile.WirteFile(Path, JsonConvert.SerializeObject(Config));
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public static List<ConfigLayer> GetAllLayer()
        {
            List<ConfigLayer> ConfigLayer = new List<ConfigLayer>();
            string json = ReadSaveFile.ReadFile(Path);
            ConfigLayer = JsonConvert.DeserializeObject<List<ConfigLayer>>(json);
            return ConfigLayer;
        }
        public static string GetFileDefaultNameSpace(string layer)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Configuration Code\\ConfigDefaultNameSpace.json";
            var x = new Layer();
            string s = JsonConvert.SerializeObject(x);
            string json = ReadSaveFile.ReadFile(path);
            DefaultNameSpace obj = JsonConvert.DeserializeObject<DefaultNameSpace>(json);
            if (layer == Layer.API)
            {
                return obj.API;
            }
            else if (layer == Layer.SERVICE)
            {
                return obj.SERVICE;
            }
            else if (layer == Layer.DATAACCESS)
            {
                return obj.DATAACCESS;
            }
            else if (layer == Layer.INTERFACE)
            {
                return obj.INTERFACE;
            }
            else if (layer == Layer.INTERFACEDATAACCESS)
            {
                return obj.INTERFACEDATAACCESS;
            }  else if (layer == Layer.DROPDOWNOPTION)
            {
                return obj.INTERFACEDATAACCESS;
            } 
            else if (layer == Layer.MODEL)
            {
                return obj.MODEL;
            }
            return "";
        }


    }
}
