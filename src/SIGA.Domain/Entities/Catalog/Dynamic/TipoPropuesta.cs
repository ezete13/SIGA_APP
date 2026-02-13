using SIGA.Domain.Common;
using SIGA.Domain.Entities.Core;

namespace SIGA.Domain.Entities;

public partial class TipoPropuesta : EntityBase
{
    public virtual ICollection<Propuesta> Propuestas { get; set; } = new List<Propuesta>();
}
