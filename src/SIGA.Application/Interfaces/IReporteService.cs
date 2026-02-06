using SIGA.Domain;

namespace SIGA.Application.Interfaces;

public interface IReporteService<T>
    where T : BaseEntity
{
    Task<MemoryStream> ObtenerReporteCsv(List<T> records);
}
