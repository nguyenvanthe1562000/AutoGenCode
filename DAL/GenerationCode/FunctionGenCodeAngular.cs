using Common;
using Model;
using Model.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DAL.GenerationCode
{
    /// <summary>
    /// lớp chưa hoàn thành vẫn còn lỗi phần {{begin.xxx}}-{{end.xxx}}-{{paste.xxx}}
    /// </summary>
    public partial class FunctionGenCodeAngular
    {
        ReadWirte _readWirte;
        // string _typeNumber = "int bigint decimal float";
        string _typeString = "char varchar text nvarchar text ntext";
        string _typeDate = "date datetime datetime2 datetimeoffset smalldatetime";
        string _temParameter = string.Empty;


        readonly ExpressionAngular _angular;
        ConvertTypeSqlToAngular ConvertTypeSqlToAngular;
        public FunctionGenCodeAngular()
        {
            _readWirte = new ReadWirte();


            _angular = new ExpressionAngular();

        }
        //function đọc file main
        public string Generate(string nameSpace, string nameTable, Dictionary<string, List<string>> model, ConfigLayer layer, out string msgError)
        {
            string str = string.Empty;;
            try
            {
                msgError = string.Empty;;
                // keyword model is  ToLower()
                var code = _readWirte.ReadFile(layer.Method.Main, out msgError);
                if (!string.IsNullOrEmpty(msgError))
                {
                    return msgError;
                }

                for (int i = 0; i < code.Length; i++)
                {
                    str += genFunction(nameSpace, nameTable, model, layer, code[i]);
                }
                return str;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }


        }
        //lớp genFunction xẽ gọi lớp này để xử lý các api trong các function đó
        string GenerateMethod(string nameSpace, string nameTable, List<string> model, Dictionary<string, List<string>> modelOption, string pathfunction, ConfigLayer layer, string optionMethod = null)
        {
            string msgError = string.Empty; ;
            string[] code = new string[1];
            if (!string.IsNullOrEmpty(optionMethod))
            {
                code = new string[] { optionMethod };
            }
            else
            {
                code = _readWirte.ReadFile(pathfunction, out msgError);
                if (!string.IsNullOrEmpty(msgError))
                {
                    return msgError;
                }
            }
            return Convert(code, nameSpace, nameTable, model, layer, modelOption);
        }
        //xử lý phần body của function
        string Convert(string[] code, string nameSpace, string nameTable, List<string> model, ConfigLayer layer = null, Dictionary<string, List<string>> modelOption = null)
        {
            string displayCode = string.Empty; ;

            bool flagbegin_end = true;
            for (int i = 0; i < code.Length; i++)
            {
                if (code[i].Equals(_angular.Fields))
                {
                    code[i] = Field(_angular.Fields,nameSpace, nameTable, model);
                }
                code[i] = GenAngular(code[i], nameSpace, nameTable);
                code[i] = GenAngular(code[i], nameSpace, nameTable, model);
                if (flagbegin_end)
                    BeginEnd(ref code, out flagbegin_end, nameSpace, nameTable, model, layer, modelOption);

                code[i] = code[i].Trim().EndsWith("AND") == true ? DeleteCharacters.LastCharacters(code[i].Trim(), 3) : code[i];
                code[i] = code[i].Trim().EndsWith(",") == true ? DeleteCharacters.LastCharacters(code[i].Trim(), 1) : code[i];
                displayCode += code[i] + "\n";
            }
            return displayCode;
        }

        void BeginEnd(ref string[] code, out bool flagbegin_end, string nameSpace, string nameTable, List<string> model, ConfigLayer layer = null, Dictionary<string, List<string>> modelOption = null)
        {

            Dictionary<string, string> _beginEnd = new Dictionary<string, string>();//key : tên begin, value:body begin.
            Dictionary<string, int> _indexPaste = new Dictionary<string, int>();
            flagbegin_end = true;
            var field = model.Where(x => x.EndsWith("#p")|| x.EndsWith("#e")|| x.EndsWith("#m")|| x.EndsWith("#k")|| x.EndsWith("#b")).ToList();

            var _code = string.Empty;
            string _beginName = string.Empty;
            for (int i = 0; i < code.Length; i++)
            {

                if (code[i].Contains(_angular.Begin))
                {
                    string[] getname = code[i].Replace("{{", string.Empty).Replace("}}", string.Empty).Split('.');
                    _beginName = getname[1];
                    flagbegin_end = false;
                    code[i] = code[i].Replace(_angular.Begin + _beginName + "}}", string.Empty);
                }
                if (!flagbegin_end)
                {
                    _code += code[i];
                    code[i] = genFunction(nameSpace, nameTable, modelOption, layer, code[i]);
                    code[i] = GenAngular(code[i], nameSpace, nameTable);
                    code[i] = GenAngular(code[i], nameSpace, nameTable, model);
                    code[i] = GenAngular(code[i], nameSpace, nameTable, field[0]);
                }

                if (code[i].Contains(_angular.End))
                {
                    code[i] = code[i].Replace(_angular.End + _beginName + "}}", string.Empty);
                    _code = _code.Replace(_angular.End + _beginName + "}}", string.Empty);
                    _beginEnd.Add(_beginName, _code);
                    _code = string.Empty;
                    flagbegin_end = true;
                }
                if (code[i].Contains(_angular.Paste))
                {
                    code[i] = code[i].Replace(_angular.Paste + _beginName + "}}", string.Empty);
                    _indexPaste.Add(_beginName, i);
                }

            }
            for (int i = 0; i < _beginEnd.Count; i++)
            {
                _code = string.Empty;
                for (int j = 1; j < field.Count; j++)
                {

                    _code += GenAngular(_beginEnd.ElementAt(i).Value, nameSpace, nameTable, field[j]) + "\n\n";

                }
                if (_indexPaste.ContainsKey(_beginEnd.ElementAt(i).Key))
                {
                    code[_indexPaste[_beginEnd.ElementAt(i).Key]] = _code;
                }
            }
        }
        string DataMember(string expression, string code, string model)
        {

            if (expression.Equals(_angular.DataMember))
            {
                string[] _type = model.Split('#');
                code = code.Replace(expression, _type[1]);
                return code;
            }
            return string.Empty;
        }
        string DataType(string expression, string code, string model)
        {

            if (expression.Equals(_angular.DataType))
            {
                string[] _type = model.Split('#');
                code = code.Replace(expression, _type[1]);
                return code;
            }
            return string.Empty;
        }
        //string DataLength(string expression, string code, string model)
        //{

        //    if (expression.Equals(_angular.DataLength))
        //    {

        //        string[] _type = model.Split('#');
        //        code = code.Replace(expression, _type[2]);
        //        return code;
        //    }
        //    return string.Empty;
        //}
        String GenFieldName(string expression, string nameTable, List<string> model)
        {
            string code = string.Empty;;
            if (_angular.GenFieldName.Equals(expression))
            {
                code = "<tr>";
                var field = model.Where(x => x.EndsWith("#c")).ToList();
                for (int i = 0; i < field.Count; i++)
                {
                    string[] type = field[i].Split('#');
                    code += string.Format("\n<td>{0}</td>", type[1]);
                }
                code += "\n</tr>";
            }
            return code;
        }
        String GenFieldValue(string expression, string nameTable, List<string> model)
        {

            string code = string.Empty;;
            if (_angular.GenFieldValue.Equals(expression))
            {
                var field = model.Where(x => x.EndsWith("#c")).ToList();
                code = string.Format("<tr *ngFor=\"let {0} of list{1}\">", nameTable.ToLower(), nameTable);
                for (int i = 0; i < field.Count; i++)
                {
                    string[] type = field[i].Split('#');
                    code += string.Format("\n<td>{{ {0}.{1} }}</td>", nameTable.ToLower(), type[1]);
                }
                code += "\n</tr>";
            }
            return code;
        }
        String GenDropdownOption(string expression, string nameTable, List<string> model)
        {

            string code = @"
            <option *ngFor='let dropdownoption of DropdownOption' [ngValue]='dropdownoption.value'>
              {{dropdownoption.label}}
             </option>
             ";
            return code;
        }
        String GenFromCreate(string expression, string nameTable, List<string> model)
        {

            string code = string.Empty;;

            if (_angular.GenFromCreate.Equals(expression))
            {
                code += @"<form novalidate autocomplete='off' #form='ngForm' (submit)='onSubmit(form)'>";
                var field = model.Where(x => x.EndsWith("#p")).ToList();
                code = string.Format("<tr *ngFor=\"let {0} of list{1}\">", nameTable.ToLower(), nameTable);
                for (int i = 0; i < field.Count; i++)
                {
                    string[] type = field[i].Split('#');
                    code += string.Format(@"
                    \n<div class='form-group'>
                        <label>{0}</label>
                        <input class='form-control form-control-lg' placeholder='{0}' name='{0}'
                            #{0}='ngModel' [(ngModel)]='service.formData.{0}'
                            required [class.invalid]='{0}.invalid && {0}.touched'>
                    </div>", type[1]);
                }
                code += "\n</from>";
            }
            return code;
        }
        String GenFromEdit(string expression, string nameTable, List<string> model)
        {

            string code = string.Empty;;

            if (_angular.GenFromEdit.Equals(expression))
            {
                code += @"<form novalidate autocomplete='off' #form='ngForm' (submit)='onSubmit(form)'>";
                var field = model.Where(x => x.EndsWith("#p")).ToList();
                code = string.Format("<tr *ngFor=\"let {0} of list{1}\">", nameTable.ToLower(), nameTable);
                for (int i = 0; i < field.Count; i++)
                {
                    string[] type = field[i].Split('#');
                    code += string.Format(@"
                    \n<div class='form-group'>
                        <label>{0}</label>
                        <input class='form-control form-control-lg' placeholder='{0}' name='{0}'
                            #{0}='ngModel' [(ngModel)]='service.formData.{0}' [value]='{0}'
                            required [class.invalid]='{0}.invalid && {0}.touched'>
                    </div>", type[1]);
                }
                code += "\n</from>";
            }
            return code;
        }
        String ParametersInit(string expression, string nameSpace, string nameTable, List<string> model)
        {

            string code = string.Empty;;

            if (expression.Equals(_angular.ParametersInit))
            {
                var field = model.Where(x => x.EndsWith("#p")).ToList();

                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');

                    if (type[2].Equals("p"))
                    {
                        code += string.Format("{0}:{1}, ", type[1], type[0]);
                    }

                }
                _temParameter = code;
                code = DeleteCharacters.TwoCharacters(code);
            }

            return code;
        }
        String ParametersPass(string expression, string nameSpace, string nameTable, List<string> model)
        {

            string code = string.Empty;;

            if (expression.Equals(_angular.ParametersPass))
            {
                var field = model.Where(x => x.EndsWith("#p")).ToList();

                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');

                    if (type[2].Equals("p"))
                    {
                        code += string.Format("{0}, ", type[1]);
                    }

                }
                code = DeleteCharacters.TwoCharacters(code);
            }

            return code;
        }
        String ParametersModelPass(string expression, string nameSpace, string nameTable, List<string> model)
        {

            string code = string.Empty;;

            if (expression.Equals(_angular.ParametersModelPass))
            {
                var field = model.Where(x => x.EndsWith("#p")).ToList();

                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');

                    if (type[2].Equals("p"))
                    {
                        code += string.Format("{0}.{1}, ", nameTable, type[1]);
                    }

                }
                code = DeleteCharacters.TwoCharacters(code);
            }

            return code;
        }
        String ParametersRoute(string expression, string nameSpace, string nameTable, List<string> model)
        {

            string code = string.Empty;;

            if (expression.Equals(_angular.ParametersRoute))
            {
                var field = model.Where(x => x.EndsWith("#p")).ToList();

                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');

                    if (type[2].Equals("p"))
                    {
                        code += string.Format("/${0} ", type[1]);
                    }

                }
                code = DeleteCharacters.LastCharacters(code, 1);
            }

            return code;
        }
        String ParametersFromBody(string expression, string nameSpace, string nameTable, List<string> model)
        {


            string code = string.Empty;;

            if (expression.Equals(_angular.ParametersRoute))
            {
                var field = model.Where(x => x.EndsWith("#c")).ToList();

                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');

                    if (type[2].Equals("p"))
                    {
                        code += string.Format("/${0} ", type[1]);
                    }

                }
                code = DeleteCharacters.LastCharacters(code, 1);
            }

            return code;
        }
        String ParametersFromUri(string expression, string nameSpace, string nameTable, List<string> model)
        {


            string code = string.Empty;;

            if (expression.Equals(_angular.ParametersFromUri))
            {
                var field = model.Where(x => x.EndsWith("#p")).ToList();

                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');

                    if (type[2].Equals("p"))
                    {
                        code += string.Format("/${0} ", type[0]);
                    }

                }
                code = DeleteCharacters.TwoCharacters(code);
            }

            return code;
        }
        String Field(string expression, string nameSpace, string nameTable, List<string> model)
        {

            string code = string.Empty;;

            if (expression.Equals(_angular.Fields))
            {
                var field = model.Where(x => x.EndsWith("#c")).ToList();

                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');


                    code += string.Format("\t\n{0} : {1}, ", type[1], type[0]);

                }
                code = DeleteCharacters.TwoCharacters(code);
            }
            return code;
        }
 



    }
}
