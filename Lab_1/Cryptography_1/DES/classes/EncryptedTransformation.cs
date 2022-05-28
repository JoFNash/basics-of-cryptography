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
            var newBlock = DES.p_block.PBlock.BitSwapping(block, constants.Constants.extensionFunctionE);
            byte[] arrayBytes = new byte[8];
            for (int j = 0; j < newBlock.Length; j++)
                arrayBytes[j] |= (byte)(newBlock[j] ^ roundKey[j]);
            var value = BitConverter.ToUInt64(arrayBytes);
            ulong res = 0;
            
            for (var i = 0; i < 8; ++i)
            {
                ulong blockB = (value >> (i * 6)) & ((uint)1 << 6) - 1; 
                ulong border = ((blockB >> 5) << 1) | (blockB & 1);
                ulong bits = (blockB >> 1) & 0b1111;
                blockB = constants.Constants.conversionS[i, border, bits];
                res = res | (blockB << 4 * i);
            }
            return (p_block.PBlock.BitSwapping(BitConverter.GetBytes(res), constants.Constants.permutationP));
        }
    }
}