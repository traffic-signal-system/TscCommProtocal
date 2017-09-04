using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TscCommProtocal.Utils;
using TscCommProtocal.Module;
using System.IO;

namespace TscCommProtocal
{
   public  class PhaseToDirecComm
    {
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
        /// <summary>
        /// 设置相位方向 表
        /// </summary>
        /// <param name="lptd"></param>
        /// <returns></returns>
        public static Message SetPhaseToDirec(List<PhaseToDirec> lptd, Node n)
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
    }
}
