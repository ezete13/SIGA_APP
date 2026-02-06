namespace SIGA.Domain.Entities;

public partial class UsuarioPermisoUnidad
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int UnidadId { get; set; }

    public int ModuloId { get; set; }

    public string? Permisos { get; set; }

    public bool? Estado { get; set; }

    public DateTime? CreadoEn { get; set; }

    public virtual required Modulo Modulo { get; set; }

    public virtual required Unidad Unidad { get; set; }

    public virtual required Usuario Usuario { get; set; }
}
