namespace SIGA.Domain.Entities;

public partial class CertificadoAutoridad
{
    public int Id { get; set; }

    public required int CertificacionId { get; set; }

    public required int AutoridadId { get; set; }

    public int? Orden { get; set; }

    public DateTime? CreadoEn { get; set; }

    public virtual required Autoridad Autoridad { get; set; }

    public virtual required Certificado Certificado { get; set; }
}
