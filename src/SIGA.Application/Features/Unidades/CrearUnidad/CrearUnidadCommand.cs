using SIGA.Application.Common;
using SIGA.Application.Common.Dispatcher.Interfaces;
using SIGA.Domain.Entities.Catalog.Dynamic;

namespace SIGA.Application.Features.Unidades.CrearUnidad;

public record CrearUnidadCommand(
    string Codigo,
    string Nombre,
    string? Descripcion,
    string NombreCorto,
    string Siglas,
    string? ColorPrincipal,
    string? ColorSecundario,
    string? Direccion,
    string? Telefono,
    string? Email
) : IUseCase<AppResult<Unidad>>;
