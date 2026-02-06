// SIGA.Persistence/Configurations/PeriodosLectivosConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class PeriodosLectivosConfiguration : IEntityTypeConfiguration<PeriodosLectivos>
{
    public void Configure(EntityTypeBuilder<PeriodosLectivos> builder)
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
            .Property(e => e.Estado)
            .HasColumnName("estado")
            .HasDefaultValue(true)
            .IsRequired(false) // Nullable
            .HasComment("Estado activo/inactivo (true=activo, false=inactivo).");

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

        // ÍNDICE UNICO
        builder.HasIndex(e => e.Codigo).IsUnique().HasDatabaseName("periodos_lectivos_codigo_key");

        // ÍNDICES adicionales
        builder.HasIndex(e => e.Estado).HasDatabaseName("IX_periodos_lectivos_estado");

        builder.HasIndex(e => e.FechaInicio).HasDatabaseName("IX_periodos_lectivos_fecha_inicio");

        builder.HasIndex(e => e.FechaFin).HasDatabaseName("IX_periodos_lectivos_fecha_fin");

        // Índice compuesto para búsqueda por rango de fechas
        builder
            .HasIndex(e => new { e.FechaInicio, e.FechaFin })
            .HasDatabaseName("IX_periodos_lectivos_rango_fechas");

        // CHECK CONSTRAINTS (si se soportan)
        // builder.HasCheckConstraint("CK_periodos_lectivos_fechas", "fecha_fin > fecha_inicio");

        // Relación inversa con Autoridades
        builder
            .HasMany(p => p.Autoridades)
            .WithOne(a => a.PeriodoLectivo)
            .HasForeignKey(a => a.PeriodoLectivoId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación inversa con Propuestas (si existe)
        // builder.HasMany(p => p.Propuestas)
        //     .WithOne(prop => prop.PeriodoLectivo)
        //     .HasForeignKey(prop => prop.PeriodoLectivoId)
        //     .OnDelete(DeleteBehavior.Restrict);
    }
}
