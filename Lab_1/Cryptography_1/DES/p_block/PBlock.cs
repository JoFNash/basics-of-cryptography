﻿using System;

namespace DES.p_block
{
    public static class PBlock
    {
        public static byte[] BitSwapping(byte[] byteArrray, int[] rule)
        {
            var value = BitConverter.ToUInt32(byteArrray, 0);
            ulong res = 0;
            int i = 0;

            if ((uint)Math.Log2(value) + 1 != rule.Length)
                throw new ArgumentException("Incorrect value argument! =)");
            
            while (i < rule.Length)
            {
                res |= (((value >> (rule[i] - 1)) & 1) << i);
                i++;
            }
            Console.WriteLine("{0} - {1}", res, (ulong)res);
            return BitConverter.GetBytes((ulong)res);
        }
        
    }
}