public interface IEncryptionStrategy
{
    string Encrypt(string plainText);
    string Decrypt(string encryptedText);
}
