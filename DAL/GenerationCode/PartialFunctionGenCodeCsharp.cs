using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Expression;

namespace DAL.GenerationCode
{
    public  partial class FunctionGenCodeCsharp
    {
       //function xử lý tìm các api( tạo mã các chức năng cho 1 class)
        string genFunction(string nameSpace, string nameTable, Dictionary<string, List<string>> model, ConfigLayer layer,string code)
        {
            code = GenCSharp(code, nameSpace, nameTable);

            if (code.Contains("{{update}}"))
            {
                if (model.ContainsKey("update") == true && model["update"].Count > 0)
                {
                    code = code.Replace("{{update}}", GenerateMethod(nameSpace, nameTable, model["update"], layer.Method.Update));
                }
                else { code = code.Replace("{{update}}", ""); }
            }
            if (code.Contains("{{insert}}"))
            {
                if (model.ContainsKey("insert") == true && model["insert"].Count > 0)
                {
                    code = code.Replace("{{insert}}", GenerateMethod(nameSpace, nameTable, model["insert"], layer.Method.Insert));
                }
                else { code = code.Replace("{{insert}}", ""); }
            }
            if (code.Contains("{{delete}}"))
            {
                if (model.ContainsKey("delete") == true && model["delete"].Count > 0)
                {
                    code = code.Replace("{{delete}}", GenerateMethod(nameSpace, nameTable, model["delete"], layer.Method.Delete));
                }
                else { code = code.Replace("{{delete}}", ""); }
            }
            if (code.Contains("{{getAll}}"))
            {
                if (model.ContainsKey("getall") == true && model["getall"].Count > 0)
                {
                    code = code.Replace("{{getAll}}", GenerateMethod(nameSpace, nameTable, model["getall"], layer.Method.GetAll));
                }
                else { code = code.Replace("{{getAll}}", ""); }
            }
            if (code.Contains("{{getById}}"))
            {
                if (model.ContainsKey("getbyid") && model["getbyid"].Count > 0)
                {
                    code = code.Replace("{{getById}}", GenerateMethod(nameSpace, nameTable, model["getbyid"], layer.Method.GetById));
                }
                else { code = code.Replace("{{getById}}", ""); }
            }
            if (code.Contains("{{dropdown}}"))
            {
                if (model.ContainsKey("dropdown") && model["dropdown"].Count > 0)
                {
                    code = code.Replace("{{dropdown}}", GenerateMethod(nameSpace, nameTable, model["dropdown"], layer.Method.DropDown));
                }
                else { code = code.Replace("{{dropdown}}", ""); }
            }
            if (code.Contains("{{search}}"))
            {
                if (model.ContainsKey("search") && model["search"].Count > 0)
                {
                    code = code.Replace("{{search}}", GenerateMethod(nameSpace, nameTable, model["search"], layer.Method.Search));
                }
                else { code = code.Replace("{{search}}", ""); }
            }
            if (code.Contains("{{saveFromList}}"))
            {
                if (model.ContainsKey("savefromlist") && model["savefromlist"].Count > 0)
                {
                    code = code.Replace("{{saveFromList}}", GenerateMethod(nameSpace, nameTable, model["savefromlist"], layer.Method.saveFromList));
                }
                else { code = code.Replace("{{saveFromList}}", ""); }
            }
            if (code.Contains("{{fields}}"))
            {
                if (model.ContainsKey("model") && model["model"].Count > 0)
                {
                    code = code.Replace("{{fields}}", GenerateMethod(nameSpace, nameTable, model["model"], layer.Method.Main, "{{fields}}"));
                }
                else { code = code.Replace("{{fields}}", ""); }
            }
            return code+ "\n";
        }
         string GenCSharp(string code, string nameSpace, string nameTable)
         {
            if (code.Contains(_cSharp.Namespace) == true)
            {
                code = code.Replace(_cSharp.Namespace, nameSpace);
            }
            if (code.Contains(_cSharp.NameTable) == true)
            {
                code = code.Replace(_sQL.NameTable, nameTable);
            }
            if (code.Contains(_cSharp.Iclass) == true)
            {
                string str = "";
                str += "I" + nameTable + ";";
                code = code.Replace(_cSharp.Iclass, str);
            }
            if (code.Contains(_cSharp.IclassService) == true)
            {
                string str = "";
                str += "I" + nameTable + "Service";
                code = code.Replace(_cSharp.IclassService, str);
            }
            if (code.Contains(_cSharp.IclassRepository))
            {
                string strx = "";
                strx += "I" + nameTable + "Repository";
                code = code.Replace(_cSharp.IclassRepository, strx);
            }
            if (code.Contains(_cSharp.ClassModel) == true)
            {
        
                string strx =nameTable + "Model";
                code = code.Replace(_cSharp.ClassModel, strx);
            }
            if (code.Contains(_cSharp.ClassService))
            {
                string strx = "";
                strx += nameTable + "Service";
                code = code.Replace(_cSharp.ClassService, strx);
            }
            if (code.Contains(_cSharp.ClassRepository))
            {
                string strx = "";
                strx += nameTable + "Repository";
                code = code.Replace(_cSharp.ClassRepository, strx);
            }
            if (code.Contains(_cSharp.VariableService) == true)
            {
                string str = "";
                str += "_" + nameTable + "Service";
                code = code.Replace(_cSharp.VariableService, str);
            }
            if (code.Contains(_cSharp.VariableRepository))
            {
                string strx = "";
                strx += "_" + nameTable + "Repository";
                code = code.Replace(_cSharp.VariableRepository, strx);
            }
            if (code.Contains(_cSharp.ParametersService))
            {
                string strx = "";
                strx += nameTable.ToLower() + "Service";
                code = code.Replace(_cSharp.ParametersService, strx);
            }
            if (code.Contains(_cSharp.ParametersRepository))
            {
                string strx = "";
                strx += nameTable.ToLower() + "Repository";
                code = code.Replace(_cSharp.ParametersRepository, strx);
            }
            if (code.Contains(_cSharp.ParametersViewModel))
            {
                string strx = "";
                strx += nameTable.ToLower() + "ViewModel";
                code = code.Replace(_cSharp.ParametersViewModel, strx);
            }
          
            return code;
        }
         string GenCSharp(string code, string nameSpace, string nameTable, List<string> model, Dictionary<string, List<string>> modelOption=null, ConfigLayer layerOption=null)
        {

            if (code.Contains(_cSharp.CommentParam))
            {
                string str = Convert_p(_cSharp.ParametersInit, nameSpace, nameTable, model);
                code = code.Replace(_cSharp.ParametersInit, str);
            }
            if (code.Contains(_cSharp.Fields) == true)
            {
                string str = Convert_c(_cSharp.Fields, nameSpace, nameTable, model);
                code = code.Replace(_cSharp.Fields, str);
            }
            if (code.Contains(_cSharp.ParametersInit) == true)
            {
                string str = Convert_p(_cSharp.ParametersInit, nameSpace, nameTable, model);
                code = code.Replace(_cSharp.ParametersInit, str);
            }
            if (code.Contains(_cSharp.ParametersStore) == true)
            {
                string str = Convert_p(_cSharp.ParametersStore, nameSpace, nameTable, model);
                code = code.Replace(_cSharp.ParametersStore, str);
            }
            if (code.Contains(_cSharp.ParametersPass) == true)
            {
                string str = Convert_p(_cSharp.ParametersPass, nameSpace, nameTable, model);
                code = code.Replace(_cSharp.ParametersPass, str);
            }
            if (code.Contains(_cSharp.ParametersModelPass) == true)
            {
                string str = Convert_p(_cSharp.ParametersModelPass, nameSpace, nameTable, model);
                code = code.Replace(_cSharp.ParametersModelPass, str);
            }
            if (code.Contains(_cSharp.ParametersModelStore) == true)
            {
                string str = Convert_p(_cSharp.ParametersModelStore, nameSpace, nameTable, model);
                code = code.Replace(_cSharp.ParametersModelStore, str);
            }
            if (code.Contains(_cSharp.ParametersFromBody))
            {
                string str = Convert_p(_cSharp.ParametersFromBody, nameSpace, nameTable, model);
                code = code.Replace(_cSharp.ParametersFromBody, str);
            }
            if (code.Contains(_cSharp.ParametersFromUri))
            {
                string str = Convert_p(_cSharp.ParametersFromUri, nameSpace, nameTable, model);
                code = code.Replace(_cSharp.ParametersFromUri, str);
            }
            if (code.Contains(_cSharp.ParametersRoute))
            {
                string str = Convert_p(_cSharp.ParametersRoute, nameSpace, nameTable, model);
                code = code.Replace(_cSharp.ParametersRoute, str);
            }
            if(modelOption!=null&& layerOption != null)
            {
                code= genFunction(nameSpace, nameTable, modelOption, layerOption, code);
            }
            if (code.Contains(_cSharp.ParametersCreateModel))
            {
                string str = Convert_v(_cSharp.ParametersCreateModel, nameSpace, nameTable, model);
                code = code.Replace(_cSharp.ParametersCreateModel, str);
            }
           
            return code;
        }
         string BacsicGenSql(string code, string nameSpace, string nameTable, List<string> model)
        {

            if (code.Contains(_sQL.StoreParameter_1) == true)
            {
                string str = Convert_p(_sQL.StoreParameter_1, nameSpace, nameTable, model);
                code = code.Replace(_sQL.StoreParameter_1, str);
            }
            if (code.Contains(_sQL.StoreParameter_2) == true)
            {
                string str = Convert_p(_sQL.StoreParameter_2, nameSpace, nameTable, model);
                code = code.Replace(_sQL.StoreParameter_2, str);
            }
            if (code.Contains(_sQL.StoreTablefield) == true)
            {
                string str = Convert_c(_sQL.StoreTablefield, nameSpace, nameTable, model);
                code = code.Replace(_sQL.StoreTablefield, str);
            }
            if (code.Contains(_sQL.StoreTableFieldStoreUpdateSet))
            {
                string str = Convert_c(_sQL.StoreTableFieldStoreUpdateSet, nameSpace, nameTable, model);
                code = code.Replace(_sQL.StoreTableFieldStoreUpdateSet, str);
            }
            if (code.Contains(_sQL.StoreChecking) == true)
            {
                string str = Convert_p(_sQL.StoreChecking, nameSpace, nameTable, model);
                code = code.Replace(_sQL.StoreChecking, str);
            }
            if (code.Contains(_sQL.StoreOrder) == true)
            {
                string str = Convert_a_d(_sQL.StoreOrder, nameSpace, nameTable, model);
                code = code.Replace(_sQL.StoreOrder, str);
            }
            if (code.Contains(_sQL.StoreLang_v) == true)
            {
                string str = Convert_e_m(_sQL.StoreLang_v, nameSpace, nameTable, model);
                code = code.Replace(_sQL.StoreLang_v, str);
            }
            if (code.Contains(_sQL.StoreLang_e) == true)
            {
                string str = Convert_e_m(_sQL.StoreLang_e, nameSpace, nameTable, model);
                code = code.Replace(_sQL.StoreLang_e, str);
            }
            if (code.Contains(_sQL.StoreLang_v_Check) == true)
            {
                string str = Convert_e_m(_sQL.StoreLang_v_Check, nameSpace, nameTable, model);
                code = code.Replace(_sQL.StoreLang_v_Check, str);
            }
            if (code.Contains(_sQL.StoreLang_e_Check) == true)
            {
                string str = Convert_e_m(_sQL.StoreLang_e_Check, nameSpace, nameTable, model);
                code = code.Replace(_sQL.StoreLang_e_Check, str);
            }
            if (code.Contains(_sQL.StoreRequired_1) == true)
            {
                string str = Convert_r(_sQL.StoreRequired_1, nameSpace, nameTable, model);
                code = code.Replace(_sQL.StoreRequired_1, str);
            }
            if (code.Contains(_sQL.StoreRequired_2) == true)
            {
                string str = Convert_r(_sQL.StoreRequired_2, nameSpace, nameTable, model);
                code = code.Replace(_sQL.StoreRequired_2, str);
            }
            if (code.Contains(_sQL.StoreRequired_3))
            {
                string str = Convert_r(_sQL.StoreRequired_3, nameSpace, nameTable,  model);
                code = code.Replace(_sQL.StoreRequired_3, str);
            }
            if (code.Contains(_sQL.StoreJsonfield))
            {
                string str = Convert_j(_sQL.StoreJsonfield, nameSpace, nameTable, ref model);
                code = code.Replace(_sQL.StoreJsonfield, str);
            }
            if (code.Contains(_sQL.StoreFromjson))
            {
                string str = Convert_j(_sQL.StoreFromjson, nameSpace, nameTable, ref model);
                code = code.Replace(_sQL.StoreFromjson, str);
            }
            if (code.Contains(_sQL.StoreSelectJsonField))
            {
                string str = Convert_j(_sQL.StoreSelectJsonField, nameSpace, nameTable, ref model);
                code = code.Replace(_sQL.StoreSelectJsonField, str);
            }
            if (code.Contains(_sQL.StoreInsert_1))
            {
                string str = Convert_i(_sQL.StoreInsert_1, nameSpace, nameTable,  model);
                code = code.Replace(_sQL.StoreInsert_1, str);

            }
            if (code.Contains(_sQL.StoreInsert_2))
            {
                string str = Convert_i(_sQL.StoreInsert_2, nameSpace, nameTable,  model);
                code = code.Replace(_sQL.StoreInsert_2, str);
            } 
            if (code.Contains(_sQL.StoreUpdate))
            {
                string str = Convert_i(_sQL.StoreUpdate, nameSpace, nameTable,  model);
                code = code.Replace(_sQL.StoreUpdate, str);
            }
            if (code.Contains(_cSharp.ParametersCheckData) )
            {
                string str = CsharpParametersCheckData(_cSharp.ParametersCheckData, nameSpace, nameTable, model);
                code = code.Replace(_cSharp.ParametersCheckData, str);
            }  
            if (code.Contains(_cSharp.CommentParam) )
            {
                string str = CsharpCommentParam(_cSharp.CommentParam, nameSpace, nameTable, model);
                code = code.Replace(_cSharp.CommentParam, str);
            }
            return code;
        }
    }
}
