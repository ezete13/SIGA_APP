using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Infrastructure.Data.Configurations;

public class InscripcionConfiguration : IEntityTypeConfiguration<Inscripcion>
{
    public void Configure(EntityTypeBuilder<Inscripcion> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureRelationships(builder);
    }

    private static void ConfigureTable(EntityTypeBuilder<Inscripcion> builder)
    {
        builder.ToTable(
            "inscripcion",
            "siga",
            tb =>
                tb.HasComment(
                    "Registro de inscripciones definitivas de alumnos a propuestas educativas"
                )
        );

        builder.HasKey(e => e.Id).HasName("pk_inscripcion");
    }

    private static void ConfigureProperties(EntityTypeBuilder<Inscripcion> builder)
    {
        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .UseIdentityColumn()
            .HasComment("Identificador único de la inscripción.");

        builder
            .Property(e => e.Uuid)
            .HasColumnName("uuid")
            .HasDefaultValueSql("NEWID()")
            .IsRequired()
            .HasComment("Identificador único universal para exposición pública.");

        builder
            .Property(e => e.AlumnoId)
            .HasColumnName("alumno_id")
            .IsRequired()
            .HasComment("ID del alumno que se inscribe.");

        builder
            .Property(e => e.PropuestaId)
            .HasColumnName("propuesta_id")
            .IsRequired()
            .HasComment("ID de la propuesta educativa a la que se inscribe.");

        builder
            .Property(e => e.InscripcionEstadoId)
            .HasColumnName("inscripcion_estado_id")
            .IsRequired()
            .HasComment("ID del estado actual de la inscripción (Activa, Finalizada, Baja).");

        builder
            .Property(e => e.PreinscripcionId)
            .HasColumnName("preinscripcion_id")
            .IsRequired(false)
            .HasComment("ID de la preinscripción que dio origen a esta inscripción.");

        builder
            .Property(e => e.FechaInscripcion)
            .HasColumnName("fecha_inscripcion")
            .HasColumnType("datetime2")
            .IsRequired()
            .HasComment("Fecha y hora UTC en que se realizó la inscripción.");

        builder
            .Property(e => e.EsBaja)
            .HasColumnName("es_baja")
            .IsRequired()
            .HasDefaultValue(false)
            .HasComment("Indica si la inscripción fue dada de baja.");

        builder
            .Property(e => e.FechaBaja)
            .HasColumnName("fecha_baja")
            .HasColumnType("datetime2")
            .IsRequired(false)
            .HasComment("Fecha y hora UTC en que se dio de baja la inscripción.");

        builder
            .Property(e => e.MotivoBaja)
            .HasColumnName("motivo_baja")
            .HasMaxLength(500)
            .IsRequired(false)
            .HasComment("Motivo por el cual se dio de baja la inscripción.");

        builder
            .Property(e => e.CreadoEn)
            .HasColumnName("creado_en")
            .HasColumnType("datetime2")
            .HasDefaultValueSql("GETUTCDATE()")
            .IsRequired()
            .HasComment("Fecha y hora UTC de creación del registro.");

        builder
            .Property(e => e.ActualizadoEn)
            .HasColumnName("actualizado_en")
            .HasColumnType("datetime2")
            .IsRequired(false)
            .HasComment("Fecha y hora UTC de la última actualización.");
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Inscripcion> builder)
    {
        // Índice único para UUID
        builder.HasIndex(e => e.Uuid).HasDatabaseName("ix_inscripciones_uuid").IsUnique();

        // Índice compuesto para búsqueda por alumno y propuesta
        builder
            .HasIndex(e => new { e.AlumnoId, e.PropuestaId })
            .HasDatabaseName("ix_inscripciones_alumno_propuesta")
            .IsUnique(); // Un alumno no puede inscribirse dos veces a la misma propuesta

        // Índice para búsqueda por estado
        builder.HasIndex(e => e.InscripcionEstadoId).HasDatabaseName("ix_inscripciones_estado_id");

        // Índice para búsqueda por preinscripción
        builder
            .HasIndex(e => e.PreinscripcionId)
            .HasDatabaseName("ix_inscripciones_preinscripcion_id")
            .IsUnique()
            .HasFilter("preinscripcion_id IS NOT NULL"); // Una preinscripción solo genera una inscripción

        // Índice para búsqueda por fecha de inscripción
        builder
            .HasIndex(e => e.FechaInscripcion)
            .HasDatabaseName("ix_inscripciones_fecha_inscripcion");

        // Índice para búsqueda de bajas
        builder
            .HasIndex(e => new { e.EsBaja, e.FechaBaja })
            .HasDatabaseName("ix_inscripciones_bajas")
            .HasFilter("es_baja = 1");

        // Índice compuesto para vigencia (estado Activa)
        builder
            .HasIndex(e => new { e.AlumnoId, e.InscripcionEstadoId })
            .HasDatabaseName("ix_inscripciones_alumno_vigente")
            .HasFilter("inscripcion_estado_id = 1"); // Solo inscripciones activas
    }

    private static void ConfigureRelationships(EntityTypeBuilder<Inscripcion> builder)
    {
        // Relación con Alumno
        builder
            .HasOne(e => e.Alumno)
            .WithMany(a => a.Inscripciones)
            .HasForeignKey(e => e.AlumnoId)
            .HasConstraintName("fk_inscripciones_alumnos_alumno_id")
            .OnDelete(DeleteBehavior.Restrict); // No permitir eliminar alumnos con inscripciones

        // Relación con Propuesta
        builder
            .HasOne(e => e.Propuesta)
            .WithMany(p => p.Inscripciones)
            .HasForeignKey(e => e.PropuestaId)
            .HasConstraintName("fk_inscripciones_propuestas_propuesta_id")
            .OnDelete(DeleteBehavior.Restrict); // No permitir eliminar propuestas con inscripciones

        // Relación con EstadoInscripcion
        builder
            .HasOne(e => e.InscripcionEstado)
            .WithMany(ei => ei.Inscripciones)
            .HasForeignKey(e => e.InscripcionEstadoId)
            .HasConstraintName("fk_inscripciones_estados_inscripcion_estado_id")
            .OnDelete(DeleteBehavior.Restrict);

        // Relación con Preinscripcion (opcional)
        builder
            .HasOne(e => e.Preinscripcion)
            .WithOne(p => p.Inscripcion) // Asumiendo que Preinscripcion tiene propiedad de navegación Inscripcion
            .HasForeignKey<Inscripcion>(e => e.PreinscripcionId)
            .HasConstraintName("fk_inscripciones_preinscripciones_preinscripcion_id")
            .OnDelete(DeleteBehavior.Restrict); // No permitir eliminar preinscripciones con inscripciones
    }
}
