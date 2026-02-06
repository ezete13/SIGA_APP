using SIGA.Application.Common.Interfaces;

namespace SIGA.Application.Features.Unidades.CrearUnidad;

public record CrearUnidadCommand(
    string Codigo,
    string Nombre,
    string NombreCorto,
    string Siglas,
    int SedeId,
    string? ColorPrincipal = null,
    string? ColorSecundario = null,
    string? Direccion = null,
    string? Telefono = null,
    string? Email = null
) : IUseCase<int>; // Devuelve el ID de la unidad creada
