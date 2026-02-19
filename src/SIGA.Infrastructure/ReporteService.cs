using System.Globalization;
using CsvHelper;
using SIGA.Application.Interfaces;
using SIGA.Domain.Common;

namespace SIGA.Infrastructure;

public class ReporteService<T> : IReporteService<T>
    where T : EntityBase
{
    public Task<MemoryStream> ObtenerReporteCsv(List<T> records)
    {
        using var memoryStream = new MemoryStream();
        using var textWriter = new StreamWriter(memoryStream);
        using var csvWriter = new CsvWriter(textWriter, CultureInfo.InvariantCulture);

        csvWriter.WriteRecords(records);
        textWriter.Flush();
        memoryStream.Seek(0, SeekOrigin.Begin);

        return Task.FromResult(memoryStream);
    }
}
