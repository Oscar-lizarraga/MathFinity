using MathFinity.DAL;
using Microsoft.AspNetCore.Mvc;

namespace MathFinity.API;


[ApiController]
[Route("api/[Controller]")]
public class Employee : ControllerBase
{
    [HttpPut]
    public async Task<IActionResult> PutEmployeeAsync()
    {
        try
        {
            List<MathFinity.BOL.Employee> employees = await DALEmployee.EmployeeGetAllAsync();
            return Ok(employees);
        }
        catch (System.Exception)
        {
            return StatusCode(500, "Bad Request");
        }
    }

    // [HttpGet] 
    // public async Task<IActionResult> GetAllEmployeesAsync()
    // {
    //     return Ok();
    // }


    // [HttpDelete]
    // public async Task<IActionResult> DeleteEmployee()
    // {
    //     return Ok();
    // }

}
