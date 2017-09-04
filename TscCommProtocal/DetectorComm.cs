using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TscCommProtocal.Utils;
using TscCommProtocal.Module;
using System.IO;

namespace TscCommProtocal
{
    public class DetectorComm
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
        public static Message SetDetector(List<Detector> ld, Node n)
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
                bool b = Udp.sendUdpNoReciveData(n.sIpAddress, n.iPort, hex);
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
    }
}
