using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace DAL.GenerationCode
{
    public class ReadWirte
    {
        public string[] ReadFile(string path , out string msgError)
        {
            string[] lines =new string[]{};
            try
            {
                lines = File.ReadAllLines(path);

                msgError = "";
               
            }
            catch (Exception e)
            {
                lines = null;
                msgError= e.Message;
            } 
            return lines;
        }
        public bool WirteFileConfig(string URLproject, string code)
        {
            try
            {
                string filepath = URLproject;
                FileStream fs = new FileStream(filepath, FileMode.Create);
                StreamWriter stream = new StreamWriter(fs, Encoding.UTF8);
                stream.WriteLine(code);
                stream.Flush();
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool WriteToProject(string url, string nameSpace, string NameApi, string nameTable,string language, string code)
        {
            try
            {
                string directoryPath = url + @"\" + nameSpace + "." + @"\" + NameApi;
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);
                string filePath = directoryPath + @"\" + nameTable + language;
                FileStream fs = new FileStream(filePath, FileMode.Create);
                StreamWriter stream = new StreamWriter(fs, Encoding.UTF8);
                stream.WriteLine(code);
                stream.Flush();
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
