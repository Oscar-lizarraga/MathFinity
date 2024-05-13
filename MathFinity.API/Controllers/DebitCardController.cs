using MathFinity.BOL;
using MathFinity.DAL;
using Microsoft.AspNetCore.Mvc;

namespace MathFinity.API;

[ApiController]
[Route("api/[Controller]")]
public class DebitCardController: ControllerBase
{


    [HttpGet("{cardNumber}/{NIP}")] 
    public async Task<IActionResult> GetDebitCardLogInAsync(string cardNumber, string NIP)
    {
        try 
        {
            BOL.DebitCard card = new BOL.DebitCard();
            card.NIP = NIP;
            card.cardNumber = cardNumber;
            return Ok(await DALDebitCard.DebitCardLogInAsync(card));
        }
        catch(System.Exception ex)
        {
            return StatusCode(500, $"Error al obtener los datos de los empledos {ex.Message}");
        }
    }

    [HttpGet("test/{cardNumber}/{NIP}")] 
    public async Task<IActionResult> GetDebitCardLogInTestAsync(string cardNumber, string NIP)
    {
        try 
        {
            BOL.DebitCard card = new BOL.DebitCard();
            card.NIP = NIP;
            card.cardNumber = cardNumber;
            return Ok(await DALDebitCard.DebitCardLogInAsyncTest(card));
        }
        catch(System.Exception ex)
        {
            return StatusCode(500, $"Error al obtener los datos de los empledos {ex.Message}");
        }
    }
}