using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TscCommProtocal.Utils;
using TscCommProtocal.Module;
using System.Net;
using System.IO;

namespace TscCommProtocal
{
    public class TscServiceComm
    {
        /// <summary>
        /// 得到当前设备的状态
        /// </summary>
        /// <returns></returns>
        public static DevMonitor GetTscMonitor(Node n)
        {
            //TscData t = Utils.Util.GetTscDataByApplicationCurrentProperties();
            DevMonitor dm = new DevMonitor();
            byte[] ba = Udp.recvUdp(n.sIpAddress, n.iPort, Define.TSC_MONITOR_STAUTS);
            byte[] temp = { ba[3], ba[4] };
            dm.temperature = System.BitConverter.ToUInt16(temp, 0);
            dm.door = ba[5];
            byte[] vo = { ba[6], ba[7] };
            dm.voltage = System.BitConverter.ToUInt16(vo, 0);
            dm.powerType = ba[8];
            return dm;
        }
        /// <summary>
        /// 得到信号机的当前状态，信号机的状态对象已经定义在数据对象中。
        /// </summary>
        /// <returns></returns>
        public static void GetReportStatus(Node n)
        {
            //TscData td = (TscData)Application.Current.Properties[Define.TSC_DATA];

            Udp.StartReceive();
            Udp.sendUdp(n.sIpAddress, n.iPort, Define.REPORT_TSC_STATUS);
        }
        /// <summary>
        /// 修改为IPv6 和TCP协议
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Message UpdateCommInterfaceIPV4TCP(Node n)
        {
            Message m = new Message();
            bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.TSC_MODIFY_COMM_TCP_IPV4);
            if (b)
            {
                m.flag = true;
                m.obj = "通信接口";
                m.msg = "修改通信接口为IPV4,TCP协议成功！";
            }
            else
            {
                m.flag = false;
                m.obj = "通信接口";
                m.msg = "修改通信接口为IPV4,TCP协议失败！";
            }
            return m;
        }
        /// <summary>
        /// 修改为IPv6 和TCP协议
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Message UpdateCommInterfaceIPV6TCP(Node n)
        {
            Message m = new Message();
            bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.TSC_MODIFY_COMM_TCP_IPV6);
            if (b)
            {
                m.flag = true;
                m.obj = "通信接口";
                m.msg = "修改通信接口为IPV6,TCP协议成功！";
            }
            else
            {
                m.flag = false;
                m.obj = "通信接口";
                m.msg = "修改通信接口为IPV6,TCP协议失败！";
            }
            return m;
        }
        /// <summary>
        /// 修改为IPv6 和UDP协议
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Message UpdateCommInterfaceIPV6UDP(Node n)
        {
            Message m = new Message();
            bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.TSC_MODIFY_COMM_UDP_IPV6);
            if (b)
            {
                m.flag = true;
                m.obj = "通信接口";
                m.msg = "修改通信接口为IPV6,UDP协议成功！";
            }
            else
            {
                m.flag = false;
                m.obj = "通信接口";
                m.msg = "修改通信接口为IPV6,UDP协议失败！";
            }
            return m;
        }
        /// <summary>
        /// 修改为IPv4 和UDP协议
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Message UpdateCommInterfaceIPV4UDP(Node n)
        {
            Message m = new Message();
            bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.TSC_MODIFY_COMM_UDP_IPV4);
            if (b)
            {
                m.flag = true;
                m.obj = "通信接口";
                m.msg = "修改通信接口为IPV4,UDP协议成功！";
            }
            else
            {
                m.flag = false;
                m.obj = "通信接口";
                m.msg = "修改通信接口为IPV4,UDP协议失败！";
            }
            return m;
        }
        /// <summary>
        /// 信号机网关修改，改IP地址之前修改些属性
        /// </summary>
        /// <param name="n"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public static Message UpdateGateway(Node n, string gateway)
        {
            Message m = new Message();
            byte[] bbs = ByteUtils.IPorMASKorGATEWAYToByteArray(gateway);
            byte[] full = new byte[bbs.Length + Define.TSC_MODIFY_GATEWAY.Length];
            Stream s = new MemoryStream();
            s.Write(Define.TSC_MODIFY_GATEWAY, 0, Define.TSC_MODIFY_GATEWAY.Length);
            s.Write(bbs, 0, bbs.Length);
            s.Position = 0;
            int r = s.Read(full, 0, full.Length);
            if (r > 0)
            {
                bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, full);
                if (b)
                {
                    m.flag = true;
                    m.obj = "信号机GATEWAY修改";
                    m.msg = "信号机GATEWAY地址修改成功，请重起信号机！";

                }
                else
                {
                    m.flag = true;
                    m.obj = "信号机GATEWAY修改";
                    m.msg = "信号机GATEWAY地址修改失败，请到现场观察原因并及时联系厂家！";

                }
            }

            return m;
        }
        /// <summary>
        /// 信号机子网掩码修改，改IP地址之前修改些属性
        /// </summary>
        /// <param name="n"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public static Message UpdateMask(Node n,string mask)
        {
            Message m = new Message();
            byte[] bbs = ByteUtils.IPorMASKorGATEWAYToByteArray(mask);
            byte[] full = new byte[bbs.Length + Define.TSC_MODIFY_MASK.Length];
            Stream s = new MemoryStream();
            s.Write(Define.TSC_MODIFY_MASK, 0, Define.TSC_MODIFY_MASK.Length);
            s.Write(bbs, 0, bbs.Length);
            s.Position = 0;
            int r = s.Read(full, 0, full.Length);
            if (r > 0)
            {
                bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, full);
                if (b)
                {
                    m.flag = true;
                    m.obj = "信号机MASK修改";
                    m.msg = "信号机MASK地址修改成功，请重起信号机！";

                }
                else
                {
                    m.flag = true;
                    m.obj = "信号机MASK修改";
                    m.msg = "信号机MASK地址修改失败，请到现场观察原因并及时联系厂家！";

                }
            }

            return m;
        }
        /// <summary>
        /// 修改IP地址
        /// </summary>
        /// <param name="n"></param>
        /// <param name="ipa"></param>
        /// <returns></returns>
        public static Message UpdateIPAddress(Node n, IPAddress ipa)
        {
           // ipa.AddressFamily.
            Message m = new Message();
            byte[] newIPs = ipa.GetAddressBytes();
            byte[] full = new byte[newIPs.Length + Define.TSC_MODIFY_IP.Length];
            Stream s = new MemoryStream();
            s.Write(Define.TSC_MODIFY_IP, 0, Define.TSC_MODIFY_IP.Length);
            s.Write(newIPs, 0, newIPs.Length);
            s.Position = 0;
            int r = s.Read(full, 0, full.Length);
            if (r > 0)
            {
                bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, full);
                if (b)
                {
                    m.flag = true;
                    m.obj = "信号机IP修改";
                    m.msg = "信号机IP地址修改成功，请重起信号机！";
                 
                }
                else
                {
                    m.flag = true;
                    m.obj = "信号机IP修改";
                    m.msg = "信号机IP地址修改失败，请到现场观察原因并及时联系厂家！";
                    
                }
            }
            return m;
        }
        public static Message UpdatePort(Node n,ushort port)
        {
            Message m = new Message();
            byte[] full = new byte[Define.TSC_MODIFY_PORT.Length + 2];
            byte[] bs = BitConverter.GetBytes(port);
            Stream s = new MemoryStream();
            s.Write(Define.TSC_MODIFY_PORT, 0, Define.TSC_MODIFY_PORT.Length);
            s.Write(bs, 0, bs.Length);
            s.Position = 0;
            int count = s.Read(full, 0, full.Length);
            if (count > 0)
            {
                bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, full);
                if (b)
                {
                    m.flag = true;
                    m.obj = "信号机端口";
                    m.msg = "信号机端口修改" + port + "成功!";
                }
                else
                {
                    m.flag = false;
                    m.obj = "信号机端口";
                    m.msg = "信号机端口修改" + port + "失败!";
                }
            }
            
            return m;
        }
        /// <summary>
        /// 重起信号机
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Message RebootTsc(Node n)
        {
            Message m = new Message();
            bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.TSC_CONTROL_REBOOT);
            if (b)
            {
                m.flag = true;
                m.obj = "REBOOT";
                m.msg = "信号机重起成功！";
            }
            else
            {
                m.flag = false;
                m.obj = "REBOOT";
                m.msg = "信号机重起失败！";
            }
            return m;  
        }
    }
}
