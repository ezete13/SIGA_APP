using SIGA.Application.Common.Interfaces;
using SIGA.Domain.Entities;

namespace SIGA.Application.Features.Modalidades.CrearModalidad;

public record CrearModalidadCommand(string Codigo, string Nombre, string? Descripcion)
    : IUseCase<Modalidades>;
