using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities.Catalog.Static;

namespace SIGA.Infrastructure.Data.Configurations;

public class InscripcionEstadoConfiguration : IEntityTypeConfiguration<InscripcionEstado>
{
    public void Configure(EntityTypeBuilder<InscripcionEstado> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureRelationships(builder);
        SeedData(builder);
    }

    private static void ConfigureTable(EntityTypeBuilder<InscripcionEstado> builder)
    {
        builder.ToTable(
            "estado_inscripcion",
            "siga",
            tb => tb.HasComment("Catálogo de estados posibles para una inscripción")
        );

        builder.HasKey(e => e.Id).HasName("pk_estado_inscripcion");
    }

    private static void ConfigureProperties(EntityTypeBuilder<InscripcionEstado> builder)
    {
        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedNever()
            .HasComment("Identificador único del estado de inscripción.");

        builder
            .Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(50)
            .IsRequired()
            .HasComment("Código único del estado (ACTIVA, FINALIZADA, BAJA).");

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
            .HasComment("Indica si el estado está disponible para uso.");
    }

    private static void ConfigureIndexes(EntityTypeBuilder<InscripcionEstado> builder)
    {
        builder.HasIndex(e => e.Codigo).HasDatabaseName("ix_estados_inscripcion_codigo").IsUnique();

        builder.HasIndex(e => e.Nombre).HasDatabaseName("ix_estados_inscripcion_nombre");

        builder
            .HasIndex(e => e.Activo)
            .HasDatabaseName("ix_estados_inscripcion_activo")
            .HasFilter("activo = true");
    }

    private static void ConfigureRelationships(EntityTypeBuilder<InscripcionEstado> builder)
    {
        builder
            .HasMany(e => e.Inscripciones)
            .WithOne(i => i.InscripcionEstado)
            .HasForeignKey(i => i.InscripcionEstadoId)
            .HasConstraintName("fk_estados_inscripcion_inscripciones")
            .OnDelete(DeleteBehavior.Restrict);
    }

    private static void SeedData(EntityTypeBuilder<InscripcionEstado> builder)
    {
        builder.HasData(
            new InscripcionEstado
            {
                Id = 1,
                Codigo = "ACT",
                Nombre = "Activa",
                Descripcion = "Inscripción vigente con cursada regular",
                Activo = true,
            },
            new InscripcionEstado
            {
                Id = 2,
                Codigo = "FIN",
                Nombre = "Finalizada",
                Descripcion = "Inscripción completada exitosamente",
                Activo = true,
            },
            new InscripcionEstado
            {
                Id = 3,
                Codigo = "BAJA",
                Nombre = "Baja",
                Descripcion = "Inscripción cancelada por el alumno o la institución",
                Activo = true,
            }
        );
    }
}
