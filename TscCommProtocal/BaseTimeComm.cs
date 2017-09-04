using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TscCommProtocal.Module;
using System.IO;
using TscCommProtocal.Utils;

namespace TscCommProtocal
{
   public class BaseTimeComm
    {
        /// <summary>
        /// 返回所有的时基表数据
        /// </summary>
        /// <returns></returns>
        public static List<Plan> GetPlan(Node n)
        {
            //TscData td = (TscData)Application.Current.Properties[Define.TSC_DATA];
            byte[] byt = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_PLAN);
            if (!CheckGBTUtil.CheckGBTProtocal(byt, "时基").flag)
            {
                return null;
            }
            List<Plan> listPlan = new List<Plan>();
            //取得)
            byte[] planArray = new byte[Convert.ToInt32(byt[3]) * 9];
            Array.Copy(byt, 4, planArray, 0, Convert.ToInt32(byt[3]) * 9);
            byte[,] twoArray = ByteUtils.oneArray2TwoArray(planArray, Convert.ToInt32(byt[3]), 9);
            Plan plan;
            for (int i = 0; i < Convert.ToInt32(byt[3]); i++)
            {
                plan = new Plan();
                plan.ucId = twoArray[i, 0];
                plan.usMonthFlag = (ushort)((twoArray[i, 1] << 8) + twoArray[i, 2]);//<<是移位符  21930;
                plan.ucWeekFlag = twoArray[i, 3];
                plan.ulDayFlag = (uint)((twoArray[i, 4] << 24) + (twoArray[i, 5] << 16) + (twoArray[i, 6] << 8) + twoArray[i, 7]);
                plan.ucScheduleId = twoArray[i, 8];
                listPlan.Add(plan);
            }
            return listPlan;
        }
        public static Message SetPlanByCalendar(List<Plan> lp, Node n)
        {
            Message m = new Message();
            //TscData t = Utils.Util.GetTscDataByApplicationCurrentProperties();
            byte[] hex = new byte[Define.PLAN_BYTE_SIZE * lp.Count + Define.SET_PLAN_RESPONSE.Length + 1];
            Stream s = new MemoryStream();
            s.Write(Define.SET_PLAN_RESPONSE, 0, Define.SET_PLAN_RESPONSE.Length);
            s.WriteByte(Convert.ToByte(lp.Count));
            foreach (Plan p in lp)
            {
                byte id = p.ucId;
                s.WriteByte(id);
                byte[] month = System.BitConverter.GetBytes(p.usMonthFlag);
                month = month.Reverse().ToArray();
                s.Write(month, 0, month.Length);
                byte week = p.ucWeekFlag;
                s.WriteByte(week);
                byte[] day = System.BitConverter.GetBytes(p.ulDayFlag);
                day = day.Reverse().ToArray();
                s.Write(day, 0, day.Length);
                byte schedule = p.ucScheduleId;
                s.WriteByte(schedule);
            }
            s.Position = 0;
            int count = s.Read(hex, 0, hex.Length);
            if (count > 0)
            {
                bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, hex);
                if (b)
                {
                    m.flag = true;
                    m.msg = "保存时基数据成功！";
                    m.obj = "Plan";
                }
                else
                {
                    m.flag = false;
                    m.msg = "保存时基数据失败！";
                    m.obj = "Plan";
                }
            }
            return m;
        }
        /// <summary>
        /// 保存时基数据到信号机中
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="port">商品</param>
        /// <param name="plans">时基的List集合</param>
        /// <returns></returns>
        public static bool SetPlanByWeekend(Node n, List<Plan> plans)
        {
            byte[] ba = new byte[plans.Count * Define.PLAN_BYTE_SIZE + 1];
            List<byte> lb = new List<byte>();
            lb.AddRange(Define.SET_PLAN_RESPONSE);
            lb.Add(Convert.ToByte(plans.Count));
            foreach (Plan p in plans)
            {
                byte[] bp = Utils.Util.Plan2ByteArray(p);
                lb.AddRange(bp);
            }
            ba = lb.ToArray<byte>();
            bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, ba);
            return b;
        }
    }
}
