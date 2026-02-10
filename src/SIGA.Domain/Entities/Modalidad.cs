namespace SIGA.Domain.Entities;

public partial class Modalidad
{
    public int Id { get; set; }

    public required string Codigo { get; set; }

    public required string Nombre { get; set; }

    public required string? Descripcion { get; set; }

    public bool Activo { get; set; } = true;

    public virtual ICollection<Propuesta> Propuestas { get; set; } = new List<Propuesta>();
}
