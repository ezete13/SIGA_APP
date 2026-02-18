using SIGA.Domain.Common;
using SIGA.Domain.Entities.Core;

namespace SIGA.Domain.Entities.Catalog.Static;

public partial class CertificadoEstado : EntityBase
{
    public virtual ICollection<Certificado> Certificados { get; set; } = new List<Certificado>();
}
