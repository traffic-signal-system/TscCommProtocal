using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TscCommProtocal.Utils;
using TscCommProtocal.Module;
using System.IO;

namespace TscCommProtocal
{
    public class OverlapPhaseComm
    {
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
        public static Message SetOverlapPhase(List<OverlapPhase> lop, Node n)
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
