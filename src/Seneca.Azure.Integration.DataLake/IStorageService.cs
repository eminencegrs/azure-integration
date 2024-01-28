namespace Seneca.Azure.Integration.DataLake;

public interface IStorageService
{
    Task CreateDirectory(string name);
    Task GenerateToken(string name);
}
