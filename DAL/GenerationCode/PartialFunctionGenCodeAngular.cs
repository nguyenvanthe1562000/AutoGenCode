using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Expression;

namespace DAL.GenerationCode
{
    public partial class FunctionGenCodeAngular
    {

        string genFunction(string nameSpace, string nameTable, Dictionary<string, List<string>> model, ConfigLayer layer, string code)
        {
            code = GenAngular(code, nameSpace, nameTable);

            if (code.Contains("{{update}}"))
            {
                if (model.ContainsKey("update") == true && model["update"].Count > 0)
                {
                    code = code.Replace("{{update}}", GenerateMethod(nameSpace, nameTable, model["update"], model, layer.Method.Update, layer));
                }
                else { code = code.Replace("{{update}}", ""); }
            }
            if (code.Contains("{{insert}}"))
            {
                if (model.ContainsKey("insert") == true && model["insert"].Count > 0)
                {
                    code = code.Replace("{{insert}}", GenerateMethod(nameSpace, nameTable, model["insert"], model, layer.Method.Insert, layer));
                }
                else { code = code.Replace("{{insert}}", ""); }
            }
            if (code.Contains("{{delete}}"))
            {
                if (model.ContainsKey("delete") == true && model["delete"].Count > 0)
                {
                    code = code.Replace("{{delete}}", GenerateMethod(nameSpace, nameTable, model["delete"], model, layer.Method.Delete, layer));
                }
                else { code = code.Replace("{{delete}}", ""); }
            }
            if (code.Contains("{{getAll}}"))
            {
                if (model.ContainsKey("getall") == true && model["getall"].Count > 0)
                {
                    code = code.Replace("{{getAll}}", GenerateMethod(nameSpace, nameTable, model["getall"], model, layer.Method.GetAll, layer));
                }
                else { code = code.Replace("{{getAll}}", ""); }
            }
            if (code.Contains("{{getById}}"))
            {
                if (model.ContainsKey("getbyid") && model["getbyid"].Count > 0)
                {
                    code = code.Replace("{{getById}}", GenerateMethod(nameSpace, nameTable, model["getbyid"], model, layer.Method.GetById, layer));
                }
                else { code = code.Replace("{{getById}}", ""); }
            }
            if (code.Contains("{{dropdown}}"))
            {
                if (model.ContainsKey("dropdown") && model["dropdown"].Count > 0)
                {
                    code = code.Replace("{{dropdown}}", GenerateMethod(nameSpace, nameTable, model["dropdown"], model, layer.Method.DropDown, layer));
                }
                else { code = code.Replace("{{dropdown}}", ""); }
            }
            if (code.Contains("{{search}}"))
            {
                if (model.ContainsKey("search") && model["search"].Count > 0)
                {
                    code = code.Replace("{{search}}", GenerateMethod(nameSpace, nameTable, model["search"], model, layer.Method.Search, layer));
                }
                else { code = code.Replace("{{search}}", ""); }
            }
            if (code.Contains("{{saveFromList}}"))
            {
                if (model.ContainsKey("savefromlist") && model["savefromlist"].Count > 0)
                {
                    code = code.Replace("{{saveFromList}}", GenerateMethod(nameSpace, nameTable, model["savefromlist"], model, layer.Method.saveFromList, layer));
                }
                else { code = code.Replace("{{saveFromList}}", ""); }
            }
            if (code.Contains("{{fields}}"))
            {
                if (model.ContainsKey("model") && model["model"].Count > 0)
                {
                    code = code.Replace("{{fields}}", GenerateMethod(nameSpace, nameTable, model["model"], model, layer.Method.Main, layer, _angular.Fields));
                }
                else { code = code.Replace("{{fields}}", ""); }
            }
            return code + "\n";
        }
        string GenAngular(string code, string nameSpace, string nameTable)
        {
            if (code.Contains(_angular.Namespace))
            {
                code = code.Replace(_angular.Namespace, nameSpace);
            }
            if (code.Contains(_angular.NameTable) == true)
            {
                code = code.Replace(_angular.NameTable, nameTable);
            }
            if (code.Contains(_angular.Iclass) == true)
            {
                string str = "";
                str += "I" + nameTable + ";";
                code = code.Replace(_angular.Iclass, str);
            }
            if (code.Contains(_angular.IclassService) == true)
            {
                string str = "";
                str += "I" + nameTable + "Service";
                code = code.Replace(_angular.IclassService, str);
            }
            if (code.Contains(_angular.IclassRepository))
            {
                string strx = "";
                strx += "I" + nameTable + "repository";
                code = code.Replace(_angular.IclassRepository, strx);
            }
            if (code.Contains(_angular.ClassModel) == true)
            {

                string strx = nameTable + "Model";
                code = code.Replace(_angular.ClassModel, strx);
            }
            if (code.Contains(_angular.ClassService))
            {
                string strx = "";
                strx += nameTable + "Service";
                code = code.Replace(_angular.ClassService, strx);
            }
            if (code.Contains(_angular.ClassRepository))
            {
                string strx = "";
                strx += nameTable + "Repository";
                code = code.Replace(_angular.ClassRepository, strx);
            }
            if (code.Contains(_angular.VariableService) == true)
            {
                string str = "";
                str += "_" + nameTable + "Service";
                code = code.Replace(_angular.VariableService, str);
            }
            if (code.Contains(_angular.VariableRepository))
            {
                string strx = "";
                strx += "_" + nameTable + "Repository";
                code = code.Replace(_angular.VariableRepository, strx);
            }
            if (code.Contains(_angular.ParametersService))
            {
                string strx = "";
                strx += nameTable.ToLower() + "Service";
                code = code.Replace(_angular.ParametersService, strx);
            }
            if (code.Contains(_angular.ParametersRepository))
            {
                string strx = "";
                strx += nameTable.ToLower() + "Repository";
                code = code.Replace(_angular.ParametersRepository, strx);
            }

            return code;
        }
        string GenAngular(string code, string nameSpace, string nameTable, List<string> model)
        {

            //if (code.Contains(_angular.CommentParam))
            //{
            //    string str = ParametersInit(_angular.ParametersInit, nameSpace, nameTable, model);
            //    code = code.Replace(_angular.ParametersInit, str);
            //}
            if (code.Contains(_angular.Fields) == true)
            {
                string str = Field(_angular.Fields, nameSpace, nameTable, model);
                code = code.Replace(_angular.Fields, str);
            }
            else if (code.Contains(_angular.GenFieldName) == true)
            {
                string str = GenFieldName(_angular.GenFieldName, nameTable, model);
                code = code.Replace(_angular.GenFieldName, str);
            }
            else if (code.Contains(_angular.GenFieldValue) == true)
            {
                string str = GenFieldValue(_angular.GenFieldValue, nameTable, model);
                code = code.Replace(_angular.GenFieldValue, str);
            }
            else if (code.Contains(_angular.GenDropdownOption) == true)
            {
                string str = GenDropdownOption(_angular.GenDropdownOption, nameTable, model);
                code = code.Replace(_angular.GenDropdownOption, str);
            }
            else if (code.Contains(_angular.GenFromCreate) == true)
            {
                string str = GenFromCreate(_angular.GenFromCreate, nameTable, model);
                code = code.Replace(_angular.GenFromCreate, str);
            }
            else if (code.Contains(_angular.GenFromEdit) == true)
            {
                string str = GenFromEdit(_angular.GenFromEdit, nameTable, model);
                code = code.Replace(_angular.GenFromEdit, str);
            }
            else if (code.Contains(_angular.ParametersInit) == true)
            {
                string str = ParametersInit(_angular.ParametersInit, nameSpace, nameTable, model);
                code = code.Replace(_angular.ParametersInit, str);
            }
            else if (code.Contains(_angular.ParametersPass) == true)
            {
                string str = ParametersPass(_angular.ParametersPass, nameSpace, nameTable, model);
                code = code.Replace(_angular.ParametersPass, str);
            }
            else if (code.Contains(_angular.ParametersModelPass) == true)
            {
                string str = ParametersModelPass(_angular.ParametersModelPass, nameSpace, nameTable, model);
                code = code.Replace(_angular.ParametersModelPass, str);
            }
            else if (code.Contains(_angular.ParametersFromBody))
            {
                string str = ParametersFromBody(_angular.ParametersFromBody, nameSpace, nameTable, model);
                code = code.Replace(_angular.ParametersFromBody, str);
            }
            else if (code.Contains(_angular.ParametersFromUri))
            {
                string str = ParametersFromUri(_angular.ParametersFromUri, nameSpace, nameTable, model);
                code = code.Replace(_angular.ParametersFromUri, str);
            }
            else if (code.Contains(_angular.ParametersRoute))
            {
                string str = ParametersRoute(_angular.ParametersRoute, nameSpace, nameTable, model);
                code = code.Replace(_angular.ParametersRoute, str);
            }
            return code;
        }
        string GenAngular(string code, string nameSpace, string nameTable, string model)
        {

            if (code.Contains(_angular.DataMember))
            {
            
                code =  DataMember(_angular.DataMember, code, model);
            }
            else if (code.Contains(_angular.DataType))
            {
               
                code =  DataMember(_angular.DataMember, code, model);
            }
            return code;
        }
    }
}
