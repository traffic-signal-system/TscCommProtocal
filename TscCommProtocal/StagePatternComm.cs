using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TscCommProtocal.Utils;
using TscCommProtocal.Module;
using System.IO;

namespace TscCommProtocal
{
    public class StagePatternComm
    {
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
        public static Message SetStagePattern(List<StagePattern> lsp, Node n)
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
        public static Message SetStagePattern16(List<StagePattern> lsp, Node n)
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
    }
}
