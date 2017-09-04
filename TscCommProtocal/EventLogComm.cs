using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TscCommProtocal.Module;
using TscCommProtocal.Utils;

namespace TscCommProtocal
{
    public class EventLogComm
    {
        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Message ClearEvent(Node n)
        {
            Message m = new Message();
             bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.TSC_CONTROL_CLEAR_EVENT);
             if (b)
             {
                 m.flag = true;
                 m.obj = "删除日志";
                 m.msg = "删除日志成功！";
             }

             else
             {
                 m.flag = false;
                 m.obj = "删除日志";
                 m.msg = "删除日志失败！";
             }
            return m;
        }
        /// <summary>
        /// 删除严重日志
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Message ClearSERIOUSNESSEvent(Node n)
        {
            Message m = new Message();
            bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, Define.TSC_CONTROL_CLEAR_SERIOUSNESS_EVENT);
            if (b)
            {
                m.flag = true;
                m.obj = "删除日志";
                m.msg = "删除日志成功！";
            }

            else
            {
                m.flag = false;
                m.obj = "删除日志";
                m.msg = "删除日志失败！";
            }
            return m;
        }
        /// <summary>
        /// 取得所有日志信息
        /// </summary>
        /// <returns></returns>
        public static List<EventLog> GetEventLog(Node n)
        {
            //TscData td = (TscData)Application.Current.Properties[Define.TSC_DATA];
            byte[] byt = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_EVENT_LOG);
            if (!CheckGBTUtil.CheckGBTProtocal(byt, "事件日志").flag)
            {
                return null;
            }
            List<EventLog> listPhase = new List<EventLog>();
            //取得)
            byte[] eventLogArray = new byte[Convert.ToInt32(byt[6]) * Define.EVENT_LOG_BYTE_SIZE];
            Array.Copy(byt, 7, eventLogArray, 0, Convert.ToInt32(byt[6]) * Define.EVENT_LOG_BYTE_SIZE);
            byte[,] twoArray = ByteUtils.oneArray2TwoArray(eventLogArray, Convert.ToInt32(byt[6]), Define.EVENT_LOG_BYTE_SIZE);
            EventLog obj;
            for (int i = 0; i < Convert.ToInt32(byt[6]); i++)
            {
                obj = new EventLog();
                obj.ucEvtType = twoArray[i, 1];
                obj.ucEventId = twoArray[i, 0];
                obj.ulHappenTime = (uint)((twoArray[i, 2] << 24) + (twoArray[i, 3] << 16) + (twoArray[i, 4] << 8) + twoArray[i, 5]);
                obj.ulEvtValue = (uint)((twoArray[i, 6] << 24) + (twoArray[i, 7] << 16) + (twoArray[i, 8] << 8) + twoArray[i, 9]);
                obj.ulEventTime = Utils.Util.ConvertIntDateTime(obj.ulHappenTime).ToString();
                obj.sEventType = Utils.Util.EventType2String(obj.ucEvtType);
                obj.sEventDesc = Utils.Util.EventDesc2String(obj.ulEvtValue, obj.ucEvtType);
                listPhase.Add(obj);
            }

            return listPhase;
        }
    }
}
