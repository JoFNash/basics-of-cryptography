using System;

namespace Cryptography_1
{
    class Program
    {
        /* P-block */
        private static int[] P_block = new int[] {16, 7, 20, 21,
            29, 12, 28, 17,
            1, 15, 23, 26,
            5, 18, 31, 10,
            2, 8, 24, 14,
            32, 27, 3, 9,
            19, 13, 30, 6,
            22, 11, 4, 25};

        public static byte[] BitSwapping(byte[] mass, int[] rule)
        {
            int i;
            byte[] res = new byte[32];
            
            i = 0;
            while (i < 32)
            {
                res[i] = mass[P_block[i] - 1];
                i++;
            }
            return (res);
        }

        static void Main(string[] args)
        {
            int i;
            byte[] mass = new byte[32] { 1, 0, 1, 1, 
                0, 1, 0, 0,
                1, 1, 1, 1,
                0, 0, 1, 1,
                0, 1, 1, 1,
                1, 1, 0, 1,
                0, 0, 1, 1,
                0, 1, 0, 12};

            Console.WriteLine("Lab 1, problem 1\n");
            mass = BitSwapping(mass, P_block);
            i = 0;
            while (i < 32)
            {
                Console.WriteLine("{0}, ", mass[i]);
                i++;
            }
            
        }
    }
}