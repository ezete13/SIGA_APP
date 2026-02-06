using SIGA.Application.Common.Interfaces;

namespace SIGA.Application.Features.Unidades.ObtenerUnidades;

public record c(
    string Codigo,
    string Nombre,
    string NombreCorto,
    string Siglas,
    string? ColorPrincipal,
    string? ColorSecundario,
    string? Direccion,
    string? Telefono,
    string? Email,
    string? Sede
) : IUseCase<List<Unidades>>;
