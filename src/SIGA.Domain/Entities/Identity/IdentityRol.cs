namespace SIGA.Domain.Entities;

public partial class IdentityRol
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? NormalizedName { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public virtual ICollection<IdentityRoleClaim> IdentityRoleClaims { get; set; } =
        new List<IdentityRoleClaim>();

    public virtual ICollection<IdentityUsuario> Usuarios { get; set; } =
        new List<IdentityUsuario>();
}
