using System;

namespace DES.classes
{
    public class FeistelNetwork : interfaces.ISymmetricEncryptionDecryption
    {
        private readonly interfaces.IKeyExtension _keyGenerator;
        private readonly interfaces.IEncryptionTransformation _encryptionTransformation;
        private byte[][] _roundKeys;
        
        public FeistelNetwork(interfaces.IKeyExtension keyEx, interfaces.IEncryptionTransformation encryptTransform)
        {
            _keyGenerator = keyEx;
            _encryptionTransformation = encryptTransform;
        }


        public byte[] Encryption(byte[] bytesArray)
        {
            ulong number = BitConverter.ToUInt64(bytesArray);
            uint left = (uint)(number >> 32);
            uint right = (uint)(number & (((ulong)1 << 32) - 1));
            int rounds = 16;
            uint newLeft = 0;
            uint newRight = 0;

            for (int i = 0; i < rounds; i++)
            {
                newLeft = right;
                newRight = left ^ BitConverter.ToUInt32(_encryptionTransformation.getEncryptionTransform(BitConverter.GetBytes(right), _roundKeys[i]));
                left = newLeft;
                right = newRight;
            }
            return (BitConverter.GetBytes((ulong)newLeft << 32 | newRight));
        }

        public byte[] Decryption(byte[] bytesArray)
        {
            ulong number = BitConverter.ToUInt64(bytesArray);
            uint left = (uint)(number >> 32);
            uint right = (uint)(number & (((ulong)1 << 32) - 1));
            int rounds = 16;
            uint newLeft = 0;
            uint newRight = 0;

            for (int i = rounds - 1; i >= 0; i--)
            {
                newRight = left;
                newLeft = right ^ BitConverter.ToUInt32(_encryptionTransformation.getEncryptionTransform(BitConverter.GetBytes(left), _roundKeys[i]));
                right = newRight;
                left = newLeft;
            }
            return (BitConverter.GetBytes((ulong)newLeft << 32 | newRight)); /* 32 + 32 */
        }

        public void getRoundKeys(byte[] dKey)
        {
            _roundKeys = _keyGenerator.GetRoundKeys(dKey);
        }
    }
}