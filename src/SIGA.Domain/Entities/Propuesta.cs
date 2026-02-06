namespace SIGA.Domain.Entities;

public partial class Propuesta
{
    public int Id { get; set; }

    public int UnidadId { get; set; }

    public int ModalidadId { get; set; }

    public int TipoPropuestaId { get; set; }

    public int PeriodoLectivoId { get; set; }

    public int EstadoPropuestaId { get; set; }

    public int UsuarioId { get; set; }

    public required string Titulo { get; set; }

    public int Anio { get; set; }

    public int? Edicion { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public int MaximoAlumnos { get; set; }

    public int CuposDisponibles { get; set; }

    public int? CantidadHoras { get; set; }

    public decimal? ImporteBase { get; set; }

    public int? Cuotas { get; set; }

    public string? ConceptoPago { get; set; }

    public string required EmailEncargado { get; set; }

    public string? PlanEstudioPdf { get; set; }

    public string? LugarRealizacion { get; set; }

    public bool? Estado { get; set; }

    public string? ContactoInfo { get; set; }

    public string? PagosInfo { get; set; }

    public bool WebVisible { get; set; }

    public bool PermiteInscripcionesWeb { get; set; }

    public DateTime? CreadoEn { get; set; }

    public DateTime? ActualizadoEn { get; set; }

    public virtual required Modalidad Modalidad { get; set; }

    public virtual required PeriodoLectivo PeriodoLectivo { get; set; }

    public virtual required Unidad Unidad { get; set; }

    public virtual required TipoPropuesta TipoPropuesta { get; set; }

    public virtual required EstadoPropuesta EstadoPropuesta { get; set; }

    public virtual required Usuario Usuario { get; set; }

    public virtual PropuestaWeb? PropuestaWeb { get; set; }

    public virtual ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();

    public virtual ICollection<PropuestaDocente> PropuestaDocentes { get; set; } =
        new List<PropuestaDocente>();

    public virtual ICollection<PropuestaContenido> PropuestaContenidos { get; set; } =
        new List<PropuestaContenido>();

    public virtual ICollection<PropuestaHistorial> HistorialPropuesta { get; set; } =
        new List<PropuestaHistorial>();
}
