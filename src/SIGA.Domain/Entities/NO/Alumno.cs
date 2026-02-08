namespace SIGA.Domain.Entities;

public class Alumno
{
    public int Id { get; set; }

    public required Guid Uuid { get; set; } = Guid.NewGuid();

    public required int TipoDocumentoId { get; set; }

    public virtual required TipoDocumento TipoDocumento { get; set; }

    public required int EstadoAlumnoId { get; set; }

    public virtual required EstadoAlumno EstadoAlumno { get; set; }

    public required string NumDocumento { get; set; }

    public required string Apellido { get; set; }

    public required string Nombre { get; set; }

    public required DateOnly? FechaNacimiento { get; set; }

    public string? Sexo { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? Domicilio { get; set; }

    public string? CodigoPostal { get; set; }

    public string? Ciudad { get; set; }

    public string? Provincia { get; set; }

    public string? Pais { get; set; }

    public string? CiudadNacimiento { get; set; }

    public string? Colegio { get; set; }

    public string? Profesion { get; set; }

    public string? LugarTrabajo { get; set; }

    public string? NumeroSocio { get; set; }

    public string? EsSocio { get; set; }

    public bool Estado { get; set; } = true;

    public DateTime CreadoEn { get; set; } = DateTime.UtcNow;

    public DateTime? ActualizadoEn { get; set; }

    public virtual ICollection<Certificado> Certificados { get; set; } = new List<Certificado>();

    public virtual ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();

    public virtual ICollection<Preinscripcion> Preinscripciones { get; set; } =
        new List<Preinscripcion>();
}
