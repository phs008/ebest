using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample
{
    /// <summary>
    /// 옵션전광판
    /// </summary>
    class t2301 : Query
    {
        public t2301()
            : base()
        {
            myXAQueryClass.ResFileName = @"C:\ETRADE\xingAPI\Res\t2301.res";
            GetInBlockName();
        }

        /// <param name="InputDataTable">yyyymm(월물)</param>
        public t2301(Dictionary<string, string> InputDataTable)
            : base()
        {
            this.InputDataTable = InputDataTable;
            myXAQueryClass.ResFileName = @"C:\ETRADE\xingAPI\Res\t2301.res";
            GetInBlockName();
        }

        /// <param name="InputDataTable">yyyymm(월물)</param>
        public override void QueryExcute(Dictionary<string, string> InputDataTable)
        {
            base.QueryExcute(InputDataTable);
        }

        protected override void myXAQueryClass_ReceiveData(string szTrCode)
        {
            base.myXAQueryClass_ReceiveData(szTrCode);
        }
    }
}
