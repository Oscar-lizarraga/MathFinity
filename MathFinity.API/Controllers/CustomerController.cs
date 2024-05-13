using MathFinity.BOL;
using MathFinity.DAL;
using Microsoft.AspNetCore.Mvc;

namespace MathFinity.API;

[ApiController]
[Route("api/[Controller]")]
public class CustomerController: ControllerBase
{
    [HttpGet] 
    public async Task<IActionResult> GetAllCustomersAsync()
    {
        try 
        {
            return Ok(await DALCustomer.CustomerGetAllAsync());
        }
        catch(System.Exception ex)
        {
            return StatusCode(500, $"Error al obtener los datos de los empledos {ex.Message}");

        }
    }

    [HttpGet("{id}")] 
    public async Task<IActionResult> GetAllCustomersAsync(string id)
    {
        try 
        {
            return Ok(await DALCustomer.CustomerGetByIdAsync(id));
        }
        catch(System.Exception ex)
        {
            return StatusCode(500, $"Error al obtener los datos de los empledos {ex.Message}");
        }
    }

    [HttpPut] 
    public async Task<IActionResult> UpdateCustomerAsync(BOL.Customer customer)
    {
        try 
        {
            if( await DALCustomer.EditCustomerAsync(customer))
                return StatusCode(200, "Editado con exito");
            else
                return StatusCode(500,"No se edito con exito");
        }
        catch(System.Exception ex)
        {
            return StatusCode(500, $"Error al obtener los datos de los empledos {ex.Message}");
        }
    }

    


}
