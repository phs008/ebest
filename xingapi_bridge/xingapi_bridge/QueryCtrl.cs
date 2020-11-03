using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XA_DATASETLib;

namespace xingapi_bridge
{
    public class QueryCtrl : _IXAQueryEvents , _IXARealEvents
    {
        public IXAReal m_real;
        public IXAQuery m_query;
        public QueryCtrl()
        {
            m_query = new XAQuery();
            m_query.ResFileName = "\\res\\t8435";
        }
        public void ReceiveData(string szTrCode)
        {
            throw new NotImplementedException();
        }

        public void ReceiveMessage(bool bIsSystemError, string nMessageCode, string szMessage)
        {
            throw new NotImplementedException();
        }

        public void ReceiveChartRealData(string szTrCode)
        {
            throw new NotImplementedException();
        }

        public void ReceiveSearchRealData(string szTrCode)
        {
            throw new NotImplementedException();
        }

        public void ReceiveRealData(string szTrCode)
        {
            throw new NotImplementedException();
        }

        public void RecieveLinkData(string szLinkName, string szData, string szFiller)
        {
            throw new NotImplementedException();
        }
    }
}
