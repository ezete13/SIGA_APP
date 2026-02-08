namespace SIGA.Domain.Entities;

public partial class PeriodoLectivo
{
    public int Id { get; set; }

    public required string Codigo { get; set; }

    public required string Nombre { get; set; }

    public required string? Descripcion { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public bool Estado { get; set; } = true;

    public virtual ICollection<Autoridad> Autoridades { get; set; } = new List<Autoridad>();

    public virtual ICollection<Propuesta> Propuestas { get; set; } = new List<Propuesta>();
}
