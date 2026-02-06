// SIGA.Persistence/Configurations/IdentityUserTokensConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class IdentityUserTokensConfiguration : IEntityTypeConfiguration<IdentityUserTokens>
{
    public void Configure(EntityTypeBuilder<IdentityUserTokens> builder)
    {
        builder
            .HasKey(e => new
            {
                e.UserId,
                e.LoginProvider,
                e.Name,
            })
            .HasName("identity_user_tokens_pkey");

        builder.ToTable("identity_user_tokens");

        builder.Property(e => e.UserId).HasColumnName("user_id");

        builder.Property(e => e.LoginProvider).HasColumnName("login_provider").HasMaxLength(255);

        builder.Property(e => e.Name).HasColumnName("name").HasMaxLength(255);

        builder.Property(e => e.Value).HasColumnName("value");

        // RELACIONES
        builder
            .HasOne(d => d.User)
            .WithMany(p => p.IdentityUserTokens)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("identity_user_tokens_user_id_fkey")
            .IsRequired();
    }
}
