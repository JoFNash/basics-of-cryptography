using System;
using DES.p_block;
using DES.s_block;

namespace DES
{
    class Program
    {
        static void Main(string[] args)
        {
            // /* p_block */
            // int[] P_block = new int[] {4, 1, 2, 3};
            // byte[] byteArray_p = {3, 0, 0, 0};
            //
            // byte[] newByteArray_p = DES.p_block.PBlock.BitSwapping(byteArray_p, P_block);
            // Console.WriteLine(Convert.ToString(BitConverter.ToInt32(newByteArray_p), 2).PadLeft(64, '0'));
            //
            //
            // /* s_block */
            // byte[] S_block = {1, 2, 0, 3};
            // uint value = 199;
            //
            // Console.WriteLine(Convert.ToString(value, 2).PadLeft(32, '0'));
            // var res = DES.s_block.SBlock.BitReplacement(BitConverter.GetBytes(value), S_block, 2);
            // Console.WriteLine(Convert.ToString(BitConverter.ToUInt32(res), 2).PadLeft(32, '0'));

            byte[] key = new byte[8];
            new Random(5).NextBytes(key);
            for (int i = 0; i < key.Length; i++)
                Console.WriteLine(key[i]);
            byte[][] mass = new DES.classes.KeyExtension().getRoundKeys(key);
            // foreach (byte[] i in mass)
            // {
            //     foreach (byte j in i)
            //     {
            //         Console.Write($"{j} \t");
            //     }
            //     Console.WriteLine();
            // }

            byte[] roundKeyRandom = new byte[6];
            new Random().NextBytes(roundKeyRandom);
            byte[] block = new byte[4];
            new Random().NextBytes(block);
            byte[] arrayBytes = new classes.EncryptedTransformation().getEncryptionTransform(block, roundKeyRandom);
            
        }
    }
}