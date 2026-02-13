namespace SIGA.Domain.Common;

public partial class EntityBase
{
    public int Id { get; set; }

    public required string Codigo { get; set; }

    public required string Nombre { get; set; }

    public required string? Descripcion { get; set; }

    public bool Activo { get; set; } = true;
}
