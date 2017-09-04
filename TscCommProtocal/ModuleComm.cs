using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TscCommProtocal.Module;
using TscCommProtocal.Utils;

namespace TscCommProtocal
{
    public class ModuleComm
    {
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
    }
}
