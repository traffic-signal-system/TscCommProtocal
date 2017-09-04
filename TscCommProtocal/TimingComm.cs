using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TscCommProtocal.Module;
using System.IO;
using TscCommProtocal.Utils;

namespace TscCommProtocal
{
    public class TimingComm
    {
        public static Message SetTiming(DateTime dt, Node n)
        {
            Message m = new Message();
            //TscData t = Utils.Util.GetTscDataByApplicationCurrentProperties();
            double idt = Utils.Util.ConvertDateTimeInt(dt);
            DateTime dttt = Utils.Util.ConvertIntDateTime(idt);
            byte[] ba = System.BitConverter.GetBytes(idt);
            byte[] bb = ba.Reverse().ToArray<byte>();
            byte[] hex = new byte[Define.TSC_DEV_TIMING.Length + 4];
            Stream s = new MemoryStream();
            s.Write(Define.TSC_DEV_TIMING, 0, Define.TSC_DEV_TIMING.Length);
            s.Write(bb, 0, bb.Length);
            s.Position = 0;
            int count = s.Read(hex, 0, hex.Length);
            bool b = false;
            if (count > 0)
            {
                b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, hex);
            }
            if (b == true)
            {
                m.flag = true;
                m.msg = "校时成功！";
                m.obj = "Timing";
            }
            else
            {
                m.flag = true;
                m.msg = "校时失败！";
                m.obj = "Timing";
            }
            return m;
        }
    }
}
