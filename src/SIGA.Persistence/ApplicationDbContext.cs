using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SIGA.Domain.Entities;

namespace SIGA.Persistence;

public partial class ApplicationDbContext : IdentityDbContext<Usuario>
{
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public virtual DbSet<Unidad> Unidades { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }
    
    /*
    public virtual DbSet<Autoridad> Autoridades { get; set; }
    
    public virtual DbSet<CertificacionAutoridad> CertificacionAutoridad { get; set; }
    public virtual DbSet<Certificaciones> Certificaciones { get; set; }
    public virtual DbSet<Docentes> Docentes { get; set; }
    public virtual DbSet<HistorialEstadoCertificaciones> HistorialEstadoCertificaciones { get; set; }
    public virtual DbSet<HistorialEstadoInscripciones> HistorialEstadoInscripciones { get; set; }
    public virtual DbSet<HistorialEstadoPropuestas> HistorialEstadoPropuestas { get; set; }
    public virtual DbSet<IdentityRoleClaim> IdentityRoleClaims { get; set; }
    public virtual DbSet<IdentityRoles> IdentityRoles { get; set; }
    public virtual DbSet<IdentityUserClaims> IdentityUserClaims { get; set; }
    public virtual DbSet<IdentityUsuarioLogin> IdentityUserLogins { get; set; }
    public virtual DbSet<IdentityUsuarioToken> IdentityUserTokens { get; set; }
    public virtual DbSet<IdentityUsers> IdentityUsers { get; set; }
    public virtual DbSet<Inscripciones> Inscripciones { get; set; }
    public virtual DbSet<Modalidades> Modalidades { get; set; }
    public virtual DbSet<Modulo> Modulos { get; set; }
    public virtual DbSet<PeriodosLectivos> PeriodosLectivos { get; set; }
    public virtual DbSet<Portales> Portales { get; set; }
    public virtual DbSet<PropuestaAuspiciantes> PropuestaAuspiciantes { get; set; }
    public virtual DbSet<PropuestaContactos> PropuestaContactos { get; set; }
    public virtual DbSet<PropuestaDocente> PropuestaDocente { get; set; }
    public virtual DbSet<PropuestaPagosInfo> PropuestaPagosInfo { get; set; }
    public virtual DbSet<PropuestaPlanItems> PropuestaPlanItems { get; set; }
    public virtual DbSet<PropuestaPlanModulos> PropuestaPlanModulos { get; set; }
    public virtual DbSet<Propuestas> Propuestas { get; set; }
    public virtual DbSet<Sedes> Sedes { get; set; }
    public virtual DbSet<TiposDocumento> TiposDocumento { get; set; }
    public virtual DbSet<TiposEstadoCertificado> TiposEstadoCertificado { get; set; }
    public virtual DbSet<TiposEstadoInscripcion> TiposEstadoInscripcion { get; set; }
    public virtual DbSet<TiposEstadoPropuesta> TiposEstadoPropuesta { get; set; }
    public virtual DbSet<TiposPropuesta> TiposPropuesta { get; set; }
    
    public virtual DbSet<UsuarioPermisosUnidad> UsuarioPermisosUnidad { get; set; }
    */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
