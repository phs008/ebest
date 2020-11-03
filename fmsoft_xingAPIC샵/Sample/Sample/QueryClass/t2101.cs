using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample
{
    /// <summary>
    /// 선물/옵션현재가(시세)조회
    /// </summary>
    class t2101 : Query
    {
        public t2101()
            : base()
        {
            myXAQueryClass.ResFileName = @"C:\ETRADE\xingAPI\Res\t2101.res";
            GetInBlockName();
        }

        /// <param name="InputDataTable">focode(단축코드)</param>
        public t2101(Dictionary<string, string> InputDataTable)
            : base()
        {
            this.InputDataTable = InputDataTable;
            myXAQueryClass.ResFileName = @"C:\ETRADE\xingAPI\Res\t2101.res";
            GetInBlockName();
        }

        /// <param name="InputDataTable">focode(단축코드)</param>
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
