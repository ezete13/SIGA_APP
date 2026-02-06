namespace SIGA.Domain.Entities;

public partial class Usuario : IdentityUser<int>
{
    public int Id { get; set; }

    public required string Dni { get; set; }

    public required string Nombre { get; set; }

    public required string Apellido { get; set; }

    public bool? Estado { get; set; }

    public DateTime? CreadoEn { get; set; }

    public DateTime? ActualizadoEn { get; set; }

    public virtual ICollection<PropuestaHistorial> PropuestasHistorial { get; set; } =
        new List<PropuestaHistorial>();

    public virtual ICollection<CertificadoHistorial> CertificadosHistorial { get; set; } =
        new List<CertificadoHistorial>();

    public virtual ICollection<InscripcionHistorial> InscripcionesHistorial { get; set; } =
        new List<InscripcionHistorial>();

    public virtual ICollection<EstadoPropuesta> EstadoPropuestas { get; set; } =
        new List<EstadoPropuesta>();

    public virtual ICollection<UsuarioPermisoUnidad> UsuarioPermisosUnidad { get; set; } =
        new List<UsuarioPermisoUnidad>();

    public virtual ICollection<UsuarioUnidad> UsuarioUnidades { get; set; } =
        new List<UsuarioUnidad>();
}
