namespace SIGA.Domain.Entities;

public partial class CertificadoEstado
{
    public int Id { get; set; }

    public required string Codigo { get; set; }

    public required string Nombre { get; set; }

    public string? Descripcion { get; set; }

    public bool Activo { get; set; } = true;

    public virtual ICollection<Certificado> Certificado { get; set; } = new List<Certificado>();
}
