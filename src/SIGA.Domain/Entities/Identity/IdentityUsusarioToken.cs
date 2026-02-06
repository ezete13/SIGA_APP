namespace SIGA.Domain.Entities;

public partial class IdentityUsusarioToken
{
    public int UserId { get; set; }

    public string LoginProvider { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Value { get; set; }

    public virtual IdentityUsuario Usuario { get; set; } = null!;
}
