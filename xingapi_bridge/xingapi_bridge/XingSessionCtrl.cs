using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using XA_SESSIONLib;

namespace xingapi_bridge
{
    public class XingSessionCtrl : _IXASessionEvents
    {
        public IXASession m_session;
        protected IConnectionPoint m_icp;
        protected IConnectionPointContainer m_icpc;
        protected int m_dwCookie;

        public XingSessionCtrl()
        {
            m_session = new XASession();
            m_icpc = (IConnectionPointContainer)m_session;
            Guid IID_SessionEvents = typeof(_IXASessionEvents).GUID;
            m_icpc.FindConnectionPoint(ref IID_SessionEvents, out m_icp);
            m_icp.Advise(this, out m_dwCookie);
        }
        ~XingSessionCtrl()
        {
            m_session.Logout();
            m_session.DisconnectServer();
        }
        public void Login(string szCode, string szMsg)
        {
            UI.SendConsoleMsg(this, szCode + "-" + szMsg);
            //throw new NotImplementedException();
        }

        public void Logout()
        {
            UI.SendConsoleMsg(this, "Logout");
        }

        public void Disconnect()
        {
            UI.SendConsoleMsg(this, "Disconnect");
        }
    }
}
