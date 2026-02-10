namespace SIGA.Domain.Entities;

public class Alumno
{
    public int Id { get; set; }
    public Guid Uuid { get; set; } = Guid.NewGuid();
    public int TipoDocumentoId { get; set; }
    public int AlumnoEstadoId { get; set; }
    public string NumDocumento { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public DateOnly? FechaNacimiento { get; set; }
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
    public string? EsSocio { get; set; } // S/N
    public bool Activo { get; set; } = true;
    public DateTime CreadoEn { get; set; } = DateTime.UtcNow;
    public DateTime? ActualizadoEn { get; set; }
    public virtual TipoDocumento TipoDocumento { get; set; } = null!;
    public virtual AlumnoEstado AlumnoEstado { get; set; } = null!;
    public virtual ICollection<Certificado> Certificados { get; set; } = new List<Certificado>();
    public virtual ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
    public virtual ICollection<Preinscripcion> Preinscripciones { get; set; } =
        new List<Preinscripcion>();
}
