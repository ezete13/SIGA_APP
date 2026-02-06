// SIGA.Persistence/Configurations/UsuarioPermisosUnidadConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class UsuarioPermisosUnidadConfiguration : IEntityTypeConfiguration<UsuarioPermisosUnidad>
{
    public void Configure(EntityTypeBuilder<UsuarioPermisosUnidad> builder)
    {
        builder.HasKey(e => e.Id).HasName("usuario_permisos_unidad_pkey");

        builder.ToTable(
            "usuario_permisos_unidad",
            tb => tb.HasComment("Permisos específicos de usuarios por unidad y módulo.")
        );

        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("ID único autoincremental.")
            .UseIdentityColumn();

        builder
            .Property(e => e.UsuarioId)
            .HasColumnName("usuario_id")
            .IsRequired()
            .HasComment("ID del usuario (FK a usuarios.id).");

        builder
            .Property(e => e.UnidadId)
            .HasColumnName("unidad_id")
            .IsRequired()
            .HasComment("ID de la unidad académica (FK a unidades.id).");

        builder
            .Property(e => e.ModuloId)
            .HasColumnName("modulo_id")
            .IsRequired()
            .HasComment("ID del módulo del sistema (FK a modulos.id).");

        builder
            .Property(e => e.Permisos)
            .HasColumnName("permisos")
            .HasColumnType("jsonb")
            .IsRequired()
            .HasComment(
                "Configuración de permisos en formato JSON. Ej: {\"lectura\": true, \"escritura\": false}."
            );

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

        // RELACIONES
        builder
            .HasOne(d => d.Usuario)
            .WithMany(p => p.UsuarioPermisosUnidad)
            .HasForeignKey(d => d.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("usuario_permisos_unidad_usuario_id_fkey")
            .IsRequired();

        builder
            .HasOne(d => d.Unidad)
            .WithMany(p => p.UsuarioPermisosUnidad)
            .HasForeignKey(d => d.UnidadId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("usuario_permisos_unidad_unidad_id_fkey")
            .IsRequired();

        builder
            .HasOne(d => d.Modulo)
            .WithMany(p => p.UsuarioPermisosUnidad)
            .HasForeignKey(d => d.ModuloId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("usuario_permisos_unidad_modulo_id_fkey")
            .IsRequired();

        // ÍNDICES
        builder
            .HasIndex(e => new
            {
                e.UsuarioId,
                e.UnidadId,
                e.ModuloId,
            })
            .IsUnique()
            .HasDatabaseName("usuario_permisos_unidad_usuario_id_unidad_id_modulo_id_key");

        builder.HasIndex(e => e.UsuarioId).HasDatabaseName("IX_usuario_permisos_unidad_usuario_id");

        builder.HasIndex(e => e.UnidadId).HasDatabaseName("IX_usuario_permisos_unidad_unidad_id");

        builder.HasIndex(e => e.ModuloId).HasDatabaseName("IX_usuario_permisos_unidad_modulo_id");

        builder.HasIndex(e => e.Estado).HasDatabaseName("IX_usuario_permisos_unidad_estado");

        // Índice GIN para búsqueda en JSONB
        builder
            .HasIndex(e => e.Permisos)
            .HasMethod("GIN")
            .HasDatabaseName("IX_usuario_permisos_unidad_permisos_gin");
    }
}
