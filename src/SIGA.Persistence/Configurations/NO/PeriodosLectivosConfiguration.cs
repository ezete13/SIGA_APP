// SIGA.Persistence/Configurations/PeriodosLectivosConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class PeriodoLectivoConfiguration : IEntityTypeConfiguration<PeriodoLectivo>
{
    public void Configure(EntityTypeBuilder<PeriodoLectivo> builder)
    {
        builder.HasKey(e => e.Id).HasName("periodos_lectivos_pkey");

        builder.ToTable(
            "periodos_lectivos",
            tb =>
                tb.HasComment(
                    "Períodos lectivos institucionales para organización académica de cursos y actividades."
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
            .HasComment("Código interno único. Ej: 2024-1, 2024-2.");

        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(100)
            .IsRequired()
            .HasComment("Nombre descriptivo del período. Ej: Primer Cuatrimestre 2024.");

        builder
            .Property(e => e.FechaInicio)
            .HasColumnName("fecha_inicio")
            .IsRequired()
            .HasComment("Fecha de comienzo del ciclo lectivo.");

        builder
            .Property(e => e.FechaFin)
            .HasColumnName("fecha_fin")
            .IsRequired()
            .HasComment("Fecha de finalización del ciclo lectivo.");

        builder
            .Property(e => e.Activo)
            .HasColumnName("activo")
            .HasDefaultValue(true)
            .IsRequired(false) // Nullable
            .HasComment("Estado activo/inactivo (true=activo, false=inactivo).");

        builder.HasIndex(e => e.Codigo).IsUnique().HasDatabaseName("periodos_lectivos_codigo_key");

        builder.HasIndex(e => e.Activo).HasDatabaseName("IX_periodos_lectivos_estado");

        builder.HasIndex(e => e.FechaInicio).HasDatabaseName("IX_periodos_lectivos_fecha_inicio");

        builder.HasIndex(e => e.FechaFin).HasDatabaseName("IX_periodos_lectivos_fecha_fin");

        builder
            .HasIndex(e => new { e.FechaInicio, e.FechaFin })
            .HasDatabaseName("IX_periodos_lectivos_rango_fechas");

        builder
            .HasMany(p => p.Autoridades)
            .WithOne(a => a.PeriodoLectivo)
            .HasForeignKey(a => a.PeriodoLectivoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(p => p.Propuestas)
            .WithOne(prop => prop.PeriodoLectivo)
            .HasForeignKey(prop => prop.PeriodoLectivoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
