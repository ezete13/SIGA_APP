namespace SIGA.Domain.Entities;

public class Inscripcion
{
    public int Id { get; set; }

    public required Guid Uuid { get; set; } = Guid.NewGuid();

    public required int AlumnoId { get; set; }

    public required int PropuestaId { get; set; }

    public required int InscripcionEstadoId { get; set; }

    public int? PreinscripcionId { get; set; }

    public required DateTime FechaInscripcion { get; set; }

    public bool EsBaja { get; set; } = false;

    public DateTime? FechaBaja { get; set; }

    public string? MotivoBaja { get; set; }

    public DateTime CreadoEn { get; set; } = DateTime.UtcNow;

    public DateTime? ActualizadoEn { get; set; }

    public virtual required Alumno Alumno { get; set; }

    public virtual required Propuesta Propuesta { get; set; }

    public virtual required EstadoInscripcion InscripcionEstado { get; set; }

    public virtual Preinscripcion? Preinscripcion { get; set; }
}
