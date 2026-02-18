using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities.Catalog.Static;

namespace SIGA.Infrastructure.Data.Configurations;

public class PropuestaEstadoConfiguration : IEntityTypeConfiguration<PropuestaEstado>
{
    public void Configure(EntityTypeBuilder<PropuestaEstado> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureRelationships(builder);
        ConfigureSeeds(builder);
    }

    private static void ConfigureTable(EntityTypeBuilder<PropuestaEstado> builder)
    {
        builder.ToTable(
            "propuesta_estados",
            "siga",
            tb => tb.HasComment("Registro principal de estados de Propuestas")
        );

        builder.HasKey(e => e.Id).HasName("pk_propuesta_estado");
    }

    private static void ConfigureProperties(EntityTypeBuilder<PropuestaEstado> builder)
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

    private static void ConfigureIndexes(EntityTypeBuilder<PropuestaEstado> builder)
    {
        builder.HasIndex(e => e.Codigo).HasDatabaseName("ix_estados_propuesta_codigo").IsUnique();

        builder.HasIndex(e => e.Nombre).HasDatabaseName("ix_estados_propuesta_nombre");

        builder
            .HasIndex(e => e.Activo)
            .HasDatabaseName("ix_estados_propuesta_activo")
            .HasFilter("activo = true");
    }

    private static void ConfigureRelationships(EntityTypeBuilder<PropuestaEstado> builder)
    {
        builder
            .HasMany(e => e.Propuestas)
            .WithOne(i => i.PropuestaEstado)
            .HasForeignKey(i => i.EstadoPropuestaId)
            .HasConstraintName("fk_estados_propuesta_propuestas")
            .OnDelete(DeleteBehavior.Restrict);
    }

    private static void ConfigureSeeds(EntityTypeBuilder<PropuestaEstado> builder)
    {
        // Seed data for enum values
        builder.HasData(
            new PropuestaEstado
            {
                Id = 1,
                Codigo = "BOR",
                Nombre = "Borrador",
                Descripcion = "Propuesta provisoria no disponible para inscripción",
                Activo = true,
            },
            new PropuestaEstado
            {
                Id = 2,
                Codigo = "PUB",
                Nombre = "Publicada",
                Descripcion = "Propuesta disponible para inscripcion y vista web",
                Activo = true,
            },
            new PropuestaEstado
            {
                Id = 3,
                Codigo = "ARCH",
                Nombre = "Archivada",
                Descripcion =
                    "Propuesta no permite vista web ni inscripciones. Vale para certificados",
                Activo = false,
            }
        );
    }
}
