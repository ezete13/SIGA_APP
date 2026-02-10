namespace SIGA.Domain.Entities;

public partial class Autoridad
{
    public int Id { get; set; }

    public required int UnidadId { get; set; }

    public required int PeriodoLectivoId { get; set; }

    public required string Cargo { get; set; }

    public required string Nombre { get; set; }

    public required string FirmaImg { get; set; }

    public required bool Estado { get; set; } = true;

    public required DateTime? CreadoEn { get; set; }

    public required DateTime? ActualizadoEn { get; set; }

    public virtual required PeriodoLectivo PeriodoLectivo { get; set; }

    public virtual required Unidad Unidad { get; set; }

    public virtual ICollection<CertificadoAutoridad> CertificadoAutoridades { get; set; } =
        new List<CertificadoAutoridad>();
}
