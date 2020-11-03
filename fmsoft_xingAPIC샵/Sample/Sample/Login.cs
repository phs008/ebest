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
    public partial class Login : Form
    {
        public Login(bool 실계좌여부)
        {
            InitializeComponent();
            txt_공인인증.UseSystemPasswordChar = true;
            txt_비밀번호.UseSystemPasswordChar = true;
            if (실계좌여부)
            {
                txt_공인인증.Enabled = true;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }       
    }
}
