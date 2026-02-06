// SIGA.Persistence/Configurations/IdentityUsersConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class IdentityUsersConfiguration : IEntityTypeConfiguration<IdentityUsers>
{
    public void Configure(EntityTypeBuilder<IdentityUsers> builder)
    {
        builder.HasKey(e => e.Id).HasName("identity_users_pkey");

        builder.ToTable("identity_users");

        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.UserName).HasColumnName("user_name").HasMaxLength(256);

        builder
            .Property(e => e.NormalizedUserName)
            .HasColumnName("normalized_user_name")
            .HasMaxLength(256);

        builder.Property(e => e.Email).HasColumnName("email").HasMaxLength(256);

        builder
            .Property(e => e.NormalizedEmail)
            .HasColumnName("normalized_email")
            .HasMaxLength(256);

        builder
            .Property(e => e.EmailConfirmed)
            .HasColumnName("email_confirmed")
            .HasDefaultValue(false);

        builder.Property(e => e.PasswordHash).HasColumnName("password_hash");

        builder.Property(e => e.SecurityStamp).HasColumnName("security_stamp");

        builder.Property(e => e.ConcurrencyStamp).HasColumnName("concurrency_stamp");

        builder.Property(e => e.PhoneNumber).HasColumnName("phone_number");

        builder
            .Property(e => e.PhoneNumberConfirmed)
            .HasColumnName("phone_number_confirmed")
            .HasDefaultValue(false);

        builder
            .Property(e => e.TwoFactorEnabled)
            .HasColumnName("two_factor_enabled")
            .HasDefaultValue(false);

        builder.Property(e => e.LockoutEnd).HasColumnName("lockout_end");

        builder
            .Property(e => e.LockoutEnabled)
            .HasColumnName("lockout_enabled")
            .HasDefaultValue(false);

        builder
            .Property(e => e.AccessFailedCount)
            .HasColumnName("access_failed_count")
            .HasDefaultValue(0);

        // RELACIONES INVERSAS
        builder
            .HasMany(u => u.IdentityUserClaims)
            .WithOne(uc => uc.User)
            .HasForeignKey(uc => uc.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(u => u.IdentityUserLogins)
            .WithOne(ul => ul.User)
            .HasForeignKey(ul => ul.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(u => u.IdentityUserTokens)
            .WithOne(ut => ut.User)
            .HasForeignKey(ut => ut.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(u => u.Role)
            .WithMany(r => r.User)
            .UsingEntity<Dictionary<string, object>>(
                "IdentityUserRoles",
                r => r.HasOne<IdentityRoles>().WithMany().HasForeignKey("RoleId"),
                l => l.HasOne<IdentityUsers>().WithMany().HasForeignKey("UserId"),
                j =>
                {
                    j.HasKey("UserId", "RoleId").HasName("identity_user_roles_pkey");
                    j.ToTable("identity_user_roles");
                }
            );

        // Relación 1:1 con Usuarios
        builder
            .HasOne(u => u.Usuarios)
            .WithOne(p => p.IdentityUser)
            .HasForeignKey<Usuarios>(p => p.IdentityUserId);

        // ÍNDICES
        builder
            .HasIndex(u => u.NormalizedUserName)
            .IsUnique()
            .HasDatabaseName("idx_identity_users_normalized_user_name");

        builder
            .HasIndex(u => u.NormalizedEmail)
            .HasDatabaseName("idx_identity_users_normalized_email");
    }
}
