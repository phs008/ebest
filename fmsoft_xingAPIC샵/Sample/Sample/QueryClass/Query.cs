using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XA_DATASETLib;
using System.Threading;

namespace Sample
{
    /// <summary>
    /// XAQueryClass
    /// </summary>
    class Query
    {
        protected XAQueryClass myXAQueryClass;
        public delegate void callbackdelegate(XAQueryClass myXAQueryClass);
        public callbackdelegate CallBackMethod;
        public delegate void callbackMsgdelegate(bool bIsSystemError, string Msg);
        public callbackMsgdelegate CallBackMsg;
        protected Dictionary<string, string> InputDataTable;
        protected string InBlockName = "";//단일블럭의SetFieldData를 필요로하는 tr만 사용가능(예외 : t1104 주식 현재가 시세메모)

        public Query()
        {
            myXAQueryClass = new XAQueryClass();
            myXAQueryClass.ReceiveData += new _IXAQueryEvents_ReceiveDataEventHandler(myXAQueryClass_ReceiveData);
            myXAQueryClass.ReceiveMessage += new _IXAQueryEvents_ReceiveMessageEventHandler(myXAQueryClass_ReceiveMessage);
        }

        //단일블럭의SetFieldData를 필요로하는 tr만 사용가능(예외 : t1104 주식 현재가 시세메모 등..)
        protected void GetInBlockName()//myXAQueryClass.ResFileName()호출후에 이루어짐
        {
            string resdata = myXAQueryClass.GetResData();            
            string[] strarray = resdata.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in strarray)
            {
                if (str.Contains("***"))
                {
                    string blockname = str.Replace("*", "").Replace("레코드명:", "").Replace(" ", "").ToLower();
                    if (blockname.Contains("inblock"))
                    {
                        InBlockName = blockname;
                        break;
                    }
                }
            }
        }

        private void myXAQueryClass_ReceiveMessage(bool bIsSystemError, string nMessageCode, string szMessage)
        {
            if (CallBackMsg != null)
            {
                CallBackMsg(bIsSystemError, nMessageCode + "   " + szMessage);
            }  
        }  

        protected virtual void myXAQueryClass_ReceiveData(string szTrCode)
        {
            if (CallBackMethod != null)
            {
                CallBackMethod(myXAQueryClass);
            }            
        }

        public virtual void QueryExcute(Dictionary<string, string> InputDataTable)
        {
            foreach (KeyValuePair<string, string> inputData in InputDataTable)
            {
                myXAQueryClass.SetFieldData(InBlockName, inputData.Key, 0, inputData.Value);
            }
            myXAQueryClass.Request(false);
        }

        public void QueryExcute()
        {
            this.QueryExcute(InputDataTable);
        }
    }
}
