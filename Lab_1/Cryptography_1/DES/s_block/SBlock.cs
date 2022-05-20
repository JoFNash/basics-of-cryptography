﻿using System;

namespace DES.s_block
{
    public static class SBlock
    {
        public static byte[] BitReplacement(byte[] byteArrray, byte[] rule, int k)
        {
            var value = BitConverter.ToUInt32(byteArrray, 0);
            ulong res = 0;
            int i = 0;
            
            if (Math.Log2(rule.Length) % k != 0 || byteArrray.Length / k != rule.Length)
                throw new ArgumentException("Incorrect value argument! =(");
            
            // value = 11000111 -> ?
            // rule[0] = 1; | 00 -> 01
            // rule[1] = 2; | 01 -> 10
            // rule[2] = 0; | 10 -> 00
            // rule[3] = 3; | 11 -> 11
            
            while (i < (int)((Math.Log2(value) + 1) / k))
            {
                var oldSection = ((value >> i * k) & (ulong)((1 << k) - 1));
                var newSection = rule[oldSection];
                res |=  (ulong)newSection << (i * k);
                i++;
            }
            return (BitConverter.GetBytes(res));
        }
        
    }
}