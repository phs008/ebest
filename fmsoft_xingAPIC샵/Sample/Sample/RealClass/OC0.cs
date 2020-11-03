using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample
{
    /// <summary>
    /// KOSPI200옵션체결
    /// </summary>
    class OC0 : Real
    {        
        public OC0()
            : base()
        {
            myXARealClass.ResFileName = @"C:\ETRADE\xingAPI\Res\OC0.res";
        }

        /// <param name="InputDataTable">단축코드(optcode)</param>
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
