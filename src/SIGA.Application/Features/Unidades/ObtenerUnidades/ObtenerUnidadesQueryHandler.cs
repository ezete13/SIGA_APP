using Microsoft.EntityFrameworkCore;
using SIGA.Application.Common.Dispatcher.Interfaces;
using SIGA.Application.Features.Unidades.ObtenerUnidades;
using SIGA.Domain.Entities.Catalog.Dynamic;
using SIGA.Persistence;

namespace SIGA.Application.Features.Propuestas.CrearPropuestaBorrador;

public class ObtenerUnidadesQueryHandler : IUseCaseHandler<ObtenerUnidadesQuery, List<Unidad>>
{
    private readonly ApplicationDbContext _dbContext;

    public ObtenerUnidadesQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Unidad>> Handle(
        ObtenerUnidadesQuery request,
        CancellationToken cancellationToken
    )
    {
        return await _dbContext.Unidades.Where(u => u.Activo).ToListAsync(cancellationToken);
    }
}
