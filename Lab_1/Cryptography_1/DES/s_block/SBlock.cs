using System;

namespace DES.s_block
{
    public static class SBlock
    {
        public static byte[] BitReplacement(byte[] byteArrray, byte[] rule, int k)
        {
            var value = BitConverter.ToUInt32(byteArrray, 0);
            ulong res = 0;
            int i = 0;
            
            if (byteArrray.Length * 8 % k != 0)
                throw new ArgumentException("Incorrect value argument! =(");
            
            while (i < (int)((Math.Log2(value) + 1) / k))
            {
                var OldSection = ((value >> i * k) & (ulong)((1 << k) - 1));
                var NewSection = rule[OldSection];
                res |=  (ulong)NewSection << (i * k);
                i++;
            }
            return (BitConverter.GetBytes(res));
        }
        
    }
}