using System;

namespace Cryptography_1
{
    class Program
    {
        /* P-block */
        private static int[] P_block = new int[] {7, 1, 4, 8, 3, 6, 5, 2};

        public static byte[] BitSwapping(byte[] value, int[] rule)
        {
            int i = 1;
            ulong value_num = BitConverter.ToUInt32(value, 0);
            ulong res = 0;

            if (value.Length != rule.Length)
            {
                throw new ArgumentException("Incorrect value argument");
            }
            
            // Console.WriteLine("k = " + rule.Length + "\n");
            // Console.WriteLine("value_num = " + value_num + "!");
            //
            // while (i <= rule.Length)
            // {
            //     var k = 1 << rule[i - 1];
            //     Console.WriteLine(i + " -- " + k + " -- " + Convert.ToUInt32(k));
            //     Console.WriteLine(Convert.ToUInt32(k) & Convert.ToUInt32(value_num));
            //     res |= Convert.ToUInt32(k) & value_num;
            //     i++;
            // }
            // Console.WriteLine("res = " + res);
            return (BitConverter.GetBytes(res));
        }

        // public static byte[] BitReplacement(byte[] mass, int[] S_block, byte k)
        // {
        //     
        //     
        //     return ();
        // }

        static void Main(string[] args)
        {
           
            byte[] mass = new byte[8] {0, 1, 1, 0, 0, 1, 0, 1};
            
            byte[] mass1 = new byte[32] {0, 1, 1, 0, 0, 1, 0, 1,
                0, 1, 1, 0, 0, 1, 0, 1,
                0, 1, 1, 0, 0, 1, 0, 1,
                0, 1, 1, 0, 0, 1, 209, 1 };

            Console.WriteLine("Lab 1, problem 1\n");
            mass = BitSwapping(mass, P_block);

            byte[] arr1 = BitConverter.GetBytes(256);

            byte[] arr0 = { 1, 255, 255, 3};
            byte[] arr2 = BitConverter.GetBytes(256 * 256 * 256 * 3 + 256 * 256 * 255 + 256 * 255 + 255);

            for (int i = 0; i < arr0.Length; i++)
                Console.WriteLine(i + " - " + arr0[i]);
            //for (int i = 0; i < arr1.Length; i++)
                //Console.WriteLine(i + " - " + arr1[i]);
            Console.WriteLine();
            for (int i = 0; i < arr2.Length; i++)
                Console.WriteLine(i + " - " + arr2[i]);
            
        }
    }
}