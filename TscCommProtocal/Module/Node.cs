using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TscCommProtocal.Module
{
    public class Node
    {
        public Node(string ip, string name, string version, int iport)
        {
            _sIpAddress = ip;
            _sName = name;
            _iPort = iport;
            _sVersion = version;
        }
        private string _sName;
        private string _sIpAddress;
        private string _sVersion;
        private int _iPort;
        public string sName
        {
            get { return _sName; }
            set { _sName = value; }
        }
        public string sIpAddress
        {
            get { return _sIpAddress; }
            set { _sIpAddress = value; }

        }
        public string sVersion
        {
            get { return _sVersion; }
            set { _sVersion = value; }
        }
        public int iPort
        {
            get { return _iPort; }
            set { _iPort = value; }
        }
    }
}
