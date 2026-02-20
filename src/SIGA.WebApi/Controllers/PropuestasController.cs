using Microsoft.AspNetCore.Mvc;
using SIGA.Application.Common.Dispatcher.Interfaces;
using SIGA.Application.Features.Propuestas.CrearPropuestaBorrador;

namespace SIGA.WebApi.Controllers;

[ApiController]
[Route("api/propuestas")]
public class PropuestaController : ControllerBase
{
    private readonly IUseCaseDispatcher _dispatcher;

    public PropuestaController(IUseCaseDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost("crear-borrador")]
    public async Task<ActionResult<int>> CrearPropuestaBorrador(
        [FromBody] CrearPropuestaBorradorCommand request,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var resultado = await _dispatcher.Send<CrearPropuestaBorradorCommand, int>(
                request,
                cancellationToken
            );

            return Ok(
                new
                {
                    success = true,
                    message = "Propuesta creada exitosamente",
                    propuestaId = resultado,
                }
            );
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(
                500,
                new
                {
                    success = false,
                    message = "Error interno al crear la propuesta",
                    error = ex.Message,
                }
            );
        }
    }
}
