using System;
using DES.interfaces;
using DES.constants;

namespace DES.classes
{
    public class KeyExtension : IKeyExtension
    {
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
        
        public byte[][] getRoundKeys(byte[] key)
        {
            var RoundKeys = new byte[16][];
            byte[] commonBlock;
            byte[] NewKey = BitSwapping(key, DES.constants.Constants.InitialPermutation);
            var value = BitConverter.ToUInt64(NewKey, 0);
            int i = 0;

            var blockC = value >> 28;
            var blockD = value & ((1 << 28) -1);

            while (i < 16)
            {
                var shear = DES.constants.Constants.CyclicShear[i];
                blockC = ((blockC << shear) | (blockC >> (28 - shear))) | ((1 << 28) - 1);
                blockD = ((blockD << shear) | (blockD >> (28 - shear))) | ((1 << 28) - 1);
                commonBlock = BitConverter.GetBytes((blockC << 28) | blockD);
                RoundKeys[i] = DES.p_block.PBlock.BitSwapping(commonBlock, DES.constants.Constants.FinalPermutation);
                i++;
            }
            return (RoundKeys);
        }
    }
}