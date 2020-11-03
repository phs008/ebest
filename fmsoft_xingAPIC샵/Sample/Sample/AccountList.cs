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
    public partial class AccountList : Form
    {
        bool 실계좌여부;
        public AccountList(bool 실계좌여부)
        {
            InitializeComponent();
            this.실계좌여부 = 실계좌여부;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.ReadOnly = true;
            }
            dataGridView1.Columns[1].ReadOnly = false;//비밀번호 입력란
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!실계좌여부)//모의투자는 CACBQ21900를 지원안함.
            {
            }
            else if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "확인")//확인버튼 클릭 확인하여 해당 행의 계좌정보 요청
            {
                CACBQ21900 myCACBQ21900 = new CACBQ21900();
                myCACBQ21900.CallBackMethod += ReceveData;
                myCACBQ21900.CallBackMsg += ReceveMsg;
                Dictionary<string, string> InputDataTable = new Dictionary<string, string>();
                InputDataTable.Add("RecCnt", "1");
                InputDataTable.Add("AcntNo", dataGridView1.Rows[e.RowIndex].Cells["AccNUm"].Value.ToString());
                InputDataTable.Add("InptPwd", dataGridView1.Rows[e.RowIndex].Cells["Pass"].Value.ToString());
                myCACBQ21900.QueryExcute(InputDataTable);
            }
        }


        private void ReceveData(XAQueryClass myXAQueryClass)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["AccNUm"].Value.ToString() == myXAQueryClass.GetFieldData("CACBQ21900OutBlock1","AcntNo",0).Trim())
                {
                    row.Cells["AccName"].Value = myXAQueryClass.GetFieldData("CACBQ21900OutBlock2", "AcntNm", 0).Trim();//계좌명
                    row.Cells["Item"].Value = myXAQueryClass.GetFieldData("CACBQ21900OutBlock2", "PrdtDtlNm", 0).Trim();//상품상세명
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//일괄 비밀번호 등록 및 저장
        {
            string pass = textBox1.Text.Trim();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["Pass"].Value = pass;//비밀번호 입력
                DataGridViewCellEventArgs args =new DataGridViewCellEventArgs(dataGridView1.Columns["Submit"].Index,row.Index);//해당 행의 확인 버튼 클릭
                dataGridView1_CellContentClick(null, args);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
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
