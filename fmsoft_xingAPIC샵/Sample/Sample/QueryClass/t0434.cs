using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sample
{
    /// <summary>
    /// 선물/옵션체결/미체결
    /// </summary>
    class t0434 : Query
    {
        public t0434()
            : base()
        {
            myXAQueryClass.ResFileName = @"C:\ETRADE\xingAPI\Res\t0434.res";
            GetInBlockName();
        }

        /// <param name="InputDataTable">accno(계좌번호), passwd(비밀번호), chegb(체결구분), sortgb(정렬순서)</param>
        public t0434(Dictionary<string, string> InputDataTable)
            : base()
        {
            this.InputDataTable = InputDataTable;
            myXAQueryClass.ResFileName = @"C:\ETRADE\xingAPI\Res\t0434.res";
            GetInBlockName();
        }
 
        /// <param name="InputDataTable">accno(계좌번호), passwd(비밀번호), chegb(체결구분), sortgb(정렬순서)</param>
        public override void QueryExcute(Dictionary<string, string> InputDataTable)
        {
            base.QueryExcute(InputDataTable);
        }    

        protected override void myXAQueryClass_ReceiveData(string szTrCode)
        {
            string cts_ordno = myXAQueryClass.GetFieldData("t0434OutBlock", "cts_ordno", 0);

            base.myXAQueryClass_ReceiveData(szTrCode);

            if (myXAQueryClass.IsNext)
            {
                Thread.Sleep(100);
                myXAQueryClass.SetFieldData("t0434InBlock", "cts_ordno", 0, cts_ordno);
                myXAQueryClass.Request(true);
            }
            else
            {
            }
        }
    }
}
