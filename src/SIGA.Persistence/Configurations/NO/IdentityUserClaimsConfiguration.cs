// SIGA.Persistence/Configurations/IdentityUserClaimsConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class IdentityUserClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaims>
{
    public void Configure(EntityTypeBuilder<IdentityUserClaims> builder)
    {
        builder.HasKey(e => e.Id).HasName("identity_user_claims_pkey");

        builder.ToTable("identity_user_claims");

        builder.Property(e => e.Id).HasColumnName("id").UseIdentityColumn();

        builder.Property(e => e.UserId).HasColumnName("user_id").IsRequired();

        builder.Property(e => e.ClaimType).HasColumnName("claim_type").HasMaxLength(256);

        builder.Property(e => e.ClaimValue).HasColumnName("claim_value").HasMaxLength(256);

        // RELACIONES
        builder
            .HasOne(d => d.User)
            .WithMany(p => p.IdentityUserClaims)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("identity_user_claims_user_id_fkey")
            .IsRequired();
    }
}
