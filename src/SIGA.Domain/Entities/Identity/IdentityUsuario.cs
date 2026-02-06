namespace SIGA.Domain.Entities;

public partial class IdentityUsuario
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool? EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool? PhoneNumberConfirmed { get; set; }

    public bool? TwoFactorEnabled { get; set; }

    public DateTime? LockoutEnd { get; set; }

    public bool? LockoutEnabled { get; set; }

    public int? AccessFailedCount { get; set; }

    public virtual ICollection<IdentityUsuarioClaim> IdentityUsuarioClaims { get; set; } =
        new List<IdentityUsuarioClaim>();

    public virtual ICollection<IdentityUsuarioLogin> IdentityUsuarioLogins { get; set; } =
        new List<IdentityUsuarioLogin>();

    public virtual ICollection<IdentityUsuarioToken> IdentityUsuarioTokens { get; set; } =
        new List<IdentityUsuarioToken>();

    public virtual Usuario? Usuario { get; set; }

    public virtual ICollection<IdentityRol> Roles { get; set; } = new List<IdentityRol>();
}
