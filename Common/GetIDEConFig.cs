using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTByMe;

namespace Common
{
   public class GetIDEConFig
    {
        List<IntelliSenseModel> keywords;
        List<IntelliSenseModel> methods;
        List<IntelliSenseModel> dataTypes;
        static string Path = AppDomain.CurrentDomain.BaseDirectory + "IDE\\sql";
        public GetIDEConFig()
        {
            keywords = new List<IntelliSenseModel>();
            dataTypes = new List<IntelliSenseModel>();
            methods = new List<IntelliSenseModel>();
        }
        public List<IntelliSenseModel> LoadDataTypesSQL()
        {
            var fileName = Path+"\\datatypes.txt";
            LoadIntelliSenseModel(fileName,out this.dataTypes);
            return dataTypes;
        }
        public List<IntelliSenseModel> LoadKeyWordsSQL() {
            var fileName = Path + "\\key.txt";
            LoadIntelliSenseModel(fileName, out this.keywords);
            return keywords;
        }
        public List<IntelliSenseModel> LoadMethodsSQL() {
            var fileName = Path + "\\method.txt";
            LoadIntelliSenseModel(fileName, out this.methods);
            return methods;
        }
        public string[] LoadDeclarationSnippets()
        {
         return new string[] {
                "CREATE TABLE abc\n(\n^\n)",
                "CREATE PROCEDURE ^\nAS\nBEGIN\n\nEND\nGO",
                "CREATE DATABASE ^",
                "SELECT *\nFROM ^\n",
                "SELECT *\nFROM ^\nWHERE",
                ";WITH tb AS\n(\n^\n)",
                "IF(^)\nBEGIN\n\nEND",
                "IF(^)\nBEGIN\n;\nEND\nELSE\nBEGIN\n;\nEND "
               };
        }
        public string[] LoadProperty()
        {
          
            return new string[]  {   "ID",
                                "IsGroup",
                                "ParentId",
                                "Code",
                                "Name",
                                "IsActive",
                                "CreatedBy",
                                "CreatedAt",
                                "ModifiedBy",
                                "ModifiedAt"};
        }
       
        private void LoadIntelliSenseModel(string path, out List<IntelliSenseModel> intelliSenseModels)
        {
            intelliSenseModels = new List<IntelliSenseModel>();
            var key = File.ReadAllLines(path, Encoding.UTF8).ToList();
            foreach (var item in key)
            {
                var getkey = item.Split('-');
                if (getkey.Length > 1)
                {
                    IntelliSenseModel intelliSenseModel = new IntelliSenseModel() { Key = getkey[0], Description = getkey[1] };
                    intelliSenseModels.Add(intelliSenseModel);
                }
                else
                {
                    IntelliSenseModel intelliSenseModel = new IntelliSenseModel() { Key = getkey[0], Description = "" };
                    intelliSenseModels.Add(intelliSenseModel);
                }
            }
        }
    }
}
