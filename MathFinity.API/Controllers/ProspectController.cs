using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MathFinity.DAL;
using MathFinity.BOL;   
using Microsoft.AspNetCore.Authorization;


namespace MathFinity.API;

[ApiController]
[Route("api/[controller]")]
public class ProspectController: ControllerBase
{
    [HttpGet, Authorize] 
    public async Task<IActionResult> GetAllProspectsAsync()
    {
        try 
        {
            return Ok(await DALProspect.GetAllProspectAsync());
        }
        catch(System.Exception ex)
        {
            return StatusCode(500, $"Error al obtener los datos de los empledos {ex.Message}");
        }
    }

    [HttpGet("{id:int}")] 
    public async Task<IActionResult> GetProspectById(int id)
    {
        try 
        {
            return Ok(await DALProspect.GetByIdProspectAsync(id));
        }
        catch(System.Exception ex)
        {
            return StatusCode(500, $"Error al obtener los datos de los empledos {ex.Message}");

        }
    }

    [HttpPost]
    public async Task<IActionResult> ProspectPostAsync(BOL.Prospect prospect)
    {
        bool respuesta;
        try
        {
            respuesta = await DALProspect.InsertPropectAsync(prospect);
            return Ok(prospect);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al obtener los datos de la compañía: {ex.Message}");
        }
    }


}
