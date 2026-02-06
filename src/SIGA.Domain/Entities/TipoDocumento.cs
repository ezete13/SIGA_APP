namespace SIGA.Domain.Entities;

public partial class TipoDocumento
{
    public int Id { get; set; }

    public required string Nombre { get; set; }

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();

    public virtual ICollection<Preinscripcion> Preinscripciones { get; set; } =
        new List<Preinscripcion>();
}
