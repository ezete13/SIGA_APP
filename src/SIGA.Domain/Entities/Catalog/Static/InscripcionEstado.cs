using SIGA.Domain.Common;
using SIGA.Domain.Entities.Core;

namespace SIGA.Domain.Entities.Catalog.Static;

public partial class InscripcionEstado : EntityBase
{
    public virtual ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
}
