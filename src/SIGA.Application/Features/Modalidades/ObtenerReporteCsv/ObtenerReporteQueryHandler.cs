using Microsoft.EntityFrameworkCore;
using SIGA.Application.Common.Dispatcher.Interfaces;
using SIGA.Application.Interfaces;
using SIGA.Domain.Entities.Catalog.Dynamic;
using SIGA.Persistence;

namespace SIGA.Application.Features.Modalidades.ObtenerReporteCsv;

public class ObtenerReporteQueryHandler : IUseCaseHandler<ObtenerReporteCsvQuery, MemoryStream>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IReporteService<Modalidad> _reporteService;

    public ObtenerReporteQueryHandler(
        ApplicationDbContext dbContext,
        IReporteService<Modalidad> reporteService
    )
    {
        _dbContext = dbContext;
        _reporteService = reporteService;
    }

    public async Task<MemoryStream> Handle(
        ObtenerReporteCsvQuery request,
        CancellationToken cancellationToken
    )
    {
        var modalidades = await _dbContext.Modalidades!.Take(10).Skip(0).ToListAsync();

        return await _reporteService.ObtenerReporteCsv(modalidades);
    }
}
