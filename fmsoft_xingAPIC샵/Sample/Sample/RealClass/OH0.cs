using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample
{
    /// <summary>
    /// KOSPI200옵션호가
    /// </summary>
    class OH0 : Real
    {       
        public OH0()
            : base()
        {
            myXARealClass.ResFileName = @"C:\ETRADE\xingAPI\Res\OH0.res";
        }

        /// <param name="InputDataTable">optcode(단축코드)</param>
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
