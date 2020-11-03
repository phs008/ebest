using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sample
{
    /// <summary>
    /// 선물/옵션현재가호가조회
    /// </summary>
    class t2105 : Query
    {
        public t2105()
            : base()
        {
            myXAQueryClass.ResFileName = @"C:\ETRADE\xingAPI\Res\t2105.res";
            GetInBlockName();
        }

        /// <param name="InputDataTable">shcode(단축코드)</param>
        public t2105(Dictionary<string, string> InputDataTable)
            : base()
        {
            this.InputDataTable = InputDataTable;
            myXAQueryClass.ResFileName = @"C:\ETRADE\xingAPI\Res\t2105.res";
            GetInBlockName();
        }

        /// <param name="InputDataTable">shcode(단축코드)</param>
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
