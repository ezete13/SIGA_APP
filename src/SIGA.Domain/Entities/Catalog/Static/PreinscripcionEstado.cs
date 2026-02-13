using SIGA.Domain.Common;
using SIGA.Domain.Entities.Core;

namespace SIGA.Domain.Entities.Catalog.Static;

public partial class PreinscripcionEstado : EntityBase
{
    public virtual ICollection<Preinscripcion> Preinscripciones { get; set; } =
        new List<Preinscripcion>();
}
