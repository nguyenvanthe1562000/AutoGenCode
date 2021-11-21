using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL.GenerationCode.CustomExtension;

namespace DAL.GenerationCode
{
    public class DALGenCode
    {

        public  string Generate(string nameSpace, string nameTable, Dictionary<string, List<string>> model, string language, string layer, List<string> listTable, out string msgError)
        {
            var result = "";
            msgError = "";
            if (language.Equals(Layer.LANGUAGECSHARP))
            {
                
                result = GenerateCsharp(nameSpace, nameTable, model, language, layer, listTable, out msgError);
            }
            else if (language.Equals(Layer.LANGUAGEANGULAR))
            {
                result = GenerateAngular(nameSpace, nameTable, model, language, layer, out msgError);
            }
            else
            {
                 
               
                result = GenerateSQL(nameSpace, nameTable, model, language, layer, out msgError);
            }
            return result;
        }

        public string GenerateCsharp(string nameSpace, string nameTable, Dictionary<string, List<string>> model, string language, string layer, List<string> listTable, out string msgError)
        {
            var result = "";
            msgError = "";
            if (layer.Equals(Layer.ENTITY))
            {
                EntityCsharp entity = new EntityCsharp();
                result = entity.GenEntity(listTable);
            }
            else
            {
                FunctionGenCodeCsharp _genCode = new FunctionGenCodeCsharp();
                 result = _genCode.Generate(nameSpace, nameTable, model, ConFig.GetLayer(language, layer), out msgError);
                if (string.IsNullOrEmpty(result))
                {
                    result = "";
                }
            }    
               
            return result;
        }
        public string GenerateAngular(string nameSpace, string nameTable, Dictionary<string, List<string>> model, string language, string layer, out string msgError)
        {
            FunctionGenCodeAngular _genCode = new FunctionGenCodeAngular();
            msgError = "";
            var result = _genCode.Generate(nameSpace, nameTable, model, ConFig.GetLayer(language, layer), out msgError);
            if (string.IsNullOrEmpty(result))
            {
                result = "";
            }
            return result;
        }
        public string GenerateSQL(string nameSpace, string nameTable, Dictionary<string, List<string>> model, string language, string layer, out string msgError)
        {
            msgError = "";
            var result = "";
            if (layer.Equals(Layer.TRIGGEREVENTLOG))
            {
                TriggerSQL entity = new TriggerSQL();
                result = entity.GenTrigger(nameTable, model);
            }
            else
            {
                FunctionGenCodeCsharp _genCode = new FunctionGenCodeCsharp();

                result = _genCode.Generate(nameSpace, nameTable, model, ConFig.GetLayer(language, layer), out msgError);
                if (string.IsNullOrEmpty(result))
                {
                    result = "";
                }
            }
            return result;
        }
    }
}
