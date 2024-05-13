using MathFinity.DAL;
using MathFinity.BOL;
using Microsoft.AspNetCore.Mvc;

namespace MathFinity.API;


[ApiController]
[Route("api/[Controller]")]
public class ATMController: ControllerBase
{
    [HttpGet] 
    public async Task<IActionResult> GetAllATMAsync()
    {
        try 
        {
            return Ok(await DALATM.GetAllATM());
        }
        catch(System.Exception ex)
        {
            return StatusCode(500, $"Error al obtener los datos de los empledos {ex.Message}");
        }
    }

    [HttpGet("{id:int}")] 
    public async Task<IActionResult> GetATMById(int id)
    {
        try 
        {
            return Ok(await DALATM.GetATMById(id));
        }
        catch(System.Exception ex)
        {
            return StatusCode(500, $"Error al obtener los datos de los empledos {ex.Message}");
        }
    }


    
    [HttpPost]
    public async Task<IActionResult> PostATMasync(BOL.ATM ATM)
    {
        bool respuesta;
        try
        {
            respuesta = await DALATM.InsertATMAsync(ATM);
            return Ok(respuesta);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al obtener los datos de la compañía: {ex.Message}");
        }
    }
    
}
