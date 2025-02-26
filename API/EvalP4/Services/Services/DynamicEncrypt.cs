using Microsoft.Extensions.Configuration;
using Repositories.Entities;

public class DynamicEncryptionService
{
    private readonly IEncryptionStrategy _encryptionStrategy;

    public IConfiguration Configuration { get; }

    public DynamicEncryptionService(Application application, IConfiguration configuration)
    {
        if (application.Type == "Grand public")
        {
            string aesKey = configuration["AES:Key"];
            string aesIv = configuration["AES:Iv"];
            _encryptionStrategy = new AesEncryptionService(aesKey, aesIv);
        }
        else if (application.Type == "Professionnelle")
        {
            string publicKey = configuration["RSAKeys:PublicKey"];
            string privateKey = configuration["RSAKeys:PrivateKey"];
            _encryptionStrategy = new RsaEncryptionService(publicKey, privateKey);
        }
        else
        {
            throw new InvalidOperationException("Type d'application non supporté.");
        }
    }

    public DynamicEncryptionService(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public string Encrypt(string plainText)
    {
        return _encryptionStrategy.Encrypt(plainText);
    }

    public string Decrypt(string encryptedText)
    {
        return _encryptionStrategy.Decrypt(encryptedText);
    }
}
