using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Seneca.Azure.Integration.DataLake.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataLake(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddSettings(configuration);
        services.AddAzureClients(clientBuilder =>
        {
            clientBuilder.AddDataLakeServiceClient(configuration.GetSection(DataLakeSettings.SectionName));
        });

        services.AddScoped<IStorageService, StorageService>();

        return services;
    }

    private static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DataLakeSettings>(configuration.GetSection(DataLakeSettings.SectionName));

        return services;
    }
}
