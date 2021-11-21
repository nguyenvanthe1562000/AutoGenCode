using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Expression
{
    public class ExpressionAngular : ExpressionCommon
    {
        #region api trong angular
        //api được thêm
        public string GenFieldName { get; }
        public string GenFieldValue { get; }
        public string GenDropdownOption { get; }
        public string GenFromCreate { get; }
        public string GenFromEdit { get; }
        public string DataMember { get; }
        public string DataLength { get; }
        public string DataType { get; }
        public string Begin { get; }
        public string End { get; }
        public string Paste { get; }

        // api được láy từ các api khác có sự thay đổi.
        public string ParametersInit { get; }
        public string ParametersPass { get; }
        public string ParametersStore { get; }
        public string ParametersModelStore { get; }
        public string ParametersModelPass { get; }
        public string ParametersService { get; }
        public string ParametersRepository { get; }
        public string Fields { get; }
        public string Iclass { get; }
        public string IclassService { get; }
        public string IclassRepository { get; }
        public string VariableService { get; }
        public string VariableRepository { get; }
        public string ClassModel { get; }
        public string ClassService { get; }
        public string ClassRepository { get; }
        public string CommentParam { get; }
        public string Namespace { get; }
        public string ParametersFromBody { get; }
        public string ParametersFromUri { get; }
        public string ParametersRoute { get; }
        #endregion
        public ExpressionAngular()
        {
            //
            this.GenFieldName = "{{gen.fieldname}}";
            this.GenFieldValue = "{{gen.fieldvalue}}";
            this.GenDropdownOption = "{{gen.dropdownoption}}";
            this.GenFromCreate = "{{gen.fromcreate}}";
            this.GenFromEdit = "{{gen.fromedit}}";
            this.DataMember = "{{data.member}}";
            this.DataLength = "{{data.length}}";
            this.DataType = "{{data.type}}";
            this.Begin = "{{begin.";
            this.End = "{{end.";
            this.Paste = "{{paste.";
            //
            this.ParametersInit = "{{parameters.init}}";
            this.ParametersPass = "{{parameters.pass}}";
            this.ParametersStore = "{{parameters.store}}";
            this.ParametersModelStore = "{{parameters.modelstore}}";
            this.ParametersModelPass = "{{parameters.modelpass}}";
            this.ParametersService = "{{parameters.service}}";
            this.ParametersRepository = "{{parameters.repository}}";
            this.Fields = "{{fields}}";
            this.Namespace = "{{namespace}}";
            this.Iclass = "{{iclass}}";
            this.IclassService = "{{iclass.service}}";
            this.IclassRepository = "{{iclass.repository}}";
            this.VariableRepository = "{{variable.repository}}";
            this.VariableService = "{{variable.service}}";
            this.ClassModel = "{{class.model}}";
            this.ClassService = "{{class.service}}";
            this.ClassRepository = "{{class.repository}}";
            this.CommentParam = "{{comment.param}}";
            this.ParametersFromBody = "{{parameters.frombody}}";
            this.ParametersFromUri = "{{parameters.fromuri}}";
            this.ParametersRoute = "{{parameters.route}}";
        }

    }
}
