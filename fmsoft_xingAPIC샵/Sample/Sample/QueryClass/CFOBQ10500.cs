using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample
{
    /// <summary>
    /// 선물옵션 계좌예탁금증거금조회
    /// </summary>
    class CFOBQ10500 : Query
    {
        public CFOBQ10500()
            : base()
        {
            myXAQueryClass.ResFileName = @"C:\ETRADE\xingAPI\Res\CFOBQ10500.res";
            GetInBlockName();
        }

        /// <param name="InputDataTable">RecCnt(레코드갯수), AcntNo(계좌번호), Pwd(비밀번호)</param>
        public CFOBQ10500(Dictionary<string, string> InputDataTable)
            : base()
        {
            this.InputDataTable = InputDataTable;
            myXAQueryClass.ResFileName = @"C:\ETRADE\xingAPI\Res\CFOBQ10500.res";
            GetInBlockName();
        }

        /// <param name="InputDataTable">RecCnt(레코드갯수), AcntNo(계좌번호), Pwd(비밀번호)</param>
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
