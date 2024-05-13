using MathFinity.DAL;
using Microsoft.AspNetCore.Mvc;

namespace MathFinity.API;


[ApiController]
[Route("api/[Controller]")]
public class Employee : ControllerBase
{
    // [HttpPut]
    // public async Task<IActionResult> PutEmployeeAsync()
    // {
    //     try
    //     {
    //         List<MathFinity.BOL.Employee> employees = await DALEmployee.GetAllEmployessAsync();
    //         return Ok(employees);
    //     }
    //     catch (System.Exception)
    //     {
    //         return StatusCode(500, "Bad Request");
    //     }
    // }

    [HttpGet] 
    public async Task<IActionResult> GetAllEmployeesAsync()
    {
        try 
        {
            return Ok(await DALEmployee.GetAllEmployessAsync());
        }
        catch(System.Exception ex)
        {
            return StatusCode(500, $"Error al obtener los datos de los empledos {ex.Message}");

        }
    }

    [HttpGet("{id:int}")] 
    public async Task<IActionResult> GetEmployeesById(int id)
    {
        try 
        {
            return Ok(await DALEmployee.GetEmployeeByIdAsync(id));
        }
        catch(System.Exception ex)
        {
            return StatusCode(500, $"Error al obtener los datos de los empledos {ex.Message}");

        }
    }

}
