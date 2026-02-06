// SIGA.Persistence/Configurations/IdentityUserLoginsConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class IdentityUserLoginsConfiguration : IEntityTypeConfiguration<IdentityUserLogins>
{
    public void Configure(EntityTypeBuilder<IdentityUserLogins> builder)
    {
        builder
            .HasKey(e => new { e.LoginProvider, e.ProviderKey })
            .HasName("identity_user_logins_pkey");

        builder.ToTable("identity_user_logins");

        builder.Property(e => e.LoginProvider).HasColumnName("login_provider").HasMaxLength(255);

        builder.Property(e => e.ProviderKey).HasColumnName("provider_key").HasMaxLength(255);

        builder.Property(e => e.ProviderDisplayName).HasColumnName("provider_display_name");

        builder.Property(e => e.UserId).HasColumnName("user_id").IsRequired();

        // RELACIONES
        builder
            .HasOne(d => d.User)
            .WithMany(p => p.IdentityUserLogins)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("identity_user_logins_user_id_fkey")
            .IsRequired();
    }
}
