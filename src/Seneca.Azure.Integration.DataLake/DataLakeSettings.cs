namespace Seneca.Azure.Integration.DataLake;

public record class DataLakeSettings
{
    public static readonly string SectionName = "Azure:DataLake";
    public string AccountName { get; init; } = null!;
    public string ServiceUri { get; init; } = null!;
}
