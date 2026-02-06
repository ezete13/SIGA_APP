namespace SIGA.Domain.Entities;

public partial class CertificadoHistorial
{
    public required int CertificacionId { get; set; }

    public required int EstadoCertificadoId { get; set; }

    public required int UsuarioId { get; set; }

    public required DateTime CreadoEn { get; set; } = DateTime.UtcNow;

    public virtual required Certificado Certificado { get; set; }

    public virtual required EstadoCertificado EstadoCertificado { get; set; }

    public virtual required Usuarios Usuario { get; set; }
}
