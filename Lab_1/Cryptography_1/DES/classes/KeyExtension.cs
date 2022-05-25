using System;
using DES.interfaces;
using DES.constants;

namespace DES.classes
{
    public class KeyExtension : IKeyExtension
    {
        public byte[][] getRoundKeys(byte[] key)
        {
            var RoundKeys = new byte[16][];
            var NewKey = BitSwapping(key, Constants.FirstKeyPermutation);
            var value = BitConverter.ToUInt64(NewKey, 0);

            var BlockC = value >> 28;
            var BlockD = value & ((1 << 28) -1);

            for (var i = 0; i < 16; i++)
            {
                var shear = Constants.CyclicShear[i]; /* сдвиг 1 или 2 */
                
                BlockC = ((BlockC << shear) | (BlockC >> (28 - shear))) & ((1 << 28) - 1); 
                BlockD = ((BlockD << shear) | (BlockD >> (28 - shear))) & ((1 << 28) - 1);
                
                var CommonBlock = BitConverter.GetBytes((BlockC << 28) | BlockD); /* 28 + 28 битов */
                RoundKeys[i] = DES.p_block.PBlock.BitSwapping(CommonBlock, Constants.SecondKeyPermutation);
            }
            return (RoundKeys);
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