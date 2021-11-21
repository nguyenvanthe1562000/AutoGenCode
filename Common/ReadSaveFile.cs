using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Model;
using Newtonsoft.Json;

namespace Common
{
    public class ReadSaveFile
    {
        public static string ReadFile(string path)
        {
            try
            {
                using (StreamReader stream = new StreamReader(path))
                {
                    return stream.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static void WirteFile(string path, string content)
        {
            try
            {

                string filepath = path;
                FileStream fs = new FileStream(filepath, FileMode.Create);
                StreamWriter stream = new StreamWriter(fs, Encoding.UTF8);
                stream.WriteLine(content);
                stream.Flush();
                fs.Close();

            }
            catch (Exception)
            {

            }
        }


        public static bool SaveFileToProject(string directoryPath, string language, string fileName, string content, out string msgEr)
        {
            try
            {
                msgEr = string.Empty;
                if (!Directory.Exists(directoryPath))
                {
                    msgEr = "đường dẫn không tồn tại";
                    return false;
                }

                if (language.Equals(Layer.LANGUAGECSHARP))
                {
                    string path = directoryPath + "\\" + fileName;
                    Thread t1 = new Thread(() =>
                    {
                        WirteFile(path, content);
                    });
                    t1.IsBackground = true;
                    t1.Start();

                    Thread t2 = new Thread(() =>
                    {
                        IncludeFileToFileCsproj(path);
                    });
                    t2.IsBackground = true;
                    t2.Start();
                }

                return true;
            }
            catch (Exception ex)
            {
                msgEr = ex.Message;
                return false;

            }
        }
        public static List<string> FindFolder(string path, string layer)
        {
            List<string> listFolder = new List<string>();
            var filter = layer.Split('#');
            foreach (var item in filter)
            {
              listFolder.AddRange(Directory.GetDirectories(path, item, SearchOption.AllDirectories));
            }

            return listFolder;
        }
        /// <summary>
        /// return file path
        /// </summary>
        /// <param name="path">đừng dẫn thư mục</param>
        /// <param name="fileName">tim kiem theo ten file</param>
        /// <param name="filter">tim kiem theo đuôi file và đc ưu tiên tìm kiếm trước giá trị mặc định null </param>
        /// <returns> đường dẫn file</returns>
        static string FindFile(string path, string fileName)
        {
            var lstFile = Directory.GetFiles(path, fileName, SearchOption.TopDirectoryOnly);
            return lstFile.Length > 0 ? lstFile[0] : string.Empty;
        }
        public static void IncludeFileToFileCsproj(string path)
        {
            var findFileCsproj = path.Split('\\');
            string pathCsproj = string.Empty; ;
            string csprojElementValue = string.Empty; ;
            for (int i = findFileCsproj.Length - 1; i > 0; i--)
            {
                path = Directory.GetParent(path).FullName;
                pathCsproj = FindFile(path, "*.csproj");
                csprojElementValue = string.Format(@"{0}\{1}", findFileCsproj[i], csprojElementValue);
                if (!string.IsNullOrEmpty(pathCsproj))
                {
                    AddFileToProject(pathCsproj, DeleteCharacters.LastCharacters(csprojElementValue, 1));
                    return;
                }

            }
        }
        #region đọc file csproj rồi thêm element có đường dẫn file vào nếu không phải .netframework mà là core
        //path dường dẫn đến file csproj
        private static void AddFileToProject(string csprojPath, string IncludeValue)
        {
            var unitTestProjectPath = csprojPath;
            var unitTestProjectFile = XDocument.Load(unitTestProjectPath);

            var checkNetFrameWorkVerSion = unitTestProjectFile.Nodes()
                                             .OfType<XElement>()
                                             .DescendantNodes()
                                             .OfType<XElement>().FirstOrDefault(x => x.Name.LocalName.Equals("TargetFrameworkVersion"));
            if (checkNetFrameWorkVerSion != null)
            {
                var check = unitTestProjectFile.Nodes()
                                                             .OfType<XElement>()
                                                             .DescendantNodes()
                                                             .OfType<XElement>().FirstOrDefault(x => x.Name.LocalName.Equals("Compile") && x.Attribute("Include").Value.Equals(IncludeValue));

                if (check == null)
                {
                    var itemGroup = unitTestProjectFile.Nodes()
                                                  .OfType<XElement>()
                                                  .DescendantNodes()
                                                  .OfType<XElement>().First(xy => xy.Name.LocalName == "ItemGroup");
                    var xelem = AddProjectContent(IncludeValue, unitTestProjectFile);
                    itemGroup.Add(xelem);
                    unitTestProjectFile.Save(unitTestProjectPath);
                }
            }


        }

        private static XElement AddProjectContent(string pathToAdd, XDocument doc)
        {
            XNamespace rootNamespace = doc.Root.Name.NamespaceName;
            var xelem = new XElement(rootNamespace + "Compile");
            xelem.Add(new XAttribute("Include", pathToAdd));

            return xelem;
        }
        #endregion
        public static void IncludeFileToFileModuleAngular(string path, string language, string content)
        {

        }

    }
}
