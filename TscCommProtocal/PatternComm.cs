using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TscCommProtocal.Module;
using System.IO;
using TscCommProtocal.Utils;

namespace TscCommProtocal
{
    public class PatternComm
    {
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
        public static Message SetPattern(List<Pattern> lp, Node n)
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
    }
}
