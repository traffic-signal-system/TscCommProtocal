using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TscCommProtocal.Module;
using TscCommProtocal.Utils;
using System.IO;

namespace TscCommProtocal
{
    public class PhaseComm
    {
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
        public static Message SetPhase(List<Phase> lp, Node n)
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

    }
}
