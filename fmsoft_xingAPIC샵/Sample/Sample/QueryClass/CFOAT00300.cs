using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample
{

    /// <summary>
    /// 선물옵션 취소주문(Query)
    /// </summary>
    class CFOAT00300 : Query
    {
        public CFOAT00300()
            : base()
        {
            myXAQueryClass.ResFileName = @"C:\ETRADE\xingAPI\Res\CFOAT00300.res";
            GetInBlockName();
        }

        /// <param name="InputDataTable">AcntNo(계좌번호), Pwd(계좌비밀번호), FnoIsuNo(선물옵션종목번호), OrgOrdNo(원주문번호), CancQty(취소수량)</param>
        public CFOAT00300(Dictionary<string, string> InputDataTable)
            : base()
        {
            this.InputDataTable = InputDataTable;
            myXAQueryClass.ResFileName = @"C:\ETRADE\xingAPI\Res\CFOAT00300.res";
            GetInBlockName();
        }

        /// <param name="InputDataTable">AcntNo(계좌번호), Pwd(계좌비밀번호), FnoIsuNo(선물옵션종목번호), OrgOrdNo(원주문번호), CancQty(취소수량)</param>
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
