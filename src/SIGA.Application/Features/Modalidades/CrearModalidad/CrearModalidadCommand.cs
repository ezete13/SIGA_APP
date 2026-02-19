using SIGA.Application.Common.Dispatcher.Interfaces;
using SIGA.Domain.Entities.Catalog.Dynamic;

namespace SIGA.Application.Features.Modalidades.CrearModalidad;

public record CrearModalidadCommand(string Codigo, string Nombre, string? Descripcion)
    : IUseCase<Modalidad>;
