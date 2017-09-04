using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TscCommProtocal.Module
{
    public class Message
    {
        private bool _flag;
        private string _msg;
        private string _obj;
        public Message()
        {
            _flag = true;
            _msg = "未定义消息！";
            _obj = "未定义对象！";
        }
        public Message(bool f, string m, string o)
        {
            _flag = f;
            _msg = m;
            _obj = o;
        }
        public bool flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
        public string msg
        {
            get { return _msg; }
            set { _msg = value; }
        }
        public string obj
        {
            get { return _obj; }
            set { _obj = value; }
        }
    }
}
