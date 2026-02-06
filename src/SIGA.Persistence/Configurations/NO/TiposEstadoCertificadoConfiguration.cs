// SIGA.Persistence/Configurations/TiposEstadoCertificadoConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class TiposEstadoCertificadoConfiguration : IEntityTypeConfiguration<TiposEstadoCertificado>
{
    public void Configure(EntityTypeBuilder<TiposEstadoCertificado> builder)
    {
        builder.HasKey(e => e.Id).HasName("tipos_estado_certificado_pkey");

        builder.ToTable(
            "tipos_estado_certificado",
            tb => tb.HasComment("Catálogo de estados posibles para las certificaciones.")
        );

        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("ID único autoincremental.")
            .UseIdentityColumn();

        builder
            .Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(10)
            .IsRequired()
            .HasComment("Código interno único.");

        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(50)
            .IsRequired()
            .HasComment("Nombre del estado. Ej: Pendiente, Emitido, Anulado.");

        builder
            .Property(e => e.Descripcion)
            .HasColumnName("descripcion")
            .IsRequired(false)
            .HasComment("Descripción del tipo de estado.");

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

        // RELACIONES INVERSAS
        builder
            .HasMany(t => t.Certificaciones)
            .WithOne(c => c.TipoEstadoCertificado)
            .HasForeignKey(c => c.TipoEstadoCertificadoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(t => t.HistorialEstadoCertificaciones)
            .WithOne(h => h.TipoEstadoCertificado)
            .HasForeignKey(h => h.TipoEstadoCertificadoId)
            .OnDelete(DeleteBehavior.Restrict);

        // ÍNDICES
        builder
            .HasIndex(e => e.Codigo)
            .IsUnique()
            .HasDatabaseName("tipos_estado_certificado_codigo_key");

        builder.HasIndex(e => e.Estado).HasDatabaseName("IX_tipos_estado_certificado_estado");

        builder.HasIndex(e => e.Nombre).HasDatabaseName("IX_tipos_estado_certificado_nombre");
    }
}
