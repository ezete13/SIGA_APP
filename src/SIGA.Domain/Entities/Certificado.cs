namespace SIGA.Domain.Entities;

public partial class Certificado
{
    public int Id { get; set; }

    public required Guid Uuid { get; set; }

    public required string Token { get; set; }

    public required int InscripcionId { get; set; }

    public required int AlumnoId { get; set; }

    public required int TipoEstadoCertificadoId { get; set; }

    public int Version { get; set; } = 1;

    public bool EsVersionActual { get; set; } = true;

    public required string HashSeguridad { get; set; }

    public required string TituloCertificado { get; set; }

    public string? TextoCertificado { get; set; }

    public required int HorasCertificadas { get; set; }

    public string? NotaFinal { get; set; }

    public required DateOnly FechaInicio { get; set; }

    public required DateOnly FechaFinalizacion { get; set; }

    public required DateOnly FechaEmision { get; set; }

    public int? UsuarioEmisionId { get; set; }

    public DateTime? FechaValidacion { get; set; }

    public string? IpValidacion { get; set; }

    public string? UrlVerificacion { get; set; }

    public string? RutaAlmacenamientoPdf { get; set; }

    public DateTime? FechaRevocacion { get; set; }

    public string? MotivoRevocacion { get; set; }

    public bool Estado { get; set; } = true;

    public DateTime CreadoEn { get; set; } = DateTime.UtcNow;

    public DateTime? ActualizadoEn { get; set; }

    public virtual required Alumno Alumno { get; set; }

    public virtual required Inscripcion Inscripcion { get; set; }

    public virtual required EstadoCertificado EstadoCertificado { get; set; }

    public virtual ICollection<CertificadoHistorial> CertificadoHistorial { get; set; } =
        new List<CertificadoHistorial>();

    public virtual ICollection<CertificadoAutoridad> Autoridades { get; set; } =
        new List<CertificadoAutoridad>();
}
