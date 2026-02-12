using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Infrastructure.Data.Configurations;

public class PreinscripcionConfiguration : IEntityTypeConfiguration<Preinscripcion>
{
    public void Configure(EntityTypeBuilder<Preinscripcion> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureRelationships(builder);
    }

    private static void ConfigureTable(EntityTypeBuilder<Preinscripcion> builder)
    {
        builder.ToTable(
            "preinscripcion",
            "siga",
            tb => tb.HasComment("Registro principal de preinscripciones a propuestas")
        );

        builder.HasKey(e => e.Id).HasName("pk_preinscripcion");
    }

    private static void ConfigureProperties(EntityTypeBuilder<Preinscripcion> builder)
    {
        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .UseIdentityColumn()
            .HasComment("Identificador único");

        builder
            .Property(e => e.Uuid)
            .HasColumnName("uuid")
            .HasDefaultValueSql("NEWID()")
            .IsRequired()
            .HasComment("Identificador único universal para la preinscripción.");

        builder
            .Property(e => e.AlumnoId)
            .HasColumnName("alumno_id")
            .IsRequired(false)
            .HasComment("ID del alumno asociado cuando la preinscripción es aprobada.");

        builder
            .Property(e => e.PropuestaId)
            .HasColumnName("propuesta_id")
            .IsRequired()
            .HasComment("ID de la propuesta educativa a la que se preinscribe.");

        builder
            .Property(e => e.EstadoPreinscripcionId)
            .HasColumnName("estado_preinscripcion_id")
            .IsRequired()
            .HasComment("ID del estado actual de la preinscripción.");

        builder
            .Property(e => e.Documento)
            .HasColumnName("documento")
            .HasMaxLength(20)
            .IsRequired()
            .HasComment("Número de documento del preinscripto.");

        builder
            .Property(e => e.Apellido)
            .HasColumnName("apellido")
            .HasMaxLength(100)
            .IsRequired()
            .HasComment("Apellido del preinscripto.");

        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(100)
            .IsRequired()
            .HasComment("Nombre del preinscripto.");

        builder
            .Property(e => e.Email)
            .HasColumnName("email")
            .HasMaxLength(200)
            .IsRequired()
            .HasComment("Correo electrónico del preinscripto.");

        builder
            .Property(e => e.Telefono)
            .HasColumnName("telefono")
            .HasMaxLength(50)
            .IsRequired(false)
            .HasComment("Teléfono de contacto del preinscripto.");

        builder
            .Property(e => e.Observaciones)
            .HasColumnName("observaciones")
            .HasMaxLength(500)
            .IsRequired(false)
            .HasComment("Observaciones o motivo de revocación.");

        builder
            .Property(e => e.CreadoEn)
            .HasColumnName("creado_en")
            .HasColumnType("datetime2")
            .HasDefaultValueSql("GETUTCDATE()")
            .IsRequired()
            .HasComment("Fecha y hora UTC de creación de la preinscripción.");

        builder
            .Property(e => e.ActualizadoEn)
            .HasColumnName("actualizado_en")
            .HasColumnType("datetime2")
            .IsRequired(false)
            .HasComment("Fecha y hora UTC de la última actualización.");
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Preinscripcion> builder)
    {
        // Indexes
        builder.HasIndex(e => e.Uuid).HasDatabaseName("ix_preinscripciones_uuid").IsUnique();

        builder.HasIndex(e => e.Documento).HasDatabaseName("ix_preinscripciones_documento");

        builder
            .HasIndex(e => new { e.PropuestaId, e.EstadoPreinscripcionId })
            .HasDatabaseName("ix_preinscripciones_propuesta_estado");

        builder.HasIndex(e => e.CreadoEn).HasDatabaseName("ix_preinscripciones_creado_en");

        builder.HasIndex(e => e.Email).HasDatabaseName("ix_preinscripciones_email");

        builder
            .HasIndex(e => new { e.Documento, e.PropuestaId })
            .HasDatabaseName("ix_preinscripciones_documento_propuesta")
            .IsUnique()
            .HasFilter("estado_preinscripcion_id IN (1,2)"); // Only active states (EnEspera, Aprobada)
    }

    private static void ConfigureRelationships(EntityTypeBuilder<Preinscripcion> builder)
    {
        // Relación con Propuesta (una propuesta tiene muchas preinscripciones)
        builder
            .HasOne(e => e.Propuesta)
            .WithMany(p => p.Preinscripciones) // Asumiendo que Propuesta tiene ICollection<Preinscripcion>
            .HasForeignKey(e => e.PropuestaId)
            .HasConstraintName("fk_preinscripciones_propuestas_propuesta_id")
            .OnDelete(DeleteBehavior.Restrict);

        // Relación con EstadoPreinscripcion (un estado tiene muchas preinscripciones)
        builder
            .HasOne(e => e.PreinscripcionEstado)
            .WithMany(e => e.Preinscripciones)
            .HasForeignKey(e => e.EstadoPreinscripcionId)
            .HasConstraintName("fk_preinscripciones_estados_preinscripcion_estado_id")
            .OnDelete(DeleteBehavior.Restrict);

        // Relación con Alumno (opcional - un alumno puede tener muchas preinscripciones)
        builder
            .HasOne(e => e.Alumno)
            .WithMany(a => a.Preinscripciones)
            .HasForeignKey(e => e.AlumnoId)
            .HasConstraintName("fk_preinscripciones_alumnos_alumno_id")
            .OnDelete(DeleteBehavior.SetNull); // Si se elimina el alumno, conservamos la preinscripción

        // Relación uno a uno con Inscripcion (una preinscripción aprobada genera una inscripción)
        builder
            .HasOne(e => e.Inscripcion)
            .WithOne(i => i.Preinscripcion)
            .HasForeignKey<Inscripcion>(i => i.PreinscripcionId)
            .HasConstraintName("fk_preinscripciones_inscripciones_inscripcion_id")
            .OnDelete(DeleteBehavior.Restrict); // No permitir eliminar preinscripciones con inscripciones asociadas
    }
}
