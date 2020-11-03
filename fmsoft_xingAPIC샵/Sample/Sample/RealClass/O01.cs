using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sample
{
    /// <summary>
    /// 선물접수(Real)
    /// </summary>
    class O01:Real
    {
        public O01()
            : base()
        {
            myXARealClass.ResFileName = @"C:\ETRADE\xingAPI\Res\O01.res";
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
