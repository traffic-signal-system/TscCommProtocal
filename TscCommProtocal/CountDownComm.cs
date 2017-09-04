using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TscCommProtocal.Module;
using TscCommProtocal.Utils;

namespace TscCommProtocal
{
    public class CountDownComm
    {
        /// <summary>
        /// 从信号机中取得倒计时的配置数据
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<CntDownDev> GetCntDownDev(Node n)
        {
            //TscData td = (TscData)Application.Current.Properties[Define.TSC_DATA];
            byte[] byt = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_CNTDOWNDEV);
            if (!CheckGBTUtil.CheckGBTProtocal(byt, "倒计时").flag)
            {
                return null;
            }
            List<CntDownDev> lcdd = new List<CntDownDev>();

            return lcdd;
        }
        /// <summary>
        /// 信号机倒计时输出到WPF界面功能打开 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Message SetCountDownToWPFDisplay(Node n)
        {
            Message m = new Message();
            m.obj = "CountDownComm";
            bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.TSC_COUNTDOWN_ENABLE);
            if(b)
            {
                m.flag = true;
                m.msg = "开启倒计时在界面上输出功能！";
            }
            else
            {
                m.flag = false;
                m.msg = "开户倒计时在界面上输出失败！";
            }
            return m;
        }
        /// <summary>
        /// 信号机倒计时输出到WPF界面上功能关闭
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Message SetCountDownToWPFNoDisplay(Node n)
        {
            Message m = new Message();
            m.obj = "CountDownComm";
            bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.TSC_COUNTDOWN_DISABLE);
            if (b)
            {
                m.flag = true;
                m.msg = "关闭倒计时在界面上输出功能！";
            }
            else
            {
                m.flag = false;
                m.msg = "关闭倒计时在界面上输出失败！";
            }
            return m;
        }
        
        public static Message SetCountDownTypeOff(Node n)
        {
            Message m = new Message();
            m.obj = "CountDownComm";
            bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_COUNTDOWN_485_NOOUT);
            if (b)
            {
                m.flag = true;
                m.msg = "关闭倒计时黑屏输出功能！";
            }
            else
            {
                m.flag = false;
                m.msg = "关闭倒计时黑屏输出失败！";
            }

            return m;
        }
        public static Message SetCountDownTypeKeep8(Node n)
        {
            Message m = new Message();
            m.obj = "CountDownComm";
            bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_COUNTDOWN_485_KEEP8);
            if (b)
            {
                m.flag = true;
                m.msg = "打开8秒倒计时黑屏输出功能！";
            }
            else
            {
                m.flag = false;
                m.msg = "打开8秒倒计时黑屏输出失败！";
            }

            return m;
        }
        public static Message SetCountDownType15Down(Node n)
        {
            Message m = new Message();
            m.obj = "CountDownComm";
            bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_COUNTDOWN_485_15DOWN);
            if (b)
            {
                m.flag = true;
                m.msg = "打开倒计时15秒开始倒输出功能！";
            }
            else
            {
                m.flag = false;
                m.msg = "打开倒计时15秒开始倒输出失败！";
            }

            return m;
        }
        public static Message SetCountDownTypeNormal(Node n)
        {
            Message m = new Message();
            m.obj = "CountDownComm";
            bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.SET_COUNTDOWN_485_NORMAL);
            if (b)
            {
                m.flag = true;
                m.msg = "打开正常倒计时1开始倒输出功能！";
            }
            else
            {
                m.flag = false;
                m.msg = "打开正常倒计时开始倒输出失败！";
            }

            return m;
        }
    }
}
