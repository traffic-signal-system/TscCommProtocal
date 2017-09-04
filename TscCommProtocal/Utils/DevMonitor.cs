using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TscCommProtocal.Utils
{
    public class DevMonitor
    {
        public ushort temperature { set; get; }
        public byte door { set; get; }
        public ushort voltage { set; get; }
        public byte powerType { set; get; }
    }
}
