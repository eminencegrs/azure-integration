using Microsoft.AspNetCore.Mvc;
using Seneca.Azure.Integration.DataLake;

namespace Seneca.Azure.Integration.Api;

[Route("api/[controller]")]
public class FoldersController : ControllerBase
{
    private readonly DataLakeService service;

    public FoldersController(DataLakeService service)
    {
        this.service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFolder([FromQuery] string folderName)
    {
        var result = await this.service.CreateDirectoryWithSas(folderName);
        return Ok($"{result.sasUri}");
    }
}
