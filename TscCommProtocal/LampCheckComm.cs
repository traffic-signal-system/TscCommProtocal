using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TscCommProtocal.Module;
using TscCommProtocal.Utils;

namespace TscCommProtocal
{
    public class LampCheckComm
    {
        /// <summary>
        /// 对指定IP地址进行灯泡不检测设置,不是本公司的产品,请指定IP地址
        /// 如果IP地址没有指定,会读取WPF中的信号机IP
        ///地址
        /// </summary>
        /// <param name="ip">信号机的IP地址</param>
        /// <returns></returns>
        public static bool SetLampCheckCloseOne(Node n)
        {
            bool b1 = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_LAMP_BLOCK_CHECK_COLLISION_ONE_NO_CHECK);
            if (b1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 对指定IP地址进行灯泡不检测设置,不是本公司的产品,请指定IP地址
        /// 如果IP地址没有指定,会读取WPF中的信号机IP
        ///地址
        /// </summary>
        /// <param name="ip">信号机的IP地址</param>
        /// <returns></returns>
        public static bool SetLampCheckCloseTwo(Node n)
        {

            bool b1 = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_LAMP_BLOCK_CHECK_COLLISION_TWO_NO_CHECK);
            if (b1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 对指定IP地址进行灯泡不检测设置,不是本公司的产品,请指定IP地址
        /// 如果IP地址没有指定,会读取WPF中的信号机IP
        ///地址
        /// </summary>
        /// <param name="ip">信号机的IP地址</param>
        /// <returns></returns>
        public static bool SetLampCheckCloseThree(Node n)
        {

            bool b1 = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_LAMP_BLOCK_CHECK_COLLISION_THREE_NO_CHECK);
            if (b1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 对指定IP地址进行灯泡不检测设置,不是本公司的产品,请指定IP地址
        /// 如果IP地址没有指定,会读取WPF中的信号机IP
        ///地址
        /// </summary>
        /// <param name="ip">信号机的IP地址</param>
        /// <returns></returns>
        public static bool SetLampCheckCloseFour(Node n)
        {
            bool b1 = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_LAMP_BLOCK_CHECK_COLLISION_FOUR_NO_CHECK);
            if (b1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 对指定IP地址进行灯泡不检测设置,不是本公司的产品,请指定IP地址
        /// 如果IP地址没有指定,会读取WPF中的信号机IP
        ///地址
        /// </summary>
        /// <param name="ip">信号机的IP地址</param>
        /// <returns></returns>
        public static bool SetLampCheckCloseALL(Node n)
        {

            bool b2 = false;
            bool b3 = false;
            bool b4 = false;
            bool b1 = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_LAMP_BLOCK_CHECK_COLLISION_ONE_NO_CHECK);
            if (b1)
                b2 = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_LAMP_BLOCK_CHECK_COLLISION_TWO_NO_CHECK);
            if (b2)
                b3 = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_LAMP_BLOCK_CHECK_COLLISION_THREE_NO_CHECK);
            if (b3)
                b4 = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_LAMP_BLOCK_CHECK_COLLISION_FOUR_NO_CHECK);
            if (b4)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 对指定IP地址进行灯泡检测设置,不是本公司的产品,请指定IP地址
        /// 如果IP地址没有指定,会读取WPF中的信号机IP
        ///地址
        /// </summary>
        /// <param name="ip">信号机的IP地址</param>
        /// <returns></returns>
        public static bool SetLampCheckOpenOne(Node n)
        {

            bool b1 = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_LAMP_BLOCK_CHECK_COLLISION_ONE_CHECK);
            if (b1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 对指定IP地址进行灯泡检测设置,不是本公司的产品,请指定IP地址
        /// 如果IP地址没有指定,会读取WPF中的信号机IP
        ///地址
        /// </summary>
        /// <param name="ip">信号机的IP地址</param>
        /// <returns></returns>
        public static bool SetLampCheckOpenTwo(Node n)
        {

            bool b1 = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_LAMP_BLOCK_CHECK_COLLISION_TWO_CHECK);
            if (b1)

                return true;
            else
                return false;
        }
        /// <summary>
        /// 对指定IP地址进行灯泡检测设置,不是本公司的产品,请指定IP地址
        /// 如果IP地址没有指定,会读取WPF中的信号机IP
        ///地址
        /// </summary>
        /// <param name="ip">信号机的IP地址</param>
        /// <returns></returns>
        public static bool SetLampCheckOpenThree(Node n)
        {

            bool b1 = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_LAMP_BLOCK_CHECK_COLLISION_THREE_CHECK);
            if (b1)

                return true;
            else
                return false;
        }
        /// <summary>
        /// 对指定IP地址进行灯泡检测设置,不是本公司的产品,请指定IP地址
        /// 如果IP地址没有指定,会读取WPF中的信号机IP
        ///地址
        /// </summary>
        /// <param name="ip">信号机的IP地址</param>
        /// <returns></returns>
        public static bool SetLampCheckOpenFour(Node n)
        {

            bool b1 = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_LAMP_BLOCK_CHECK_COLLISION_FOUR_CHECK);
            if (b1)

                return true;
            else
                return false;
        }
        /// <summary>
        /// 对指定IP地址进行灯泡检测设置,不是本公司的产品,请指定IP地址
        /// 如果IP地址没有指定,会读取WPF中的信号机IP
        ///地址
        /// </summary>
        /// <param name="ip">信号机的IP地址</param>
        /// <returns></returns>
        public static bool SetLampCheckOpenALL(Node n)
        {

            bool b2 = false;
            bool b3 = false;
            bool b4 = false;
            bool b1 = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_LAMP_BLOCK_CHECK_COLLISION_ONE_CHECK);
            if (b1)
                b2 = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_LAMP_BLOCK_CHECK_COLLISION_TWO_CHECK);
            if (b2)
                b3 = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_LAMP_BLOCK_CHECK_COLLISION_THREE_CHECK);
            if (b3)
                b4 = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_LAMP_BLOCK_CHECK_COLLISION_FOUR_CHECK);
            if (b4)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 取得所有的灯泡检测数据
        /// </summary>
        /// <returns></returns>
        public static List<LampCheck> GetLampCheck(Node n)
        {
            //TscData t = Utils.Util.GetTscDataByApplicationCurrentProperties();

            byte[] byt = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_LAMP_CHECK);
            if (!CheckGBTUtil.CheckGBTProtocal(byt, "主动上报").flag)
            {
                return null;
            }
            List<LampCheck> llc = new List<LampCheck>();
            byte[] lampCheckArray = new byte[Convert.ToInt32(byt[3]) * Define.LAMP_CHECK_BYTE_SIZE];
            Array.Copy(byt, 4, lampCheckArray, 0, Convert.ToInt32(byt[3]) * Define.LAMP_CHECK_BYTE_SIZE);
            byte[,] twoArray = ByteUtils.oneArray2TwoArray(lampCheckArray, Convert.ToInt32(byt[3]), Define.LAMP_CHECK_BYTE_SIZE);
            LampCheck lc;
            for (int i = 0; i < Convert.ToInt32(byt[3]); i++)
            {
                lc = new LampCheck();
                lc.ucId = twoArray[i, 0];
                lc.ucFlag = twoArray[i, 1];

                llc.Add(lc);
            }
            return llc;
        }
    }
}
