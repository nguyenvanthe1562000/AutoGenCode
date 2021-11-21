using Common;
using Model;
using Model.Expression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DAL.GenerationCode
{

    public partial class FunctionGenCodeCsharp
    {
        ReadWirte _readWirte;
        // string _typeNumber = "int bigint decimal float";
        string _typeString = "char varchar text nvarchar text ntext";
        string _typeDate = "date datetime datetime2 datetimeoffset smalldatetime";

        string _temParameter = "";// biến lưu các giá trị dầu vào 1 function
        readonly ExpressionCSharp _cSharp;
        readonly ExpressionSQL _sQL;
        public FunctionGenCodeCsharp()
        {
            _readWirte = new ReadWirte();
            _cSharp = new ExpressionCSharp();
            _sQL = new ExpressionSQL();
        }
        public string Generate(string nameSpace, string nameTable, Dictionary<string, List<string>> model, ConfigLayer layer, out string msgError)
        {
            string str = "";
            try
            {
                msgError = "";
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

        string GenerateMethod(string nameSpace, string nameTable, List<string> model, string path, string optionMethod = null)
        {
            string msgError = "";
            string[] code = new string[1];
            if (!string.IsNullOrEmpty(optionMethod))
            {
                code = new string[] { optionMethod };
            }
            else
            {
                code = _readWirte.ReadFile(path, out msgError);
                if (!string.IsNullOrEmpty(msgError))
                {
                    return msgError;
                }
            }
            return Convert(code, nameSpace, nameTable, model);
        }
        //Convert api
        string Convert(string[] code, string nameSpace, string nameTable, List<string> model, Dictionary<string, List<string>> modelOption = null, ConfigLayer layerOption = null)
        {
            string displayCode = "";

            for (int i = 0; i < code.Length; i++)
            {
                code[i] = GenCSharp(code[i], nameSpace, nameTable);
                code[i] = GenCSharp(code[i], nameSpace, nameTable, model, modelOption, layerOption);
                code[i] = BacsicGenSql(code[i], nameSpace, nameTable, model);
                code[i] = code[i].Trim().EndsWith("AND") == true ? DeleteCharacters.LastCharacters(code[i].Trim(), 3) : code[i];
                code[i] = code[i].Trim().EndsWith(",") == true ? DeleteCharacters.LastCharacters(code[i].Trim(), 1) : code[i];
                displayCode += code[i] + "\n";
            }

            return displayCode;
        }

        private string Convert_e_m(string expression, string nameSpace, string nameTable, List<string> model)
        {
            string code = "";
            if (expression.Equals(_sQL.StoreLang_v_Check))
            {
                var field = model.Where(x => x.EndsWith("#m")).ToList();
                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');

                    if (type[1].EndsWith("_l") || type[1].EndsWith("_v"))
                    {
                        code += string.Format(@"((@{0} = '') OR({1} LIKE '%' + @{0} + '%')) AND ",
                                             DeleteCharacters.TwoCharacters(type[1]), type[1]);
                    }
                    else
                        code += string.Format(@"((@{0} = '') OR({1} LIKE '%' + @{2} + '%')) AND ",
                                            type[1], type[1], type[1]);

                }
            }
            else if (expression.Equals(_sQL.StoreLang_e_Check))
            {
                var field = model.Where(x => x.EndsWith("#e")).ToList();
                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');
                    if (type[1].EndsWith("_e"))
                    {
                        code += string.Format(@"((@{0} = '') OR({1} LIKE '%' + @{0} + '%')) AND ",
                                             DeleteCharacters.TwoCharacters(type[1]), type[1]);
                    }
                    else
                        code += string.Format(@"((@{0} = '') OR({1} LIKE '%' + @{0} + '%')) AND ",
                                                 type[1], type[1]);
                }
            }
            else if (expression.Equals(_sQL.StoreLang_v))
            {
                var field = model.Where(x => x.EndsWith("#m")).ToList();
                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');
                    string valueOrLabel = model.FirstOrDefault(x => x.Contains(type[1]) && (x.EndsWith("l") || x.EndsWith("v")));
                    if (!string.IsNullOrEmpty(valueOrLabel))
                    {
                        code += Convert_l_v(valueOrLabel);
                    }
                    else
                        code += string.Format(@"{0} AS {1}, ",
                            type[1], DeleteCharacters.TwoCharacters(type[1]));
                }
                code = DeleteCharacters.TwoCharacters(code);
            }
            else if (expression.Equals(_sQL.StoreLang_e))
            {
                var field = model.Where(x => x.EndsWith("#e")).ToList();
                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');
                    string valueOrLabel = model.FirstOrDefault(x => x.Contains(type[1]) && (x.EndsWith("l") || x.EndsWith("v")));
                    if (!string.IsNullOrEmpty(valueOrLabel))
                    {
                        code += Convert_l_v(valueOrLabel);
                    }
                    else
                    {
                        code += string.Format(@"{0} AS {1}, ",
                         type[1], DeleteCharacters.TwoCharacters(type[1]));
                    }
                }
                code = DeleteCharacters.TwoCharacters(code);
            }


            return code;
        }
        //private  string Convert_e_m(string expression, string nameSpace, string nameTable, string model)
        //{
        //    string code = "";
        //    string[] type = model[j].Split('#');
        //    if (expression.Equals("{{store.parameter_1}}")
        //    {
        //        if (type[2].Equals("e"))
        //        {
        //            var parameter = field.FirstOrDefault(x => x.Contains(DeleteCharacters.TwoCharacters(type[1])) && x.EndsWith("#m"));
        //            if (!string.IsNullOrEmpty(parameter))
        //            {
        //                field.Remove(parameter);
        //            }
        //            if (type[1].EndsWith("_e"))
        //            { type[1] = DeleteCharacters.TwoCharacters(type[1]); }
        //            code += string.Format("@{0} {1}, ", type[1], type[0]);
        //        }
        //        if (type[2].Equals("m"))
        //        {
        //            var parameter = field.FirstOrDefault(x => x.Contains(DeleteCharacters.TwoCharacters(type[1])) && x.EndsWith("#e"));
        //            if (!string.IsNullOrEmpty(parameter))
        //            {
        //                field.Remove(parameter);
        //            }
        //            if (type[1].EndsWith("_l") || type[1].EndsWith("_m"))
        //            { type[1] = DeleteCharacters.TwoCharacters(type[1]); }
        //            code += string.Format("@{0} {1}, ", type[1], type[0]);
        //        }
        //    }
        //}
        private string Convert_a_d(string expression, string nameSpace, string nameTable, List<string> model)
        {
            string code = "";
            var field = model.Where(x => x.EndsWith("#a") || x.EndsWith("#d")).ToList();
            if (expression.Equals(_sQL.StoreOrder) && field.Count != 0)
            {
                code = "ORDER BY ";
                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');
                    code += string.Format("{0} {1}, ", type[1], type[2].Equals("a") ? "ASC" : "DESC");
                }
                code = DeleteCharacters.TwoCharacters(code);
            }
            return code;
        }
        //private string Convert_k_j(string expression, string nameSpace, string nameTable, List<string> model)
        //{
        //    string code = "";
        //    var field = model.Where(x => x.EndsWith("#k") || x.EndsWith("#j")).ToList();
        //    if (expression.Equals(_cSharp.ParametersConvert) && field.Count != 0)
        //    {
        //        //for (int i = 0; i < field.Count(); i++)
        //        //{

        //        //}
        //        if (field.Exists(x => x.EndsWith("#k"))
        //          { 
        //            code += string.Format("DateTime _fr_{0} = Convert.ToDateTime(fr_{0});");
        //            code += string.Format("DateTime _fr_{0} = Convert.ToDateTime(fr_{0});");
        //        }
        //        if (field.Exists(x => x.EndsWith("#j"))
        //          {
        //            string[] type = field[j].Split('#');
        //            code += string.Format("var json_list=JavaScriptSerializer().Serialize(list_);");

        //        }
        //    }
        //    code = DeleteCharacters.TwoCharacters(code);

        //    return code;
        //}
        string Convert_r(string expression, string nameSpace, string nameTable, List<string> model)
        {
            string code = "WHERE ";
            var field = model.Where(x => x.EndsWith("#r")).ToList();
            if (expression.Equals(_sQL.StoreRequired_1))
            {

                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');

                    var parameter = model.FirstOrDefault(x => x.Contains(type[1]) && x.EndsWith("#j"));
                    if (!string.IsNullOrEmpty(parameter))
                    {
                        code += string.Format("{0}.{1} = allRows.{1} and ", nameTable, type[1]);
                    }
                    else
                        code += string.Format("{0}.{1} = @{2} and ", nameTable, type[1], type[1]);
                }
                code = code.Length > 6 ? DeleteCharacters.FourCharacters(code) : "";
            }
            else if (expression.Equals(_sQL.StoreRequired_2))
            {
                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');
                    code += string.Format("{0}.{1} in ( 'your query' ) and ", nameTable, type[1], type[1]);
                }
                code = DeleteCharacters.FourCharacters(code);
            }
            else if (expression.Equals(_sQL.StoreRequired_3))
            {
                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');
                    code += string.Format("{0}.{1} = @yourparameter and ", nameTable, type[1]);
                }
                code = DeleteCharacters.FourCharacters(code);
            }
            return code;
        }
        string Convert_p(string expression, string nameSpace, string nameTable, List<string> model)
        {
            string code = "";

            var field = model.Where(x => x.EndsWith("#p") || x.EndsWith("#b") || x.EndsWith("#k") || x.EndsWith("#e") || x.EndsWith("#m") || x.EndsWith("#j")).ToList();
            if (expression.Equals(_cSharp.ParametersInit))
            {
                bool checkLang = false;
                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');
                    type[0] = ConvertTypeSqlToCSharp.Convert(type[0]);
                    if (type[2].Equals("p"))
                    {
                        code += string.Format("{0} {1}, ", type[0], type[1]);
                    }
                    else if (type[2].Equals("e"))
                    {
                        checkLang = true;
                        var parameter = field.FirstOrDefault(x => x.Contains(DeleteCharacters.TwoCharacters(type[1])) && x.EndsWith("#m"));
                        if (!string.IsNullOrEmpty(parameter))
                        {
                            field.Remove(parameter);
                        }
                        if (type[1].EndsWith("_e"))
                        { type[1] = DeleteCharacters.TwoCharacters(type[1]); }
                        code += string.Format("{0} {1}, ", type[0], type[1]);
                    }
                    else if (type[2].Equals("m"))
                    {
                        checkLang = true;
                        var parameter = field.FirstOrDefault(x => x.Contains(DeleteCharacters.TwoCharacters(type[1])) && x.EndsWith("#e"));
                        if (!string.IsNullOrEmpty(parameter))
                        {
                            field.Remove(parameter);
                        }
                        if (type[1].EndsWith("_l") || type[1].EndsWith("_m"))
                        { type[1] = DeleteCharacters.TwoCharacters(type[1]); }
                        code += string.Format("{0} {1}, ", type[0], type[1]);
                    }
                    else if (type[2].Equals("k"))
                        code += Convert_k(expression, nameSpace, nameTable, field[j]);
                    else if (type[2].Equals("b"))
                    {
                        code += Convert_b(expression, nameSpace, nameTable, field[j]);
                    }
                    else if (type[2].Equals("j"))
                    {
                        code += Convert_j(expression, nameSpace, nameTable, ref field);
                        j--;
                    }
                }
                if (checkLang)
                {
                    code += "string lang, ";
                }
                _temParameter = code;
                code = DeleteCharacters.TwoCharacters(code);
            }
            else if (expression.Equals(_cSharp.ParametersModelStore))
            {

                for (int j = 0; j < field.Count; j++)
                {
                    string[] type = field[j].Split('#');
                    if (type[2].Equals("p"))
                        code += string.Format("\"@{0}\", model.{0}, ", type[1]);
                }
                code = DeleteCharacters.TwoCharacters(code);
            }
            else if (expression.Equals(_cSharp.ParametersModelPass))
            {

                for (int j = 0; j < field.Count; j++)
                {
                    string[] type = field[j].Split('#');
                    if (type[2].Equals("p"))
                        code += string.Format("model.{0}, ", type[1]);
                }
                code = DeleteCharacters.TwoCharacters(code);
            }
            else if (expression.Equals(_cSharp.ParametersStore))
            {
                string[] parameter = _temParameter.Replace(",", "").Trim().Split(new Char[] { });
                int i = 1;
                for (int j = 0; j < parameter.Length / 2; j++)
                {
                    code += string.Format("\"@{0}\", {0}, ", parameter[j + i]);
                    i++;
                }
                code = DeleteCharacters.TwoCharacters(code);
            }
            else if (expression.Equals(_cSharp.ParametersRoute))
            {
                Convert_p(_cSharp.ParametersFromUri, nameSpace, nameTable, model);
                if (!string.IsNullOrEmpty(_temParameter) && _temParameter.Contains("[FromUri]"))
                {
                    string[] parameter = _temParameter.Replace(",", "").Trim().Split(new Char[] { });
                    int i = 2;
                    for (int j = 0; j < parameter.Length / 3; j++)
                    {
                        code += string.Format("{{{0}}}/", parameter[j + i]);
                        i += 2;
                    }
                    code = DeleteCharacters.LastCharacters(code, 1);
                }

            }
            else if (expression.Equals(_cSharp.ParametersPass))
            {
                if (!string.IsNullOrEmpty(_temParameter) && (_temParameter.Contains("[FromUri]") || _temParameter.Contains("[FromBody]")))
                {
                    string[] parameter = _temParameter.Replace(",", "").Trim().Split(new Char[] { });
                    int i = 2;
                    for (int j = 0; j < parameter.Length / 3; j++)
                    {
                        code += string.Format("{0}, ", parameter[j + i]);
                        i += 2;
                    }

                }

                else if (!string.IsNullOrEmpty(_temParameter))
                {
                    string[] parameter = _temParameter.Replace(",", "").Trim().Split(new Char[] { });
                    int i = 1;
                    if (parameter.Length == 1)
                    {
                        code += string.Format("{0}, ", parameter[0]);
                    }
                    else if (parameter[0].StartsWith("_"))
                    {
                        code += _temParameter;
                    }

                    else
                    {
                        for (int j = 0; j < parameter.Length / 2; j++)
                        {
                            code += string.Format("{0}, ", parameter[j + i]);
                            i++;
                        }

                    }
                }
                else
                {
                    for (int j = 0; j < field.Count; j++)
                    {
                        string[] type = field[j].Split('#');
                        if (type[2].Equals("p"))
                            code += string.Format("{0}, ", type[1]);
                    }
                }
                code = DeleteCharacters.LastCharacters(code, 2);
            }

            else if (expression.Equals(_cSharp.ParametersFromBody))
            {
                if (field.Exists(x => x.EndsWith("#j")))
                {
                    code += Convert_j(expression, nameSpace, nameTable, ref model);
                }
                else code += string.Format("[FromBody] {0}Model model", nameTable);
                _temParameter = code;
            }
            else if (expression.Equals(_cSharp.ParametersFromUri))
            {
                bool checkLang = false;
                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');
                    type[0] = ConvertTypeSqlToCSharp.Convert(type[0]);
                    if (type[2].Equals("p"))
                    {

                        code += string.Format("[FromUri] {0} {1}, ", type[0].Contains("DateTime") ? "string" : type[0], type[1]);
                    }
                    else if (type[2].Equals("e"))
                    {
                        checkLang = true;
                        var parameter = field.FirstOrDefault(x => x.Contains(DeleteCharacters.TwoCharacters(type[1])) && x.EndsWith("#m"));
                        if (!string.IsNullOrEmpty(parameter))
                        {
                            field.Remove(parameter);
                        }
                        if (type[1].EndsWith("_e"))
                        { type[1] = DeleteCharacters.TwoCharacters(type[1]); }
                        code += string.Format("[FromUri] {0} {1}, ", type[0], type[1]);
                    }
                    else if (type[2].Equals("m"))
                    {
                        checkLang = true;
                        var parameter = field.FirstOrDefault(x => x.Contains(DeleteCharacters.TwoCharacters(type[1])) && x.EndsWith("#e"));
                        if (!string.IsNullOrEmpty(parameter))
                        {
                            field.Remove(parameter);
                        }
                        if (type[1].EndsWith("_l") || type[1].EndsWith("_m"))
                        { type[1] = DeleteCharacters.TwoCharacters(type[1]); }
                        code += string.Format("[FromUri] {0} {1}, ", type[0], type[1]);
                    }
                    else if (type[2].Equals("k"))
                        code += Convert_k(expression, nameSpace, nameTable, field[j]);
                    else if (type[2].Equals("b"))
                    {
                        code += Convert_b(expression, nameSpace, nameTable, field[j]);
                    }
                }
                if (checkLang)
                {
                    code += "[FromUri] string lang, ";
                }
                _temParameter = code;
                code = DeleteCharacters.TwoCharacters(code);

            }
            else if (expression.Equals(_sQL.StoreParameter_1))
            {
                bool checkLang = false;
                code += "";
                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');
                    if (type[2].Equals("e"))
                    {
                        checkLang = true;
                        var parameter = field.FirstOrDefault(x => x.Contains(DeleteCharacters.TwoCharacters(type[1])) && x.EndsWith("#m"));
                        if (!string.IsNullOrEmpty(parameter))
                        {
                            field.Remove(parameter);
                        }
                        if (type[1].EndsWith("_e"))
                        { type[1] = DeleteCharacters.TwoCharacters(type[1]); }
                        code += string.Format("@{0} {1}, ", type[1], type[0]);
                    }
                    else if (type[2].Equals("m"))
                    {
                        checkLang = true;
                        var parameter = field.FirstOrDefault(x => x.Contains(DeleteCharacters.TwoCharacters(type[1])) && x.EndsWith("#e"));
                        if (!string.IsNullOrEmpty(parameter))
                        {
                            field.Remove(parameter);
                        }
                        if (type[1].EndsWith("_l") || type[1].EndsWith("_m"))
                        { type[1] = DeleteCharacters.TwoCharacters(type[1]); }
                        code += string.Format("@{0} {1}, ", type[1], type[0]);
                    }
                    else if (type[2].Equals("j"))
                    {
                        code += Convert_j(expression, nameSpace, nameTable, ref field);
                        j--;
                    }
                    else if (type[2].Equals("k"))
                        code += Convert_k(expression, nameSpace, nameTable, field[j]);
                    else if (type[2].Equals("b"))
                    {
                        code += Convert_b(expression, nameSpace, nameTable, field[j]);
                    }
                    else if (type[2].Equals("p"))
                        code += string.Format("@{0} {1}, ", type[1], type[0]);
                }
                if (checkLang)
                {
                    code += "@lang char(1), ";
                }
                code = code.Length > 4 ? DeleteCharacters.TwoCharacters(code) : code;

                code = code.Length < 4 ? DeleteCharacters.TwoCharacters(code) : code;

            }
            else if (expression.Equals(_sQL.StoreParameter_2))
            {
                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');

                    code += string.Format("@{0}, ", type[1]);
                }
                code = DeleteCharacters.TwoCharacters(code);
            }
            else if (expression.Equals(_sQL.StoreChecking))
            {
                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');
                    if (type[2].Equals("p"))
                    {
                        if (type[0].Contains("char") || type[0].Contains("text"))
                        {
                            code += string.Format(@"((@{0} = '') OR({1} LIKE '%' + @{2} + '%')) AND ",
                                type[1], type[1], type[1]);
                        }
                        else
                        {
                            code += string.Format(@"(@{0} is null OR {1}.{2} = @{3}) AND ", type[1], nameTable, type[1], type[1]);
                        }
                    }
                    else if (type[2].Equals("k"))
                    {
                        code += Convert_k(expression, nameSpace, nameTable, field[j]);
                    }
                    else if (type[2].Equals("b"))
                    {
                        code += Convert_b(expression, nameSpace, nameTable, field[j]);
                    }
                }
                code = DeleteCharacters.FourCharacters(code);
            }
            return code;

        }
        private string Convert_b(string expression, string nameSpace, string nameTable, string model)
        {
            string code = "";
            string[] type = model.Split('#');
            if (expression.Equals(_sQL.StoreChecking))
            {
                code += string.Format(@" (CONVERT(DATE, {0}) = CONVERT(DATE, @{1})) AND ", type[1], type[1]);
            }
            else if (expression.Equals(_sQL.StoreParameter_1))
            {
                code += string.Format("@{0} varchar(30), ", type[1]);
            }
            else if (expression.Equals(_cSharp.ParametersInit))
            {
                code += string.Format("string {0}, ", type[1]);
            }
            else if (expression.Equals(_cSharp.ParametersFromUri))
            {
                code += string.Format("[FromUri] string {0}, ", type[1]);
            }
            return code;
        }
        string Convert_k(string expression, string nameSpace, string nameTable, string model)
        {
            string code = "";
            string[] main = model.Split('#');
            if (expression.Equals(_sQL.StoreChecking))
            {

                code += string.Format(@"((@fr_{0} IS NULL
                                    AND @to_{0} IS NULL)
                                   OR (@fr_{0} IS NOT NULL
                                       AND @to_{0} IS NULL
                                       AND {0} >= @fr_{0})
                                   OR (@fr_{0} IS NULL
                                       AND @to_{0} IS NOT NULL
                                       AND {0} <= @to_{0})
                                   OR ({0} BETWEEN @fr_{0} AND @to_{0})) AND ", main[1]);
            }
            else if (expression.Equals(_sQL.StoreParameter_1))
            {
                code += string.Format("@fr_{0} DATETIME, @to_{1} DATETIME, ", main[1], main[1]);
            }
            else if (expression.Equals(_cSharp.ParametersInit))
            {
                code += string.Format("DateTime fr_{0}, DateTime to_{1}, ", main[1], main[1]);
            }
            else if (expression.Equals(_cSharp.ParametersFromUri))
            {
                code += string.Format("[FromUri] string fr_{0}, [FromUri] string to_{1}, ", main[1], main[1]);
            }
            return code;
        }
        string Convert_c(string expression, string nameSpace, string nameTable, List<string> model)
        {
            string code = "";
            var field = model.Where(x => x.EndsWith("c") || x.EndsWith("#j") || x.EndsWith("#p")).ToList();
            if (expression.Equals(_sQL.StoreTablefield))
            {
                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');
                    if (type[2].Equals("c"))
                    {
                        string valueOrLabel = model.FirstOrDefault(x => x.Contains(type[1]) && (x.EndsWith("l") || x.EndsWith("v")));
                        if (!string.IsNullOrEmpty(valueOrLabel))
                        {
                            code += Convert_l_v(valueOrLabel);
                        }
                        else
                        { code += string.Format("{0}, ", type[1]); }
                    }
                }
                code = DeleteCharacters.TwoCharacters(code);
            }
            else if (expression.Equals(_cSharp.Fields))
            {
                code = "\n\t";
                for (int j = 0; j < field.Count; j++)
                {
                    string[] type = field[j].Split('#');
                    string check_r = model.FirstOrDefault(x => x.Contains(type[1]) && (x.EndsWith("#r")));
                    string dataType = ConvertTypeSqlToCSharp.Convert(type[0]);
                    if (!string.IsNullOrEmpty(check_r))
                    {
                        string checkLangth = "";
                        if (_typeString.Contains(Regex.Match(type[0], @"\w+").Value))
                        {
                            string length = Regex.Match(type[0], @"-\d+").Value;
                            length = string.IsNullOrEmpty(length) ? Regex.Match(type[0], @"\d+").Value : length;
                            checkLangth += string.Format("[MaxLength({0})]", length);
                        }
                        code += string.Format(@"
                                                [Required]
                                                {0}
                                                public {1} {2}", checkLangth, dataType, type[1]
                                              ) + " {set; get;}\n";
                    }
                    else
                        code += "public " + dataType + " " + type[1] + " { set; get; }\n\t";
                }
            }
            else if (expression.Equals(_sQL.StoreTableFieldStoreUpdateSet))
            {
                for (int j = 0; j < field.Count; j++)
                {
                    string[] type = field[j].Split('#');
                    string rowUpdateSet = field.FirstOrDefault(x => x.Contains(type[1]) && (x.EndsWith("j") || x.EndsWith("p")));
                    if (rowUpdateSet.EndsWith("#p"))
                    {
                        code += string.Format("{0} = @{1}, ", type[1], type[1]);
                    }
                    else
                    {
                        code += string.Format("{0} = allRows.{1}, ", type[1], type[1]);
                    }
                    field.Remove(rowUpdateSet);
                }
            }
            return code;
        }
        //store procedure
        string Convert_l_v(string model)
        {
            string code = "";
            string[] type = model.Split('#');
            if (type[2].Equals("l"))
                code += string.Format("{0} as label, ", type[1]);
            else if (type[2].Equals("v"))
                code += string.Format("{0} as value, ", type[1]);
            return code;
        }
        string Convert_j(string expression, string nameSpace, string nameTable, ref List<string> model)
        {
            string code = "";

            var field = model.Where(x => x.EndsWith("j")).ToList();
            if (expression.Equals(_sQL.StoreParameter_1))
            {
                if (field.Count > 0)
                {
                    code += string.Format("@listjson_{0} nvarchar(max), ", nameTable);
                    model.RemoveAll(x => x.EndsWith("j"));
                }
            }
            else if (expression.Equals(_cSharp.ParametersInit))
            {
                if (field.Count > 0)
                {
                    code += string.Format("string listjson_{0} ,", nameTable);
                    model.RemoveAll(x => x.EndsWith("j"));
                }
            }
            else if (expression.Equals(_cSharp.ParametersFromBody))
            {
                if (field.Count > 1)
                {
                    code += string.Format("[FromBody] List<{0}Model> listjson_{0}", nameTable);
                    model.RemoveAll(x => x.EndsWith("#j"));
                }
                else
                {
                    string[] type = field[0].Split('#');
                    code += string.Format("[FromBody] List<{0}> listjson_{0}", type[0]);
                    model.RemoveAll(x => x.EndsWith("#j"));
                }
            }
            else if (expression.Equals(_sQL.StoreSelectJsonField))
            {
                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');
                    code += string.Format(" JSON_VALUE({0}.value, '$.{1}') AS {1}, \n", nameTable[0], type[1]);
                }
                code = DeleteCharacters.TwoCharacters(code);
            }
            else if (expression.Equals(_sQL.StoreFromjson))
            {
                code += string.Format("OPENJSON(@listjson_{0}) AS {1}", nameTable, nameTable[0]);
            }
            else if (expression.Equals(_sQL.StoreJsonfield))
            {
                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');
                    code += string.Format("JSON_VALUE(@listjson_{0}, '$.{0}[0].{1}') \n ", nameTable, type[1]);
                }
                code = DeleteCharacters.TwoCharacters(code);
            }
            return code;
        }
        string Convert_i(string expression, string nameSpace, string nameTable, List<string> model)
        {
            string code = "";
            var field = model.Where(x => x.EndsWith("#i") || x.EndsWith("#j") || x.EndsWith("#p")).ToList();
            if (expression.Equals(_sQL.StoreInsert_1))
            {
                for (int j = 0; j < field.Count(); j++)
                {

                    string[] type = field[j].Split('#');
                    if (type[2].Equals("i"))
                        code += string.Format("\n\t\t\t{0},", type[1]);
                }

            }
            else if (expression.Equals(_sQL.StoreInsert_2))
            {
                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');
                    if (type[2].Equals("i"))
                    {
                        var parameter = field.FirstOrDefault(x => x.Contains(type[1]) && (x.EndsWith("#j")));

                        if (!string.IsNullOrEmpty(parameter) && parameter.EndsWith("#j"))
                        {

                            code += string.Format("allRows.{0},\n\t\t\t", type[1]);
                        }

                        else
                        {
                            code += string.Format("@{0},\n\t\t\t", type[1]);
                        }
                        if (_typeDate.Contains(type[0].ToLower()) && (type[1].Contains("create") || type[1].Contains("update")))
                        {
                            code += string.Format("GETDATE(), \n\t\t\t");
                        }

                    }
                }

            }
            else if (expression.Equals(_sQL.StoreUpdate))
            {
                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');
                    if (type[2].Equals("i"))
                    {

                        var parameter = field.FirstOrDefault(x => x.Contains(type[1]) && (x.EndsWith("#j") || x.EndsWith("#p")));
                        if (!string.IsNullOrEmpty(parameter) && parameter.EndsWith("#j"))
                        {

                            code += string.Format("{0}.{1}=allRows.{1},\n\t\t\t", nameTable, type[1]);
                        }
                        else if (!string.IsNullOrEmpty(parameter) && parameter.EndsWith("#p"))
                        {
                            code += string.Format("{0}.{1}=@{1},\n\t\t\t", nameTable, type[1]);
                        }
                        else if (_typeDate.Contains(type[0].ToLower()) && (type[1].Contains("create") || type[1].Contains("update")))
                        {
                            code += string.Format("{0}.{1}=GETDATE(), \n\t\t\t", nameTable, type[1]);
                        }
                    }
                }
            }
            return code;
        }

        public string CsharpCommentParam(string expression, string nameSpace, string nameTable, List<string> model)
        {
            string code = "/// <summary> </summary>\n";
            _temParameter = string.Empty;
            if (expression.Equals(_cSharp.CommentParam))
            {
                string _parameter = Convert_p(_cSharp.ParametersInit, nameSpace, nameTable, model);
                if (!string.IsNullOrEmpty(_parameter))
                {
                    string[] parameter = _parameter.Replace(",", "").Trim().Split(new Char[] { });// string a string b string c
                    int i = 1;//lấy tên biến
                    int k = 2;//lấy kiểu gữ liệu
                    for (int j = 0; j < parameter.Length / 2; j++)
                    {
                        code += string.Format(" /// <param name=\"{0}\">kiểu dữ liệu {1}</param>\n", parameter[j + i], parameter[j * k]);
                        _temParameter += parameter[j + i] + ", ";
                        _temParameter = DeleteCharacters.TwoCharacters(_temParameter);
                        i++;
                    }
                }

            }
            code += "/// <returns> </returns>\n";
            return code;
        }
        public string CsharpParametersCheckData(string expression, string nameSpace, string nameTable, List<string> model)
        {
            string code = string.Empty;
            var field = model.Where(x => x.EndsWith("#j")).ToList();
            if (expression.Equals(_cSharp.ParametersCheckData))
            {
                if (_temParameter.Contains("listjson"))
                {
                    string[] parameter = _temParameter.Replace(",", "").Trim().Split(new Char[] { });
                    int i = 2;
                    _temParameter = string.Empty;
                    for (int j = 0; j < parameter.Length / 3; j++)
                    {
                        code = string.Format(@"string {0} = {1} != null ? JsonConvert.SerializeObject( {1} ) :null;"
                                                , "_" + parameter[j + i], parameter[j + i]);
                        _temParameter += "_" + parameter[j + i] + ", ";
                        _temParameter = DeleteCharacters.TwoCharacters(_temParameter);
                        i += 2;
                    }
                    return code;

                }
                string _paramter = Convert_p(_cSharp.ParametersInit, nameSpace, nameTable, model);
                _temParameter = string.Empty;
                if (!string.IsNullOrEmpty(_paramter))
                {
                    string[] parameter = _paramter.Replace(",", "").Trim().Split(new Char[] { });// string a string b string c
                    int i = 1;//lấy tên biến
                    int k = 2;//lấy kiểu gữ liệu
                    for (int j = 0; j < parameter.Length / 2; j++)
                    {
                        if (parameter[j * k].Equals("DateTime"))
                        {
                            if (parameter[j + i].Contains("fr_"))
                            {
                                code += string.Format(
                                "DateTime {0} = default;\n" +
                                "if (fromData.Keys.Contains(\"{1}\") && fromData[\"{1}\"] != null && fromData[\"{1}\"].ToString() != \"\")\n" +
                                "{{\n" +
                                "var dt  = Convert.ToDateTime(fromData[\"{1}\"].ToString());\n" +
                                "if (dt != null)\n" +
                                "{0} = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);\n" +
                                "}}\n"
                                , "_" + parameter[j + i], parameter[j + i]);

                            }

                            else if (parameter[j + i].Contains("to_"))
                            {

                                code += string.Format(
                                "DateTime {0} = default;\n" +
                                "if (fromData.Keys.Contains(\"{1}\") && fromData[\"{1}\"] != null && fromData[\"{1}\"].ToString() != \"\")\n" +
                                "{{\n" +
                                "var dt  = Convert.ToDateTime(fromData[\"{1}\"].ToString());\n" +
                                "if (dt != null)\n" +
                                "{0} = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);\n" +
                                "}}\n"
                                , "_" + parameter[j + i], parameter[j + i]);

                            }
                            else
                            {
                                code += string.Format(
                                "DateTime {0} = default;\n" +
                                "if (fromData.Keys.Contains(\"{1}\") && fromData[\"{1}\"] != null && fromData[\"{1}\"].ToString() != \"\")\n" +
                                "{{\n" +
                                "var dt  = Convert.ToDateTime(fromData[\"{1}\"].ToString());\n" +
                                "if (dt != null)\n" +
                                "{0} = DateTime.Now();\n" +
                                "}}\n"
                            , "_" + parameter[j + i], parameter[j + i]);
                            }
                        }
                        else if (parameter[j * k].Equals("int"))
                        {
                            code += string.Format(
                                "int {0} = default;\n" +
                                "if (fromData.Keys.Contains(\"{1}\") && fromData[\"{1}\"] != null && fromData[\"{1}\"].ToString() != \"\")\n" +
                                "{{" +
                                "{0}  = Convert.ToInt32(fromData[\"{1}\"].ToString());" +
                                "}}\n"
                            , "_" + parameter[j + i], parameter[j + i]);
                        }
                        else if (parameter[j * k].Equals("string"))
                        {
                            code += string.Format(
                             "string {0} =  \"\";\n" +
                             "if (fromData.Keys.Contains(\"{1}\") && fromData[\"{1}\"] != null && fromData[\"{1}\"].ToString() != \"\")\n" +
                             "{{" +
                             "{0}  = Convert.ToString(fromData[\"{1}\"].ToString());" +
                             "}}\n"
                            , "_" + parameter[j + i], parameter[j + i]);
                        }
                        else if (parameter[j * k].Equals("bool"))
                        {
                            code += string.Format(
                             "bool {0} = default;\n" +
                             "if (fromData.Keys.Contains(\"{1}\") && fromData[\"{1}\"] != null && fromData[\"{1}\"].ToString() != \"\")\n" +
                             "{{" +
                             "{0}  = Convert.ToBoolean(fromData[\"{1}\"].ToString());" +
                             "}}\n"
                             , "_" + parameter[j + i], parameter[j + i]);
                        }

                        _temParameter += "_" + parameter[j + i] + ", ";
                        i++;
                    }

                }
            }
            return code;
        }
        string Convert_v(string expression, string nameSpace, string nameTable, List<string> model)
        {
            string code = "";

            var field = model.Where(x => x.EndsWith("#v")).ToList();
            if (expression.Equals(_cSharp.ParametersCreateModel))
            {

                code = string.Format("{0}Model {1}Model= new {0}Model(){{;\n", nameTable, nameTable.ToLower());
                for (int j = 0; j < field.Count(); j++)
                {
                    string[] type = field[j].Split('#');
                    type[0] = ConvertTypeSqlToCSharp.Convert(type[0]);
                    code += string.Format("{0} = model.{0},\n", type[1]);

                }
                code += "};";
            }
            return code;
        }
    }
}
