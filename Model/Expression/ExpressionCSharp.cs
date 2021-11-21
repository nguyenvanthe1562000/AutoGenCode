 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Expression
{
    public class ExpressionCSharp : ExpressionCommon
    {
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
        public string ParametersConvert { get; }
        public string ParametersCheckData { get; }
        public string ParametersCreateModel { get; }
        public string ParametersViewModel { get; }

        public ExpressionCSharp()
        {
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
            this.ParametersConvert = "{{parameters.convert}}";
            this.ParametersCheckData = "{{parameters.checkdata}}";
            this.ParametersCreateModel = "{{parameters.createmodel}}";
            this.ParametersViewModel = "{{parameters.viewmodel}}";

        }

    }
}
