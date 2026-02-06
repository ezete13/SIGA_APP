// SIGA.Persistence/Configurations/TiposEstadoInscripcionConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class TiposEstadoInscripcionConfiguration : IEntityTypeConfiguration<TiposEstadoInscripcion>
{
    public void Configure(EntityTypeBuilder<TiposEstadoInscripcion> builder)
    {
        builder.HasKey(e => e.Id).HasName("tipos_estado_inscripcion_pkey");

        builder.ToTable(
            "tipos_estado_inscripcion",
            tb => tb.HasComment("Catálogo de posibles estados que puede tener una inscripción.")
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
            .HasComment("Nombre del estado. Ej: Preinscripto, Confirmado, Aprobado.");

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
            .HasMany(t => t.Inscripciones)
            .WithOne(i => i.TipoEstadoInscripcion)
            .HasForeignKey(i => i.TipoEstadoInscripcionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(t => t.HistorialEstadoInscripciones)
            .WithOne(h => h.TipoEstadoInscripcion)
            .HasForeignKey(h => h.TipoEstadoInscripcionId)
            .OnDelete(DeleteBehavior.Restrict);

        // ÍNDICES
        builder
            .HasIndex(e => e.Codigo)
            .IsUnique()
            .HasDatabaseName("tipos_estado_inscripcion_codigo_key");

        builder.HasIndex(e => e.Estado).HasDatabaseName("IX_tipos_estado_inscripcion_estado");

        builder.HasIndex(e => e.Nombre).HasDatabaseName("IX_tipos_estado_inscripcion_nombre");
    }
}
