using System;

namespace DES.interfaces
{
    public interface ISymmetricEncryptionDecryption
    {
        public byte[] Encryption(byte[] bytesArray);

        public byte[] Decryption(byte[] bytesArray);

        public void getRoundKeys(byte[] dKey);
    }
}