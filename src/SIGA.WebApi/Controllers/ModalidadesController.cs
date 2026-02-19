using Microsoft.AspNetCore.Mvc;
using SIGA.Application.Common.Dispatcher.Interfaces;
using SIGA.Application.Features.Modalidades;
using SIGA.Application.Features.Modalidades.CrearModalidad;
using SIGA.Application.Features.Modalidades.ObtenerReporteCsv;
using SIGA.Domain.Entities.Catalog.Dynamic;

namespace SIGA.WebApi.Controllers;

[ApiController]
[Route("api/modalidades")]
public class ModalidadController : ControllerBase
{
    private readonly IUseCaseDispatcher _dispatcher;

    public ModalidadController(IUseCaseDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost("create")]
    public async Task<ActionResult<Modalidad>> CrearModalidad(
        [FromForm] CrearModalidadRequest request,
        CancellationToken cancellationToken
    )
    {
        // throw new Exception("Esta excepcion es forzada solo por prueba");
        var command = new CrearModalidadCommand(
            request.Codigo,
            request.Nombre,
            request.Descripcion
        );
        var resultado = await _dispatcher.Send<CrearModalidadCommand, Modalidad>(
            command,
            cancellationToken
        );

        return Ok(resultado);
    }

    [HttpGet("reporte_csv")]
    public async Task<IActionResult> ObtenerReporteCsv(CancellationToken cancellationToken)
    {
        var query = new ObtenerReporteCsvQuery();
        MemoryStream resultado = await _dispatcher.Send<ObtenerReporteCsvQuery, MemoryStream>(
            query,
            cancellationToken
        );

        return File(
            resultado.ToArray(),
            "text/csv",
            $"modalidades_{DateTime.UtcNow:yyyyMMdd_HHmmss}.csv"
        );
    }
}
