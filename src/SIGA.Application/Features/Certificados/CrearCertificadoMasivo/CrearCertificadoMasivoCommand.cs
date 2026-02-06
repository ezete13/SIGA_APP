using SIGA.Application.Common.Interfaces;
using SIGA.Domain.Entities;

namespace SIGA.Application.Features.Certificados.CrearCertificadoMasivo;

public record CrearCertificadoMasivoCommand : IUseCase<Certificado>
{
    public required int PropuestaId { get; set; }
    public required List<AlumnoExcelDto> Alumnos { get; set; }
    public required DateTime FechaFinalizacion { get; set; }
    public string MotivoCambio { get; set; } = "Carga masiva desde Csv";

    public int TipoEstadoCertificado { get; set; } = 3; // En la BD 3 es Generado

    // public int UsuarioId { get; set; }
}

public class AlumnoExcelDto
{
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string DNI { get; set; }
    public required string Email { get; set; }
}
