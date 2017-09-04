using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TscCommProtocal.Utils;
using System.IO;
using TscCommProtocal.Module;

namespace TscCommProtocal
{
    public class ScheduleComm
    {
        /// <summary>
        /// 返回所有时段表数据
        /// </summary>
        /// <returns></returns>
        public static List<Schedule> GetSchedule(Node n)
        {
            // TscData td = (TscData)Application.Current.Properties[Define.TSC_DATA];
            byte[] byt = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_SCHEDULE);
            if (!CheckGBTUtil.CheckGBTProtocal(byt, "时段").flag)
            {
                return null;
            }
            List<Schedule> listSchedule = new List<Schedule>();
            byte[] scheduleArray = new byte[6144];
            Array.Copy(byt, 5, scheduleArray, 0, 6144);
            byte[,] twoArray = ByteUtils.oneArray2TwoArray(scheduleArray, 768, Define.SCHEDULE_BYTE_SIZE);
            Schedule schedule;
            for (int i = 0; i < 768; i++)
            {
                schedule = new Schedule();
                schedule.ucId = twoArray[i, 0];
                schedule.ucEventId = twoArray[i, 1];
                schedule.ucHour = twoArray[i, 2];
                schedule.ucMin = twoArray[i, 3];
                schedule.ucCtrl = twoArray[i, 4];
                schedule.ucTimePatternId = twoArray[i, 5];
                schedule.ucAuxOut = twoArray[i, 6];
                schedule.ucSpecialOut = twoArray[i, 7];
                listSchedule.Add(schedule);
            }
            return listSchedule;
        }
        public static Message SetSchedule(List<Schedule> ls, Node n)
        {
            //TscData t = Utils.Util.GetTscDataByApplicationCurrentProperties();
            Message m = new Message();
            //字节 长度，需要加2 ，因为。数据长度需要2个字段表示。
            byte[] hex = new byte[Define.SCHEDULE_BYTE_SIZE * (Define.SCHEDULE_RESULT_LEN * Define.SCHEDULE_EVENT_RESULT_LEN) + Define.SET_SCHEDULE_RESPONSE.Length + 2];
            Stream s = new MemoryStream();
            s.Write(Define.SET_SCHEDULE_RESPONSE, 0, Define.SET_SCHEDULE_RESPONSE.Length);
            s.WriteByte(Convert.ToByte(Define.SCHEDULE_RESULT_LEN));
            s.WriteByte(Convert.ToByte(Define.SCHEDULE_EVENT_RESULT_LEN));
            foreach (Schedule sc in ls)
            {
                byte id = sc.ucId;
                s.WriteByte(id);
                byte eventid = sc.ucEventId;
                s.WriteByte(eventid);
                byte hour = sc.ucHour;
                s.WriteByte(hour);
                byte min = sc.ucMin;
                s.WriteByte(min);
                byte ctrl = sc.ucCtrl;
                s.WriteByte(ctrl);
                byte patterntime = sc.ucTimePatternId;
                s.WriteByte(patterntime);
                byte opt = sc.ucAuxOut;
                s.WriteByte(opt);
                byte sp = sc.ucSpecialOut;
                s.WriteByte(sp);
            }
            s.Position = 0;
            int count = s.Read(hex, 0, hex.Length);

            if (count > 0)
            {
                bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, hex);
                if (b)
                {
                    m.flag = true;
                    m.msg = "保存时段数据成功！";
                    m.obj = "Schedule";
                }
                else
                {
                    m.flag = false;
                    m.msg = "保存时段数据失败！";
                    m.obj = "Schedule";
                }
            }

            return m;
        }
    }
}
