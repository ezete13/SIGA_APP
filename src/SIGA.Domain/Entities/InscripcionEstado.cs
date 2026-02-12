namespace SIGA.Domain.Entities;

public partial class InscripcionEstado
{
    public int Id { get; set; }

    public required string Codigo { get; set; }

    public required string Nombre { get; set; }

    public string? Descripcion { get; set; }

    public bool Activo { get; set; } = true;

    public virtual ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
}
