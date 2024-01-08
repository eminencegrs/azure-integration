namespace Seneca.Azure.Integration.DataLake;

public class DataLakeSettings
{
    public static readonly string SectionName = "DataLakeSettings";
    public string AccountName { get; set; } = null!;
    public string AccountKey { get; set; } = null!;
}
