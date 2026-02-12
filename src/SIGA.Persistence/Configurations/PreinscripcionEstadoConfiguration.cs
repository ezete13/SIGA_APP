using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Infrastructure.Data.Configurations;

public class PreinscripcionEstadoConfiguration : IEntityTypeConfiguration<PreinscripcionEstado>
{
    public void Configure(EntityTypeBuilder<PreinscripcionEstado> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureRelationships(builder);
        ConfigureSeeds(builder);
    }

    private static void ConfigureTable(EntityTypeBuilder<PreinscripcionEstado> builder)
    {
        builder.ToTable(
            "preinscripcion_estados",
            "siga",
            tb => tb.HasComment("Registro principal de estados de preinscripciones")
        );

        builder.HasKey(e => e.Id).HasName("pk_preinscripcion_estado");
    }

    private static void ConfigureProperties(EntityTypeBuilder<PreinscripcionEstado> builder)
    {
        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .UseIdentityColumn()
            .HasComment("Identificador único del estado (corresponde al valor del enum).");

        builder
            .Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(50)
            .IsRequired()
            .HasComment("Código único del estado");

        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(100)
            .IsRequired()
            .HasComment("Nombre descriptivo del estado para mostrar en UI.");

        builder
            .Property(e => e.Descripcion)
            .HasColumnName("descripcion")
            .HasMaxLength(255)
            .IsRequired(false)
            .HasComment("Descripción detallada del significado del estado.");

        builder
            .Property(e => e.Activo)
            .HasColumnName("activo")
            .HasDefaultValue(true)
            .IsRequired()
            .HasComment("Indica si el estado está disponible");
    }

    private static void ConfigureIndexes(EntityTypeBuilder<PreinscripcionEstado> builder)
    {
        builder
            .HasIndex(e => e.Codigo)
            .HasDatabaseName("ix_estados_preinscripcion_codigo")
            .IsUnique();

        builder.HasIndex(e => e.Nombre).HasDatabaseName("ix_estados_preinscripcion_nombre");

        builder
            .HasIndex(e => e.Activo)
            .HasDatabaseName("ix_estados_preinscripcion_activo")
            .HasFilter("activo = 1");
    }

    private static void ConfigureRelationships(EntityTypeBuilder<PreinscripcionEstado> builder)
    {
        builder
            .HasMany(e => e.Preinscripciones)
            .WithOne(i => i.PreinscripcionEstado)
            .HasForeignKey(i => i.EstadoPreinscripcionId)
            .HasConstraintName("fk_estados_inscripcion_inscripciones")
            .OnDelete(DeleteBehavior.Restrict);
    }

    private static void ConfigureSeeds(EntityTypeBuilder<PreinscripcionEstado> builder)
    {
        // Seed data for enum values
        builder.HasData(
            new PreinscripcionEstado
            {
                Id = 1,
                Codigo = "EN_ESPERA",
                Nombre = "En Espera",
                Descripcion = "Preinscripción pendiente de revisión",
                Activo = true,
            },
            new PreinscripcionEstado
            {
                Id = 2,
                Codigo = "APROBADA",
                Nombre = "Aprobada",
                Descripcion = "Preinscripción aprobada y convertida a alumno",
                Activo = true,
            },
            new PreinscripcionEstado
            {
                Id = 3,
                Codigo = "REVOCADA",
                Nombre = "Revocada",
                Descripcion = "Preinscripción rechazada o cancelada",
                Activo = false,
            },
            new PreinscripcionEstado
            {
                Id = 4,
                Codigo = "EXPIRADA",
                Nombre = "Expirada",
                Descripcion = "Preinscripción no procesada dentro del plazo establecido",
                Activo = false,
            }
        );
    }
}
