namespace Seneca.Azure.Integration.KeyVault;

public record class KeyVaultSettings
{
    public static readonly string SectionName = "Azure:KeyVault";

    public string VaultUri { get; init; } = null!;

    public string KeyId { get; init; } = null!;
}
