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
    public partial class CurrMargin : Form
    {
        CFOBQ10500 myCFOBQ10500;
        public CurrMargin()
        {
            InitializeComponent();

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
            
            myCFOBQ10500 = new CFOBQ10500();
            myCFOBQ10500.CallBackMethod += ReceveData;
            myCFOBQ10500.CallBackMsg += ReceveMsg;

            btn_조회_Click(null, null);
        }

        private void btn_조회_Click(object sender, EventArgs e)
        {
            int num;
            foreach (Control ctrl in tableLayoutPanel1.Controls)
            {
                if (ctrl is Label && int.TryParse(((Label)ctrl).Text, out num))
                    ((Label)ctrl).Text = "0";
            }

            Dictionary<string, string> InputDataTable = new Dictionary<string, string>();
            InputDataTable.Add("RecCnt", "1");
            InputDataTable.Add("AcntNo", cmb_AccNum.SelectedItem.ToString().Trim());
            InputDataTable.Add("Pwd", txt_Pass.Text.Trim());

            myCFOBQ10500.QueryExcute(InputDataTable);
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

        private void ReceveData(XAQueryClass myXAQueryClass)
        {
            label8.Text = string.Format("{0:#,0}", int.Parse(myXAQueryClass.GetFieldData("CFOBQ10500OutBlock2", "DpsamtTotamt", 0)));//예탁금총액
            label9.Text = string.Format("{0:#,0}", int.Parse(myXAQueryClass.GetFieldData("CFOBQ10500OutBlock2", "Dps", 0)));//예수금
            label10.Text = string.Format("{0:#,0}", int.Parse(myXAQueryClass.GetFieldData("CFOBQ10500OutBlock2", "SubstAmt", 0)));//대용금액
            label12.Text = string.Format("{0:#,0}", int.Parse(myXAQueryClass.GetFieldData("CFOBQ10500OutBlock2", "FilupDpsamtTotamt", 0)));//충당예탁금총액
            label13.Text = string.Format("{0:#,0}", int.Parse(myXAQueryClass.GetFieldData("CFOBQ10500OutBlock2", "FilupDps", 0)));//충당예수금
            label34.Text = string.Format("{0:#,0}", int.Parse(myXAQueryClass.GetFieldData("CFOBQ10500OutBlock2", "FutsPnlAmt", 0)));//선물손익금액
            label28.Text = string.Format("{0:#,0}", int.Parse(myXAQueryClass.GetFieldData("CFOBQ10500OutBlock2", "WthdwAbleAmt", 0)));//인출가능금액
            label29.Text = string.Format("{0:#,0}", int.Parse(myXAQueryClass.GetFieldData("CFOBQ10500OutBlock2", "PsnOutAbleCurAmt", 0)));//인출가능현금액
            label30.Text = string.Format("{0:#,0}", int.Parse(myXAQueryClass.GetFieldData("CFOBQ10500OutBlock2", "PsnOutAbleSubstAmt", 0)));//인출가능대용금액
            label16.Text = string.Format("{0:#,0}", int.Parse(myXAQueryClass.GetFieldData("CFOBQ10500OutBlock2", "Mgn", 0)));//증거금액
            label17.Text = string.Format("{0:#,0}", int.Parse(myXAQueryClass.GetFieldData("CFOBQ10500OutBlock2", "MnyMgn", 0)));//현금증거금액
            label20.Text = string.Format("{0:#,0}", int.Parse(myXAQueryClass.GetFieldData("CFOBQ10500OutBlock2", "OrdAbleAmt", 0)));//주문가능금액
            label21.Text = string.Format("{0:#,0}", int.Parse(myXAQueryClass.GetFieldData("CFOBQ10500OutBlock2", "MnyOrdAbleAmt", 0)));//현금주문가능금액
            label24.Text = string.Format("{0:#,0}", int.Parse(myXAQueryClass.GetFieldData("CFOBQ10500OutBlock2", "AddMgn", 0)));//추가증거금액
            label25.Text = string.Format("{0:#,0}", int.Parse(myXAQueryClass.GetFieldData("CFOBQ10500OutBlock2", "MnyAddMgn", 0)));//현금추가증거금액
            label32.Text = string.Format("{0:#,0}", int.Parse(myXAQueryClass.GetFieldData("CFOBQ10500OutBlock2", "AmtPrdayChckInAmt", 0)));//금전일수표입금액
            label36.Text = string.Format("{0:#,0}", int.Parse(myXAQueryClass.GetFieldData("CFOBQ10500OutBlock2", "FnoPrdaySubstSellAmt", 0)));//선물옵션전일대용매도금액
            label40.Text = string.Format("{0:#,0}", int.Parse(myXAQueryClass.GetFieldData("CFOBQ10500OutBlock2", "FnoCrdaySubstSellAmt", 0)));//선물옵션금일대용매도금액
            label38.Text = string.Format("{0:#,0}", int.Parse(myXAQueryClass.GetFieldData("CFOBQ10500OutBlock2", "FnoPrdayFdamt", 0)));//선물옵션전일가입금액
            label42.Text = string.Format("{0:#,0}", int.Parse(myXAQueryClass.GetFieldData("CFOBQ10500OutBlock2", "FnoCrdayFdamt", 0)));//선물옵션금일가입금액
        }

        private void cmb_AccNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Pass.Text = MainForm.AccList[cmb_AccNum.SelectedItem.ToString()][0];
            lbl_AccName.Text = MainForm.AccList[cmb_AccNum.SelectedItem.ToString()][1];
        }

        private void CurrMargin_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.LoadedForm.Remove(this);
        }
    }
}
