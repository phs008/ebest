using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using XA_DATASETLib;

namespace Sample
{
    public partial class CurrPosition : Form
    {
        enum ColumnName { expcode, medosu, jqty, pamt, price, appamt, dtsunik1, sunikrt };
        enum ColumnText { 종목명, 구분, 잔고, 평균단가, 현재가, 평가금액, 평가손익, 손익율 };
        DataTable table;
        C01 myC01;
        FC0 myFC0;
        OC0 myOC0;

        double 매매손익 = 0d;

        public CurrPosition()
        {
            InitializeComponent();

            myC01 = new C01();
            myFC0 = new FC0();
            myOC0 = new OC0();

            foreach (string acc in MainForm.AccList.Keys)
            {
                cmb_AccNum.Items.Add(acc);
            }
            if (cmb_AccNum.Items.Count > 0)
            {
                cmb_AccNum.SelectedIndex = 0;
            }

            table = new DataTable();
            dataGridView1.DataSource = table;

            string[] name = Enum.GetNames(typeof(ColumnName));
            string[] headertext = Enum.GetNames(typeof(ColumnText));

            for (int i = 0; i < name.Length; i++)
            {
                table.Columns.Add(name[i]);
                dataGridView1.Columns[i].HeaderText = headertext[i];
            }

            table.Columns["jqty"].DataType = typeof(double);
            table.Columns["pamt"].DataType = typeof(double);
            table.Columns["price"].DataType = typeof(double);
            table.Columns["appamt"].DataType = typeof(double);
            table.Columns["dtsunik1"].DataType = typeof(double);
            table.Columns["sunikrt"].DataType = typeof(double);

            dataGridView1.Columns["expcode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["medosu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["jqty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["jqty"].DefaultCellStyle.Format = "#,0";
            dataGridView1.Columns["pamt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["pamt"].DefaultCellStyle.Format = "0.00";
            dataGridView1.Columns["price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["price"].DefaultCellStyle.Format = "0.00";
            dataGridView1.Columns["appamt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["appamt"].DefaultCellStyle.Format = "#,0";
            dataGridView1.Columns["dtsunik1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["dtsunik1"].DefaultCellStyle.Format = "#,0";
            dataGridView1.Columns["sunikrt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["sunikrt"].DefaultCellStyle.Format = "#.#0";

            this.Show();
            MainForm.LoadedForm.Add(this);
        }

        private void btn_조회_Click(object sender, EventArgs e)
        {
            table.Clear();
            조회();
        }

        private void btn_실시간_Click(object sender, EventArgs e)//이전 데이타는 반영이 안됨.
        {
            매매손익 = 0d;
            label4.Text = "0";
            label6.Text = "0";
            label8.Text = "0";
            label10.Text = "0";
            table.Clear();
            실시간();
        }

        private void btn_조회실시간_Click(object sender, EventArgs e)
        {
            table.Clear();
            조회();
            실시간();
        }

        private void 조회()
        {
            Real해제();

            Dictionary<string, string> InputDataTable = new Dictionary<string, string>();
            InputDataTable.Add("accno", cmb_AccNum.SelectedItem.ToString().Trim());
            InputDataTable.Add("passwd", txt_Pass.Text.Trim());      
            t0441 myt0441 = new t0441(InputDataTable);
            myt0441.CallBackMethod += ReceveData;
            myt0441.CallBackMsg += ReceveMsg;
            Thread trd = new Thread(new ThreadStart(myt0441.QueryExcute));
            trd.Start();
        }

        private void 실시간()
        {
            Real해제();

            myC01.CallBackMethod += ReceveRealData_C01;
            myC01.AdviseExcute(new Dictionary<string, string>());
        }

        private void ReceveData(XAQueryClass myXAQueryClass)
        {      
            string[] names = Enum.GetNames(typeof(ColumnName));
            int cnt_t0441OutBlock1 = myXAQueryClass.GetBlockCount("t0441OutBlock1");
            for (int i = 0; i < cnt_t0441OutBlock1; i++)
            {
                DataRow newrow = table.NewRow();
                foreach (string colname in names)
                {
                    newrow[colname] = myXAQueryClass.GetFieldData("t0441OutBlock1", colname, i);
                }

                table.Rows.Add(newrow);
            }
            
            매매손익 = double.Parse(myXAQueryClass.GetFieldData("t0441OutBlock", "tdtsunik", 0));
            총손익계산();

            현재가Real요청();
        }

        private void 총손익계산()//매매손익 변동, 포지션변동(청산), 현재가 변동시 호출됨.
        {
            label4.Text = string.Format("{0:#,0}", 매매손익);
            double 진입금액 = 0d;
            double 평가손익 = 0d;
            foreach (DataRow row in table.Rows)
            {
                진입금액 += 500000d * (double)row["jqty"] * (double)row["pamt"];
                평가손익 += (double)row["dtsunik1"];
            }
            label6.Text = string.Format("{0:#,0}", 진입금액);

            label8.Text = string.Format("{0:#,0}", 평가손익);
            if (진입금액 > 0d)
                label10.Text = string.Format("{0:0.00}", 100d * double.Parse(label8.Text) / double.Parse(label6.Text));
            else
                label10.Text = "0";
        }

        private void 현재가Real요청()//Query요청시, 잔고의청산완료, 새로운종목의 신규진입시 호출됨
        {
            //요청사마다 기존요청내역은 모두 지우고 table종목의 현재가 요청을 다시 하게됨.
            myFC0.CallBackMethod = null;
            myFC0.UnadviseRealData();

            myOC0.CallBackMethod = null;
            myOC0.UnadviseRealData();

            myFC0.CallBackMethod += ReceveRealData_FC0;
            myOC0.CallBackMethod += ReceveRealData_OC0;
            foreach (DataRow row in table.Rows)
            {
                if (row["expcode"].ToString().Substring(0, 3) == "101")//선물
                {
                    Dictionary<string, string> InputDataTable = new Dictionary<string, string>();
                    InputDataTable.Add("futcode", row["expcode"].ToString());
                    myFC0.AdviseExcute(InputDataTable);
                }
                else//옵션
                {
                    Dictionary<string, string> InputDataTable = new Dictionary<string, string>();
                    InputDataTable.Add("optcode", row["expcode"].ToString());
                    myOC0.AdviseExcute(InputDataTable);
                }
            }
        }

        private void ReceveRealData_FC0(XARealClass myXARealClass)
        {
            double 현재가 = double.Parse(myXARealClass.GetFieldData("OutBlock", "price"));
            string Code = myXARealClass.GetFieldData("OutBlock", "futcode").Trim();
            손익계산(Code, 현재가);
        }

        private void ReceveRealData_OC0(XARealClass myXARealClass)
        {
            double 현재가 = double.Parse(myXARealClass.GetFieldData("OutBlock", "price"));
            string Code = myXARealClass.GetFieldData("OutBlock", "optcode").Trim();
            손익계산(Code, 현재가);
        }

        private void 손익계산(string Code, double 현재가)
        {
            foreach (DataRow row in table.Rows)
            {
                if (row["expcode"].ToString() == Code)
                {
                    if ((double)row["price"] != 현재가)//현재가가 바뀔때만.
                    {
                        row["price"] = 현재가;
                        row["appamt"] = (double)row["jqty"] * 현재가 * 500000d;// 선/옵 모두 승수는 1Pt.당 500000원 임.

                        if (row["medosu"].ToString() == "매도")
                        {
                            row["dtsunik1"] = 500000d * (double)row["jqty"] * ((double)row["pamt"] - 현재가);
                            row["sunikrt"] = 100d * ((double)row["pamt"] - 현재가) / (double)row["pamt"];
                        }
                        else
                        {
                            row["dtsunik1"] = 500000d * (double)row["jqty"] * (현재가 - (double)row["pamt"]);
                            row["sunikrt"] = 100d * (현재가 - (double)row["pamt"]) / (double)row["pamt"];
                        }

                        총손익계산();
                    }
                    break;
                }
            }
        }

        private void ReceveRealData_C01(XARealClass myXARealClass)
        {
            if (cmb_AccNum.SelectedItem.ToString().Trim() != myXARealClass.GetFieldData("OutBlock", "accno").Trim())
            {
                return;
            }

            string code = MainForm.종목마스터[myXARealClass.GetFieldData("OutBlock", "expcode")][0];//종목코드(표준==>단축)
            double cheprice = double.Parse(myXARealClass.GetFieldData("OutBlock", "cheprice"));//체결가격
            double chevol = double.Parse(myXARealClass.GetFieldData("OutBlock", "chevol"));//체결수량
            string dosugb = myXARealClass.GetFieldData("OutBlock", "dosugb");//매도수구분            
            if (dosugb == "1")
            {
                dosugb = "매도";
            }
            else if (dosugb == "2")
            {
                dosugb = "매수";
            }

            bool 잔고없슴=true;
            for(int i=0;i<table.Rows.Count;i++)
            {
                DataRow row=table.Rows[i];
                if (row["expcode"].ToString() == code)
                {
                    잔고없슴 = false;
                    double 잔고 = double.Parse(row["jqty"].ToString());
                    double 평균단가 = double.Parse(row["pamt"].ToString());
                    string 구분 = row["medosu"].ToString();

                    //실현손익계산
                    if (구분 == "매도")
                    {
                        매매손익 += Math.Min(잔고, chevol) * (평균단가 - cheprice) * 500000d;
                    }
                    else
                    {
                        매매손익 += Math.Min(잔고, chevol) * (cheprice - 평균단가) * 500000d;
                    }

                    if (dosugb == 구분)//잔고추가(진입)
                    {
                        row["pamt"] = Math.Round((cheprice * chevol + 잔고 * 평균단가) / (잔고 + chevol), 4);
                        row["jqty"] = Math.Round(잔고 + chevol, 0);
                    }
                    else//청산
                    {
                        int new잔고 = (int)Math.Round(잔고 - chevol, 0);

                        if (new잔고 == 0)//청산완료
                        {
                            table.Rows.RemoveAt(i);
                            현재가Real요청();
                            break;
                        }
                        else if (new잔고 < 0)//Stop and Reverse
                        {
                            row["jqty"] = Math.Abs(new잔고).ToString();
                            row["pamt"] = cheprice.ToString();
                        }
                        else//일부청산
                        {
                            row["jqty"] = new잔고.ToString();
                        }
                    }
                }
            }

            if (잔고없슴)//진입
            {
                DataRow newrow = table.NewRow();
                newrow["expcode"] = code;
                newrow["medosu"] = dosugb;
                newrow["jqty"] = chevol.ToString();
                newrow["pamt"] = cheprice.ToString();
                newrow["price"] = cheprice.ToString();
                newrow["appamt"] = chevol * cheprice * 500000d;
                newrow["dtsunik1"] = "0";
                newrow["sunikrt"] = "0";
                table.Rows.Add(newrow);
                현재가Real요청();
            }   
     
            총손익계산();
        }
        
        private void Real해제()
        {
            myC01.CallBackMethod = null;
            myC01.UnadviseRealData();

            myFC0.CallBackMethod = null;
            myFC0.UnadviseRealData();

            myOC0.CallBackMethod = null;
            myOC0.UnadviseRealData();
        }

        private void cmb_AccNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Pass.Text = MainForm.AccList[cmb_AccNum.SelectedItem.ToString()][0];
            lbl_AccName.Text = MainForm.AccList[cmb_AccNum.SelectedItem.ToString()][1];
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

        private void CurrPosition_FormClosing(object sender, FormClosingEventArgs e)
        {
            Real해제();
            MainForm.LoadedForm.Remove(this);
        }
    }
}
