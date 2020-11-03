using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample
{
    /// <summary>
    /// 선물옵션 정정주문(Query)
    /// </summary>
    class CFOAT00200 : Query
    {
        public CFOAT00200()
            : base()
        {
            myXAQueryClass.ResFileName = @"C:\ETRADE\xingAPI\Res\CFOAT00200.res";
            GetInBlockName();
        }

        /// <param name="InputDataTable">AcntNo(계좌번호), Pwd(계좌비밀번호), FnoIsuNo(선물옵션종목번호), OrgOrdNo(원주문번호), FnoOrdprcPtnCode(선물옵션호가유형코드(00_지정가, 03_시장가, 05_조건부지정가, 06_최유리지정가, 10_지정가(IOC), 20_지정가(FOK), 13_시장가(IOC), 23_시장가(FOK), 16_최유리지정가(IOC), 26_최유리지정가(FOK))), OrdPrc(주문가격), MdfyQty(정정수량)</param>
        public CFOAT00200(Dictionary<string, string> InputDataTable)
            : base()
        {
            this.InputDataTable = InputDataTable;
            myXAQueryClass.ResFileName = @"C:\ETRADE\xingAPI\Res\CFOAT00200.res";
            GetInBlockName();
        }

        /// <param name="InputDataTable">AcntNo(계좌번호), Pwd(계좌비밀번호), FnoIsuNo(선물옵션종목번호), OrgOrdNo(원주문번호), FnoOrdprcPtnCode(선물옵션호가유형코드(00_지정가, 03_시장가, 05_조건부지정가, 06_최유리지정가, 10_지정가(IOC), 20_지정가(FOK), 13_시장가(IOC), 23_시장가(FOK), 16_최유리지정가(IOC), 26_최유리지정가(FOK))), OrdPrc(주문가격), MdfyQty(정정수량)</param>
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
