using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities.Catalog.Dynamic;

namespace SIGA.Infrastructure.Data.Configurations;

public class ModalidadConfiguration : IEntityTypeConfiguration<Modalidad>
{
    public void Configure(EntityTypeBuilder<Modalidad> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureRelationships(builder);
        ConfigureSeeds(builder);
    }

    private static void ConfigureTable(EntityTypeBuilder<Modalidad> builder)
    {
        builder.ToTable(
            "modalidades",
            "siga",
            tb => tb.HasComment("Catálogo de modalidades de cursado disponibles para propuestas")
        );

        builder.HasKey(e => e.Id).HasName("pk_modalidad");
    }

    private static void ConfigureProperties(EntityTypeBuilder<Modalidad> builder)
    {
        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .UseIdentityColumn()
            .HasComment("Identificador único de la modalidad");

        builder
            .Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(50)
            .IsRequired()
            .HasComment("Código único de la modalidad (PRE, DIS, SEM, ELE, etc.)");

        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(100)
            .IsRequired()
            .HasComment("Nombre descriptivo de la modalidad para mostrar en UI");

        builder
            .Property(e => e.Descripcion)
            .HasColumnName("descripcion")
            .HasMaxLength(500)
            .IsRequired(false)
            .HasComment("Descripción detallada de la modalidad y sus características");

        builder
            .Property(e => e.Activo)
            .HasColumnName("activo")
            .HasDefaultValue(true)
            .IsRequired()
            .HasComment("Indica si la modalidad está disponible para uso");
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Modalidad> builder)
    {
        builder.HasIndex(e => e.Codigo).HasDatabaseName("ix_modalidades_codigo").IsUnique();

        builder.HasIndex(e => e.Nombre).HasDatabaseName("ix_modalidades_nombre");

        builder
            .HasIndex(e => e.Activo)
            .HasDatabaseName("ix_modalidades_activo")
            .HasFilter("activo = true");
    }

    private static void ConfigureRelationships(EntityTypeBuilder<Modalidad> builder)
    {
        builder
            .HasMany(e => e.Propuestas)
            .WithOne(i => i.Modalidad)
            .HasForeignKey(i => i.ModalidadId)
            .HasConstraintName("fk_modalidades_propuestas")
            .OnDelete(DeleteBehavior.Restrict);
    }

    private static void ConfigureSeeds(EntityTypeBuilder<Modalidad> builder)
    {
        builder.HasData(
            new Modalidad
            {
                Id = 1,
                Codigo = "PRE",
                Nombre = "Presencial",
                Descripcion =
                    "Clases 100% en sede física con asistencia obligatoria a todas las actividades académicas",
                Activo = true,
            },
            new Modalidad
            {
                Id = 2,
                Codigo = "DIS",
                Nombre = "A Distancia",
                Descripcion =
                    "Clases 100% en línea sin requerimiento de presencia física, utilizando plataformas digitales",
                Activo = true,
            },
            new Modalidad
            {
                Id = 3,
                Codigo = "SEM",
                Nombre = "Semipresencial",
                Descripcion =
                    "Modalidad con mayor porcentaje virtual complementado con sesiones presenciales obligatorias específicas",
                Activo = true,
            },
            new Modalidad
            {
                Id = 4,
                Codigo = "ELE",
                Nombre = "A Elección",
                Descripcion =
                    "El estudiante puede elegir entre asistir presencialmente o seguir virtualmente cada clase según su preferencia",
                Activo = true,
            }
        );
    }
}
