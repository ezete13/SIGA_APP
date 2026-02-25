using Microsoft.AspNetCore.Mvc;
using SIGA.Application.Common.Dispatcher.Interfaces;
using SIGA.Application.Features.Unidades.ObtenerUnidades;
using SIGA.Domain.Entities.Catalog.Dynamic;

namespace SIGA.WebApi.Controllers;

[ApiController]
[Route("api/unidades")]
public class UnidadController : ControllerBase
{
    private readonly IUseCaseDispatcher _dispatcher;

    public UnidadController(IUseCaseDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    // GET /api/unidades
    // GET /api/unidades/lookup
    // GET /api/unidades/{id}

    [HttpGet("obtener-unidades")]
    public async Task<IActionResult> ObtenerUnidades(CancellationToken cancellationToken)
    {
        var query = new ObtenerUnidadesQuery();
        var unidades = await _dispatcher.Send<ObtenerUnidadesQuery, List<Unidad>>(
            query,
            cancellationToken
        );

        return Ok(unidades);
    }
}
