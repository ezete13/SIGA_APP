// SIGA.Persistence/Configurations/IdentityRoleClaimsConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class IdentityRoleClaimsConfiguration : IEntityTypeConfiguration<IdentityRoleClaims>
{
    public void Configure(EntityTypeBuilder<IdentityRoleClaims> builder)
    {
        builder.HasKey(e => e.Id).HasName("identity_role_claims_pkey");

        builder.ToTable("identity_role_claims");

        builder.Property(e => e.Id).HasColumnName("id").UseIdentityColumn();

        builder.Property(e => e.RoleId).HasColumnName("role_id").IsRequired();

        builder.Property(e => e.ClaimType).HasColumnName("claim_type").HasMaxLength(256);

        builder.Property(e => e.ClaimValue).HasColumnName("claim_value").HasMaxLength(256);

        // RELACIONES
        builder
            .HasOne(d => d.Role)
            .WithMany(p => p.IdentityRoleClaims)
            .HasForeignKey(d => d.RoleId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("identity_role_claims_role_id_fkey")
            .IsRequired();
    }
}
