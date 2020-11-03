using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XA_DATASETLib;

namespace Sample
{
    public partial class CurrPrice : Form
    {
        private string strCode = "";
        private double currprice;

        FH0 myFH0;
        FC0 myFC0;
        OH0 myOH0;
        OC0 myOC0;

        public CurrPrice()
        {
            InitializeComponent();

            myFH0 = new FH0();
            myFC0 = new FC0();
            myOH0 = new OH0();
            myOC0 = new OC0();

            this.Show();
            MainForm.LoadedForm.Add(this);
        }

        private void btn_종목_Click(object sender, EventArgs e)
        {
            CodeSelector.textbox = txt_종목;
            CodeSelector.Instance.ShowDialog(this);
        }

        private void txt_종목_TextChanged(object sender, EventArgs e)
        {
            if (txt_종목.Text.Trim().Length == 8)
            {
                foreach (KeyValuePair<string, List<string>> Code in MainForm.종목마스터)
                {
                    if (txt_종목.Text.Trim() == Code.Value[0])
                    {
                        strCode = txt_종목.Text.Trim();
                        lbl_Name.Text = Code.Value[1];

                        Dictionary<string, string> InputDataTable = new Dictionary<string, string>();
                        InputDataTable.Add("shcode", strCode);
                        t2105 myt2105 = new t2105(InputDataTable);
                        myt2105.CallBackMethod = ReceiveData_t2105;
                        myt2105.QueryExcute();
                    }
                }
            }
        }
       
        private void ReceiveData_t2105(XAQueryClass myXAQueryClass)
        {
            if (myXAQueryClass.GetFieldData("t2105OutBlock", "shcode", 0) == strCode)
            {
                string[] Str = new string[]{
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "offerho1", 0),//매도호가1
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "bidho1", 0),//매수호가1
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "offerrem1", 0),//매도호가수량1
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "bidrem1", 0),//매수호가수량1
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "dcnt1", 0),//매도호가건수1
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "scnt1", 0),//매수호가건수1
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "offerho2", 0),//매도호가2
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "bidho2", 0),//매수호가2
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "offerrem2", 0),//매도호가수량2
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "bidrem2", 0),//매수호가수량2
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "dcnt2", 0),//매도호가건수2
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "scnt2", 0),//매수호가건수2
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "offerho3", 0),//매도호가3
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "bidho3", 0),//매수호가3
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "offerrem3", 0),//매도호가수량3
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "bidrem3", 0),//매수호가수량3
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "dcnt3", 0),//매도호가건수3
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "scnt3", 0),//매수호가건수3
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "offerho4", 0),//매도호가4
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "bidho4", 0),//매수호가4
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "offerrem4", 0),//매도호가수량4
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "bidrem4", 0),//매수호가수량4
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "dcnt4", 0),//매도호가건수4
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "scnt4", 0),//매수호가건수4
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "offerho5", 0),//매도호가5
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "bidho5", 0),//매수호가5
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "offerrem5", 0),//매도호가수량5
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "bidrem5", 0),//매수호가수량5
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "dcnt5", 0),//매도호가건수5
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "scnt5", 0),//매수호가건수5
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "dvol", 0),//매도호가총수량
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "svol", 0),//매수호가총수량
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "toffernum", 0),//총매도호가건수
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "tbidnum", 0),//총매수호가건수
                                    myXAQueryClass.GetFieldData("t2105OutBlock", "time", 0)//수신시간
                                    };
                DataUpdate(Str);

                currprice = double.Parse(myXAQueryClass.GetFieldData("t2105OutBlock", "price", 0));
                CurrPriceUpdate();

                if (strCode.Substring(0, 3) == "101")
                {
                    Real해제();

                    myFH0.CallBackMethod += ReceiveRealData_FH0;
                    myFC0.CallBackMethod += ReceiveRealData_FC0;

                    Dictionary<string, string> InputDataTable = new Dictionary<string, string>();
                    InputDataTable.Add("futcode", strCode);
                    myFH0.AdviseExcute(InputDataTable);
                    myFC0.AdviseExcute(InputDataTable);
                }
                else if (strCode.Substring(0, 3) == "201" || strCode.Substring(0, 3) == "301")
                {
                    Real해제();

                    myOH0.CallBackMethod += ReceiveRealData_OH0;
                    myOC0.CallBackMethod += ReceiveRealData_OC0;

                    Dictionary<string, string> InputDataTable = new Dictionary<string, string>();
                    InputDataTable.Add("optcode", strCode);
                    myOH0.AdviseExcute(InputDataTable);
                    myOC0.AdviseExcute(InputDataTable);
                }

            }
        }

        private void Real해제()
        {
            myOC0.CallBackMethod = null;
            myOH0.CallBackMethod = null;
            myFC0.CallBackMethod = null;
            myFH0.CallBackMethod = null;

            myOC0.UnadviseRealData();
            myOH0.UnadviseRealData();
            myFC0.UnadviseRealData();
            myFH0.UnadviseRealData();
        } 

        private void ReceiveRealData_FH0(XARealClass myXARealClass)
        {
             string[] Str = new string[]{       
                                myXARealClass.GetFieldData("OutBlock", "offerho1"),//매도호가1
                                myXARealClass.GetFieldData("OutBlock", "bidho1"),//매수호가1
                                myXARealClass.GetFieldData("OutBlock", "offerrem1"),//매도호가수량1
                                myXARealClass.GetFieldData("OutBlock", "bidrem1"),//매수호가수량1
                                myXARealClass.GetFieldData("OutBlock", "offercnt1"),//매도호가건수1
                                myXARealClass.GetFieldData("OutBlock", "bidcnt1"),//매수호가건수1

                                myXARealClass.GetFieldData("OutBlock", "offerho2"),//매도호가2
                                myXARealClass.GetFieldData("OutBlock", "bidho2"),//매수호가2
                                myXARealClass.GetFieldData("OutBlock", "offerrem2"),//매도호가수량2
                                myXARealClass.GetFieldData("OutBlock", "bidrem2"),//매수호가수량2
                                myXARealClass.GetFieldData("OutBlock", "offercnt2"),//매도호가건수2
                                myXARealClass.GetFieldData("OutBlock", "bidcnt2"),//매수호가건수2

                                myXARealClass.GetFieldData("OutBlock", "offerho3"),//매도호가3
                                myXARealClass.GetFieldData("OutBlock", "bidho3"),//매수호가3
                                myXARealClass.GetFieldData("OutBlock", "offerrem3"),//매도호가수량3
                                myXARealClass.GetFieldData("OutBlock", "bidrem3"),//매수호가수량3
                                myXARealClass.GetFieldData("OutBlock", "offercnt3"),//매도호가건수3
                                myXARealClass.GetFieldData("OutBlock", "bidcnt3"),//매수호가건수3

                                myXARealClass.GetFieldData("OutBlock", "offerho4"),//매도호가4
                                myXARealClass.GetFieldData("OutBlock", "bidho4"),//매수호가4
                                myXARealClass.GetFieldData("OutBlock", "offerrem4"),//매도호가수량4
                                myXARealClass.GetFieldData("OutBlock", "bidrem4"),//매수호가수량4
                                myXARealClass.GetFieldData("OutBlock", "offercnt4"),//매도호가건수4
                                myXARealClass.GetFieldData("OutBlock", "bidcnt4"),//매수호가건수4

                                myXARealClass.GetFieldData("OutBlock", "offerho5"),//매도호가5
                                myXARealClass.GetFieldData("OutBlock", "bidho5"),//매수호가5
                                myXARealClass.GetFieldData("OutBlock", "offerrem5"),//매도호가수량5
                                myXARealClass.GetFieldData("OutBlock", "bidrem5"),//매수호가수량5
                                myXARealClass.GetFieldData("OutBlock", "offercnt5"),//매도호가건수5
                                myXARealClass.GetFieldData("OutBlock", "bidcnt5"),//매수호가건수5

                                myXARealClass.GetFieldData("OutBlock", "totofferrem"),//매도호가총수량
                                myXARealClass.GetFieldData("OutBlock", "totbidrem"),//매수호가총수량
                                myXARealClass.GetFieldData("OutBlock", "totoffercnt"),//매도호가총건수
                                myXARealClass.GetFieldData("OutBlock", "totbidcnt"),//매수호가총건수

                                myXARealClass.GetFieldData("OutBlock", "hotime"),//호가시간
                                };
             DataUpdate(Str);
        }

        private void ReceiveRealData_FC0(XARealClass myXARealClass)
        {
            currprice = double.Parse(myXARealClass.GetFieldData("OutBlock", "price"));//현재가
            CurrPriceUpdate();
        }

        private void ReceiveRealData_OH0(XARealClass myXARealClass)
        {
            string[] Str = new string[]{       
                                   myXARealClass.GetFieldData("OutBlock", "offerho1"),//매도호가1
                                   myXARealClass.GetFieldData("OutBlock", "bidho1"),//매수호가1
                                   myXARealClass.GetFieldData("OutBlock", "offerrem1"),//매도호가수량1
                                   myXARealClass.GetFieldData("OutBlock", "bidrem1"),//매수호가수량1
                                   myXARealClass.GetFieldData("OutBlock", "offercnt1"),//매도호가건수1
                                   myXARealClass.GetFieldData("OutBlock", "bidcnt1"),//매수호가건수1

                                   myXARealClass.GetFieldData("OutBlock", "offerho2"),//매도호가2
                                   myXARealClass.GetFieldData("OutBlock", "bidho2"),//매수호가2
                                   myXARealClass.GetFieldData("OutBlock", "offerrem2"),//매도호가수량2
                                   myXARealClass.GetFieldData("OutBlock", "bidrem2"),//매수호가수량2
                                   myXARealClass.GetFieldData("OutBlock", "offercnt2"),//매도호가건수2
                                   myXARealClass.GetFieldData("OutBlock", "bidcnt2"),//매수호가건수2

                                   myXARealClass.GetFieldData("OutBlock", "offerho3"),//매도호가3
                                   myXARealClass.GetFieldData("OutBlock", "bidho3"),//매수호가3
                                   myXARealClass.GetFieldData("OutBlock", "offerrem3"),//매도호가수량3
                                   myXARealClass.GetFieldData("OutBlock", "bidrem3"),//매수호가수량3
                                   myXARealClass.GetFieldData("OutBlock", "offercnt3"),//매도호가건수3
                                   myXARealClass.GetFieldData("OutBlock", "bidcnt3"),//매수호가건수3

                                   myXARealClass.GetFieldData("OutBlock", "offerho4"),//매도호가4
                                   myXARealClass.GetFieldData("OutBlock", "bidho4"),//매수호가4
                                   myXARealClass.GetFieldData("OutBlock", "offerrem4"),//매도호가수량4
                                   myXARealClass.GetFieldData("OutBlock", "bidrem4"),//매수호가수량4
                                   myXARealClass.GetFieldData("OutBlock", "offercnt4"),//매도호가건수4
                                   myXARealClass.GetFieldData("OutBlock", "bidcnt4"),//매수호가건수4

                                   myXARealClass.GetFieldData("OutBlock", "offerho5"),//매도호가5
                                   myXARealClass.GetFieldData("OutBlock", "bidho5"),//매수호가5
                                   myXARealClass.GetFieldData("OutBlock", "offerrem5"),//매도호가수량5
                                   myXARealClass.GetFieldData("OutBlock", "bidrem5"),//매수호가수량5
                                   myXARealClass.GetFieldData("OutBlock", "offercnt5"),//매도호가건수5
                                   myXARealClass.GetFieldData("OutBlock", "bidcnt5"),//매수호가건수5

                                   myXARealClass.GetFieldData("OutBlock", "totofferrem"),//매도호가총수량
                                   myXARealClass.GetFieldData("OutBlock", "totbidrem"),//매수호가총수량
                                   myXARealClass.GetFieldData("OutBlock", "totoffercnt"),//매도호가총건수
                                   myXARealClass.GetFieldData("OutBlock", "totbidcnt"),//매수호가총건수

                                   myXARealClass.GetFieldData("OutBlock", "hotime")//호가시간
                                    };
            DataUpdate(Str);
        }

        private void ReceiveRealData_OC0(XARealClass myXARealClass)
        {
            currprice = double.Parse(myXARealClass.GetFieldData("OutBlock", "price"));//현재가
            CurrPriceUpdate();
        }

        private void CurrPriceUpdate()
        {
            foreach (Control ctrl in tlp_호가.Controls)
            {
                if (ctrl is Label && double.Parse(((Label)ctrl).Text) == currprice)
                {
                    ((Label)ctrl).BorderStyle = BorderStyle.FixedSingle;
                    ((Label)ctrl).BackColor = Color.Yellow;
                }
                else
                {
                    ((Label)ctrl).BorderStyle = BorderStyle.None;
                    if (((Label)ctrl).Name.Contains("매도"))
                        ((Label)ctrl).BackColor = Color.LightCyan;
                    else
                        ((Label)ctrl).BackColor = Color.MistyRose;
                }
            }
        }

        private void DataUpdate(string[] strarray)
        {
            lbl_매도1_호가.Text = string.Format("{0:0.00}", double.Parse(strarray[0]));
            lbl_매수1_호가.Text = string.Format("{0:0.00}", double.Parse(strarray[1]));
            lbl_매도1_잔량.Text = string.Format("{0:#,#}", int.Parse(strarray[2]));
            lbl_매수1_잔량.Text = string.Format("{0:#,#}", int.Parse(strarray[3]));
            lbl_매도1_건수.Text = string.Format("{0:#,#}", int.Parse(strarray[4]));
            lbl_매수1_건수.Text = string.Format("{0:#,#}", int.Parse(strarray[5]));

            lbl_매도2_호가.Text = string.Format("{0:0.00}", double.Parse(strarray[6]));
            lbl_매수2_호가.Text = string.Format("{0:0.00}", double.Parse(strarray[7]));
            lbl_매도2_잔량.Text = string.Format("{0:#,#}", int.Parse(strarray[8]));
            lbl_매수2_잔량.Text = string.Format("{0:#,#}", int.Parse(strarray[9]));
            lbl_매도2_건수.Text = string.Format("{0:#,#}", int.Parse(strarray[10]));
            lbl_매수2_건수.Text = string.Format("{0:#,#}", int.Parse(strarray[11]));

            lbl_매도3_호가.Text = string.Format("{0:0.00}", double.Parse(strarray[12]));
            lbl_매수3_호가.Text = string.Format("{0:0.00}", double.Parse(strarray[13]));
            lbl_매도3_잔량.Text = string.Format("{0:#,#}", int.Parse(strarray[14]));
            lbl_매수3_잔량.Text = string.Format("{0:#,#}", int.Parse(strarray[15]));
            lbl_매도3_건수.Text = string.Format("{0:#,#}", int.Parse(strarray[16]));
            lbl_매수3_건수.Text = string.Format("{0:#,#}", int.Parse(strarray[17]));

            lbl_매도4_호가.Text = string.Format("{0:0.00}", double.Parse(strarray[18]));
            lbl_매수4_호가.Text = string.Format("{0:0.00}", double.Parse(strarray[19]));
            lbl_매도4_잔량.Text = string.Format("{0:#,#}", int.Parse(strarray[20]));
            lbl_매수4_잔량.Text = string.Format("{0:#,#}", int.Parse(strarray[21]));
            lbl_매도4_건수.Text = string.Format("{0:#,#}", int.Parse(strarray[22]));
            lbl_매수4_건수.Text = string.Format("{0:#,#}", int.Parse(strarray[23]));

            lbl_매도5_호가.Text = string.Format("{0:0.00}", double.Parse(strarray[24]));
            lbl_매수5_호가.Text = string.Format("{0:0.00}", double.Parse(strarray[25]));
            lbl_매도5_잔량.Text = string.Format("{0:#,#}", int.Parse(strarray[26]));
            lbl_매수5_잔량.Text = string.Format("{0:#,#}", int.Parse(strarray[27]));
            lbl_매도5_건수.Text = string.Format("{0:#,#}", int.Parse(strarray[28]));
            lbl_매수5_건수.Text = string.Format("{0:#,#}", int.Parse(strarray[29]));

            lbl_총매도잔량.Text = string.Format("{0:#,#}", int.Parse(strarray[30]));
            lbl_총매수잔량.Text = string.Format("{0:#,#}", int.Parse(strarray[31]));
            lbl_총매도건수.Text = string.Format("{0:#,#}", int.Parse(strarray[32]));
            lbl_총매수건수.Text = string.Format("{0:#,#}", int.Parse(strarray[33]));

            lbl_수신시각.Text = string.Format("{0:0#:##:##}", int.Parse(strarray[34]));
            lbl_잔량차이.Text = string.Format("{0:#,#}", int.Parse(strarray[31]) - int.Parse(strarray[30]));

            if (int.Parse(strarray[31]) - int.Parse(strarray[30]) > 0)
                lbl_잔량차이.ForeColor = Color.Red;
            else if (int.Parse(strarray[31]) - int.Parse(strarray[30]) < 0)
                lbl_잔량차이.ForeColor = Color.Blue;
            else
                lbl_잔량차이.ForeColor = Color.Black;

            CurrPriceUpdate();
        }

        private void CurrPrice_FormClosing(object sender, FormClosingEventArgs e)
        {
            Real해제();
            MainForm.LoadedForm.Remove(this);
        }
    }
}
