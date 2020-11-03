using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sample
{
    /// <summary>
    /// CodeSelector : Singleton Instance
    /// </summary>
    public partial class CodeSelector : Form
    {
        private Label selectedLabel;

        public static TextBox textbox;
        static object lockInstance = new object();
        static CodeSelector _instance;
        /// <summary>
        /// Singleton Instance
        /// </summary>
        public static CodeSelector Instance
        {
            get 
            {
                if (CodeSelector._instance == null)
                {
                    lock (lockInstance)
                    {
                        if (CodeSelector._instance == null)
                        {
                            CodeSelector._instance = new CodeSelector();
                        }
                    }
                }
                return CodeSelector._instance; 
            }
        }

        private CodeSelector()//Singleton Instance
        {
            InitializeComponent();

            SortedDictionary<string, string> 옵션월물 = new SortedDictionary<string, string>();

            int 선물Cnt = 1;
            int 옵션Cnt = 1;

            double Max_행사가 = -999d;
            double Min_행사가 = 999d;            

            foreach (KeyValuePair<string, List<string>> Code in MainForm.종목마스터)
            {
                if (Code.Key.Substring(3, 3) == "101")
                {
                    foreach (Control ctrl in tableLayoutPanel1.Controls)
                    {
                        if (ctrl is Button && ((Button)ctrl).Name == "button" + 선물Cnt)
                        {
                            ((Button)ctrl).Text = Code.Value[1];
                            선물Cnt++;
                        }
                    }
                }
                else if (Code.Key.Substring(3, 3) == "201")
                {
                    if (!옵션월물.ContainsKey(Code.Key.Substring(6, 2)))
                    {
                        옵션월물.Add(Code.Key.Substring(6, 2), Code.Value[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1]);
                    }                    

                    Max_행사가 = Math.Max(Max_행사가, double.Parse(Code.Value[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2]));
                    Min_행사가 = Math.Min(Min_행사가, double.Parse(Code.Value[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2]));
                }
            }

            옵션Cnt = 1;
            foreach (string str in 옵션월물.Values)
            {
                foreach (Control ctrl in tableLayoutPanel3.Controls)
                {
                    if (ctrl is Label && ((Label)ctrl).Name == "lbl_C_" + 옵션Cnt)
                    {
                        ((Label)ctrl).Text = str;
                    }
                    else if (ctrl is Label && ((Label)ctrl).Name == "lbl_P_" + 옵션Cnt)
                    {
                        ((Label)ctrl).Text = str;                       
                    }
                }
                옵션Cnt++;
            }


            tableLayoutPanel2.RowCount = (int)Math.Round((Max_행사가 - Min_행사가) / 2.5d, 0) + 2;
            
            tableLayoutPanel2.AutoScroll = true;
            tableLayoutPanel2.RowStyles.Clear();
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            for (int i = 0; i < tableLayoutPanel2.RowCount-1; i++)
            {
                for (int j = 0; j < tableLayoutPanel2.ColumnCount; j++)
                {
                    //Adding a lable control                               
                    Label objlabel = new Label();
                    objlabel.Click += new EventHandler(objlabel_Click);
                    objlabel.TextAlign = ContentAlignment.MiddleCenter;
                    objlabel.BorderStyle = BorderStyle.Fixed3D;
                    objlabel.Text = "";    //◎○
                    if (j == 4)
                    {
                        objlabel.Text =String.Format("{0:0.0}", Max_행사가 - i * 2.5);
                    }
                    //Add the table cell and label control    
                    tableLayoutPanel2.Controls.Add(objlabel, j, i);
                }
            }

            foreach (KeyValuePair<string, List<string>> Code in MainForm.종목마스터)
            {
                string[] str = Code.Value[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (str[0] == "콜")
                {
                    int col_indx = 0;
                    int row_indx = 0;
                    foreach(Control ctrl in tableLayoutPanel3.Controls)
                    {
                        if(ctrl is Label && ((Label)ctrl).Text==str[1] && tableLayoutPanel3.GetColumn(ctrl)<4)
                        {
                            col_indx=tableLayoutPanel3.GetColumn(ctrl);
                        }
                    }

                    double db;

                    foreach (Control ctrl in tableLayoutPanel2.Controls)
                    {
                        if (ctrl is Label && double.TryParse( ((Label)ctrl).Text,out db) && db == double.Parse( str[2]))
                        {
                            row_indx = tableLayoutPanel2.GetRow(ctrl);
                        }
                    }

                    ((Label)tableLayoutPanel2.GetControlFromPosition(col_indx, row_indx)).Text = "○";
                    ((Label)tableLayoutPanel2.GetControlFromPosition(8 - col_indx, row_indx)).Text = "○";
                }
            }
        }

        void objlabel_Click(object sender, EventArgs e)
        {
            if (((Label)sender).Text == "○" || ((Label)sender).Text == "◎")
            {
                if (selectedLabel != null)
                {
                    selectedLabel.Text = "○";
                    selectedLabel.ForeColor = Color.Black;
                }
                
                int col_indx = tableLayoutPanel2.GetColumn((Label)sender);
                int row_indx = tableLayoutPanel2.GetRow((Label)sender);
                double 행사가 = double.Parse(((Label)tableLayoutPanel2.GetControlFromPosition(4, row_indx)).Text);
                string 콜풋="풋";
                if(col_indx<4)
                    콜풋="콜";
                string 월물=((Label)tableLayoutPanel3.GetControlFromPosition(col_indx, 1)).Text;

                selectedLabel = ((Label)sender);

                ((Label)sender).Text = "◎";
                if (col_indx < 4)
                    selectedLabel.ForeColor = Color.Red;
                else
                    selectedLabel.ForeColor = Color.Blue;

                foreach (KeyValuePair<string, List<string>> Code in MainForm.종목마스터)
                {
                    if (Code.Key.Substring(3, 3) == "201" || Code.Key.Substring(3, 3) == "301")
                    {
                        if (Math.Round(double.Parse(Code.Value[1].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2]) - 행사가, 2) == 0d && Code.Value[1].Contains(콜풋) && Code.Value[1].Contains(월물))
                        {
                            textbox.Text = Code.Value[0];
                            this.Close();
                            break;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, List<string>> Code in MainForm.종목마스터)
            {
                if (Code.Key.Substring(3, 3) == "101")
                {
                    if (((Button)sender).Text == Code.Value[1])
                    {
                        textbox.Text = Code.Value[0];
                        this.Close();
                        break;
                    }
                }
            }
        }

        private void CodeSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
