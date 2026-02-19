using SIGA.Domain;
using SIGA.Domain.Common;

namespace SIGA.Application.Interfaces;

public interface IReporteService<T>
    where T : EntityBase
{
    Task<MemoryStream> ObtenerReporteCsv(List<T> records);
}
