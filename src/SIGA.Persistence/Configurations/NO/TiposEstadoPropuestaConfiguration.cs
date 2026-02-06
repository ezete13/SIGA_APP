// SIGA.Persistence/Configurations/TiposEstadoPropuestaConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class TiposEstadoPropuestaConfiguration : IEntityTypeConfiguration<TiposEstadoPropuesta>
{
    public void Configure(EntityTypeBuilder<TiposEstadoPropuesta> builder)
    {
        builder.HasKey(e => e.Id).HasName("tipos_estado_propuesta_pkey");

        builder.ToTable(
            "tipos_estado_propuesta",
            tb => tb.HasComment("Catálogo de estados posibles para las propuestas académicas.")
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
            .HasComment("Nombre del estado. Ej: Borrador, Publicada, Archivada.");

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
            .HasMany(t => t.Propuestas)
            .WithOne(p => p.TipoEstadoPropuesta)
            .HasForeignKey(p => p.TipoEstadoPropuestaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(t => t.HistorialEstadoPropuestas)
            .WithOne(h => h.TipoEstadoPropuesta)
            .HasForeignKey(h => h.TipoEstadoPropuestaId)
            .OnDelete(DeleteBehavior.Restrict);

        // ÍNDICES
        builder
            .HasIndex(e => e.Codigo)
            .IsUnique()
            .HasDatabaseName("tipos_estado_propuesta_codigo_key");

        builder.HasIndex(e => e.Estado).HasDatabaseName("IX_tipos_estado_propuesta_estado");

        builder.HasIndex(e => e.Nombre).HasDatabaseName("IX_tipos_estado_propuesta_nombre");
    }
}
