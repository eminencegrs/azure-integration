using Microsoft.AspNetCore.Mvc;

namespace Seneca.Azure.Integration.Api;

[Route("api/[controller]")]
public class DirectoriesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateFolder()
    {
        // TODO: add implementation.

        return await Task.FromResult(new OkObjectResult("Not implemented yet"));
    }
}
