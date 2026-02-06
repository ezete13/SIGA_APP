
using Microsoft.Extensions.Logging;
using SIGA.Application.Common.Interfaces;
using SIGA.Persistence;

namespace SIGA.Application.Features.Certificados.CrearCertificadoMasivo;

public class CrearCertificadoMasivoCommandHandler
    : IUseCaseHandler<CrearCertificadoMasivoCommand, CrearCertificadoMasivoResult>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CrearCertificadoMasivoCommandHandler> _logger;

    //>> Constructor
    public CrearCertificadoMasivoCommandHandler(
        ApplicationDbContext dbContext,
        ILogger<CrearCertificadoMasivoCommandHandler> logger
    )
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    //>> Handler
    public async Task<CrearCertificadoMasivoResult> Handle(
        CrearCertificadoMasivoCommand request,
        CancellationToken cancellationToken
    )
    {
        var resultados = new List<ResultadoCertificadoDto>();

        var propuesta = await _dbContext







        foreach (var alumno in request.Alumnos)
        {
            // 1. Crear inscripción simulada (temporal)
            var inscripcionId = await CrearInscripcionTemporal(alumno, request.PropuestaId);

            // 2. Crear certificado con estado "Generado" directamente
            var certificado = new Certificacion
            {
                InscripcionId = inscripcionId,
                TipoEstadoCertificadoId = 3, // "Generado" (saltamos Pendiente)
                FechaEmision = DateTime.Now,
                FechaFinalizacion = await ObtenerFechaFinPropuesta(request.PropuestaId),
                Metadata = new
                {
                    CreadoVia = "Excel Masivo",
                    NombreCompleto = $"{alumno.Apellido}, {alumno.Nombre}",
                    DNI = alumno.DNI,
                    PropuestaId = request.PropuestaId,
                },
                Version = 1,
                EsVersionActual = true,
            };

            await _certificadoRepo.AddAsync(certificado);
            resultados.Add(
                new
                {
                    Alumno = alumno,
                    CertificadoId = certificado.Id,
                    Success = true,
                }
            );
        }

        return new CertificadoMasivoResponse { Resultados = resultados };
    }
}

