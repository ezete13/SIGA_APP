using Microsoft.AspNetCore.Mvc;
using SIGA.Application.Common.Dispatcher.Interfaces;
using SIGA.Application.Features.Preinscripciones.CrearPreinscripcionPendiente;

namespace SIGA.WebApi.Controllers;

[ApiController]
[Route("api/preinscripciones")]
public class PreinscripcionController : ControllerBase
{
    private readonly IUseCaseDispatcher _dispatcher;

    public PreinscripcionController(IUseCaseDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost("create")]
    public async Task<ActionResult<Guid>> CrearModalidad(
        [FromForm] CrearPreinscripcionPendienteCommand request,
        CancellationToken cancellationToken
    )
    {
        // throw new Exception("Esta excepcion es forzada solo por prueba");
        var command = new CrearPreinscripcionPendienteCommand(
            request.PropuestaId,
            request.TipoDocumentoId,
            request.Documento,
            request.Apellido,
            request.Nombre,
            request.Email
        );
        var resultado = await _dispatcher.Send<CrearPreinscripcionPendienteCommand, Guid>(
            command,
            cancellationToken
        );

        return Ok(resultado);
    }
}
