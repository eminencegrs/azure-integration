using Azure.Storage.Files.DataLake;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Seneca.Azure.Integration.DataLake;

internal class StorageService
{
    private readonly ILogger<StorageService> logger;
    private readonly DataLakeSettings settings;
    private readonly DataLakeServiceClient serviceClient;

    public StorageService(
        ILogger<StorageService> logger,
        IOptions<DataLakeSettings> options,
        DataLakeServiceClient serviceClient)
    {
        this.logger = logger;
        this.settings = options.Value;
        this.serviceClient = serviceClient;
    }

    public Task CreateDirectory(string name)
    {
        throw new NotImplementedException();
    }

    public Task GenerateToken(string name)
    {
        throw new NotImplementedException();
    }

    public async Task UploadFile(string directoryName, string fileName, Stream stream)
    {
        throw new NotImplementedException();
    }
}
