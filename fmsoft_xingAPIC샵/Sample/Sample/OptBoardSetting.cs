using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Sample
{
    public partial class OptBoardSetting : Form
    {       
        public OptBoardSetting(string SelectedCategory)
        {
            InitializeComponent();

            string[] listitems = Enum.GetNames(typeof(OptionBoard.ColumnText));
            foreach (string item in listitems)
            {
                listBox1.Items.Add(item);
            }

            foreach (string key in OptionBoard.Categories.Keys)
            {
                comboBox1.Items.Add(key);
            }

            if (SelectedCategory == "")
            {
                button8_Click(null, null);
            }
            else
            {
                comboBox1.SelectedItem = SelectedCategory;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] listitems = Enum.GetNames(typeof(OptionBoard.ColumnText));
            foreach (string item in listitems)
            {
                listBox1.Items.Add(item);
            }

            listBox2.Items.Clear();
            foreach (string item in OptionBoard.Categories[comboBox1.SelectedItem.ToString()])
            {
                listBox2.Items.Add(item);
                listBox1.Items.Remove(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                OptionBoard.Categories[comboBox1.SelectedItem.ToString()].Add(listBox1.SelectedItems[i].ToString());
            }
            comboBox1_SelectedIndexChanged(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox2.SelectedItems.Count; i++)
            {
                if (listBox2.SelectedItems[i].ToString() != "현재가")
                {
                    OptionBoard.Categories[comboBox1.SelectedItem.ToString()].Remove(listBox2.SelectedItems[i].ToString());
                }
            }
            comboBox1_SelectedIndexChanged(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                listBox1.SelectedIndices.Add(i);
            }

            button1_Click(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            while (listBox2.Items.Count > 1)
            {
                if (listBox2.Items[0].ToString() == "현재가")
                    listBox2.SelectedIndex = 1;
                else
                    listBox2.SelectedIndex = 0;
                button2_Click(null, null);
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("OptBoardCategories.txt", false))
            {
                foreach (KeyValuePair<string, List<string>> category in OptionBoard.Categories)
                {
                    sw.Write(category.Key + ":");
                    foreach (string item in category.Value)
                    {
                        sw.Write(item + ",");
                    }
                    sw.WriteLine();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddCategory myAddCategory = new AddCategory();
            DialogResult result = myAddCategory.ShowDialog();

            if (result == DialogResult.OK)
            {
                string CategorName = myAddCategory.textBox1.Text.Trim();
                if (OptionBoard.Categories.ContainsKey(CategorName))
                {
                    MessageBox.Show("중복된 이름 입니다.");
                    return;
                }
                OptionBoard.Categories.Add(CategorName, new List<string> { "현재가" });
                comboBox1.Items.Add(CategorName);
                comboBox1.SelectedItem = CategorName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OptionBoard.Categories.Remove(comboBox1.SelectedItem.ToString());
            comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int indx = listBox2.SelectedIndex;

            if (indx == 0)
                return;
            List<string> imsi = new List<string>();
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                if (i == indx - 1)
                {
                    imsi.Add(listBox2.Items[indx].ToString());
                }
                else if (i == indx)
                {
                    imsi.Add(listBox2.Items[indx - 1].ToString());
                }
                else
                {
                    imsi.Add(listBox2.Items[i].ToString());
                }
            }
            listBox2.SelectedIndex = indx - 1;

            OptionBoard.Categories[comboBox1.SelectedItem.ToString()] = imsi;
            comboBox1_SelectedIndexChanged(null, null);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int indx = listBox2.SelectedIndex;

            if (indx == listBox2.Items.Count - 1)
                return;
            List<string> imsi = new List<string>();
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                if (i == indx)
                {
                    imsi.Add(listBox2.Items[indx + 1].ToString());
                }
                else if (i == indx + 1)
                {
                    imsi.Add(listBox2.Items[indx].ToString());
                }
                else
                {
                    imsi.Add(listBox2.Items[i].ToString());
                }
            }
            listBox2.SelectedIndex = indx + 1;

            OptionBoard.Categories[comboBox1.SelectedItem.ToString()] = imsi;
            comboBox1_SelectedIndexChanged(null, null);
        }
    }
}
