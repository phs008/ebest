using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample
{
    /// <summary>
    /// KOSPI200선물체결
    /// </summary>
    class FC0 : Real
    {
       public FC0()
            : base()
        {
            myXARealClass.ResFileName = @"C:\ETRADE\xingAPI\Res\FC0.res";
        }

       /// <param name="InputDataTable">futcode(단축코드)</param>
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
