using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample
{
    /// <summary>
    /// KOSPI200옵션민감도
    /// </summary>
    class OMG  : Real
    {        
        public OMG()
            : base()
        {
            myXARealClass.ResFileName = @"C:\ETRADE\xingAPI\Res\OMG.res";
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
