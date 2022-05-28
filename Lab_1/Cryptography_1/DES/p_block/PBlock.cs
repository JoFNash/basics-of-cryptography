using System;

namespace DES.p_block
{
    public static class PBlock
    {
        public static byte[] BitSwapping(byte[] byteArrray, int[] rule)
        {
            uint res = 0;
            
            // if (byteArrray.Length * 8 % rule.Length != 0)
            //     throw new ArgumentException("Incorrect value argument! =(");
            
            for (int i = 0; i < rule.Length; i++)
            {
                var block = byteArrray[(rule[i] - 1) / 8];
                var offset = (rule[i] - 1) % 8;
                var bit = (byte)((block >> (8 - offset - 1)) & 1);
                res = (res << 1) | bit;
            }
            return (BitConverter.GetBytes(res));
        }
    }
}