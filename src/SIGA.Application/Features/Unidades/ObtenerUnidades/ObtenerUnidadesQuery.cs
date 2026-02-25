using SIGA.Application.Common.Dispatcher.Interfaces;
using SIGA.Domain.Entities.Catalog.Dynamic;

namespace SIGA.Application.Features.Unidades.ObtenerUnidades;

public record ObtenerUnidadesQuery() : IUseCase<List<Unidad>>;
