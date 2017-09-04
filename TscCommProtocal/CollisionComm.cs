using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TscCommProtocal.Utils;
using TscCommProtocal.Module;
using System.IO;

namespace TscCommProtocal
{
    public class CollisionComm
    {
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
        public static Message SetCollision(List<Collision> lc, Node n)
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
    }
}
