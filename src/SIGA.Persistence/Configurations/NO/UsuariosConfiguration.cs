// SIGA.Persistence/Configurations/UsuariosConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class UsuariosConfiguration : IEntityTypeConfiguration<Usuarios>
{
    public void Configure(EntityTypeBuilder<Usuarios> builder)
    {
        builder.HasKey(e => e.Id).HasName("usuarios_pkey");

        builder.ToTable(
            "usuarios",
            tb => tb.HasComment("Perfil extendido de usuarios del sistema con datos adicionales.")
        );

        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("ID único autoincremental.")
            .UseIdentityColumn();

        builder
            .Property(e => e.IdentityUserId)
            .HasColumnName("identity_user_id")
            .IsRequired()
            .HasComment("ID del usuario en Identity (FK a identity_users.id).");

        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(100)
            .IsRequired()
            .HasComment("Nombre del usuario.");

        builder
            .Property(e => e.Apellido)
            .HasColumnName("apellido")
            .HasMaxLength(100)
            .IsRequired()
            .HasComment("Apellido del usuario.");

        builder
            .Property(e => e.Dni)
            .HasColumnName("dni")
            .HasMaxLength(20)
            .IsRequired()
            .HasComment("Documento Nacional de Identidad.");

        builder
            .Property(e => e.Email)
            .HasColumnName("email")
            .HasMaxLength(150)
            .IsRequired()
            .HasComment("Email de contacto (debe coincidir con Identity si aplica).");

        builder
            .Property(e => e.Telefono)
            .HasColumnName("telefono")
            .HasMaxLength(20)
            .IsRequired(false)
            .HasComment("Teléfono de contacto.");

        builder
            .Property(e => e.Estado)
            .HasColumnName("estado")
            .HasDefaultValue(true)
            .IsRequired()
            .HasComment("Estado activo/inactivo (true=activo, false=inactivo).");

        builder
            .Property(e => e.CreadoEn)
            .HasColumnName("creado_en")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired(false)
            .HasComment("Fecha y hora de creación del registro.");

        builder
            .Property(e => e.ActualizadoEn)
            .HasColumnName("actualizado_en")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired(false)
            .HasComment("Fecha y hora de última actualización del registro.");

        // RELACIONES
        // 1:1 con IdentityUsers
        builder
            .HasOne(d => d.IdentityUser)
            .WithOne(p => p.Usuarios)
            .HasForeignKey<Usuarios>(d => d.IdentityUserId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("usuarios_identity_user_id_fkey")
            .IsRequired();

        // Relación inversa con UsuarioPermisosUnidad
        builder
            .HasMany(u => u.UsuarioPermisosUnidad)
            .WithOne(upu => upu.Usuario)
            .HasForeignKey(upu => upu.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación inversa con HistorialEstadoX
        builder
            .HasMany(u => u.HistorialEstadoPropuestas)
            .WithOne(hep => hep.Usuario)
            .HasForeignKey(hep => hep.UsuarioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasMany(u => u.HistorialEstadoInscripciones)
            .WithOne(hei => hei.Usuario)
            .HasForeignKey(hei => hei.UsuarioId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasMany(u => u.HistorialEstadoCertificaciones)
            .WithOne(hec => hec.Usuario)
            .HasForeignKey(hec => hec.UsuarioId)
            .OnDelete(DeleteBehavior.SetNull);

        // ÍNDICES
        builder
            .HasIndex(e => e.IdentityUserId)
            .IsUnique()
            .HasDatabaseName("usuarios_identity_user_id_key");

        builder.HasIndex(e => e.Dni).IsUnique().HasDatabaseName("usuarios_dni_key");

        builder.HasIndex(e => e.Email).IsUnique().HasDatabaseName("usuarios_email_key");

        builder.HasIndex(e => e.Estado).HasDatabaseName("IX_usuarios_estado");

        builder
            .HasIndex(e => new { e.Apellido, e.Nombre })
            .HasDatabaseName("IX_usuarios_apellido_nombre");

        // Propiedad computada para nombre completo
        builder
            .Property(e => e.NombreCompleto)
            .HasComputedColumnSql("nombre || ' ' || apellido", stored: true)
            .HasColumnName("nombre_completo")
            .HasComment("Nombre completo del usuario (computado).");
    }
}
