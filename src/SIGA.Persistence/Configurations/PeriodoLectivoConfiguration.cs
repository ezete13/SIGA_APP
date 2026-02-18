using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities.Catalog.Dynamic;

namespace SIGA.Infrastructure.Data.Configurations;

public class PeriodoLectivoConfiguration : IEntityTypeConfiguration<PeriodoLectivo>
{
    public void Configure(EntityTypeBuilder<PeriodoLectivo> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureRelationships(builder);
        ConfigureSeeds(builder);
    }

    private static void ConfigureTable(EntityTypeBuilder<PeriodoLectivo> builder)
    {
        builder.ToTable(
            "periodos_lectivos",
            "siga",
            tb => tb.HasComment("Períodos lectivos académicos (semestres, anuales, etc.)")
        );

        builder.HasKey(e => e.Id).HasName("pk_periodo_lectivo");
    }

    private static void ConfigureProperties(EntityTypeBuilder<PeriodoLectivo> builder)
    {
        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .UseIdentityColumn()
            .HasComment("Identificador único del período lectivo");

        builder
            .Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(50)
            .IsRequired()
            .HasComment("Código único del período lectivo (24S1, 25AN, etc.)");

        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(100)
            .IsRequired()
            .HasComment("Nombre descriptivo del período lectivo para mostrar en UI");

        builder
            .Property(e => e.Descripcion)
            .HasColumnName("descripcion")
            .HasMaxLength(255)
            .IsRequired(false)
            .HasComment("Descripción adicional del período lectivo");

        builder
            .Property(e => e.FechaInicio)
            .HasColumnName("fecha_inicio")
            .HasColumnType("date")
            .IsRequired()
            .HasComment("Fecha de inicio del período lectivo");

        builder
            .Property(e => e.FechaFin)
            .HasColumnName("fecha_fin")
            .HasColumnType("date")
            .IsRequired()
            .HasComment("Fecha de finalización del período lectivo");

        builder
            .Property(e => e.Activo)
            .HasColumnName("activo")
            .HasDefaultValue(true)
            .IsRequired()
            .HasComment("Indica si el período lectivo está disponible para uso");
    }

    private static void ConfigureIndexes(EntityTypeBuilder<PeriodoLectivo> builder)
    {
        builder.HasIndex(e => e.Codigo).HasDatabaseName("ix_periodos_lectivos_codigo").IsUnique();

        builder.HasIndex(e => e.Nombre).HasDatabaseName("ix_periodos_lectivos_nombre");

        builder
            .HasIndex(e => e.Activo)
            .HasDatabaseName("ix_periodos_lectivos_activo")
            .HasFilter("activo = true");

        builder
            .HasIndex(e => new { e.FechaInicio, e.FechaFin })
            .HasDatabaseName("ix_periodos_lectivos_fechas");
    }

    private static void ConfigureRelationships(EntityTypeBuilder<PeriodoLectivo> builder)
    {
        builder
            .HasMany(e => e.Autoridades)
            .WithOne(i => i.PeriodoLectivo)
            .HasForeignKey(i => i.PeriodoLectivoId)
            .HasConstraintName("fk_periodos_lectivos_autoridades")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(e => e.Propuestas)
            .WithOne(i => i.PeriodoLectivo)
            .HasForeignKey(i => i.PeriodoLectivoId)
            .HasConstraintName("fk_periodos_lectivos_propuestas")
            .OnDelete(DeleteBehavior.Restrict);
    }

    private static void ConfigureSeeds(EntityTypeBuilder<PeriodoLectivo> builder)
    {
        builder.HasData(
            new PeriodoLectivo
            {
                Id = 1,
                Codigo = "24S1",
                Nombre = "Primer Semestre 2024",
                Descripcion = "",
                FechaInicio = new DateOnly(2024, 3, 1),
                FechaFin = new DateOnly(2024, 6, 30),
                Activo = true,
            },
            new PeriodoLectivo
            {
                Id = 2,
                Codigo = "24S2",
                Nombre = "Segundo Semestre 2024",
                Descripcion = "",
                FechaInicio = new DateOnly(2024, 8, 1),
                FechaFin = new DateOnly(2024, 11, 30),
                Activo = true,
            },
            new PeriodoLectivo
            {
                Id = 3,
                Codigo = "25S1",
                Nombre = "Primer Semestre 2025",
                Descripcion = "",
                FechaInicio = new DateOnly(2025, 3, 1),
                FechaFin = new DateOnly(2025, 6, 30),
                Activo = true,
            },
            new PeriodoLectivo
            {
                Id = 4,
                Codigo = "25S2",
                Nombre = "Segundo Semestre 2025",
                Descripcion = "",
                FechaInicio = new DateOnly(2025, 8, 1),
                FechaFin = new DateOnly(2025, 11, 30),
                Activo = true,
            },
            new PeriodoLectivo
            {
                Id = 5,
                Codigo = "24AN",
                Nombre = "Ciclo Anual 2024",
                Descripcion = "",
                FechaInicio = new DateOnly(2024, 3, 1),
                FechaFin = new DateOnly(2024, 11, 30),
                Activo = true,
            },
            new PeriodoLectivo
            {
                Id = 6,
                Codigo = "25AN",
                Nombre = "Ciclo Anual 2025",
                Descripcion = "",
                FechaInicio = new DateOnly(2025, 3, 1),
                FechaFin = new DateOnly(2025, 11, 30),
                Activo = true,
            }
        );
    }
}
