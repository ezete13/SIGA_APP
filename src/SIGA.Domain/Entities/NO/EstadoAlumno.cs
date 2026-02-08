namespace SIGA.Domain.Entities;

public partial class EstadoAlumno
{
    public int Id { get; set; }

    public required string Codigo { get; set; }

    public required string Nombre { get; set; }

    public string? Descripcion { get; set; }

    public bool Estado { get; set; } = true;

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
}
