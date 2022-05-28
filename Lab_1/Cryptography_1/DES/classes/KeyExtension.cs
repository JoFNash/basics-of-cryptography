using System;
using DES.interfaces;
using DES.constants;

namespace DES.classes
{
    public class KeyExtension : IKeyExtension
    {
        public byte[][] GetRoundKeys(byte[] key)
        {
            var roundKeys = new byte[16][];
            var newKey = BitSwapping(key, Constants.FirstKeyPermutation);
            var value = BitConverter.ToUInt64(newKey, 0);

            var blockC = value >> 28;
            var blockD = value & ((1 << 28) -1);

            for (var i = 0; i < 16; i++)
            {
                var shear = Constants.CyclicShear[i]; /* сдвиг 1 или 2 */
                
                blockC = ((blockC << shear) | (blockC >> (28 - shear))) & ((1 << 28) - 1); 
                blockD = ((blockD << shear) | (blockD >> (28 - shear))) & ((1 << 28) - 1);
                
                var commonBlock = BitConverter.GetBytes((blockC << 28) | blockD); /* 28 + 28 битов */
                roundKeys[i] = DES.p_block.PBlock.BitSwapping(commonBlock, Constants.SecondKeyPermutation);
            }
            return (roundKeys);
        }
        
        public static byte[] BitSwapping(byte[] byteArrray, int[] rule)
                {
                    var value = BitConverter.ToUInt64(byteArrray, 0);
                    ulong res = 0;
                    int i = 0;
                    
                    while (i < rule.Length)
                    {
                        res |= (((value >> (rule[i] - 1)) & 1) << i);
                        i++;
                    }
                    return BitConverter.GetBytes((ulong)res);
                }
    }
}