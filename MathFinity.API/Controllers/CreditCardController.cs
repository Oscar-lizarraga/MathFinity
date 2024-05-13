using Microsoft.AspNetCore.Mvc;
using MathFinity.BOL;
using MathFinity.DAL;

namespace MathFinity.API;

[ApiController]
[Route("api/[controller]")]
public class CreditCardController : ControllerBase
{
    [HttpGet] 
    public async Task<IActionResult> GetAllCreditCardsAsync()
    {
        try 
        {
            return Ok(await DALCreditCard.CreditCardGetAllAsync());
        }
        catch(System.Exception ex)
        {
            return StatusCode(500, $"Error al obtener los datos de los empledos {ex.Message}");
        }
    }

    [HttpGet("{id}")] 
    public async Task<IActionResult> GetByIdCreditCardAsync(string id)
    {
        try 
        {
            return Ok(await DALCreditCard.CreditCardGetByIdAsync(id));
        }
        catch(System.Exception ex)
        {
            return StatusCode(500, $"Error al obtener los datos de los empledos {ex.Message}");
        }
    }
}
