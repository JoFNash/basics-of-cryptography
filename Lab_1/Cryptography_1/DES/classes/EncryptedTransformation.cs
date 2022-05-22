using System;
using DES.interfaces;

namespace DES.classes
{
    public class EncryptedTransformation: IEncryptionTransformation
    {
        /* шифрующее преобразование */
        public byte[] getEncryptionTransform(byte[] block, byte[] roundKey)
        {
            /* функция расширения Е */
            byte[] newBlock = DES.p_block.PBlock.BitSwapping(block, constants.Constants.extensionFunctionE);
            ulong value = BitConverter.ToUInt64(newBlock) ^ BitConverter.ToUInt64(roundKey);
            int i = 0;
            ulong res = 0;
            
            while (i < 8)
            {
                ulong firstB = (value >> (i * 6)) & ((uint)1 << 6) - 1;
                
                ulong a_b = ((firstB >> 5) << 1) | (firstB & 1);
                ulong bits = (firstB >> 1) & 15;
                firstB = constants.Constants.conversionS[i, a_b, bits];
                res = res | (firstB << 4 * i);
            }
            return (p_block.PBlock.BitSwapping(BitConverter.GetBytes(res), constants.Constants.permutationP));
        }
    }
}