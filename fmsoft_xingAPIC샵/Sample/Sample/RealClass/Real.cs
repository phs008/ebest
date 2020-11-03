using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XA_DATASETLib;
using System.Threading;

namespace Sample
{
    /// <summary>
    /// XARealClass
    /// </summary>
    class Real
    {
        protected XARealClass myXARealClass;
        public delegate void callbackdelegate(XARealClass myXARealClass);
        public callbackdelegate CallBackMethod;
        protected Dictionary<string, string> InputDataTable;
        protected string InBlockName = "InBlock";

        public Real()
        {
            myXARealClass = new XARealClass();
            myXARealClass.ReceiveRealData += new _IXARealEvents_ReceiveRealDataEventHandler(myXARealClass_ReceiveRealData);
        }

        protected virtual void myXARealClass_ReceiveRealData(string szTrCode)
        {
            if (CallBackMethod != null)
            {
                CallBackMethod(myXARealClass);
            }       
        }

        public virtual void AdviseExcute(Dictionary<string, string> InputDataTable)
        {
            foreach (KeyValuePair<string, string> inputData in InputDataTable)
            {
                myXARealClass.SetFieldData(InBlockName, inputData.Key, inputData.Value);
            }
            myXARealClass.AdviseRealData();
        }

        public void UnadviseRealData()
        {
            myXARealClass.UnadviseRealData();
        }

        ~Real()
        {
            CallBackMethod = null;
            myXARealClass.UnadviseRealData();
            Console.WriteLine("myXARealClass.UnadviseRealData(); " + myXARealClass.GetTrCode());
        }
    }
}
