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
    public partial class Order : Form
    {
        string OrderType;

        public Order(string OrderType)
        {
            InitializeComponent();
            tabControl1.SelectedTab = tabControl1.TabPages["tab_" + OrderType.Substring(0, 2)];
            TabControlEventArgs args = new TabControlEventArgs(tabControl1.SelectedTab, tabControl1.SelectedIndex, TabControlAction.Selected);
            tabControl1_Selected(null, args);

            foreach (string acc in MainForm.AccList.Keys)
            {
                cmb_AccNum.Items.Add(acc);
            }
            if (cmb_AccNum.Items.Count > 0)
            {
                cmb_AccNum.SelectedIndex = 0;
            }      

            this.Show();
            MainForm.LoadedForm.Add(this);
        }
        
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            OrderType = e.TabPage.Text;
        }

        private void cmb_AccNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Pass.Text = MainForm.AccList[cmb_AccNum.SelectedItem.ToString()][0];
            lbl_AccName.Text = MainForm.AccList[cmb_AccNum.SelectedItem.ToString()][1];
        }

        private void btn_매도종목_Click(object sender, EventArgs e)
        {
            CodeSelector.textbox = txt_매도종목;
            CodeSelector.Instance.ShowDialog(this);
        }

        private void btn_매수종목_Click(object sender, EventArgs e)
        {
            CodeSelector.textbox = txt_매수종목;
            CodeSelector.Instance.ShowDialog(this);
        }

        private void btn_정정주문번호_Click(object sender, EventArgs e)
        {
            OpenOrds myOpenOrds = new OpenOrds(cmb_AccNum.SelectedItem.ToString(), txt_Pass.Text.Trim());
            myOpenOrds.textbox = txt_정정주문번호;
            myOpenOrds.label = lbl_정정종목;
            myOpenOrds.ShowDialog(this);
        }

        private void btn_취소주문번호_Click(object sender, EventArgs e)
        {
            OpenOrds myOpenOrds = new OpenOrds(cmb_AccNum.SelectedItem.ToString(), txt_Pass.Text.Trim());
            myOpenOrds.textbox = txt_취소주문번호;
            myOpenOrds.label = lbl_취소종목;
            myOpenOrds.ShowDialog(this);
        }

        private void ReceveData(XAQueryClass myXAQueryClass)
        {

        }

        private void ReceveMsg(bool bIsSystemError, string Msg)
        {
            if (bIsSystemError)
            {
                MessageBox.Show(Msg);
            }
            else
            {
                toolStripStatusLabel1.Text = Msg;
            }
        }

        private void btn_매도주문_Click(object sender, EventArgs e)
        {
            CFOAT00100 myCFOAT00100 = new CFOAT00100();
            myCFOAT00100.CallBackMethod+=ReceveData;
            myCFOAT00100.CallBackMsg+=ReceveMsg;
            Dictionary<string, string> InputDataTable = new Dictionary<string, string>();
            InputDataTable.Add("AcntNo", cmb_AccNum.SelectedItem.ToString());
            InputDataTable.Add("Pwd", txt_Pass.Text.Trim());
            foreach (KeyValuePair<string, List<string>> code in MainForm.종목마스터)
            {
                if (code.Value[0] == txt_매도종목.Text.Trim())
                {
                    InputDataTable.Add("FnoIsuNo", code.Key);
                }
            }

            InputDataTable.Add("BnsTpCode", "1");
            InputDataTable.Add("FnoOrdprcPtnCode", "00");
            InputDataTable.Add("OrdPrc", num_매도가격.Value.ToString());
            InputDataTable.Add("OrdQty", num_매도수량.Value.ToString());

            myCFOAT00100.QueryExcute(InputDataTable);
        }

        private void btn_매수주문_Click(object sender, EventArgs e)
        {
            CFOAT00100 myCFOAT00100 = new CFOAT00100();
            myCFOAT00100.CallBackMethod += ReceveData;
            myCFOAT00100.CallBackMsg += ReceveMsg;
            Dictionary<string, string> InputDataTable = new Dictionary<string, string>();
            InputDataTable.Add("AcntNo", cmb_AccNum.SelectedItem.ToString());
            InputDataTable.Add("Pwd", txt_Pass.Text.Trim());
            foreach (KeyValuePair<string, List<string>> code in MainForm.종목마스터)
            {
                if (code.Value[0] == txt_매수종목.Text.Trim())
                {
                    InputDataTable.Add("FnoIsuNo", code.Key);
                }
            }

            InputDataTable.Add("BnsTpCode", "2");
            InputDataTable.Add("FnoOrdprcPtnCode", "00");
            InputDataTable.Add("OrdPrc", num_매수가격.Value.ToString());
            InputDataTable.Add("OrdQty", num_매수수량.Value.ToString());

            myCFOAT00100.QueryExcute(InputDataTable);
        }

        private void btn_정정주문_Click(object sender, EventArgs e)
        {
            CFOAT00200 myCFOAT00200 = new CFOAT00200();
            myCFOAT00200.CallBackMethod += ReceveData;
            myCFOAT00200.CallBackMsg += ReceveMsg;
            Dictionary<string, string> InputDataTable = new Dictionary<string, string>();
            InputDataTable.Add("AcntNo", cmb_AccNum.SelectedItem.ToString());
            InputDataTable.Add("Pwd", txt_Pass.Text.Trim());
            foreach (KeyValuePair<string, List<string>> code in MainForm.종목마스터)
            {
                if (code.Value[0] == lbl_정정종목.Text.Split(new string[]{","},StringSplitOptions.RemoveEmptyEntries)[0].Trim())
                {
                    InputDataTable.Add("FnoIsuNo", code.Key);
                }
            }

            InputDataTable.Add("OrgOrdNo", txt_정정주문번호.Text.Trim());
            InputDataTable.Add("FnoOrdprcPtnCode", "00");
            InputDataTable.Add("OrdPrc", num_정정가격.Value.ToString());
            InputDataTable.Add("MdfyQty", num_정정수량.Value.ToString());

            myCFOAT00200.QueryExcute(InputDataTable);
        }

        private void btn_취소주문_Click(object sender, EventArgs e)
        {
            CFOAT00300 myCFOAT00300 = new CFOAT00300();
            myCFOAT00300.CallBackMethod += ReceveData;
            myCFOAT00300.CallBackMsg += ReceveMsg;
            Dictionary<string, string> InputDataTable = new Dictionary<string, string>();
            InputDataTable.Add("AcntNo", cmb_AccNum.SelectedItem.ToString());
            InputDataTable.Add("Pwd", txt_Pass.Text.Trim());
            foreach (KeyValuePair<string, List<string>> code in MainForm.종목마스터)
            {
                if (code.Value[0] == lbl_취소종목.Text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0].Trim())
                {
                    InputDataTable.Add("FnoIsuNo", code.Key);
                }
            }

            InputDataTable.Add("OrgOrdNo", txt_취소주문번호.Text.Trim());
            InputDataTable.Add("CancQty", num_취소수량.Value.ToString());

            myCFOAT00300.QueryExcute(InputDataTable);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PriceSelector myPriceSelector = new PriceSelector(txt_매도종목.Text.Trim());
            myPriceSelector.num = num_매도가격;
            myPriceSelector.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PriceSelector myPriceSelector = new PriceSelector(txt_매수종목.Text.Trim());
            myPriceSelector.num = num_매수가격;
            myPriceSelector.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PriceSelector myPriceSelector = new PriceSelector(lbl_정정종목.Text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0].Trim());
            myPriceSelector.num = num_정정가격;
            myPriceSelector.ShowDialog();
        }

        private void num_매도가격_ValueChanged(object sender, EventArgs e)
        {
            if (((NumericUpDown)sender).Value <= 3.00m && ((NumericUpDown)sender).Increment != 0.01m)
            {
                ((NumericUpDown)sender).Increment = 0.01m;
            }
            else if (((NumericUpDown)sender).Value >= 3.01m && ((NumericUpDown)sender).Increment != 0.05m)
            {
                ((NumericUpDown)sender).Value = decimal.Ceiling(decimal.Divide(((NumericUpDown)sender).Value, 0.05m)) * 0.05m;
                ((NumericUpDown)sender).Increment = 0.05m;
            }
        }

        private void Order_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.LoadedForm.Remove(this);
        }
    }
}
