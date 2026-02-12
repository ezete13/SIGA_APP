using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Infrastructure.Data.Configurations;

public class AlumnoEstadoConfiguration : IEntityTypeConfiguration<AlumnoEstado>
{
    public void Configure(EntityTypeBuilder<AlumnoEstado> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureSeeds(builder);
    }

    private static void ConfigureTable(EntityTypeBuilder<AlumnoEstado> builder)
    {
        builder.ToTable(
            "alumno_estados",
            "siga",
            tb => tb.HasComment("Registro principal de estados de alumnos")
        );

        builder.HasKey(e => e.Id).HasName("pk_alumno_estado");
    }

    private static void ConfigureProperties(EntityTypeBuilder<AlumnoEstado> builder)
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

    private static void ConfigureIndexes(EntityTypeBuilder<AlumnoEstado> builder)
    {
        builder.HasIndex(e => e.Codigo).HasDatabaseName("ix_estados_alumno_codigo").IsUnique();

        builder.HasIndex(e => e.Nombre).HasDatabaseName("ix_estados_alumno_nombre");

        builder
            .HasIndex(e => e.Activo)
            .HasDatabaseName("ix_estados_alumno_activo")
            .HasFilter("activo = 1");
    }

    private static void ConfigureRelationships(EntityTypeBuilder<AlumnoEstado> builder)
    {
        builder
            .HasMany(e => e.Alumnos)
            .WithOne(i => i.AlumnoEstado)
            .HasForeignKey(i => i.AlumnoEstadoId)
            .HasConstraintName("fk_estados_inscripcion_inscripciones")
            .OnDelete(DeleteBehavior.Restrict);
    }

    private static void ConfigureSeeds(EntityTypeBuilder<AlumnoEstado> builder)
    {
        builder.HasData(
            new PreinscripcionEstado
            {
                Id = 1,
                Codigo = "ACTIVO",
                Nombre = "Activo",
                Descripcion = "Alumno con al menos una inscripción activa",
                Activo = true,
            },
            new PreinscripcionEstado
            {
                Id = 2,
                Codigo = "INACTIVO",
                Nombre = "Inactivo",
                Descripcion = "Alumno con ninguna inscripción activa",
                Activo = true,
            },
            new PreinscripcionEstado
            {
                Id = 3,
                Codigo = "BLOQUEADO",
                Nombre = "Bloqueado",
                Descripcion = "Alumno que no puede obtener ninguna inscripción",
                Activo = false,
            },
            new PreinscripcionEstado
            {
                Id = 4,
                Codigo = "SUSPENDIDO",
                Nombre = "Suspendido",
                Descripcion = "Alumno suspendido temporalmente",
                Activo = false,
            }
        );
    }
}
