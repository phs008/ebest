using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;

namespace Sample
{
    /// <summary>
    /// 선물/옵션잔고평가(이동평균)(Query)
    /// </summary>
    class t0441:Query
    {
        public t0441()
            : base()
        {
            myXAQueryClass.ResFileName = @"C:\ETRADE\xingAPI\Res\t0441.res";
            GetInBlockName();
        }

        /// <param name="InputDataTable">accno(계좌번호), passwd(계좌비밀번호)</param>
        public t0441(Dictionary<string, string> InputDataTable)
            : base()
        {
            this.InputDataTable = InputDataTable;
            myXAQueryClass.ResFileName = @"C:\ETRADE\xingAPI\Res\t0441.res";
            GetInBlockName();
        }

        /// <param name="InputDataTable">accno(계좌번호), passwd(계좌비밀번호)</param>
        public override void QueryExcute(Dictionary<string, string> InputDataTable)
        {
            base.QueryExcute(InputDataTable);
        }

        protected override void myXAQueryClass_ReceiveData(string szTrCode)
        {
            string t0441OutBlock_cts_expcode = myXAQueryClass.GetFieldData("t0441OutBlock", "cts_expcode", 0);//CTS_종목번호
            string t0441OutBlock_cts_medocd = myXAQueryClass.GetFieldData("t0441OutBlock", "cts_medocd", 0);//CTS_매매구분

            base.myXAQueryClass_ReceiveData(szTrCode);

            if (myXAQueryClass.IsNext)
            {
                Thread.Sleep(100);
                myXAQueryClass.SetFieldData("t0441InBlock", "cts_expcode", 0, t0441OutBlock_cts_expcode);//CTS_종목번호
                myXAQueryClass.SetFieldData("t0441InBlock", "cts_medocd", 0, t0441OutBlock_cts_medocd);//CTS_매매구분
                myXAQueryClass.Request(true);
            }
            else
            {
            }
        }
    }
}
