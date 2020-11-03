using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using XA_DATASETLib;

namespace Sample
{
    public partial class OptionBoard : Form
    {
        public static SortedDictionary<string, List<string>> Categories;

        enum ColumnName { actprice, optcode, price, change, diff, volume, iv, mgjv, mgjvupdn, offerho1, bidho1, cvolume, delt, gama, vega, ceta, rhox, theoryprice, impv, timevl, offerrem1, bidrem1, open, high, low, value };
        public enum ColumnText { 행사가, 옵션코드, 현재가, 전일대비, 등락율, 거래량, IV, 미결제약정, 미결제약정증감, 매도호가, 매수호가, 체결량, 델타, 감마, 베가, 쎄타, 로우, 이론가, 내재가치, 시간가치, 매도잔량, 매수잔량, 시가, 고가, 저가, 거래대금 };

        DataTable CallTable;
        DataTable PutTable;

        Dictionary<string, List<string>> 월물 = new Dictionary<string, List<string>>();

        OC0 myOC0;
        OH0 myOH0;
        OMG myOMG;

        List<string> CallCodeList;
        List<string> PutCodeList;

        public OptionBoard()
        {
            InitializeComponent();

             myOC0 = new OC0();
             myOH0 = new OH0();
             myOMG = new OMG();

            foreach(KeyValuePair<string, List<string>> code in MainForm.종목마스터)
            {
                if (code.Value[0].Substring(0, 3) == "201")
                {
                    string 만기월 = code.Value[2];
                    if (월물.ContainsKey(만기월))
                    {
                        월물[만기월].Add(code.Value[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2]);
                    }
                    else
                    {
                        월물.Add(만기월, new List<string> { code.Value[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2] });
                        if (button1.Text == "")
                        {
                            button1.Text = 만기월;
                        }
                        else if (button2.Text == "")
                        {
                            button2.Text = 만기월;
                        }
                        else if (button3.Text == "")
                        {
                            button3.Text = 만기월;
                        }
                        else if (button4.Text == "")
                        {
                            button4.Text = 만기월;
                        }
                    }
                }
            }


            string[] name = Enum.GetNames(typeof(ColumnName));
            string[] headertext = Enum.GetNames(typeof(ColumnText));

            PutTable = new DataTable();
            dataGridView3.DataSource = PutTable;

            for (int i = 0; i < name.Length; i++)
            {
                PutTable.Columns.Add(name[i]);
                dataGridView3.Columns[i].HeaderText = headertext[i];
                dataGridView3.Columns[i].Visible = false;
                dataGridView3.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            
            CallTable = new DataTable();
            dataGridView1.DataSource = CallTable;

            for (int i = name.Length - 1; i >= 0; i--)
            {
                CallTable.Columns.Add(name[i]);
                dataGridView1.Columns[name.Length - 1 - i].HeaderText = headertext[i];
                dataGridView1.Columns[name.Length - 1 - i].Visible = false;
                dataGridView1.Columns[name.Length - 1 - i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                GridFormat(col, CallTable.Columns[col.Name]);
            }
            foreach (DataGridViewColumn col in dataGridView3.Columns)
            {
                GridFormat(col, PutTable.Columns[col.Name]);
            }

            dataGridView2.Columns.Add("행사가", "행사가");
            dataGridView2.Columns["행사가"].SortMode = DataGridViewColumnSortMode.NotSortable;

            Categories = new SortedDictionary<string, List<string>>();
            using (StreamReader sr = new StreamReader("OptBoardCategories.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line == "" || line.Length < 1)
                        break;

                    string CategoryName = line.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    string[] items = line.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    Categories.Add(CategoryName, items.Select(item => item).ToList());
                    comboBox1.Items.Add(CategoryName);
                    comboBox1.SelectedIndex = 0;
                }
            }

            this.Show();
            MainForm.LoadedForm.Add(this);
        }

        private void GridFormat(DataGridViewColumn grd_col, DataColumn tbl_col)
        {
            switch (grd_col.Name)
            {
                case "actprice"://행사가
                case "price"://현재가
                case "diff"://등락율
                case "offerho1"://매도호가
                case "bidho1"://매수호가
                case "open"://시가
                case "high"://고가
                case "low"://저가
                case "theoryprice"://이론가
                case "impv"://내재가치
                case "timevl"://시간가치
                case "iv"://IV
                    tbl_col.DataType = typeof(double);
                    grd_col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grd_col.DefaultCellStyle.Format = "0.00";
                    break;
                case "delt"://델타
                case "gama"://감마
                case "vega"://베가
                case "ceta"://쎄타
                case "rhox"://로우
                    tbl_col.DataType = typeof(double);
                    grd_col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grd_col.DefaultCellStyle.Format = "0.0000";
                    break;
                case "change"://전일대비
                case "optcode"://옵션코드
                    tbl_col.DataType = typeof(string);
                    grd_col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    break;
                case "volume"://거래량
                case "mgjv"://미결제약정
                case "mgjvupdn"://미결제약정증감
                case "cvolume"://체결량
                case "offerrem1"://매도잔량
                case "bidrem1"://매수잔량
                case "value"://거래대금                
                    tbl_col.DataType = typeof(int);
                    grd_col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grd_col.DefaultCellStyle.Format = "#,0";
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OptBoardSetting myOptBoardSetting;
            if (comboBox1.SelectedIndex >= 0)
            {
                myOptBoardSetting = new OptBoardSetting(comboBox1.SelectedItem.ToString());
            }
            else
            {
                myOptBoardSetting = new OptBoardSetting("");
            }

            myOptBoardSetting.ShowDialog();

            Categories = new SortedDictionary<string, List<string>>();
            using (StreamReader sr = new StreamReader("OptBoardCategories.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line == "" || line.Length < 1)
                        break;

                    string CategoryName = line.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    string[] items = line.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    Categories.Add(CategoryName, items.Select(item => item).ToList());
                    comboBox1.Items.Add(CategoryName);
                }
            }

            comboBox1_SelectedIndexChanged(null, null);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dataGridView3.Columns)
            {
                if (Categories[comboBox1.SelectedItem.ToString()].Contains(col.HeaderText))
                {
                    col.Visible = true;
                }
                else
                {
                    col.Visible = false;
                }
            }

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (Categories[comboBox1.SelectedItem.ToString()].Contains(col.HeaderText))
                {
                    col.Visible = true;
                }
                else
                {
                    col.Visible = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            ((Button)sender).Enabled = false;

            Real해제();

            CallTable.Rows.Clear();
            dataGridView2.Rows.Clear();
            PutTable.Rows.Clear();

            for (int i = 월물[((Button)sender).Text.Trim()].Count - 1; i >= 0; i--)
            {
                dataGridView2.Rows[dataGridView2.Rows.Add()].Cells[0].Value = 월물[((Button)sender).Text.Trim()][i];
                DataRow callrow = CallTable.NewRow();
                DataRow putrow = PutTable.NewRow();
                CallTable.Rows.Add(callrow);
                PutTable.Rows.Add(putrow);
            }
            
            Dictionary<string, string> InputDataTable = new Dictionary<string, string>();
            InputDataTable.Add("yyyymm", ((Button)sender).Text.Trim());
            t2301 myt2301 = new t2301();
            myt2301.CallBackMethod += ReceveData;
            myt2301.QueryExcute(InputDataTable);
        }        

        private void ReceveData(XAQueryClass myXAQueryClass)
        {
            CallCodeList = new List<string>();
            PutCodeList = new List<string>();

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                CallCodeList.Add("");
                PutCodeList.Add("");
            }


            
            int cnt_t2301OutBlock1 = myXAQueryClass.GetBlockCount("t2301OutBlock1");
            for (int i = 0; i < cnt_t2301OutBlock1; i++)
            {
                for (int j = 0; j < dataGridView2.Rows.Count; j++)
                {
                    if (dataGridView2.Rows[j].Cells[0].Value.ToString() + "0" == myXAQueryClass.GetFieldData("t2301OutBlock1", "actprice", i))//행사가
                    {
                        CallCodeList[j] = myXAQueryClass.GetFieldData("t2301OutBlock1", "optcode", i);
                        foreach (DataColumn col in CallTable.Columns)
                        {
                            CallTable.Rows[j][col] = myXAQueryClass.GetFieldData("t2301OutBlock1", col.ColumnName, i);
                        }
                        CallTable.Rows[j]["change"] = 전일대비구분포함(myXAQueryClass.GetFieldData("t2301OutBlock1", "sign", i)) + CallTable.Rows[j]["change"].ToString();
                    }
                }
            }

            int cnt_t2301OutBlock2 = myXAQueryClass.GetBlockCount("t2301OutBlock2");
            for (int i = 0; i < cnt_t2301OutBlock2; i++)
            {
                for (int j = 0; j < dataGridView2.Rows.Count; j++)
                {
                    if (dataGridView2.Rows[j].Cells[0].Value.ToString() + "0" == myXAQueryClass.GetFieldData("t2301OutBlock2", "actprice", i))//행사가
                    {
                        PutCodeList[j] = myXAQueryClass.GetFieldData("t2301OutBlock2", "optcode", i);

                        foreach (DataColumn col in PutTable.Columns)
                        {
                            PutTable.Rows[j][col] = myXAQueryClass.GetFieldData("t2301OutBlock2", col.ColumnName, i);
                        }

                        PutTable.Rows[j]["change"] = 전일대비구분포함(myXAQueryClass.GetFieldData("t2301OutBlock2", "sign", i)) + PutTable.Rows[j]["change"].ToString();
                    }
                }
            }

            //real등록
            myOC0.CallBackMethod += ReceiveRealData_OC0;
            myOH0.CallBackMethod += ReceiveRealData_OH0;
            myOMG.CallBackMethod += ReceiveRealData_OMG;

            foreach (DataRow row in CallTable.Rows)
            {
                Dictionary<string, string> InputDataTable = new Dictionary<string, string>();
                InputDataTable.Add("optcode", row["optcode"].ToString());
                myOC0.AdviseExcute(InputDataTable);
                myOH0.AdviseExcute(InputDataTable);
                myOMG.AdviseExcute(InputDataTable);
            }

            foreach (DataRow row in PutTable.Rows)
            {
                Dictionary<string, string> InputDataTable = new Dictionary<string, string>();
                InputDataTable.Add("optcode", row["optcode"].ToString());
                myOC0.AdviseExcute(InputDataTable);
                myOH0.AdviseExcute(InputDataTable);
                myOMG.AdviseExcute(InputDataTable);
            }
        }

        private string 전일대비구분포함(string 전일대비구분값)
        {
            switch (전일대비구분값)
            {
                case "2":
                    return "▲";
                case "5":
                    return "▼";
                case "3":
                    return " ";
                case "1":
                    return "↑";
                case "4":
                    return "↓";
                default:
                    return "";
            }
        }

        private void ReceiveRealData_OC0(XARealClass myXARealClass)
        {
            label1.Text = string.Format("{0:0#:##:##}", int.Parse(myXARealClass.GetFieldData("OutBlock", "chetime")));
            DataRow row;
            string code = myXARealClass.GetFieldData("OutBlock", "optcode");
            if (code.Contains("201"))
            {
                row = CallTable.Rows[CallCodeList.IndexOf(code)];

            }
            else
            {
                row = PutTable.Rows[PutCodeList.IndexOf(code)];
            }

            row["change"] = 전일대비구분포함(myXARealClass.GetFieldData("OutBlock", "sign")) + myXARealClass.GetFieldData("OutBlock", "change");//전일대비
            row["diff"] = myXARealClass.GetFieldData("OutBlock", "drate");//등락율
            row["price"] = myXARealClass.GetFieldData("OutBlock", "price");//현재가
            row["open"] = myXARealClass.GetFieldData("OutBlock", "open");//시가
            row["high"] = myXARealClass.GetFieldData("OutBlock", "high");//고가
            row["low"] = myXARealClass.GetFieldData("OutBlock", "low");//저가
            row["volume"] = myXARealClass.GetFieldData("OutBlock", "volume");//누적거래량
            row["cvolume"] = myXARealClass.GetFieldData("OutBlock", "cvolume");//체결량
            row["value"] = myXARealClass.GetFieldData("OutBlock", "value");//누적거래대금
            row["offerho1"] = myXARealClass.GetFieldData("OutBlock", "offerho1");//매도호가1
            row["bidho1"] = myXARealClass.GetFieldData("OutBlock", "bidho1");//매수호가1
            row["mgjv"] = myXARealClass.GetFieldData("OutBlock", "openyak");//미결제약정수량
            row["mgjvupdn"] = myXARealClass.GetFieldData("OutBlock", "openyakcha");//미결제약정증감
            row["theoryprice"] = myXARealClass.GetFieldData("OutBlock", "theoryprice");//이론가
            row["timevl"] = myXARealClass.GetFieldData("OutBlock", "timevalue");//시간가치
            row["impv"] = myXARealClass.GetFieldData("OutBlock", "impv");//내재변동성//??
        }

        private void ReceiveRealData_OH0(XARealClass myXARealClass)
        {
            label1.Text = string.Format("{0:0#:##:##}", int.Parse(myXARealClass.GetFieldData("OutBlock", "hotime")));
            DataRow row;
            string code = myXARealClass.GetFieldData("OutBlock", "optcode");
            if (code.Contains("201"))
            {
                row = CallTable.Rows[CallCodeList.IndexOf(code)];

            }
            else
            {
                row = PutTable.Rows[PutCodeList.IndexOf(code)];
            }

            row["offerrem1"] = myXARealClass.GetFieldData("OutBlock", "offerrem1");//매도호가수량1
            row["bidrem1"] = myXARealClass.GetFieldData("OutBlock", "bidrem1");//매수호가수량1
        }

        private void ReceiveRealData_OMG(XARealClass myXARealClass)
        {
            label1.Text = string.Format("{0:0#:##:##}", int.Parse(myXARealClass.GetFieldData("OutBlock", "chetime")));
            DataRow row;
            string code = myXARealClass.GetFieldData("OutBlock", "optcode");
            if (code.Contains("201"))
            {
                row = CallTable.Rows[CallCodeList.IndexOf(code)];

            }
            else
            {
                row = PutTable.Rows[PutCodeList.IndexOf(code)];
            }

            row["iv"] = myXARealClass.GetFieldData("OutBlock", "impv");//내재변동성
            row["delt"] = myXARealClass.GetFieldData("OutBlock", "delt");//델타(블랙숄즈)
            row["gama"] = myXARealClass.GetFieldData("OutBlock", "gama");//감마(블랙숄즈)
            row["vega"] = myXARealClass.GetFieldData("OutBlock", "vega");//베가(블랙숄즈)
            row["ceta"] = myXARealClass.GetFieldData("OutBlock", "ceta");//세타(블랙숄즈)
            row["rhox"] = myXARealClass.GetFieldData("OutBlock", "rhox");//로우(블랙숄즈)

            row["ceta"] = myXARealClass.GetFieldData("OutBlock", "ceta");//세타(블랙숄즈)
            row["theoryprice"] = myXARealClass.GetFieldData("OutBlock", "theoryprice");//이론가(블랙숄즈)
        }

        private void dataGridView2_Scroll(object sender, ScrollEventArgs e)
        {
            int indx = dataGridView2.FirstDisplayedScrollingRowIndex;
            dataGridView3.FirstDisplayedScrollingRowIndex = indx;
            dataGridView1.FirstDisplayedScrollingRowIndex = indx;
        }

        private void Real해제()
        {
            myOC0.CallBackMethod = null;
            myOH0.CallBackMethod = null;
            myOMG.CallBackMethod = null;

            myOC0.UnadviseRealData();
            myOH0.UnadviseRealData();
            myOMG.UnadviseRealData();            
        }

        private void OptionBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Real해제();
            MainForm.LoadedForm.Remove(this);
        }
    }
}
