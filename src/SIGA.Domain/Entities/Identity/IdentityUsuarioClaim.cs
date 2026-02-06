namespace SIGA.Domain.Entities;

public partial class IdentityUsuarioClaim
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    public virtual IdentityUsuario Usuario { get; set; } = null!;
}
