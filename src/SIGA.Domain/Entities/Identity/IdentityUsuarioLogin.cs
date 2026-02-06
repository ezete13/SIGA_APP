namespace SIGA.Domain.Entities;

public partial class IdentityUsuarioLogin
{
    public string LoginProvider { get; set; } = null!;

    public string ProviderKey { get; set; } = null!;

    public string? ProviderDisplayName { get; set; }

    public int UserId { get; set; }

    public virtual IdentityUsuario Usuario { get; set; } = null!;
}
