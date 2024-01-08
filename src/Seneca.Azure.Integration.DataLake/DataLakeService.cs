using System;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Files.DataLake;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Sas;
using Microsoft.Extensions.Options;

namespace Seneca.Azure.Integration.DataLake;

public class DataLakeService
{
    private const string FileSystemDefaultName = "default-file-system";
    
    private readonly DataLakeServiceClient serviceClient;
    private readonly DataLakeSettings settings;
    
    public DataLakeService(IOptions<DataLakeSettings> options)
    {
        this.settings = options.Value;
        var credential = new StorageSharedKeyCredential(this.settings.AccountName, this.settings.AccountKey);
        var serviceUri = new Uri($"https://{this.settings.AccountName}.dfs.core.windows.net");
        this.serviceClient = new DataLakeServiceClient(serviceUri, credential);
    }

    public async Task<(DataLakeDirectoryClient directoryClient, Uri sasUri)> CreateDirectoryWithSas(
        string directoryName,
        string policyName = "mySasPolicy")
    {
        var fileSystemClient = this.serviceClient.GetFileSystemClient(FileSystemDefaultName);
        await fileSystemClient.CreateIfNotExistsAsync();
        
        var directoryClientResponse = await fileSystemClient.CreateDirectoryAsync(directoryName);
        var directoryClient = directoryClientResponse.HasValue
            ? directoryClientResponse.Value
            : throw new InvalidOperationException();

        var sasBuilder = new DataLakeSasBuilder
        {
            FileSystemName = fileSystemClient.Name,
            Path = directoryClient.Path,
            // TODO: move to the settings.
            ExpiresOn = DateTimeOffset.UtcNow.AddDays(1),
            Protocol = SasProtocol.Https,
            // TODO: move to the settings?
            Resource = "d", // 'd' for directory
            StartsOn = DateTimeOffset.UtcNow,
        };

        // TODO: manage permissions properly.
        sasBuilder.SetPermissions(DataLakeSasPermissions.Read | DataLakeSasPermissions.Write);

        var sasToken = sasBuilder
            .ToSasQueryParameters(new StorageSharedKeyCredential(this.settings.AccountName, this.settings.AccountKey))
            .ToString();

        var sasUri = new Uri($"{directoryClient.Uri}?{sasToken}");

        return (directoryClient, sasUri);
    }
}
