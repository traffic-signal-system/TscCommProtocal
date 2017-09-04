using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TscCommProtocal.Utils;
using TscCommProtocal.Module;

namespace TscCommProtocal
{
    public class AdapterParaComm
    {
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
    }
}
