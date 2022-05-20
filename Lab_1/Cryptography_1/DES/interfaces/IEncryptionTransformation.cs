namespace DES.interfaces
{
    public interface IEncryptionTransformation
    {
        public byte[] getEncryptionTransform(byte[] block, byte[] roundKey);
    }
}