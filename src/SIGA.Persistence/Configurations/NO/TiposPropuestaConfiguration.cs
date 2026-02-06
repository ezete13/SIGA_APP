// SIGA.Persistence/Configurations/TiposPropuestaConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class TiposPropuestaConfiguration : IEntityTypeConfiguration<TiposPropuesta>
{
    public void Configure(EntityTypeBuilder<TiposPropuesta> builder)
    {
        builder.HasKey(e => e.Id).HasName("tipos_propuesta_pkey");

        builder.ToTable(
            "tipos_propuesta",
            tb =>
                tb.HasComment(
                    "Catálogo de tipos de propuestas académicas. Ej: Curso, Jornada, Diplomatura, Evento."
                )
        );

        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("ID único autoincremental.")
            .UseIdentityColumn();

        builder
            .Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(20)
            .IsRequired()
            .HasComment("Código interno único.");

        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(100)
            .IsRequired()
            .HasComment("Nombre del tipo de propuesta. Ej: Curso, Jornada, Diplomatura.");

        builder
            .Property(e => e.Descripcion)
            .HasColumnName("descripcion")
            .IsRequired(false)
            .HasComment("Descripción del tipo de propuesta.");

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
            .WithOne(p => p.TipoPropuesta)
            .HasForeignKey(p => p.TipoPropuestaId)
            .OnDelete(DeleteBehavior.Restrict);

        // ÍNDICES
        builder.HasIndex(e => e.Codigo).IsUnique().HasDatabaseName("tipos_propuesta_codigo_key");

        builder.HasIndex(e => e.Nombre).IsUnique().HasDatabaseName("tipos_propuesta_nombre_key");

        builder.HasIndex(e => e.Estado).HasDatabaseName("IX_tipos_propuesta_estado");

        // Índice compuesto para búsqueda
        builder
            .HasIndex(e => new { e.Codigo, e.Nombre })
            .HasDatabaseName("IX_tipos_propuesta_codigo_nombre");
    }
}
