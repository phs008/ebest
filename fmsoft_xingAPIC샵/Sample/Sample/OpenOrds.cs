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
    public partial class OpenOrds : Form
    {
        public TextBox textbox;
        public Label label;
        enum ColumnName { ordno, orgordno, expcode, medosu, ordgb, qty, price, cheqty, cheprice, ordrem, status, ordtime };
        enum ColumnText { 주문NO, 원주문, 종목명, 매매구분, 유형, 주문량, 주문가, 체결량, 체결가, 미체결량, 상태, 주문시간 };
        DataTable table;

        public OpenOrds(string accno, string passwd)
        {
            InitializeComponent();

            table = new DataTable();
            dataGridView1.DataSource = table;

            string[] name = Enum.GetNames(typeof(ColumnName));
            string[] headertext = Enum.GetNames(typeof(ColumnText));

            for (int i = 0; i < name.Length; i++)
            {
                table.Columns.Add(name[i]);
                dataGridView1.Columns[i].HeaderText = headertext[i];
            }

            Dictionary<string, string> InputDataTable = new Dictionary<string, string>();
            InputDataTable.Add("accno", accno);
            InputDataTable.Add("passwd", passwd);
            InputDataTable.Add("chegb", "2");
            InputDataTable.Add("sortgb", "1");
            t0434 myt0434 = new t0434(InputDataTable);
            myt0434.CallBackMethod += ReceveData;
            myt0434.CallBackMsg += ReceveMsg;
            myt0434.QueryExcute();
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

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textbox.Text = dataGridView1.Rows[e.RowIndex].Cells["ordno"].Value.ToString();
            label.Text = dataGridView1.Rows[e.RowIndex].Cells["expcode"].Value.ToString() + ",  " + dataGridView1.Rows[e.RowIndex].Cells["medosu"].Value.ToString() + ",  " + dataGridView1.Rows[e.RowIndex].Cells["ordrem"].Value.ToString();

            this.Close();
        }
    }
}
