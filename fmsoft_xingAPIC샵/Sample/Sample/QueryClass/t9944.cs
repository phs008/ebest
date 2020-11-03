using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample
{
    /// <summary>
    /// 지수옵션마스터조회
    /// </summary>
    class t9944 : Query
    {      
        public t9944()
            : base()
        {
            myXAQueryClass.ResFileName = @"C:\ETRADE\xingAPI\Res\t9944.res";
            GetInBlockName();
        }

        /// <param name="InputDataTable">입력사항 없슴</param>
        public t9944(Dictionary<string, string> InputDataTable)
            : base()
        {
            this.InputDataTable = InputDataTable;
            myXAQueryClass.ResFileName = @"C:\ETRADE\xingAPI\Res\t9944.res";
            GetInBlockName();
        }

        /// <param name="InputDataTable">입력사항 없슴</param>
        public override void QueryExcute(Dictionary<string, string> InputDataTable)
        {
            base.QueryExcute(InputDataTable);
        }

        protected override void myXAQueryClass_ReceiveData(string szTrCode)
        {
            int cnt_t9944OutBlock = myXAQueryClass.GetBlockCount("t9944OutBlock");
            for (int i = 0; i < cnt_t9944OutBlock; i++)
            {
                 List<string> list = new List<string>();
                string shcode = myXAQueryClass.GetFieldData("t9944OutBlock", "shcode", i);
                string yyyy = "";
                if (shcode.Substring(3, 1) == "H")
                    yyyy = "2013";
                else if (shcode.Substring(3, 1) == "J")
                    yyyy = "2014";
                else if (shcode.Substring(3, 1) == "K")
                    yyyy = "2015";
                string hname = myXAQueryClass.GetFieldData("t9944OutBlock", "hname", i);
                list.Add(shcode);
                list.Add(hname);
                list.Add(yyyy+hname.Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries)[1].Replace("월",""));
                if (!MainForm.종목마스터.ContainsKey(myXAQueryClass.GetFieldData("t9944OutBlock", "expcode", i)))
                    MainForm.종목마스터.Add(myXAQueryClass.GetFieldData("t9944OutBlock", "expcode", i), list);
            }
        }
    }
}
