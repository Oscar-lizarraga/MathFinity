using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MathFinity.API;

[ApiController]
[Route("api/[controller]")]
public class ProspectController: ControllerBase
{
    [HttpGet]
    public IActionResult GetAllBranch()
    {
        return Ok();
    }
    
    [HttpPost]
    public IActionResult PostBranch()
    {
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteBranch()
    {
        return Ok();
    }

    [HttpPut]
    public IActionResult PutBranch()
    {
        return Ok();
    }
}
