namespace DES.interfaces
{
    public interface IKeyExtension
    {
        /* (входной ключ - массив байтов,
            результат - массив раундовых ключей (каждый раундовый ключ - массив байтов)) */
        public byte[][] getRoundKeys(byte[] key);
    }
}