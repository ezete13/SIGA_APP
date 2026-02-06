// SIGA.Persistence/Configurations/IdentityRolesConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class IdentityRolesConfiguration : IEntityTypeConfiguration<IdentityRoles>
{
    public void Configure(EntityTypeBuilder<IdentityRoles> builder)
    {
        builder.HasKey(e => e.Id).HasName("identity_roles_pkey");

        builder.ToTable("identity_roles");

        builder.Property(e => e.Id).HasColumnName("id").UseIdentityAlwaysColumn();

        builder.Property(e => e.Name).HasColumnName("name").HasMaxLength(256);

        builder.Property(e => e.NormalizedName).HasColumnName("normalized_name").HasMaxLength(256);

        builder.Property(e => e.ConcurrencyStamp).HasColumnName("concurrency_stamp");

        // RELACIONES INVERSAS
        builder
            .HasMany(r => r.IdentityRoleClaims)
            .WithOne(rc => rc.Role)
            .HasForeignKey(rc => rc.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(r => r.User)
            .WithMany(u => u.Role)
            .UsingEntity<Dictionary<string, object>>(
                "IdentityUserRoles",
                r => r.HasOne<IdentityUsers>().WithMany().HasForeignKey("UserId"),
                l => l.HasOne<IdentityRoles>().WithMany().HasForeignKey("RoleId"),
                j =>
                {
                    j.HasKey("UserId", "RoleId").HasName("identity_user_roles_pkey");
                    j.ToTable("identity_user_roles");
                    j.Property("UserId").HasColumnName("user_id");
                    j.Property("RoleId").HasColumnName("role_id");
                }
            );

        // ÍNDICES
        builder.HasIndex(r => r.NormalizedName).HasDatabaseName("RoleNameIndex").IsUnique();
    }
}
