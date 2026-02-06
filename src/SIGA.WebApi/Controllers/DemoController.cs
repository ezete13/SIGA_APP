using Microsoft.AspNetCore.Mvc;

namespace SIGA.WebApi.Controllers;

[ApiController]
[Route("demo")]
public class DemoController : ControllerBase
{
    [HttpGet("nombre")]
    public string GetNombre()
    {
        return "Ezequiel";
    }
}
