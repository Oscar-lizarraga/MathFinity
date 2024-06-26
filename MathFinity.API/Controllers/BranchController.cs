﻿using MathFinity.DAL;
using MathFinity.BOL;
using Microsoft.AspNetCore.Mvc;

namespace MathFinity.API;


[ApiController]
[Route("api/[Controller]")]
public class BranchController: ControllerBase
{

    [HttpGet] 
    public async Task<IActionResult> GetAllBranchsAsync()
    {
        try 
        {
            return Ok(await DALBranch.GetAllBranchAsync());
        }
        catch(System.Exception ex)
        {
            return StatusCode(500, $"Error al obtener los datos de los empledos {ex.Message}");

        }
    }


    [HttpGet("{id:int}")] 
    public async Task<IActionResult> GetAllBranchByIdAsync(int id)
    {
        try 
        {
            return Ok(await DALBranch.GetBranchByIdAsync(id));
        }
        catch(System.Exception ex)
        {
            return StatusCode(500, $"Error al obtener los datos de los empledos {ex.Message}");

        }
    }

    [HttpPost]
    public async Task<IActionResult> PostBranchAsync(BOL.Branch branch)
    {
        bool respuesta;
        try
        {
            respuesta = await DALBranch.InsertBranchAsync(branch);
            return Ok(branch);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al obtener los datos de la compañía: {ex.Message}");
        }
    }
}
