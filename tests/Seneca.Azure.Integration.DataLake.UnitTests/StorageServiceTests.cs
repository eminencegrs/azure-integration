using Azure.Storage.Files.DataLake;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using Shouldly;
using Xunit;

namespace Seneca.Azure.Integration.DataLake.UnitTests;

public class StorageServiceTests
{
    [Fact]
    public void GivenNull_WhenCallCreateDirectory_ThenNotImplementedExceptionThrown()
    {
        var logger = new NullLogger<StorageService>();
        var settingsMock = new Mock<IOptions<DataLakeSettings>>();
        var clientMock = new Mock<DataLakeServiceClient>();
        var sut = new StorageService(logger, settingsMock.Object, clientMock.Object);
        var action = () => sut.CreateDirectory(default!);
        action.ShouldThrow<NotImplementedException>();
    }

    [Fact]
    public void GivenNull_WhenCallGenerateToken_ThenNotImplementedExceptionThrown()
    {
        var logger = new NullLogger<StorageService>();
        var settingsMock = new Mock<IOptions<DataLakeSettings>>();
        var clientMock = new Mock<DataLakeServiceClient>();
        var sut = new StorageService(logger, settingsMock.Object, clientMock.Object);
        var action = () => sut.GenerateToken(default!);
        action.ShouldThrow<NotImplementedException>();
    }
}
