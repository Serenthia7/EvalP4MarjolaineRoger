using System;
using System.Security.Cryptography;
using System.Text;

public class AesEncryptionService : IEncryptionStrategy
{
    private readonly string _key;
    private readonly string _iv;

    public AesEncryptionService(string key, string iv)
    {
        _key = key; // Clé secrète AES
        _iv = iv;   // Vecteur d'initialisation AES
    }

    public string Encrypt(string plainText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Convert.FromBase64String(_key);
            aesAlg.IV = Convert.FromBase64String(_iv);

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            byte[] encryptedBytes = PerformCryptography(plainText, encryptor);
            return Convert.ToBase64String(encryptedBytes);
        }
    }

    public string Decrypt(string encryptedText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Convert.FromBase64String(_key);
            aesAlg.IV = Convert.FromBase64String(_iv);

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            byte[] decryptedBytes = PerformCryptography(encryptedText, decryptor);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }

    private byte[] PerformCryptography(string data, ICryptoTransform cryptoTransform)
    {
        byte[] dataBytes = Convert.FromBase64String(data);
        return cryptoTransform.TransformFinalBlock(dataBytes, 0, dataBytes.Length);
    }
}
