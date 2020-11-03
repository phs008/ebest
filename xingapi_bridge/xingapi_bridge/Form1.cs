using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XA_DATASETLib;
using XA_SESSIONLib;

namespace xingapi_bridge
{
    
    public partial class Form1 : Form
    {
        protected XingSessionCtrl m_Session;
        public Form1()
        {
            InitializeComponent();
            m_Session = new XingSessionCtrl();
            UI.console_event += Update_ConsoleLog;
        }

        private void login_text_btn_Click(object sender, EventArgs e)
        {
            m_Session.m_session.ConnectServer("demo.etrade.co.kr", 12000);
            m_Session.m_session.Login("skinnine", "1a1a1a1a", "", 0, true);
        }

        private void Update_ConsoleLog(object sender, string msg)
        {
            this.console.AppendText(msg);
        }

        private void buy_btn_Click(object sender, EventArgs e)
        {

        }
    }
    public class UI
    {
        public static event EventHandler<string> console_event;
        public static void SendConsoleMsg(object sender , string msg)
        {
            if (UI.console_event != null)
            {
                UI.console_event(sender, msg);
            }
        }
    }
}
