namespace SIGA.Domain.Entities;

public class Preinscripcion
{
    public int Id { get; set; }

    public required Guid Uuid { get; set; } = Guid.NewGuid();

    public int? AlumnoId { get; set; }

    public required int PropuestaId { get; set; }

    public required int EstadoPreinscripcionId { get; set; }

    public required string Documento { get; set; }

    public required string Apellido { get; set; }

    public required string Nombre { get; set; }

    public required string Email { get; set; }

    public string? Telefono { get; set; }

    public string? Observaciones { get; set; }

    public DateTime CreadoEn { get; set; } = DateTime.UtcNow;

    public DateTime? ActualizadoEn { get; set; }

    public virtual required Propuesta Propuesta { get; set; }

    public virtual required EstadoPreinscripcion EstadoPreinscripcion { get; set; }

    public virtual Alumno? Alumno { get; set; }
}
