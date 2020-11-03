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
    public partial class TradeHistory : Form
    {
        enum ColumnName { ordno, orgordno, expcode, medosu, ordgb, qty, price, cheqty, cheprice, ordrem, status, ordtime };
        enum ColumnText { 주문NO, 원주문, 종목명, 매매구분, 유형, 주문량, 주문가, 체결량, 체결가, 미체결량, 상태, 주문시간 };
        DataTable table;

        string chegb = "0";

        C01 myC01;
        H01 myH01;
        O01 myO01;

        public TradeHistory()
        {
            InitializeComponent();

            myC01 = new C01();
            myH01 = new H01();
            myO01 = new O01();

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

            table.Columns["ordno"].DataType = typeof(int);
            table.Columns["orgordno"].DataType = typeof(int);
            table.Columns["expcode"].DataType = typeof(string);
            table.Columns["medosu"].DataType = typeof(string);
            table.Columns["ordgb"].DataType = typeof(string);
            table.Columns["qty"].DataType = typeof(int);
            table.Columns["price"].DataType = typeof(double);
            table.Columns["cheqty"].DataType = typeof(int);
            table.Columns["cheprice"].DataType = typeof(double);
            table.Columns["ordrem"].DataType = typeof(int);
            table.Columns["status"].DataType = typeof(string);
            table.Columns["ordtime"].DataType = typeof(string);

            dataGridView1.Columns["ordno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["orgordno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["expcode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["medosu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["ordgb"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["qty"].DefaultCellStyle.Format = "#,0";
            dataGridView1.Columns["price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["price"].DefaultCellStyle.Format = "0.00";
            dataGridView1.Columns["cheqty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["cheqty"].DefaultCellStyle.Format = "#,0";
            dataGridView1.Columns["cheprice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["cheprice"].DefaultCellStyle.Format = "0.00";
            dataGridView1.Columns["ordrem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["ordrem"].DefaultCellStyle.Format = "#,0";
            dataGridView1.Columns["status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["ordtime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.Show();
            MainForm.LoadedForm.Add(this);
        }

        private void cmb_AccNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Pass.Text = MainForm.AccList[cmb_AccNum.SelectedItem.ToString()][0];
            lbl_AccName.Text = MainForm.AccList[cmb_AccNum.SelectedItem.ToString()][1];
        }

        private void rbtn_전체_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_전체.Checked)
            {
                chegb = "0";
                모두표시();
            }
            else if (rbtn_체결.Checked)
            {
                chegb = "1";
                체결만표시();
            }
            else if (rbtn_미체결.Checked)
            {
                chegb = "2";
                미체결만표시();
            }
        }

        private void btn_조회_Click(object sender, EventArgs e)
        {
            table.Clear();
            조회();
        }

        private void btn_실시간_Click(object sender, EventArgs e)
        {
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
            InputDataTable.Add("chegb", "0");
            InputDataTable.Add("sortgb", "1");
            t0434 myt0434 = new t0434(InputDataTable);
            myt0434.CallBackMethod += ReceveData;
            myt0434.CallBackMsg += ReceveMsg;
            Thread trd = new Thread(new ThreadStart(myt0434.QueryExcute));
            trd.Start();
        }

        private void 실시간()
        {
            Real해제();

            myC01.CallBackMethod += ReceveRealData_C01;
            myH01.CallBackMethod += ReceveRealData_H01;
            myO01.CallBackMethod += ReceveRealData_O01;

            myC01.AdviseExcute(new Dictionary<string, string>());
            myH01.AdviseExcute(new Dictionary<string, string>());
            myO01.AdviseExcute(new Dictionary<string, string>());
        }

        private void 체결만표시()
        {
            dataGridView1.CurrentCell = null;
            //dataGridView1.ClearSelection();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (int.Parse(dataGridView1.Rows[i].Cells["cheqty"].Value.ToString()) > 0)
                    dataGridView1.Rows[i].Visible = true;
                else
                {
                    dataGridView1.Rows[i].Visible = false;
                }
            }
        }

        private void 미체결만표시()
        {
            dataGridView1.CurrentCell = null;
            //dataGridView1.ClearSelection();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (int.Parse(dataGridView1.Rows[i].Cells["ordrem"].Value.ToString()) > 0)
                    dataGridView1.Rows[i].Visible = true;
                else
                {
                    dataGridView1.Rows[i].Visible = false;
                }
            }
        }

        private void 모두표시()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Visible = true;
            }
        }

        private void Grid표시()
        {
            if (chegb == "0")
                모두표시();
            else if (chegb == "1")
                체결만표시();
            else if (chegb == "2")
                미체결만표시();

            int 선물미체결수량 = Convert.ToInt32(table.Compute("Sum(ordrem)", "expcode LIKE '101*'"));
            int 옵션미체결수량 = Convert.ToInt32(table.Compute("Sum(ordrem)", "expcode NOT LIKE '101*'"));
            int 선물체결수량 = Convert.ToInt32(table.Compute("Sum(cheqty)", "expcode LIKE '101*'"));
            int 옵션체결수량 = Convert.ToInt32(table.Compute("Sum(cheqty)", "expcode NOT LIKE '101*'"));

            label5.Text = string.Format("{0:#,0}", 선물미체결수량 + 선물체결수량);
            label6.Text = string.Format("{0:#,0}", 선물체결수량);
            label9.Text = string.Format("{0:#,0}", 옵션미체결수량 + 옵션체결수량);
            label10.Text = string.Format("{0:#,0}", 옵션체결수량);

        }

        private void ReceveData(XAQueryClass myXAQueryClass)
        {
            string[] names = Enum.GetNames(typeof(ColumnName));
            int cnt_t0434OutBlock1 = myXAQueryClass.GetBlockCount("t0434OutBlock1");
            for (int i = 0; i < cnt_t0434OutBlock1; i++)
            {
                DataRow newrow = table.NewRow();
                foreach (string colname in names)
                {
                    newrow[colname] = myXAQueryClass.GetFieldData("t0434OutBlock1", colname, i);
                }
                table.Rows.Add(newrow);
            }

            Grid표시();
        }

        private void ReceveRealData_C01(XARealClass myXARealClass)//선물주문체결(Real)--주문 체결 과 관련된 처리를 함.
        {
            if (cmb_AccNum.SelectedItem.ToString().Trim() != myXARealClass.GetFieldData("OutBlock", "accno").Trim())
            {
                return;
            }
            string ordno = myXARealClass.GetFieldData("OutBlock", "ordno");//주문번호
            DataRow row = table.Select("ordno = '" + ordno + "'")[0];

            double cheprice = double.Parse(myXARealClass.GetFieldData("OutBlock", "cheprice"));//체결가격
            double chevol = double.Parse(myXARealClass.GetFieldData("OutBlock", "chevol"));//체결수량
            double 체결량 = double.Parse(row["cheqty"].ToString());
            double 체결가 = double.Parse(row["cheprice"].ToString());
            double 미체결량 = double.Parse(row["ordrem"].ToString());

            row["cheprice"] = Math.Round((cheprice * chevol + 체결가 * 체결량) / (체결량 + chevol), 4);//체결량 가중평균
            row["cheqty"] = Math.Round(체결량 + chevol, 0);
            row["ordrem"] = Math.Round(미체결량 - chevol, 0);
            row["status"] = "완료";
            Grid표시();
        }

        private void ReceveRealData_H01(XARealClass myXARealClass)//선물주문정정취소(Real)--정정/취소 확인 부분만 처리됨
        {
            if (cmb_AccNum.SelectedItem.ToString().Trim() != myXARealClass.GetFieldData("OutBlock", "accno").Trim())
            {
                return;
            }

            if (myXARealClass.GetFieldData("OutBlock", "trcode").Trim() == "TTRODP11301" && (myXARealClass.GetFieldData("OutBlock", "mocagb").Trim() == "2" || myXARealClass.GetFieldData("OutBlock", "mocagb").Trim() == "3"))
            {
                string ordno = int.Parse(myXARealClass.GetFieldData("OutBlock", "ordno")).ToString();//주문번호
                string orgordno = int.Parse(myXARealClass.GetFieldData("OutBlock", "orgordno")).ToString();//원주문번호
                string qty = myXARealClass.GetFieldData("OutBlock", "qty");//실정정취소수량

                DataRow row_원주문 = table.Select("ordno = '" + orgordno + "'")[0];
                row_원주문["ordrem"] = int.Parse(row_원주문["ordrem"].ToString()) - int.Parse(qty);

                DataRow row_주문 = table.Select("ordno = '" + ordno + "'")[0];
                row_주문["status"] = row_주문["status"].ToString().Replace("주문", "확인");
                if (myXARealClass.GetFieldData("OutBlock", "mocagb") == "3")//정정취소구분 1 신규, 2 정정, 3 취소
                {
                    row_주문["ordrem"] = 0;
                }
            }

            Grid표시();
        }

        private void ReceveRealData_O01(XARealClass myXARealClass)//선물접수(Real)--매도/매수/정정/취소 주문 접수 처리됨
        {
            if (cmb_AccNum.SelectedItem.ToString().Trim() != myXARealClass.GetFieldData("OutBlock", "accno").Trim())
            {
                return;
            }

            DataRow newrow = table.NewRow();
            newrow["ordno"] = myXARealClass.GetFieldData("OutBlock", "ordno");//주문번호
            newrow["orgordno"] = myXARealClass.GetFieldData("OutBlock", "orgordno");//원주문번호
            newrow["expcode"] = myXARealClass.GetFieldData("OutBlock", "fnoIsuno");//선물옵션종목번호

            string bnstp = myXARealClass.GetFieldData("OutBlock", "bnstp");//매매구분  //1:매도 2:매수
            if (bnstp == "1")
                bnstp = "매도";
            else if (bnstp == "2")
                bnstp = "매수";

            string trcode = myXARealClass.GetFieldData("OutBlock", "trcode");//TRCODE  //SONBT001:신규주문  SONBT002:정정주문  SONBT003:취소주문
            if (trcode == "SONBT002")
                trcode = "정정";
            else if (trcode == "SONBT003")
                trcode = "취소";
            else
                trcode = "";

            newrow["medosu"] = bnstp + trcode;

            string hogatype = myXARealClass.GetFieldData("OutBlock", "hogatype");   //호가유형코드 
            switch (hogatype)
            {
                case "00":
                    hogatype = "지정가";
                    break;
                case "03":
                    hogatype = "시장가";
                    break;
                case "05":
                    hogatype = "조건부지정가";
                    break;
                case "06":
                    hogatype = "최유리지정가";
                    break;
                case "10":
                    hogatype = "지정가(IOC)";
                    break;
                case "20":
                    hogatype = "지정가(FOK)";
                    break;
                case "13":
                    hogatype = "시장가(IOC)";
                    break;
                case "23":
                    hogatype = "시장가(FOK)";
                    break;
                case "16":
                    hogatype = "최유리지정가(IOC)";
                    break;
                case "26":
                    hogatype = "최유리지정가(FOK)";
                    break;
            }

            newrow["ordgb"] = hogatype;

            newrow["qty"] = myXARealClass.GetFieldData("OutBlock", "ordqty");//주문수량
            newrow["price"] = myXARealClass.GetFieldData("OutBlock", "ordprc");//주문가격

            newrow["cheqty"] = myXARealClass.GetFieldData("OutBlock", "execqty");//체결수량
            newrow["cheprice"] = myXARealClass.GetFieldData("OutBlock", "execprc");//체결가격            
            newrow["ordrem"] = myXARealClass.GetFieldData("OutBlock", "unercqty");//미체결수량

            string trcode1 = myXARealClass.GetFieldData("OutBlock", "trcode1");//tr코드
            switch (trcode1)
            {
                case "FO01":
                    trcode1 = "접수";//정상주문
                    break;
                case "FO02":
                    trcode1 = "정정주문";
                    break;
                case "FO03":
                    trcode1 = "취소주문";
                    break;
                case "HO01":
                    trcode1 = "확인";
                    break;
                case "CH01":
                    trcode1 = "체결";
                    break;
            }
            newrow["status"] = trcode1;
            newrow["ordtime"] = myXARealClass.GetFieldData("OutBlock", "trxtime");//처리시각

            table.Rows.InsertAt(newrow, 0);

            Grid표시();
        }

        private void Real해제()
        {
            //real의 UnadviseRealData 호출은 CallBackMethod = null; 과정이후에 해주어야 함.
            myC01.CallBackMethod = null;
            myH01.CallBackMethod = null;
            myO01.CallBackMethod = null;

            myC01.UnadviseRealData();
            myH01.UnadviseRealData();
            myO01.UnadviseRealData();
        }

        private void TradeHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            Real해제();
            MainForm.LoadedForm.Remove(this);
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
    }
}
