using DES.interfaces;

namespace DES.classes
{
    public class EncryptedTransformation: IEncryptionTransformation
    {
        public byte[] getEncryptionTransform(byte[] block, byte[] roundKey)
        {
            throw new System.NotImplementedException();
        }
    }
}