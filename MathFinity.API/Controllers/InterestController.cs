using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MathFinity.DAL;
using MathFinity.BOL;

namespace MathFinity.API;

[ApiController]
[Route("api/[Controller]")]
public class InterestController: ControllerBase
{
    [HttpGet] 
    public async Task<IActionResult> GetAllInterestAsync()
    {
        try 
        {
            return Ok(await DALInterest.GetAllInterestAsync());
        }
        catch(System.Exception ex)
        {
            return StatusCode(500, $"Error al obtener los datos de los empledos {ex.Message}");
        }
    }
}
