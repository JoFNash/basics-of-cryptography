using System;
using DES.interfaces;

namespace DES.classes
{
    public class EncryptedTransformation: IEncryptionTransformation
    {
        /* шифрующее преобразование */
        public byte[] getEncryptionTransform(byte[] block, byte[] roundKey) /* 32-bit, 48-bit*/
        {
            /* функция расширения Е */
            byte[] NewBlock = DES.p_block.PBlock.BitSwapping(block, constants.Constants.extensionFunctionE);
            var value = BitConverter.ToUInt64(NewBlock) ^ BitConverter.ToUInt64(roundKey);
            int i = 0;
            ulong res = 0;
            
            // 1.0010.0 = 10 + 0010
            while (i < 8)
            {
                ulong BlockB = (value >> (i * 6)) & ((uint)1 << 6) - 1; 
                ulong Border = ((BlockB >> 5) << 1) | (BlockB & 1);
                ulong bits = (BlockB >> 1) & 0b1111;
                BlockB = constants.Constants.conversionS[i, Border, bits];
                res = res | (BlockB << 4 * i);
            }
            return (p_block.PBlock.BitSwapping(BitConverter.GetBytes(res), constants.Constants.permutationP));
        }
    }
}