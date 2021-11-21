using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Expression
{
 public  class ExpressionSQL:ExpressionCommon
    {
        public string StoreParameter_1 { get; }
        public string StoreParameter_2 { get; }
        public string StoreTablefield { get; }
        public string StoreRequired_1 { get; }
        public string StoreTableFieldStoreUpdateSet { get; }
        public string StoreChecking { get; }
        public string StoreOrder { get; }
        public string StoreLang_v { get; }
        public string StoreLang_e { get; }
        public string StoreLang_v_Check { get; }
        public string StoreLang_e_Check { get; }
        public string StoreJsonfield { get; }
        public string StoreRequired_2 { get; }
        public string StoreFromjson { get; }
        public string StoreSelectJsonField { get; }
        public string StoreInsert_1 { get; }
        public string StoreInsert_2 { get; }
        public string StoreUpdate { get; }
        public string StoreRequired_3 { get; set; }

        public ExpressionSQL()
        {
            this.StoreParameter_1 = "{{store.parameter_1}}";
            this.StoreParameter_2 = "{{store.parameter_2}}";
            this.StoreTablefield = "{{store.tablefield}}";
            this.StoreRequired_1 = "{{store.required_1}}";
            this.StoreTableFieldStoreUpdateSet = "{{store.tablefield=store.updateset}} ";
            this.StoreChecking = "{{store.checking}}";
            this.StoreOrder = "{{store.order}}";
            this.StoreLang_v = "{{store.lang_v}}";
            this.StoreLang_e = "{{store.lang_e}}";
            this.StoreLang_v_Check = "{{store.lang_v_check}}";
            this.StoreLang_e_Check = "{{store.lang_e_check}}";
            this.StoreJsonfield = "{{store.jsonfield}}";
            this.StoreRequired_2 = "{{store.required_2}}";
            this.StoreFromjson = " {{store.fromjson}}";
            this.StoreSelectJsonField = "{{store.selectjsonfield}}";
            this.StoreInsert_1 = "{{store.insert_1}}";
            this.StoreInsert_2 = "{{store.insert_2}}";
            this.StoreUpdate = "{{store.update}}";
        
        this.StoreRequired_3 = "{{store.required_3}}";
            }
}
}
