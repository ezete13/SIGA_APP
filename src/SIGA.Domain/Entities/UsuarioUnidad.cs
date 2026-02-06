namespace SIGA.Domain.Entities;

public class UsuarioUnidad
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int UnidadId { get; set; }

    public int? RolId { get; set; }

    public string PermisosPorModulo { get; set; } = "{}";

    public bool EsPrincipal { get; set; } = false;

    public bool Estado { get; set; } = true;

    public DateTime AsignadoEn { get; set; } = DateTime.UtcNow;

    public DateTime? ActualizadoEn { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;

    public virtual Unidad Unidad { get; set; } = null!;

    public virtual Rol? Rol { get; set; }
}
