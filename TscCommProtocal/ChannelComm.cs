using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TscCommProtocal.Module;
using TscCommProtocal.Utils;
using System.IO;

namespace TscCommProtocal
{
   public class ChannelComm
    {
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
        public static Message SetChannel(List<Channel> lc, Node n)
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
    }
}
