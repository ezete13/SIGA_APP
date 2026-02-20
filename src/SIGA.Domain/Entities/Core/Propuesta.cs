using SIGA.Domain.Entities.Catalog.Dynamic;
using SIGA.Domain.Entities.Catalog.Static;
using SIGA.Domain.Exceptions;

namespace SIGA.Domain.Entities.Core;

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

    public int CantidadHoras { get; set; }

    public decimal? ImporteBase { get; set; }

    public int? Cuotas { get; set; }

    public string? ConceptoPago { get; set; }

    public string? EmailEncargado { get; set; }

    public string? PlanEstudioPdf { get; set; }

    public string? LugarRealizacion { get; set; }

    public bool? Estado { get; set; }

    public string? ContactoInfo { get; set; }

    public string? PagosInfo { get; set; }

    public bool WebVisible { get; set; }

    public bool PermiteInscripcionesWeb { get; set; }

    public DateTime? CreadoEn { get; set; }

    public DateTime? ActualizadoEn { get; set; }

    public virtual Modalidad Modalidad { get; set; } = null!;

    public virtual PeriodoLectivo PeriodoLectivo { get; set; } = null!;

    public virtual Unidad Unidad { get; set; } = null!;

    public virtual TipoPropuesta TipoPropuesta { get; set; } = null!;

    public virtual PropuestaEstado PropuestaEstado { get; set; } = null!;

    public virtual PropuestaWeb? PropuestaWeb { get; set; }

    public virtual ICollection<Preinscripcion> Preinscripciones { get; set; } =
        new List<Preinscripcion>();

    public virtual ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();

    public virtual ICollection<PropuestaDocente> PropuestaDocentes { get; set; } =
        new List<PropuestaDocente>();

    public virtual ICollection<Temario> PropuestaContenidos { get; set; } = new List<Temario>();

    public static Propuesta Crear(
        int unidadId,
        int tipoPropuestaId,
        int periodoLectivoId,
        string titulo,
        int anio,
        int? edicion,
        DateOnly fechaInicio,
        DateOnly fechaFin,
        int maximoAlumnos,
        int cantidadHoras,
        int usuarioId,
        int modalidadId,
        int estadoPropuestaId,
        decimal? importeBase = null,
        int? cuotas = null,
        string? conceptoPago = null,
        string? emailEncargado = null,
        string? planEstudioPdf = null,
        string? lugarRealizacion = null,
        string? contactoInfo = null,
        string? pagosInfo = null,
        bool webVisible = false,
        bool permiteInscripcionesWeb = false
    )
    {
        // Validaciones básicas
        if (string.IsNullOrWhiteSpace(titulo))
            throw new DomainException("El título es requerido");

        if (fechaInicio >= fechaFin)
            throw new DomainException("La fecha de inicio debe ser anterior a la fecha de fin");

        if (maximoAlumnos <= 0)
            throw new DomainException("El máximo de alumnos debe ser mayor a cero");

        if (cantidadHoras <= 0)
            throw new DomainException("La cantidad de horas debe ser mayor a cero");

        return new Propuesta
        {
            UnidadId = unidadId,
            ModalidadId = modalidadId,
            TipoPropuestaId = tipoPropuestaId,
            PeriodoLectivoId = periodoLectivoId,
            EstadoPropuestaId = estadoPropuestaId,
            UsuarioId = usuarioId,
            Titulo = titulo.Trim(),
            Anio = anio,
            Edicion = edicion,
            FechaInicio = fechaInicio,
            FechaFin = fechaFin,
            MaximoAlumnos = maximoAlumnos,
            CuposDisponibles = maximoAlumnos,
            CantidadHoras = cantidadHoras,
            ImporteBase = importeBase,
            Cuotas = cuotas,
            ConceptoPago = conceptoPago?.Trim(),
            EmailEncargado = emailEncargado?.Trim(),
            PlanEstudioPdf = planEstudioPdf,
            LugarRealizacion = lugarRealizacion?.Trim(),
            ContactoInfo = contactoInfo?.Trim(),
            PagosInfo = pagosInfo?.Trim(),
            WebVisible = webVisible,
            PermiteInscripcionesWeb = permiteInscripcionesWeb,
            Estado = true,
            CreadoEn = DateTime.UtcNow,
            ActualizadoEn = DateTime.UtcNow,
            Preinscripciones = new List<Preinscripcion>(),
            Inscripciones = new List<Inscripcion>(),
            PropuestaDocentes = new List<PropuestaDocente>(),
            PropuestaContenidos = new List<Temario>(),
        };
    }

    // Método para actualizar una propuesta (considerando el estado)
    public void Actualizar(
        string titulo,
        DateOnly fechaInicio,
        DateOnly fechaFin,
        int maximoAlumnos,
        int cantidadHoras,
        decimal? importeBase,
        int? cuotas,
        string? conceptoPago,
        string? emailEncargado,
        string? planEstudioPdf,
        string? lugarRealizacion,
        string? contactoInfo,
        string? pagosInfo,
        bool webVisible,
        bool permiteInscripcionesWeb,
        int? unidadId = null,
        int? tipoPropuestaId = null,
        int? periodoLectivoId = null,
        int? anio = null,
        int? edicion = null
    )
    {
        // Verificar si está en estado borrador
        if (PropuestaEstado?.Codigo != "BORRADOR")
            throw new InvalidOperationException(
                "Solo se pueden modificar propuestas en estado borrador"
            );

        // Validaciones básicas
        if (string.IsNullOrWhiteSpace(titulo))
            throw new DomainException("El título es requerido");

        if (fechaInicio >= fechaFin)
            throw new DomainException("La fecha de inicio debe ser anterior a la fecha de fin");

        if (maximoAlumnos <= 0)
            throw new DomainException("El máximo de alumnos debe ser mayor a cero");

        if (cantidadHoras <= 0)
            throw new DomainException("La cantidad de horas debe ser mayor a cero");

        // Actualizar campos restringidos (solo si se proporcionan)
        if (unidadId.HasValue)
            UnidadId = unidadId.Value;

        if (tipoPropuestaId.HasValue)
            TipoPropuestaId = tipoPropuestaId.Value;

        if (periodoLectivoId.HasValue)
            PeriodoLectivoId = periodoLectivoId.Value;

        if (anio.HasValue)
            Anio = anio.Value;

        if (edicion.HasValue)
            Edicion = edicion;

        // Actualizar campos generales
        Titulo = titulo.Trim();
        FechaInicio = fechaInicio;
        FechaFin = fechaFin;
        MaximoAlumnos = maximoAlumnos;

        // Ajustar cupos disponibles si cambió el máximo
        if (maximoAlumnos > MaximoAlumnos)
        {
            CuposDisponibles += (maximoAlumnos - MaximoAlumnos);
        }
        else if (maximoAlumnos < MaximoAlumnos)
        {
            var diferencia = MaximoAlumnos - maximoAlumnos;
            CuposDisponibles = Math.Max(0, CuposDisponibles - diferencia);
        }

        CantidadHoras = cantidadHoras;
        ImporteBase = importeBase;
        Cuotas = cuotas;
        ConceptoPago = conceptoPago?.Trim();
        EmailEncargado = emailEncargado?.Trim();
        PlanEstudioPdf = planEstudioPdf;
        LugarRealizacion = lugarRealizacion?.Trim();
        ContactoInfo = contactoInfo?.Trim();
        PagosInfo = pagosInfo?.Trim();
        WebVisible = webVisible;
        PermiteInscripcionesWeb = permiteInscripcionesWeb;
        ActualizadoEn = DateTime.UtcNow;
    }

    // Método para publicar una propuesta
    public void Publicar()
    {
        if (PropuestaEstado?.Codigo != "BORRADOR")
            throw new InvalidOperationException(
                "Solo se pueden publicar propuestas en estado borrador"
            );

        // Validar que tenga los datos mínimos necesarios para publicar
        if (string.IsNullOrWhiteSpace(LugarRealizacion))
            throw new InvalidOperationException(
                "Debe especificar el lugar de realización antes de publicar"
            );

        if (ImporteBase.HasValue && string.IsNullOrWhiteSpace(ConceptoPago))
            throw new InvalidOperationException(
                "Debe especificar el concepto de pago si la propuesta tiene un importe base"
            );

        // Cambiar estado a publicado (asumiendo que el ID de publicado es 2 o el que corresponda)
        // Nota: Deberías obtener el ID correcto según tu catálogo
        EstadoPropuestaId = 2; // Publicado
        ActualizadoEn = DateTime.UtcNow;
    }

    // Método para archivar una propuesta
    public void Archivar()
    {
        if (PropuestaEstado?.Codigo == "ARCHIVADO")
            throw new InvalidOperationException("La propuesta ya está archivada");

        // Cambiar estado a archivado (asumiendo que el ID de archivado es 3 o el que corresponda)
        EstadoPropuestaId = 3; // Archivado
        WebVisible = false; // Al archivar, desactivar visibilidad web
        PermiteInscripcionesWeb = false; // Desactivar inscripciones web
        ActualizadoEn = DateTime.UtcNow;
    }

    // Método para activar/desactivar visibilidad web (solo si no está archivada)
    public void SetWebVisible(bool visible)
    {
        if (PropuestaEstado?.Codigo == "ARCHIVADO")
            throw new InvalidOperationException(
                "No se puede activar el sitio web de una propuesta archivada"
            );

        WebVisible = visible;
        ActualizadoEn = DateTime.UtcNow;
    }

    // Método para activar/desactivar inscripciones web (solo si no está archivada)
    public void SetPermiteInscripcionesWeb(bool permite)
    {
        if (PropuestaEstado?.Codigo == "ARCHIVADO")
            throw new InvalidOperationException(
                "No se pueden activar las inscripciones web de una propuesta archivada"
            );

        PermiteInscripcionesWeb = permite;
        ActualizadoEn = DateTime.UtcNow;
    }

    // Método para inscribir un alumno (reducir cupos disponibles)
    public bool InscribirAlumno()
    {
        if (PropuestaEstado?.Codigo != "PUBLICADO")
            throw new InvalidOperationException(
                "Solo se pueden inscribir alumnos en propuestas publicadas"
            );

        if (!PermiteInscripcionesWeb)
            throw new InvalidOperationException("Esta propuesta no permite inscripciones web");

        if (CuposDisponibles <= 0)
            return false;

        CuposDisponibles--;
        ActualizadoEn = DateTime.UtcNow;
        return true;
    }

    // Método para cancelar una inscripción (aumentar cupos disponibles)
    public void CancelarInscripcion()
    {
        if (CuposDisponibles < MaximoAlumnos)
        {
            CuposDisponibles++;
            ActualizadoEn = DateTime.UtcNow;
        }
    }
}
