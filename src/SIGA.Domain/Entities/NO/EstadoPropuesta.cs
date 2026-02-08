namespace SIGA.Domain.Entities;

public partial class EstadoPropuesta
{
    public int Id { get; set; }

    public required string Codigo { get; set; }

    public required string Nombre { get; set; }

    public string? Descripcion { get; set; }

    public bool Estado { get; set; } = true;

    public virtual ICollection<Propuesta> Propuestas { get; set; } = new List<Propuesta>();
}
