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
    public partial class PriceSelector : Form
    {
        private DataTable table;
        SortedDictionary<double, string> 항목List = new SortedDictionary<double, string>();
        public NumericUpDown num;
        public PriceSelector(string Code)
        {
            InitializeComponent();

            table = new DataTable();
            table.Columns.Add("항목");
            table.Columns.Add("호가");
            table.Columns.Add("등락율");

            dataGridView1.DataSource = table;

            t2101 myt2101 = new t2101();
            myt2101.CallBackMethod += ReceveData;
            myt2101.CallBackMsg += ReceveMsg;
            Dictionary<string, string> InputDataTable = new Dictionary<string, string>();
            InputDataTable.Add("focode", Code);
            myt2101.QueryExcute(InputDataTable);
        }

        private void ReceveData(XAQueryClass myXAQueryClass)
        {
            double jnilclose = double.Parse(myXAQueryClass.GetFieldData("t2101OutBlock", "jnilclose", 0));//전일종가
            double uplmtprice = double.Parse(myXAQueryClass.GetFieldData("t2101OutBlock", "uplmtprice", 0));//상한가
            double dnlmtprice = double.Parse(myXAQueryClass.GetFieldData("t2101OutBlock", "dnlmtprice", 0));//하한가
            double 현재가 = double.Parse(myXAQueryClass.GetFieldData("t2101OutBlock", "price", 0));//현재가

            항목List작성(double.Parse(myXAQueryClass.GetFieldData("t2101OutBlock", "jnilclose", 0)), "전일종가");
            항목List작성(double.Parse(myXAQueryClass.GetFieldData("t2101OutBlock", "price", 0)), "현재가");
            항목List작성(double.Parse(myXAQueryClass.GetFieldData("t2101OutBlock", "open", 0)), "시가");
            항목List작성(double.Parse(myXAQueryClass.GetFieldData("t2101OutBlock", "high", 0)), "고가");
            항목List작성(double.Parse(myXAQueryClass.GetFieldData("t2101OutBlock", "low", 0)), "저가");
            항목List작성(double.Parse(myXAQueryClass.GetFieldData("t2101OutBlock", "high52w", 0)), "52최고가");
            항목List작성(double.Parse(myXAQueryClass.GetFieldData("t2101OutBlock", "low52w", 0)), "52최저가");
            항목List작성(double.Parse(myXAQueryClass.GetFieldData("t2101OutBlock", "listhprice", 0)), "상장최고가");
            항목List작성(double.Parse(myXAQueryClass.GetFieldData("t2101OutBlock", "listlprice", 0)), "상장최저가");
            항목List작성(double.Parse(myXAQueryClass.GetFieldData("t2101OutBlock", "recprice", 0)), "기준가");
            항목List작성(double.Parse(myXAQueryClass.GetFieldData("t2101OutBlock", "theoryprice", 0)), "이론가");
            항목List작성(double.Parse(myXAQueryClass.GetFieldData("t2101OutBlock", "theorypriceg", 0)), "이론가");
            항목List작성(double.Parse(myXAQueryClass.GetFieldData("t2101OutBlock", "yeprice", 0)), "예상체결가");


            label1.Text = "상한(" + uplmtprice + ")";
            label2.Text = "하한(" + dnlmtprice + ")";

            table.Clear();

            double gab = 0.01d;
            if (uplmtprice >= 3.05d)
            {
                gab = 0.05d;
            }

            int indxcnt = 0;
            int 현재가indx = 0;

            for (double 호가 = uplmtprice - gab; 호가 > dnlmtprice; 호가 = 호가 - gab)
            {
                DataRow newrow = table.NewRow();
                double hoga = Math.Round(호가, 2);

                if (hoga <= dnlmtprice)
                    break;

                newrow["호가"] = string.Format("{0:0.#0}", hoga);
                if (hoga > jnilclose)
                {
                    newrow["등락율"] = "+" + Math.Round((100d * (hoga - jnilclose) / jnilclose), 2) + "%";
                }
                else
                {
                    newrow["등락율"] = Math.Round((100d * (hoga - jnilclose) / jnilclose), 2) + "%";
                }

                foreach (KeyValuePair<double, string> 항목 in 항목List)
                {
                    if (hoga == 항목.Key)
                    {
                        newrow["항목"] = 항목.Value;
                    }
                }

                table.Rows.Add(newrow);

                if (hoga <= 3.00d)
                {
                    gab = 0.01d;
                }

                indxcnt++;
                if (hoga == 현재가)
                {
                    현재가indx = indxcnt;
                }
            }

            dataGridView1.FirstDisplayedScrollingRowIndex = Math.Max(0, 현재가indx - 6);
        }

        private void 항목List작성(double key, string value)
        {
            if (항목List.ContainsKey(key))
            {
                항목List[key] = 항목List[key] + ";" + value;
            }
            else
            {
                항목List.Add(key, value);
            }
        }
        
        private void ReceveMsg(bool bIsSystemError, string Msg)
        {
            if (bIsSystemError)
            {
                System.Windows.Forms.MessageBox.Show(Msg);
            }
            else
            {
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            num.Value = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["호가"].Value.ToString());
            this.Close();
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            num.Value = decimal.Parse(((Label)sender).Text.Split(new string[] { "(", ")" }, StringSplitOptions.RemoveEmptyEntries)[1]);
            this.Close();
        }
    }
}
