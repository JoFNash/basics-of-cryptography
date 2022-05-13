using System;

namespace Cryptography_1
{
    class Program
    {
        /* P-block */
        private static int[] P_block = new int[] {7, 1, 4, 8, 3, 6, 5, 2};

        public static byte[] BitSwapping(byte[] value, int[] rule)
        {
            int i = 0;
            ulong value_num = BitConverter.ToUInt64(value, 0);
            ulong res = 0;
            
            if (value.Length != rule.Length)
                throw new ArgumentException("Incorrect value argument");
            
            Console.WriteLine("value_num = " + value_num);
            
            while (i < rule.Length)
            {
                var k = 1 << rule[i] - 1;
                Console.WriteLine("{0} - {1}", k, value_num);
                res |= (ulong)k & value_num;
                i++;
            }
            return (BitConverter.GetBytes(res));
        }
        
        static void Main(string[] args)
        {
            byte[] mass = new byte[8] {2, 1, 1, 0, 0, 0, 0, 0};
            for (int i = 0 ; i < mass.Length; i++)
                Console.Write(mass[i] + " "); 
            Console.WriteLine();
            byte[] mass1 = BitSwapping(mass, P_block);
            for (int i = 0 ; i < mass1.Length; i++)
                Console.Write(mass1[i] + " ");   
        }
        
        // public static byte[] BitReplacement(byte[] mass, int[] S_block, byte k)
        // {
        //     
        //     
        //     return ();
        // }
        
    }
}