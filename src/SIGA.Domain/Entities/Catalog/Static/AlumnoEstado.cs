using SIGA.Domain.Common;
using SIGA.Domain.Entities.Core;

namespace SIGA.Domain.Entities.Catalog.Static;

public partial class AlumnoEstado : EntityBase
{
    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
}
