using Microsoft.AspNetCore.Mvc;
using Seneca.Azure.Integration.DataLake;
using Swashbuckle.AspNetCore.Annotations;

namespace Seneca.Azure.Integration.Api;

[ApiController]
[Route("api/[controller]/{name}")]
public class DirectoriesController : ControllerBase
{
    private readonly IStorageService storageService;

    public DirectoriesController(IStorageService storageService)
    {
        this.storageService = storageService;
    }

    [HttpPut]
    public async Task<IActionResult> CreateDirectory(string name)
    {
        // TODO: add implementation.
        return await Task.FromResult(new OkObjectResult("Not implemented yet"));
    }

    [HttpPut("link")]
    public async Task<IActionResult> GenerateToken(string name)
    {
        // TODO: add implementation.
        return await Task.FromResult(new OkObjectResult("Not implemented yet"));
    }
}
