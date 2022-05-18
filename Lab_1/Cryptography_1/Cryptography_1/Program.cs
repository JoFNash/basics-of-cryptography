using System;
using System.Numerics;
using System.Xml;

namespace Cryptography_1
{
    class Program
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

        public static byte[] BitReplacement(byte[] byteArrray, byte[] rule, int k)
        {
            var value = BitConverter.ToUInt32(byteArrray, 0);
            ulong res = 0;
            int i = 0;
            
            if (Math.Log2(rule.Length) % k != 0)
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

        static void Main(string[] args)
        {
            int[] P_block = new int[] {4, 1, 2, 3};
            byte[] byteArray_p = {3, 0, 0, 0};
            
            byte[] newByteArray_p = BitSwapping(byteArray_p, P_block);
            //Console.WriteLine(Convert.ToString(BitConverter.ToInt32(newByteArray_p), 2).PadLeft(64, '0'));

            byte[] S_block = {1, 2, 0, 3};
            uint value = 199;
            
            //Console.WriteLine(Convert.ToString(value, 2).PadLeft(32, '0'));
            var res = BitReplacement(BitConverter.GetBytes(value), S_block, 2);
            //Console.WriteLine(Convert.ToString(BitConverter.ToUInt32(res), 2).PadLeft(32, '0'));

        }
    }
}

