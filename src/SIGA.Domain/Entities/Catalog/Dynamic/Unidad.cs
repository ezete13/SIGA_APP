using SIGA.Domain.Common;
using SIGA.Domain.Entities.Core;

namespace SIGA.Domain.Entities.Catalog.Dynamic;

public partial class Unidad : EntityBase
{
    public required string NombreCorto { get; set; }

    public required string Siglas { get; set; }

    public string? ColorPrincipal { get; set; }

    public string? ColorSecundario { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Autoridad> Autoridades { get; set; } = new List<Autoridad>();

    public virtual ICollection<Propuesta> Propuestas { get; set; } = new List<Propuesta>();
}
