using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TscCommProtocal.Utils
{
    public class ByteUtils
    {
        public static byte[] concatByteArray(byte[] b1, byte[] b2)
        {
            List<byte> tmp = new List<byte>(b1.Length + b2.Length);
            tmp.AddRange(b1);
            tmp.AddRange(b2);
            byte[] merged = tmp.ToArray();
            return merged;
        }
        public static byte[,] oneArray2TwoArray(byte[] bty, int row, int column)
        {
            byte[,] barray = new byte[row, column];
            for (int i = 0; i < bty.Length; i++)
                barray[i / column, i % column] = bty[i];
            return barray;
        }
        public static byte[] twoArray2OneArray(byte[,] a, int r, int c)
        {
            //int[,] a = new int[r, c];
            byte[] b = new byte[r * c];
            for (int i = 0; i < b.Length; i++)
                b[i] = a[i / c, i % c];
            return b;
        }
        public static byte[] IPorMASKorGATEWAYToByteArray(string str)
        {
            string[] strs = str.Split(new char[] { '.' });
            byte[] bytes = new byte[strs.Length];
            bytes[0] = Byte.Parse(strs[0]);
            bytes[1] = Byte.Parse(strs[1]);
            bytes[2] = Byte.Parse(strs[2]);
            bytes[3] = Byte.Parse(strs[3]);
            return bytes;
        }
    }
}
