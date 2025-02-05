using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthCookieApi.Controller;

[ApiController]
[Route("api/data")]
public class DataController : ControllerBase
{
    [HttpGet]
    [Authorize] 
    public IActionResult GetData()
    {
        return Ok(new { message = "This is protected data!" });
    }
}