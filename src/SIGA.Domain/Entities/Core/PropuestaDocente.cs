namespace SIGA.Domain.Entities.Core;

public partial class PropuestaDocente
{
    public int Id { get; set; }

    public required int PropuestaId { get; set; }

    public required int DocenteId { get; set; }

    public required string Rol { get; set; }

    public int? OrdenWeb { get; set; }

    public virtual Docente Docente { get; set; } = null!;

    public virtual Propuesta Propuesta { get; set; } = null!;
}
