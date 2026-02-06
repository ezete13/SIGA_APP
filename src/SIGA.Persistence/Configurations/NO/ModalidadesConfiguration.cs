// SIGA.Persistence/Configurations/ModalidadesConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class ModalidadesConfiguration : IEntityTypeConfiguration<Modalidades>
{
    public void Configure(EntityTypeBuilder<Modalidades> builder)
    {
        builder.HasKey(e => e.Id).HasName("modalidades_pkey");

        builder.ToTable(
            "modalidades",
            tb =>
                tb.HasComment(
                    "Modalidades que un curso o jornada puede tener (presencial, virtual, híbrido)."
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
            .HasMaxLength(10)
            .IsRequired()
            .HasComment("Código interno único.");

        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(50)
            .IsRequired()
            .HasComment("Nombre de la modalidad. Ej: Presencial, Virtual, Híbrido.");

        builder
            .Property(e => e.Descripcion)
            .HasColumnName("descripcion")
            .IsRequired(false) // Nullable
            .HasComment("Descripción detallada de la modalidad.");

        builder
            .Property(e => e.Estado)
            .HasColumnName("estado")
            .HasDefaultValue(true)
            .IsRequired(false) // Nullable
            .HasComment("Estado activo/inactivo (true=activa, false=inactiva).");

        builder
            .Property(e => e.CreadoEn)
            .HasColumnName("creado_en")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired(false) // Nullable
            .HasComment("Fecha y hora de creación del registro.");

        builder
            .Property(e => e.ActualizadoEn)
            .HasColumnName("actualizado_en")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired(false) // Nullable
            .HasComment("Fecha y hora de última actualización del registro.");

        // ÍNDICES UNICOS
        builder.HasIndex(e => e.Codigo).IsUnique().HasDatabaseName("modalidades_codigo_key");

        builder.HasIndex(e => e.Nombre).IsUnique().HasDatabaseName("modalidades_nombre_key");

        // ÍNDICES adicionales
        builder.HasIndex(e => e.Estado).HasDatabaseName("IX_modalidades_estado");

        // Relación inversa con Inscripciones
        builder
            .HasMany(m => m.Inscripciones)
            .WithOne(i => i.Modalidad)
            .HasForeignKey(i => i.ModalidadId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación inversa con Propuestas (si existe)
        // builder.HasMany(m => m.Propuestas)
        //     .WithOne(p => p.Modalidad)
        //     .HasForeignKey(p => p.ModalidadId)
        //     .OnDelete(DeleteBehavior.Restrict);
    }
}
