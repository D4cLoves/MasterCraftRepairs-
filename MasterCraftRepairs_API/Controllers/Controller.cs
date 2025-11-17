using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MasterCraftRepairs_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Controller
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            message = "БЕК ЖИВ!", 
            time = DateTime.UtcNow
        });
    }       
    
}