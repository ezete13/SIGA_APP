namespace SIGA.Domain.Entities;

public partial class Modulo
{
    public int Id { get; set; }

    public required string Codigo { get; set; } // "PROPUESTA", "INSCRIPCION", etc.

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public int? Orden { get; set; }

    public string? Icono { get; set; }

    public DateTime? CreadoEn { get; set; } = DateTime.UtcNow;

    public DateTime? ActualizadoEn { get; set; }

    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();
}
