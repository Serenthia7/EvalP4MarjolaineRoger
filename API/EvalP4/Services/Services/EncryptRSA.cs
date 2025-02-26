using System;
using System.Security.Cryptography;
using System.Text;

public class RsaEncryptionService : IEncryptionStrategy
{
    private readonly string _publicKey;
    private readonly string _privateKey;

    public RsaEncryptionService(string publicKey, string privateKey)
    {
        _publicKey = publicKey;
        _privateKey = privateKey;
    }

    public string Encrypt(string plainText)
    {
        using (RSA rsa = RSA.Create())
        {
            rsa.ImportFromPem(_publicKey.ToCharArray());

            byte[] data = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedData = rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA256);
            return Convert.ToBase64String(encryptedData);
        }
    }

    public string Decrypt(string encryptedText)
    {
        using (RSA rsa = RSA.Create())
        {
            rsa.ImportFromPem(_privateKey.ToCharArray());

            byte[] data = Convert.FromBase64String(encryptedText);
            byte[] decryptedData = rsa.Decrypt(data, RSAEncryptionPadding.OaepSHA256);
            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}
