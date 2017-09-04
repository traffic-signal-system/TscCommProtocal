using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TscCommProtocal.Module;
using TscCommProtocal.Utils;

namespace TscCommProtocal
{
    public class TSCorPSCComm
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Message ChangeTsc(Node n)
        {
            Message m = new Message();
            bool boolTsc = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_TSC);
            //string result = "Tsc模式切换：";
            if (boolTsc)
            {
                m.flag = true;
                m.obj = "TSC/PSC";
                m.msg = "切换到Tsc模式成功!";
                //result += "切换到Tsc模式成功。";
            }
            else
            {
                m.flag = true;
                m.obj = "TSC/PSC";
                m.msg = "切换到Tsc模式失败，请检查信号机IP地址及网络情况！";
                //result += "切换到Tsc模式失败，请检查信号机IP地址及网络情况！";
            }

            return m;
        }
        /// <summary>
        /// 切换到PSC模式
        /// </summary>
        /// <param name="n"></param>
        /// <param name="greentime"></param>
        /// <returns></returns>
        public static Message ChangePSCOne(Node n,int greentime)
        {
            Message m = new Message();
            bool boolPsc1 = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_PSC_1);
           // string str = dudOnePSC.Text;
            //int greentime = int.Parse(str);
            byte[] psc1greentime = Define.SET_PSC_1_GREEN_TIME;
            psc1greentime[5] = (byte)greentime;
            bool boolPsc1time = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, psc1greentime);
            if (boolPsc1time)
            {
                m.flag = true;
                m.obj = "TSC/PSC";
                m.msg = "切换到Tsc模式成功!";
                //result += "切换到Tsc模式成功。";
            }
            else
            {
                m.flag = true;
                m.obj = "TSC/PSC";
                m.msg = "切换到Tsc模式失败，请检查信号机IP地址及网络情况！";
                //result += "切换到Tsc模式失败，请检查信号机IP地址及网络情况！";
            }

            return m;
        }

        /// <summary>
        /// 切换到PSC模式 二次过街
        /// </summary>
        /// <param name="n"></param>
        /// <param name="greentime"></param>
        /// <returns></returns>
        public static Message ChangePSCOne(Node n, int greentime1, int greentime2)
        {
            Message m = new Message();
            bool boolPsc2 = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_PSC_2);
            //string str1 = dudOnePSC.Text;
            //int greentime1 = int.Parse(str1);
            byte[] psc1greentime = Define.SET_PSC_1_GREEN_TIME;
            psc1greentime[5] = (byte)greentime1;
            bool boolPsc1time = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, psc1greentime);

            //string str2 = dudTwoPSC.Text;
            //int greentime2 = int.Parse(str2);
            byte[] psc2greentime = Define.SET_PSC_2_GREEN_TIME;
            psc2greentime[5] = (byte)greentime2;
            bool boolPsc2time = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, psc2greentime);
            if (boolPsc1time)
            {
                m.flag = true;
                m.obj = "TSC/PSC";
                m.msg = "切换到Tsc模式成功!";
                //result += "切换到Tsc模式成功。";
            }
            else
            {
                m.flag = true;
                m.obj = "TSC/PSC";
                m.msg = "切换到Tsc模式失败，请检查信号机IP地址及网络情况！";
                //result += "切换到Tsc模式失败，请检查信号机IP地址及网络情况！";
            }

            return m;
        }
    }
}
