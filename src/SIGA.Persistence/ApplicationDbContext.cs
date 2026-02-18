using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SIGA.Domain.Entities.Catalog.Dynamic;
using SIGA.Domain.Entities.Catalog.Static;
using SIGA.Domain.Entities.Core;

namespace SIGA.Persistence;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    // Catalog - Static (Enums/tablas fijas)
    public virtual DbSet<AlumnoEstado> AlumnoEstados { get; set; }
    public virtual DbSet<CertificadoEstado> CertificadoEstados { get; set; }
    public virtual DbSet<InscripcionEstado> InscripcionEstados { get; set; }
    public virtual DbSet<PreinscripcionEstado> PreinscripcionEstados { get; set; }
    public virtual DbSet<PropuestaEstado> PropuestaEstados { get; set; }
    public virtual DbSet<TipoDocumento> TiposDocumento { get; set; }

    // Catalog - Dynamic (Catálogos editables)
    public virtual DbSet<Modalidad> Modalidades { get; set; }
    public virtual DbSet<PeriodoLectivo> PeriodosLectivos { get; set; }
    public virtual DbSet<TipoPropuesta> TiposPropuesta { get; set; }
    public virtual DbSet<Unidad> Unidades { get; set; }

    // Core (Entidades principales del negocio)
    public virtual DbSet<Alumno> Alumnos { get; set; }
    public virtual DbSet<Autoridad> Autoridades { get; set; }
    public virtual DbSet<Certificado> Certificados { get; set; }
    public virtual DbSet<Docente> Docentes { get; set; }
    public virtual DbSet<Inscripcion> Inscripciones { get; set; }
    public virtual DbSet<Preinscripcion> Preinscripciones { get; set; }
    public virtual DbSet<Propuesta> Propuestas { get; set; }
    public virtual DbSet<PropuestaDocente> PropuestaDocentes { get; set; }
    public virtual DbSet<PropuestaWeb> PropuestasWeb { get; set; }
    public virtual DbSet<Temario> Temarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
