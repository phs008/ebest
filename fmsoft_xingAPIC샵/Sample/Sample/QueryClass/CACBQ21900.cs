using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample
{
    /// <summary>
    /// 개별계좌정보조회(Query)
    /// </summary>
    class CACBQ21900 : Query
    {
        public CACBQ21900()
            : base()
        {
            myXAQueryClass.ResFileName = @"C:\ETRADE\xingAPI\Res\CACBQ21900.res";
            GetInBlockName();
        }

        /// <param name="InputDataTable">RecCnt(레코드갯수), AcntNo(계좌번호), InptPwd(계좌비밀번호)</param>
        public CACBQ21900(Dictionary<string, string> InputDataTable)
            : base()
        {
            this.InputDataTable = InputDataTable;
            myXAQueryClass.ResFileName = @"C:\ETRADE\xingAPI\Res\CACBQ21900.res";
            GetInBlockName();
        }

        /// <param name="InputDataTable">RecCnt(레코드갯수), AcntNo(계좌번호), InptPwd(계좌비밀번호)</param>
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
