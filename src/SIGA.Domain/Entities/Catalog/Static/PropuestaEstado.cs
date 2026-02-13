using SIGA.Domain.Common;
using SIGA.Domain.Entities.Core;

namespace SIGA.Domain.Entities.Catalog.Static;

public partial class EstadoPropuesta : EntityBase
{
    public virtual ICollection<Propuesta> Propuestas { get; set; } = new List<Propuesta>();
}
