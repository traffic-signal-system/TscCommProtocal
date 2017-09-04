using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows;
using TscCommProtocal.Module;

namespace TscCommProtocal.Utils
{
    class TscDataUtils
    {
        public static int GetDetectorSensitivityOneBorad1_8(Node n)
        {
            //TscData t = Utils.Util.GetTscDataByApplicationCurrentProperties();
            byte[] result = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_DETECTOR_SENSITIVITY_1_1_8);
            int level = Convert.ToInt32(result[5]);

            return level;
        }
        public static int GetDetectorSensitivityOneBorad9_16(Node n)
        {
            //TscData t = Utils.Util.GetTscDataByApplicationCurrentProperties();
            byte[] result = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_DETECTOR_SENSITIVITY_1_9_16);
            int level = Convert.ToInt32(result[5]);

            return level;
        }
        public static int GetDetectorOscillatorFrequency1(Node n)
        {
            //TscData t = Utils.Util.GetTscDataByApplicationCurrentProperties();
            byte[] result = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_DETECTOR_OSCILLATOR_FREQUENCY_1);
            int level = Convert.ToInt32(result[5]);
            return level;
        }
        public static int GetDetectorOscillatorFrequency2(Node n)
        {
            //TscData t = Utils.Util.GetTscDataByApplicationCurrentProperties();
            byte[] result = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_DETECTOR_OSCILLATOR_FREQUENCY_2);
            int level = Convert.ToInt32(result[5]);
            return level;
        }
        public static int GetDetectorSensitivityTwoBorad1_8(Node n)
        {
            //TscData t = Utils.Util.GetTscDataByApplicationCurrentProperties();
            byte[] result = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_DETECTOR_SENSITIVITY_2_1_8);
            int level = Convert.ToInt32(result[5]);

            return level;
        }
        public static int GetDetectorSensitivityTwoBorad9_16(Node n)
        {
            //TscData t = Utils.Util.GetTscDataByApplicationCurrentProperties();
            byte[] result = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_DETECTOR_SENSITIVITY_2_9_16);
            int level = Convert.ToInt32(result[5]);

            return level;
        }

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
        public static bool SetLampCheckCloseThree(Node n )
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
        /// 取得所有的方向对应相位的数据
        /// </summary>
        /// <returns></returns>
        public static List<PhaseToDirec> GetPhaseToDirec(Node n)
        {
            //TscData t = Utils.Util.GetTscDataByApplicationCurrentProperties();
            byte[] byt = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_PHASE_DIREC);
            if (!CheckGBTUtil.CheckGBTProtocal(byt, "相位与方向关系").flag)
            {
                return null;
            }
            List<PhaseToDirec> llc = new List<PhaseToDirec>();
            byte[] pdArray = new byte[Convert.ToInt32(byt[3]) * Define.PHASE_DIREC_BYTE_SIZE];
            Array.Copy(byt, 4, pdArray, 0, Convert.ToInt32(byt[3]) * Define.PHASE_DIREC_BYTE_SIZE);
            byte[,] twoArray = ByteUtils.oneArray2TwoArray(pdArray, Convert.ToInt32(byt[3]), Define.PHASE_DIREC_BYTE_SIZE);
            PhaseToDirec lc;
            for (int i = 0; i < Convert.ToInt32(byt[3]); i++)
            {
                lc = new PhaseToDirec();
                lc.ucId = twoArray[i, 0];
                lc.ucPhase = twoArray[i, 1];
                lc.ucOverlapPhase = twoArray[i, 2];
                lc.ucRoadCnt = twoArray[i, 3];
                llc.Add(lc);
            }
            return llc;
        }
        public static Message SetTiming(DateTime dt,Node n)
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
        /// <summary>
        /// 设置震荡频率
        /// </summary>
        /// <param name="sf"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Message SetOscillatorFrequency(byte sf, Node n)
        {
            Message m = new Message();
            byte[] hex = new byte[Define.DETECTOR_OSCILLATOR_FREQUENCY.Length + 4];
            Stream s = new MemoryStream();
            s.Write(Define.DETECTOR_OSCILLATOR_FREQUENCY, 0, Define.DETECTOR_OSCILLATOR_FREQUENCY.Length);
            byte sfc = sf;
            sfc = (byte)(sf | sfc << 2);
            sfc = (byte)(sf | sfc << 2);
            sfc = (byte)(sf | sfc << 2);
            s.WriteByte(sfc);
            s.WriteByte(sfc);
            s.WriteByte(sfc);
            s.WriteByte(sfc);
            s.Position = 0;
            int count = s.Read(hex, 0, hex.Length);
            if (count > 0)
            {

                Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, hex);

            }
            return m;
        }
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
        /// 设置检测器灵敏 度
        /// </summary>
        /// <param name="borad"></param>
        /// <param name="se"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Message SetSensitivity(int borad, byte se, Node n)
        {
            Message m = new Message();

            byte[] hex = new byte[Define.DETECTOR_SENSITIVITY.Length + 4];
            Stream s = new MemoryStream();
            s.Write(Define.DETECTOR_SENSITIVITY, 0, Define.DETECTOR_SENSITIVITY.Length);
            byte sen = se;
            sen = (byte)(sen | se << 4);

            s.WriteByte(sen);
            s.WriteByte(sen);
            s.WriteByte(sen);
            s.WriteByte(sen);
            s.Position = 0;
            int count = s.Read(hex, 0, hex.Length);
            if (count > 0)
            {
                if (borad == 1)
                {
                    hex[3] = 0x0b;
                    hex[4] = 0x00;
                    Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, hex);
                    hex[3] = 0x0c;
                    hex[4] = 0x00;
                    Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, hex);
                }
                if (borad == 2)
                {
                    hex[3] = 0x0b;
                    hex[4] = 0x01;
                    Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, hex);
                    hex[3] = 0x0c;
                    hex[4] = 0x01;
                    Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, hex);
                    // Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, hex);
                }
            }

            return m;
        }
        /// <summary>
        /// 设置相位方向 表
        /// </summary>
        /// <param name="lptd"></param>
        /// <returns></returns>
        public static Message SetPhaseToDirec(List<PhaseToDirec> lptd,Node n)
        {
            //TscData t = Utils.Util.GetTscDataByApplicationCurrentProperties();
            Message msg = new Message();
            //字节 长度，需要加1 ，因为。数据长度需要一个字段表示。
            byte[] hex = new byte[Define.PHASE_DIREC_BYTE_SIZE * Define.PHASE_DIREC_RESULT_LEN + Define.SET_PHASE_DIREC_RESPONSE.Length + 1];
            Stream s = new MemoryStream();
            s.Write(Define.SET_PHASE_DIREC_RESPONSE, 0, Define.SET_PHASE_DIREC_RESPONSE.Length);
            s.WriteByte(Convert.ToByte(Define.PHASE_DIREC_RESULT_LEN));
            foreach (PhaseToDirec ptd in lptd)
            {
                byte id = ptd.ucId;
                s.WriteByte(id);
                byte phase = ptd.ucPhase;
                s.WriteByte(phase);
                byte op = ptd.ucOverlapPhase;
                s.WriteByte(op);
                byte rc = ptd.ucRoadCnt;
                s.WriteByte(rc);
            }
            s.Position = 0;
            int count = s.Read(hex, 0, hex.Length);
            if (count > 0)
            {
                bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, hex);
                if (b)
                {
                    msg.flag = true;
                    msg.msg = "设置方向属性成功！";
                    msg.obj = "PhaseToDirec";
                }
                else
                {
                    msg.flag = false;
                    msg.msg = "设置方向属性失败！";
                    msg.obj = "PhaseToDirec";
                }
            }

            return msg;
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
        /// <summary>
        /// 取得事件日志对象的所有 数据，
        /// </summary>
        /// <returns></returns>
        public static List<EventType> GetEventType(Node n)
        {
            //TscData td = (TscData)Application.Current.Properties[Define.TSC_DATA];
            byte[] byt = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_EVENT_TYPE);
            if (!CheckGBTUtil.CheckGBTProtocal(byt, "事件类型").flag)
            {
                return null;
            }
            List<EventType> listPlan = new List<EventType>();
            return null;
        }
        /// <summary>
        /// 取得信号机的模块数据信息
        /// </summary>
        /// <returns></returns>
        public static List<Module.Module> GetModule(Node n)
        {
            //TscData td = (TscData)Application.Current.Properties[Define.TSC_DATA];
            //取得所有字节数组
            byte[] byt = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_MODULE);
            if (!CheckGBTUtil.CheckGBTProtocal(byt, "模块").flag)
            {
                return null;
            }
            //去除协议部分
            byte[] moduleArray = new byte[byt.Length - 4];
            Array.Copy(byt, 4, moduleArray, 0, moduleArray.Length);

            List<Module.Module> listModule = new List<Module.Module>();
            List<int> everySetLength = new List<int>();
            List<byte[]> everyByteArray = new List<byte[]>();
            int modules = Convert.ToInt32(byt[3]);
            int count = 0;
            //一条记录的长度
            for (int i = 0; i < modules; i++)
            {
                int idcount = 1;
                int devNode = Convert.ToInt32(moduleArray[1 + count]);
                //这里加1是因为有一个字节 的设备节点长度。并不是数据
                int company = Convert.ToInt32(moduleArray[devNode + 1 + count + idcount]);
                //这里加2 = 1（devNode长度字节）+ 1（company长度字节）。并不是数据
                int model = Convert.ToInt32(moduleArray[devNode + company + 2 + count + idcount]);
                //这里加3 = 1（devNode长度字节）+ 1（company长度字节）+ 1（model长度字节）。并不是数据
                int version = Convert.ToInt32(moduleArray[devNode + company + model + 3 + count + idcount]);
                int typecount = 1;
                //最后 加上4， 是因为，有四个字段的字节长度属性，并不是真正的数据
                int all = idcount + devNode + company + model + version + typecount + 4;
                byte[] oneSetByteArray = new byte[all];
                Array.Copy(moduleArray, count, oneSetByteArray, 0, all);
                everyByteArray.Add(oneSetByteArray);
                count = count + all;

            }
            //主要是将每一条记录的数组独立出来一个数据并放到集合中，等待处理

            //foreach (int one in everySetLength)
            //{
            //    byte[] oneSetByteArray = new byte[one];
            //    Array.Copy(moduleArray, count, oneSetByteArray, 0, one);


            //}


            foreach (byte[] ba in everyByteArray)
            {
                Module.Module module = new Module.Module();
                module.ucModuleId = ba[0];
                int idCount = 1;

                int devNodeCount = Convert.ToInt32(ba[1]);
                int companyCount = Convert.ToInt32(ba[devNodeCount + 1 + idCount]);
                int modelCount = Convert.ToInt32(ba[devNodeCount + 2 + companyCount + idCount]);
                int versionCount = Convert.ToInt32(ba[devNodeCount + 3 + companyCount + idCount + modelCount]);
                //int typeCount = 1;

                byte[] bdevnode = new byte[devNodeCount];
                idCount += 1;
                for (int j = 0; j < devNodeCount; j++)
                {
                    bdevnode[j] = ba[idCount + j];
                }
                string sDevNode = System.Text.Encoding.ASCII.GetString(bdevnode);
                module.sDevNode = sDevNode;

                byte[] bcompany = new byte[companyCount];
                devNodeCount += 1;
                for (int k = 0; k < companyCount; k++)
                {
                    bcompany[k] = ba[idCount + devNodeCount + k];
                }
                string scompany = System.Text.Encoding.ASCII.GetString(bcompany);
                module.sCompany = scompany;

                byte[] bModel = new byte[modelCount];
                companyCount += 1;
                for (int l = 0; l < modelCount; l++)
                {
                    bModel[l] = ba[idCount + devNodeCount + companyCount + l];
                }
                string sModel = System.Text.Encoding.ASCII.GetString(bModel);
                module.sModel = sModel;

                byte[] bVersion = new byte[versionCount];
                modelCount += 1;
                for (int u = 0; u < versionCount; u++)
                {
                    bVersion[u] = ba[idCount + devNodeCount + modelCount + companyCount + u];
                }
                string sVersion = System.Text.Encoding.ASCII.GetString(bVersion);
                module.sVersion = sVersion;

                module.ucType = ba[idCount + devNodeCount + modelCount + companyCount + versionCount];

                listModule.Add(module);
            }


            return listModule;
        }

        /// <summary>
        /// 返回所有适配参数
        /// </summary>
        /// <returns></returns>
        public static List<AdapterPara> GetAdapterPara(Node n)
        {
           // TscData td = (TscData)Application.Current.Properties[Define.TSC_DATA];
            byte[] byt = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_CHANNEL);
            if (!CheckGBTUtil.CheckGBTProtocal(byt, "适配参数").flag)
            {
                return null;
            }
            List<AdapterPara> listPlan = new List<AdapterPara>();
            ////取得)
            //byte[] adapterParaArray = new byte[Convert.ToInt32(byt[3]) * 9];
            //Array.Copy(byt, 4, planArray, 0, Convert.ToInt32(byt[3]) * 9);
            //byte[,] twoArray = ByteUtils.oneArray2TwoArray(planArray, Convert.ToInt32(byt[3]), 9);
            //Plan plan;
            //for (int i = 0; i < Convert.ToInt32(byt[3]); i++)
            //{
            //    plan = new Plan();
            //    plan.ucId = twoArray[i, 0];
            //    plan.usMonthFlag = (short)((twoArray[i, 1] << 8) + twoArray[i, 2]);//<<是移位符  21930;
            //    plan.ucWeekFlag = twoArray[i, 3];
            //    plan.ulDayFlag = (int)((twoArray[i, 4] << 24) + (twoArray[i, 5] << 16) + (twoArray[i, 6] << 8) + twoArray[i, 7]);
            //    plan.usMonthFlag = twoArray[i, 8];
            //    listPlan.Add(plan);
            //}
            return null;
        }

        /// <summary>
        /// 返回所有相位表数据
        /// </summary>
        /// <returns></returns>
        public static List<Phase> GetPhase(Node n)
        {
            //TscData td = (TscData)Application.Current.Properties[Define.TSC_DATA];
            byte[] byt = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_PHASE);
            if (!CheckGBTUtil.CheckGBTProtocal(byt, "相位").flag)
            {
                return null;
            }
            List<Phase> listPhase = new List<Phase>();
            //取得)
            byte[] phaseArray = new byte[Convert.ToInt32(byt[3]) * Define.PAHSE_BYTE_SIZE];
            Array.Copy(byt, 4, phaseArray, 0, Convert.ToInt32(byt[3]) * Define.PAHSE_BYTE_SIZE);
            byte[,] twoArray = ByteUtils.oneArray2TwoArray(phaseArray, Convert.ToInt32(byt[3]), Define.PAHSE_BYTE_SIZE);
            Phase phase;
            for (int i = 0; i < Convert.ToInt32(byt[3]); i++)
            {
                phase = new Phase();
                phase.ucId = twoArray[i, 0];
                phase.ucPedestrianGreen = twoArray[i, 1];
                phase.ucPedestrianClear = twoArray[i, 2];
                phase.ucMinGreen = twoArray[i, 3];
                phase.ucGreenDelayUnit = twoArray[i, 4];
                phase.ucMaxGreen1 = twoArray[i, 5];
                phase.ucMaxGreen2 = twoArray[i, 6];
                phase.ucFixedGreen = twoArray[i, 7];
                phase.ucGreenFlash = twoArray[i, 8];
                phase.ucType = twoArray[i, 9];
                phase.ucOption = twoArray[i, 10];
                phase.ucExtend = twoArray[i, 11];

                listPhase.Add(phase);
            }
            return listPhase;
        }
        public static Message SetPhase(List<Phase> lp,Node n)
        {
            //TscData t = Utils.Util.GetTscDataByApplicationCurrentProperties();
            Message msg = new Message();
            //字节 长度，需要加1 ，因为。数据长度需要一个字段表示。
            byte[] hex = new byte[Define.PHASE_BYTE_SIZE * Define.PHASE_RESULT_LEN + Define.SET_PHASE_RESPONSE.Length + 1];
            Stream s = new MemoryStream();
            s.Write(Define.SET_PHASE_RESPONSE, 0, Define.SET_PHASE_RESPONSE.Length);
            s.WriteByte(Convert.ToByte(Define.PHASE_RESULT_LEN));
            foreach (Phase ptd in lp)
            {
                byte id = ptd.ucId;
                s.WriteByte(id);
                byte pg = ptd.ucPedestrianGreen;
                s.WriteByte(pg);
                byte pc = ptd.ucPedestrianClear;
                s.WriteByte(pc);
                byte mg = ptd.ucMinGreen;
                s.WriteByte(mg);
                byte gdu = ptd.ucGreenDelayUnit;
                s.WriteByte(gdu);
                byte mg1 = ptd.ucMaxGreen1;
                s.WriteByte(mg1);
                byte mg2 = ptd.ucMaxGreen2;
                s.WriteByte(mg2);
                byte fg = ptd.ucFixedGreen;
                s.WriteByte(fg);
                byte gf = ptd.ucGreenFlash;
                s.WriteByte(gf);
                byte type = ptd.ucType;
                s.WriteByte(type);
                byte opt = ptd.ucOption;
                s.WriteByte(opt);
                byte ext = ptd.ucExtend;
                s.WriteByte(ext);
            }
            s.Position = 0;
            int count = s.Read(hex, 0, hex.Length);
            if (count > 0)
            {
                bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, hex);
                if (b)
                {
                    msg.flag = true;
                    msg.msg = "设置相位属性成功！";
                    msg.obj = "Phase";
                }
                else
                {
                    msg.flag = false;
                    msg.msg = "设置相位属性失败！";
                    msg.obj = "Phase";
                }
            }

            return msg;
        }

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
        /// 返回所有的相位屏障数据
        /// </summary>
        /// <returns></returns>
        public static List<Collision> GetCollision(Node n)
        {
            //TscData td = (TscData)Application.Current.Properties[Define.TSC_DATA];
            byte[] byt = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_COLLISION);
            if (!CheckGBTUtil.CheckGBTProtocal(byt, "绿冲突").flag)
            {
                return null;
            }
            List<Collision> listCollision = new List<Collision>();
            //取得)
            byte[] collisionArray = new byte[Convert.ToInt32(byt[3]) * Define.GBT20999_COLLISION_BYTE_SIZE];
            Array.Copy(byt, 4, collisionArray, 0, Convert.ToInt32(byt[3]) * Define.GBT20999_COLLISION_BYTE_SIZE);
            byte[,] twoArray = ByteUtils.oneArray2TwoArray(collisionArray, Convert.ToInt32(byt[3]), Define.GBT20999_COLLISION_BYTE_SIZE);
            Collision collision;
            for (int i = 0; i < Convert.ToInt32(byt[3]); i++)
            {
                collision = new Collision();
                collision.ucPhaseId = twoArray[i, 0];
                collision.ucCollisionFlag = (uint)((twoArray[i, 1] << 24) + (twoArray[i, 2] << 16) + (twoArray[i, 3] << 8) + twoArray[i, 4]);

                listCollision.Add(collision);
            }
            return listCollision;
        }
        public static Message SetCollision(List<Collision> lc,Node n)
        {
            //TscData t = Utils.Util.GetTscDataByApplicationCurrentProperties();
            Message msg = new Message();
            //字节 长度，需要加1 ，因为。数据长度需要一个字段表示。
            byte[] hex = new byte[Define.COLLISION_BYTE_SIZE * Define.COLLISION_RESULT_LENGTH + Define.SET_COLLISION_RESPONSE.Length + 1];
            Stream s = new MemoryStream();
            s.Write(Define.SET_COLLISION_RESPONSE, 0, Define.SET_COLLISION_RESPONSE.Length);
            s.WriteByte(Convert.ToByte(Define.COLLISION_RESULT_LENGTH));
            foreach (Collision c in lc)
            {
                byte id = c.ucPhaseId;
                s.WriteByte(id);
                byte[] flag = System.BitConverter.GetBytes(c.ucCollisionFlag);
                flag = flag.Reverse().ToArray();
                s.Write(flag, 0, flag.Length);
            }
            s.Position = 0;
            int count = s.Read(hex, 0, hex.Length);
            if (count > 0)
            {
                bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, hex);
                if (b)
                {
                    msg.flag = true;
                    msg.msg = "设置相位冲突属性成功！";
                    msg.obj = "Collision";
                }
                else
                {
                    msg.flag = false;
                    msg.msg = "设置相位冲突属性失败！";
                    msg.obj = "Collision";
                }
            }

            return msg;
        }
        
        /// <summary>
        /// 返回检测器的所有数据
        /// </summary>
        /// <returns></returns>
        public static List<Detector> GetDetector(Node n)
        {
            //TscData td = (TscData)Application.Current.Properties[Define.TSC_DATA];
            byte[] byt = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_DETECTOR);
            if (!CheckGBTUtil.CheckGBTProtocal(byt, "检测器").flag)
            {
                return null;
            }
            List<Detector> listDetector = new List<Detector>();
            //取得)
            byte[] detectorArray = new byte[Convert.ToInt32(byt[3]) * Define.DETECTOR_BYTE_SIZE];
            Array.Copy(byt, 4, detectorArray, 0, Convert.ToInt32(byt[3]) * Define.DETECTOR_BYTE_SIZE);
            byte[,] twoArray = ByteUtils.oneArray2TwoArray(detectorArray, Convert.ToInt32(byt[3]), Define.DETECTOR_BYTE_SIZE);
            Detector detector;
            for (int i = 0; i < Convert.ToInt32(byt[3]); i++)
            {
                detector = new Detector();
                detector.ucDetectorId = twoArray[i, 0];
                detector.ucPhaseId = twoArray[i, 1];
                detector.ucDetFlag = twoArray[i, 2];
                detector.ucDirect = twoArray[i, 3];
                detector.ucValidTime = twoArray[i, 4];
                detector.ucOptionFlag = twoArray[i, 5];
                detector.usSaturationFlow = (short)((twoArray[i, 6] << 8) + twoArray[i, 7]);
                detector.ucSaturationOccupy = twoArray[i, 8];
                listDetector.Add(detector);
            }
            return listDetector;
        }
        public static Message SetDetector(List<Detector> ld,Node n)
        {
            Message msg = new Message();
            //TscData t = Utils.Util.GetTscDataByApplicationCurrentProperties();
            //字节 长度，需要加1 ，因为。数据长度需要一个字段表示。
            byte[] hex = new byte[Define.DETECTOR_BYTE_SIZE * Define.DETECTOR_RESULT_LEN + Define.SET_DETECTOR_RESPONSE.Length + 1];
            Stream s = new MemoryStream();
            s.Write(Define.SET_DETECTOR_RESPONSE, 0, Define.SET_DETECTOR_RESPONSE.Length);
            s.WriteByte(Convert.ToByte(ld.Count));
            foreach (Detector d in ld)
            {
                byte id = d.ucDetectorId;
                s.WriteByte(id);
                byte phaseid = d.ucPhaseId;
                s.WriteByte(phaseid);
                byte type = d.ucDetFlag;
                s.WriteByte(type);
                byte dirc = d.ucDirect;
                s.WriteByte(dirc);
                byte time = d.ucValidTime;
                s.WriteByte(time);
                byte opt = d.ucOptionFlag;
                s.WriteByte(opt);
                byte[] flow = System.BitConverter.GetBytes(d.usSaturationFlow);
                flow = flow.Reverse().ToArray();
                s.Write(flow, 0, flow.Length);
                byte occupy = d.ucSaturationOccupy;
                s.WriteByte(occupy);
            }
            s.Position = 0;
            int count = s.Read(hex, 0, hex.Length);
            if (count > 0)
            {
                bool b = Udp.sendUdpNoReciveData(n.sIpAddress,n.iPort, hex);
                if (b)
                {
                    msg.flag = true;
                    msg.msg = "发送检测器数据成功！";
                    msg.obj = "Detector";
                }
                else
                {
                    msg.flag = false;
                    msg.msg = "发送检测器数据失败！";
                    msg.obj = "Detector";
                }
            }

            return msg;
        }
        
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
        public static Message SetSchedule(List<Schedule> ls,Node n)
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
        /// <summary>
        /// 从信号机取得所有的通道信息。
        /// </summary>
        /// <returns></returns>
        public static List<Channel> GetChannel(Node n)
        {
            //TscData td = (TscData)Application.Current.Properties[Define.TSC_DATA];
            byte[] byt = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_CHANNEL);
            if (!CheckGBTUtil.CheckGBTProtocal(byt, "通道").flag)
            {
                return null;
            }
            List<Channel> listChannel = new List<Channel>();
            //取得)
            byte[] channelArray = new byte[Convert.ToInt32(byt[3]) * Define.CHANNEL_BYTE_SIZE];
            Array.Copy(byt, 4, channelArray, 0, Convert.ToInt32(byt[3]) * Define.CHANNEL_BYTE_SIZE);
            byte[,] twoArray = ByteUtils.oneArray2TwoArray(channelArray, Convert.ToInt32(byt[3]), Define.CHANNEL_BYTE_SIZE);
            Channel obj;
            for (int i = 0; i < Convert.ToInt32(byt[3]); i++)
            {
                obj = new Channel();
                obj.ucId = twoArray[i, 0];
                obj.ucSourcePhase = twoArray[i, 1];
                obj.ucFlashAuto = twoArray[i, 2];
                obj.ucType = twoArray[i, 3];

                listChannel.Add(obj);
            }
            return listChannel;
        }
        public static Message SetChannel(List<Channel> lc,Node n)
        {
            //TscData t = Utils.Util.GetTscDataByApplicationCurrentProperties();
            Message m = new Message();
            //字节 长度，需要加1 ，因为。数据长度需要一个字段表示。
            byte[] hex = new byte[Define.CHANNEL_BYTE_SIZE * Define.CHANNEL_RESULT_LEN + Define.SET_CHANNEL_RESPONSE.Length + 1];
            Stream s = new MemoryStream();
            s.Write(Define.SET_CHANNEL_RESPONSE, 0, Define.SET_CHANNEL_RESPONSE.Length);
            s.WriteByte(Convert.ToByte(Define.CHANNEL_RESULT_LEN));
            foreach (Channel c in lc)
            {
                byte id = c.ucId;
                s.WriteByte(id);
                byte sp = c.ucSourcePhase;
                s.WriteByte(sp);
                byte af = c.ucFlashAuto;
                s.WriteByte(af);
                byte type = c.ucType;
                s.WriteByte(type);
            }
            s.Position = 0;
            int count = s.Read(hex, 0, hex.Length);
            if (count > 0)
            {
                bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, hex);
                if (b)
                {
                    m.flag = true;
                    m.msg = "保存通道数据成功！";
                    m.obj = "Channel";
                }
                else
                {
                    m.flag = false;
                    m.msg = "保存通道数据失败！";
                    m.obj = "Channel";
                }
            }

            return m;
        }
        /// <summary>
        /// 从信号机取得所有的配时方案信息。
        /// </summary>
        /// <returns></returns>
        public static List<Pattern> GetPattern(Node n)
        {
            //TscData td = (TscData)Application.Current.Properties[Define.TSC_DATA];
            byte[] byt = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_PATTERN);
            if (!CheckGBTUtil.CheckGBTProtocal(byt, "配时方案").flag)
            {
                return null;
            }
            List<Pattern> listPattern = new List<Pattern>();
            //取得)
            byte[] arrayPattern = new byte[Convert.ToInt32(byt[3]) * Define.PATTERN_BYTE_SIZE];
            Array.Copy(byt, 4, arrayPattern, 0, Convert.ToInt32(byt[3]) * Define.PATTERN_BYTE_SIZE);
            byte[,] twoArray = ByteUtils.oneArray2TwoArray(arrayPattern, Convert.ToInt32(byt[3]), Define.PATTERN_BYTE_SIZE);
            Pattern obj;
            for (int i = 0; i < Convert.ToInt32(byt[3]); i++)
            {
                obj = new Pattern();
                obj.ucPatternId = twoArray[i, 0];
                obj.ucCycleTime = twoArray[i, 1];
                obj.ucOffset = twoArray[i, 2];
                obj.ucCoorPhase = twoArray[i, 3];
                obj.ucStagePatternId = twoArray[i, 4];
                listPattern.Add(obj);
            }
            return listPattern;
        }
        public static Message SetPattern(List<Pattern> lp,Node n)
        {
            //TscData t = Utils.Util.GetTscDataByApplicationCurrentProperties();
            Message m = new Message();
            //字节 长度，需要加1 ，因为。数据长度需要一个字段表示。
            byte[] hex = new byte[Define.PATTERN_BYTE_SIZE * lp.Count + Define.SET_PATTERN_RESPONSE.Length + 1];
            Stream s = new MemoryStream();
            s.Write(Define.SET_PATTERN_RESPONSE, 0, Define.SET_PATTERN_RESPONSE.Length);
            s.WriteByte(Convert.ToByte(lp.Count));
            foreach (Pattern p in lp)
            {
                byte id = p.ucPatternId;
                s.WriteByte(id);
                byte cyc = p.ucCycleTime;
                s.WriteByte(cyc);
                byte r = p.ucOffset;
                s.WriteByte(r);
                byte coor = p.ucCoorPhase;
                s.WriteByte(coor);
                byte stageid = p.ucStagePatternId;
                s.WriteByte(stageid);
            }
            s.Position = 0;
            int count = s.Read(hex, 0, hex.Length);
            if (count > 0)
            {
                bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, hex);
                if (b)
                {
                    m.flag = true;
                    m.msg = "保存配时方案数据成功！";
                    m.obj = "Pattern";
                }
                else
                {
                    m.flag = false;
                    m.msg = "保存配时方案数据失败！";
                    m.obj = "Pattern";
                }
            }
            return m;
        }
        /// <summary>
        /// 从信号机取得所有阶段配时信息。
        /// </summary>
        /// <returns></returns>
        public static List<StagePattern> GetStagePattern(Node n)
        {
            //TscData td = (TscData)Application.Current.Properties[Define.TSC_DATA];
            byte[] byt = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_STAGEPATTERN);
            if (!CheckGBTUtil.CheckGBTProtocal(byt, "阶段配时").flag)
            {
                return null;
            }
            List<StagePattern> listStagePattern = new List<StagePattern>();
            //取得)
            byte[] arrayStagePattern = new byte[Convert.ToInt32(byt[3]) * Convert.ToInt32(byt[4]) * Define.STAGEPATTERN_BYTE_SIZE];
            Array.Copy(byt, 5, arrayStagePattern, 0, Convert.ToInt32(byt[3]) * Convert.ToInt32(byt[4]) * Define.STAGEPATTERN_BYTE_SIZE);
            byte[,] twoArray = ByteUtils.oneArray2TwoArray(arrayStagePattern, Convert.ToInt32(byt[3]) * Convert.ToInt32(byt[4]), Define.STAGEPATTERN_BYTE_SIZE);
            StagePattern obj;
            for (int i = 0; i < (Convert.ToInt32(byt[3]) * Convert.ToInt32(byt[4])); i++)
            {
                obj = new StagePattern();
                obj.ucStagePatternId = twoArray[i, 0];
                obj.ucStageNo = twoArray[i, 1];
                obj.usAllowPhase = (uint)((twoArray[i, 2] << 24) + (twoArray[i, 3] << 16) + (twoArray[i, 4] << 8) + twoArray[i, 5]);
                obj.ucGreenTime = twoArray[i, 6];
                obj.ucYellowTime = twoArray[i, 7];
                obj.ucRedTime = twoArray[i, 8];
                obj.ucOption = twoArray[i, 9];
                listStagePattern.Add(obj);
            }
            return listStagePattern;
        }
        public static Message SetStagePattern(List<StagePattern> lsp,Node n)
        {
            //TscData t = Utils.Util.GetTscDataByApplicationCurrentProperties();
            Message m = new Message();
            ////字节 长度，需要加2 ，因为。数据长度需要2个字段表示，二维数组。
            byte[] hex = new byte[Define.STAGEPATTERN_BYTE_SIZE * (Define.STAGEPATTERN_RESULT_LEN * Define.STAGE_RESULT_LEN) + Define.SET_STAGEPATTERN_RESPONSE.Length + 2];
            Stream s = new MemoryStream();
            s.Write(Define.SET_STAGEPATTERN_RESPONSE, 0, Define.SET_STAGEPATTERN_RESPONSE.Length);
            s.WriteByte(Convert.ToByte(Define.STAGEPATTERN_RESULT_LEN));
            s.WriteByte(Convert.ToByte(Define.STAGE_RESULT_LEN));
            foreach (StagePattern sp in lsp)
            {
                byte id = sp.ucStagePatternId;
                s.WriteByte(id);
                byte stageno = sp.ucStageNo;
                s.WriteByte(stageno);
                byte[] ap = System.BitConverter.GetBytes(sp.usAllowPhase);
                ap = ap.Reverse().ToArray();
                s.Write(ap, 0, ap.Length);
                byte green = sp.ucGreenTime;
                s.WriteByte(green);
                byte yellow = sp.ucYellowTime;
                s.WriteByte(yellow);
                byte red = sp.ucRedTime;
                s.WriteByte(red);
                byte opt = sp.ucOption;
                s.WriteByte(opt);
            }
            s.Position = 0;
            int count = s.Read(hex, 0, hex.Length);
            if (count > 0)
            {
                bool b = Udp.sendUdpNoReciveData(n.sIpAddress,n.iPort, hex);
                if (b)
                {
                    m.flag = true;
                    m.msg = "保存阶段配时方案数据成功！";
                    m.obj = "Pattern";
                }
                else
                {
                    m.flag = false;
                    m.msg = "保存阶段配时方案数据失败！";
                    m.obj = "Pattern";
                }
            }
            return m;
        }
        /// <summary>
        /// 从信号机取得所有阶段配时信息。
        /// </summary>
        /// <returns></returns>
        public static List<StagePattern> GetStagePattern16(Node n)
        {
           // TscData td = (TscData)Application.Current.Properties[Define.TSC_DATA];
            byte[] byt = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_STAGEPATTERN);
            if (!CheckGBTUtil.CheckGBTProtocal(byt, "阶段配时").flag)
            {
                return null;
            }
            List<StagePattern> listStagePattern = new List<StagePattern>();
            //取得)
            byte[] arrayStagePattern = new byte[Convert.ToInt32(byt[3]) * Convert.ToInt32(byt[4]) * Define.STAGE_PATTERN_BYTE_SIZE_16];
            Array.Copy(byt, 5, arrayStagePattern, 0, Convert.ToInt32(byt[3]) * Convert.ToInt32(byt[4]) * Define.STAGE_PATTERN_BYTE_SIZE_16);
            byte[,] twoArray = ByteUtils.oneArray2TwoArray(arrayStagePattern, Convert.ToInt32(byt[3]) * Convert.ToInt32(byt[4]), Define.STAGE_PATTERN_BYTE_SIZE_16);
            StagePattern obj;
            for (int i = 0; i < (Convert.ToInt32(byt[3]) * Convert.ToInt32(byt[4])); i++)
            {
                obj = new StagePattern();
                obj.ucStagePatternId = twoArray[i, 0];
                obj.ucStageNo = twoArray[i, 1];
                obj.usAllowPhase = (uint)((twoArray[i, 2] << 8) + twoArray[i, 3]);
                obj.ucGreenTime = twoArray[i, 4];
                obj.ucYellowTime = twoArray[i, 5];
                obj.ucRedTime = twoArray[i, 6];
                obj.ucOption = twoArray[i, 7];
                listStagePattern.Add(obj);
            }
            return listStagePattern;
        }
        public static Message SetStagePattern16(List<StagePattern> lsp,Node n)
        {
           // TscData t = Utils.Util.GetTscDataByApplicationCurrentProperties();
            Message m = new Message();
            ////字节 长度，需要加2 ，因为。数据长度需要2个字段表示，二维数组。
            byte[] hex = new byte[Define.STAGE_PATTERN_BYTE_SIZE_16 * (Define.STAGEPATTERN_RESULT_LEN * Define.STAGE_RESULT_LEN) + Define.SET_STAGEPATTERN_RESPONSE.Length + 2];
            Stream s = new MemoryStream();
            s.Write(Define.SET_STAGEPATTERN_RESPONSE, 0, Define.SET_STAGEPATTERN_RESPONSE.Length);
            s.WriteByte(Convert.ToByte(Define.STAGEPATTERN_RESULT_LEN));
            s.WriteByte(Convert.ToByte(Define.STAGE_RESULT_LEN));
            foreach (StagePattern sp in lsp)
            {
                byte id = sp.ucStagePatternId;
                s.WriteByte(id);
                byte stageno = sp.ucStageNo;
                s.WriteByte(stageno);
                byte[] ap = System.BitConverter.GetBytes(sp.usAllowPhase);
                ap = ap.Reverse().ToArray();
                s.Write(ap, 0, ap.Length);
                byte green = sp.ucGreenTime;
                s.WriteByte(green);
                byte yellow = sp.ucYellowTime;
                s.WriteByte(yellow);
                byte red = sp.ucRedTime;
                s.WriteByte(red);
                byte opt = sp.ucOption;
                s.WriteByte(opt);
            }
            s.Position = 0;
            int count = s.Read(hex, 0, hex.Length);
            if (count > 0)
            {
                bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, hex);
                if (b)
                {
                    m.flag = true;
                    m.msg = "保存阶段配时方案数据成功！";
                    m.obj = "Pattern";
                }
                else
                {
                    m.flag = false;
                    m.msg = "保存阶段配时方案数据失败！";
                    m.obj = "Pattern";
                }
            }
            return m;
        }
        /// <summary>
        /// 从信号机取得所有的跟随相位信息。
        /// </summary>
        /// <returns></returns>
        public static List<OverlapPhase> GetOverlapPhase(Node n)
        {
            //TscData td = (TscData)Application.Current.Properties[Define.TSC_DATA];
            byte[] byt = Udp.recvUdp(n.sIpAddress, n.iPort, Define.GET_OVERLAPPHASE);
            if (!CheckGBTUtil.CheckGBTProtocal(byt, "跟随相位").flag)
            {
                return null;
            }
            List<OverlapPhase> listOverlapPhase = new List<OverlapPhase>();
            //取得)
            byte[] arrayOverlapPhase = new byte[Convert.ToInt32(byt[3]) * Define.GBT20999_OVERLAPPHASE_BYTE_SIZE];
            Array.Copy(byt, 4, arrayOverlapPhase, 0, Convert.ToInt32(byt[3]) * Define.GBT20999_OVERLAPPHASE_BYTE_SIZE);
            byte[,] twoArray = ByteUtils.oneArray2TwoArray(arrayOverlapPhase, Convert.ToInt32(byt[3]), Define.GBT20999_OVERLAPPHASE_BYTE_SIZE);
            OverlapPhase obj;
            for (int i = 0; i < Convert.ToInt32(byt[3]); i++)
            {
                obj = new OverlapPhase();
                obj.ucId = twoArray[i, 0];
                obj.ucOperateType = twoArray[i, 1];
                obj.ucIncludePhaseLen = twoArray[i, 2];
                obj.ucIncludePhase = new byte[] { twoArray[i, 3], twoArray[i, 4], twoArray[i, 5], twoArray[i, 6], twoArray[i, 7], twoArray[i, 8], twoArray[i, 9], twoArray[i, 10], twoArray[i, 11], twoArray[i, 12], twoArray[i, 13], twoArray[i, 14], twoArray[i, 15], twoArray[i, 16], twoArray[i, 17], twoArray[i, 18] };
                obj.ucCorrectPhaseLen = twoArray[i, 19];
                obj.ucCorrectPhase = new byte[] { twoArray[i, 20], twoArray[i, 21], twoArray[i, 22], twoArray[i, 23], twoArray[i, 24], twoArray[i, 25], twoArray[i, 26], twoArray[i, 27], twoArray[i, 28], twoArray[i, 29], twoArray[i, 30], twoArray[i, 31], twoArray[i, 32], twoArray[i, 33], twoArray[i, 34], twoArray[i, 35] };
                obj.ucTailGreen = twoArray[i, 36];
                obj.ucTailYellow = twoArray[i, 37];
                obj.ucTailRed = twoArray[i, 38];
                listOverlapPhase.Add(obj);
            }
            return listOverlapPhase;
        }
        public static Message SetOverlapPhase(List<OverlapPhase> lop,Node n)
        {
           // TscData t = Utils.Util.GetTscDataByApplicationCurrentProperties();
            Message m = new Message();
            //字节 长度，需要加1 ，因为。数据长度需要一个字段表示。
            byte[] hex = new byte[Define.OVERLAPPHASE_BYTE_SIZE * Define.OVERLAPPHASE_RESULT_LEN + Define.SET_OVERLAPPHASE_RESPONSE.Length + 1];
            Stream s = new MemoryStream();
            s.Write(Define.SET_OVERLAPPHASE_RESPONSE, 0, Define.SET_OVERLAPPHASE_RESPONSE.Length);
            s.WriteByte(Convert.ToByte(lop.Count));
            foreach (OverlapPhase op in lop)
            {
                byte id = op.ucId;
                s.WriteByte(id);
                byte ot = op.ucOperateType;
                s.WriteByte(ot);

                byte ipl = op.ucIncludePhaseLen;
                s.WriteByte(ipl);
                byte[] ip = op.ucIncludePhase;
                s.Write(ip, 0, ip.Length);
                byte cpl = op.ucCorrectPhaseLen;
                s.WriteByte(cpl);
                byte[] cp = op.ucCorrectPhase;
                s.Write(cp, 0, cp.Length);
                byte green = op.ucTailGreen;
                s.WriteByte(green);
                byte yellow = op.ucTailYellow;
                s.WriteByte(yellow);
                byte red = op.ucTailRed;
                s.WriteByte(red);
            }
            s.Position = 0;
            int count = s.Read(hex, 0, hex.Length);
            if (count > 0)
            {
                bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, hex);
                if (b)
                {
                    m.flag = true;
                    m.msg = "保存跟随相位数据成功！";
                    m.obj = "Pattern";
                }
                else
                {
                    m.flag = false;
                    m.msg = "保存跟随相位数据失败！";
                    m.obj = "Pattern";
                }
            }
            return m;
        }
    }
}
