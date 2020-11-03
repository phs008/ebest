using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sample
{
    /// <summary>
    /// 선물주문정정취소(Real)
    /// </summary>
    class H01 : Real
    {
        public H01()
            : base()
        {
            myXARealClass.ResFileName = @"C:\ETRADE\xingAPI\Res\H01.res";
        }
        /// <param name="InputDataTable">입력사항 없슴</param>
        public override void AdviseExcute(Dictionary<string, string> InputDataTable)
        {
            base.AdviseExcute(InputDataTable);
        }

        protected override void myXARealClass_ReceiveRealData(string szTrCode)
        {
            base.myXARealClass_ReceiveRealData(szTrCode);
        }
    }
}
