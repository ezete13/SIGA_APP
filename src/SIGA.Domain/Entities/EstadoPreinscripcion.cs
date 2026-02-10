namespace SIGA.Domain.Entities;

public partial class EstadoPreinscripcion
{
    public int Id { get; set; }

    public required string Codigo { get; set; }

    public required string Nombre { get; set; }

    public string? Descripcion { get; set; }

    public bool Activo { get; set; } = true;

    public virtual ICollection<Preinscripcion> Preinscripciones { get; set; } =
        new List<Preinscripcion>();
}
