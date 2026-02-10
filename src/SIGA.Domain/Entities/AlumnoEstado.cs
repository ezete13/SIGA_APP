namespace SIGA.Domain.Entities;

public partial class AlumnoEstado
{
    public int Id { get; set; }

    public required string Codigo { get; set; }

    public required string Nombre { get; set; }

    public string? Descripcion { get; set; }

    public bool Activo { get; set; } = true;

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
}
