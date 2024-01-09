using System.Text;
using Azure.Security.KeyVault.Keys.Cryptography;

namespace Seneca.Azure.Integration.KeyVault;

public class CryptographyService
{
    private readonly CryptographyClient cryptographyClient;

    public CryptographyService(CryptographyClient cryptographyClient)
    {
        this.cryptographyClient = cryptographyClient;
    }

    public async Task<string> Encrypt(string payload, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(payload);
        var data = Encoding.UTF8.GetBytes(payload);
        var encryptParameters = EncryptParameters.RsaOaepParameters(data);
        var result = await cryptographyClient.EncryptAsync(encryptParameters, cancellationToken);
        return Convert.ToBase64String(result.Ciphertext);
    }

    public async Task<string> Decrypt(string ciphertext, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(ciphertext);
        var encryptedData = Convert.FromBase64String(ciphertext);
        var decryptParameters = DecryptParameters.RsaOaepParameters(encryptedData);
        var result = await cryptographyClient.DecryptAsync(decryptParameters, cancellationToken);
        return Encoding.UTF8.GetString(result.Plaintext);
    }
}
