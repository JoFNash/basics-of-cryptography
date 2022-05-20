using System;

namespace DES.interfaces
{
    public interface ISymmetricEncryptionDecryption
    {
        public byte[] Encryption(byte[] bytesArray);

        public byte[] Decryption(byte[] bytesArray);

        public byte[] getRoundKeys(byte[] dKey);
    }
}