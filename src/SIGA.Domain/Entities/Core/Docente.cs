namespace SIGA.Domain.Entities.Core;

public partial class Docente
{
    public int Id { get; set; }

    public required string Nombre { get; set; }

    public required string Apellido { get; set; }

    public required string Dni { get; set; }

    public required string Profesion { get; set; }

    public required string Telefono { get; set; }

    public required string Email { get; set; }

    public string? Especialidad { get; set; }

    public string? Biografia { get; set; }

    public string? Linkedin { get; set; }

    public bool Estado { get; set; } = true;

    public DateTime? CreadoEn { get; set; } = DateTime.UtcNow;

    public DateTime? ActualizadoEn { get; set; }

    public virtual ICollection<PropuestaDocente> PropuestaDocentes { get; set; } =
        new List<PropuestaDocente>();
}
