using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sample
{
    /// <summary>
    /// 선물주문체결(Real)
    /// </summary>
    class C01 : Real
    {
        public C01()
            : base()
        {
            myXARealClass.ResFileName = @"C:\ETRADE\xingAPI\Res\C01.res";
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
