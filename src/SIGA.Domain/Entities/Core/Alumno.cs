using SIGA.Domain.Entities.Catalog.Static;
using SIGA.Domain.Enums;

namespace SIGA.Domain.Entities.Core;

public class Alumno
{
    public int Id { get; set; }
    public required Guid Uuid { get; set; } = Guid.NewGuid();
    public int TipoDocumentoId { get; set; }
    public int AlumnoEstadoId { get; set; }
    public required string NumDocumento { get; set; } = string.Empty;
    public required string Apellido { get; set; } = string.Empty;
    public required string Nombre { get; set; } = string.Empty;
    public required DateOnly FechaNacimiento { get; set; }
    public required string Email { get; set; }
    public string? Sexo { get; set; }
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

    // Regla: nacen activos al inscribirse
    public static Alumno Crear(
        int tipoDocumentoId,
        string numDocumento,
        string apellido,
        string nombre,
        DateOnly fechaNacimiento,
        string email
    )
    {
        return new Alumno
        {
            Uuid = Guid.NewGuid(),
            TipoDocumentoId = tipoDocumentoId,
            AlumnoEstadoId = (int)EstadoAlumnoEnum.Activo,
            NumDocumento = numDocumento,
            Apellido = apellido,
            Nombre = nombre,
            FechaNacimiento = fechaNacimiento,
            Email = email,
            Activo = true,
            CreadoEn = DateTime.UtcNow,
        };
    }

    // Regla: No se puede inscribir si está Bloqueado o Suspendido
    public bool PuedeInscribirse()
    {
        return AlumnoEstadoId == (int)EstadoAlumnoEnum.Activo
            || AlumnoEstadoId == (int)EstadoAlumnoEnum.Inactivo;
    }

    // Regla: Transición manual auditada para sanciones
    public void AplicarSancion(EstadoAlumnoEnum nuevoEstado, string motivo)
    {
        // Guardar motivo en alguna tabla de auditoría o campo de observaciones
        this.AlumnoEstadoId = (int)nuevoEstado;
        this.ActualizadoEn = DateTime.UtcNow;
    }

    // Regla: Cálculo automático de actividad
    public void ActualizarEstadoSegunInscripciones()
    {
        // Esta lógica suele dispararse cuando se cierra una inscripción
        // Si no hay inscripciones vigentes (estado != Finalizada/Baja), pasa a Inactivo
        // Pero OJO: Si está Bloqueado o Suspendido, el sistema NO debe cambiarlo solo.

        if (
            AlumnoEstadoId == (int)EstadoAlumnoEnum.Bloqueado
            || AlumnoEstadoId == (int)EstadoAlumnoEnum.Suspendido
        )
            return;

        bool tieneInscripcionesActivas = this.Inscripciones.Any(i => i.EsVigente()); // Método en Inscripcion

        this.AlumnoEstadoId = tieneInscripcionesActivas
            ? (int)EstadoAlumnoEnum.Activo
            : (int)EstadoAlumnoEnum.Inactivo;
    }
}
