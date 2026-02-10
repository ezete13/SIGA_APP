namespace SIGA.Domain.Entities;

public partial class CertificadoHistorial
{
    public int Id { get; set; }

    public required int CertificadoId { get; set; }

    public required int CertificadoEstadoId { get; set; }

    public int? UsuarioId { get; set; }

    public DateTime Fecha { get; set; } = DateTime.UtcNow;

    public string? Observacion { get; set; }

    public string? Ip { get; set; }

    public virtual required Certificado Certificado { get; set; }

    public virtual required CertificadoEstado CertificadoEstado { get; set; }
}
