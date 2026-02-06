// SIGA.Persistence/Configurations/HistorialEstadoInscripcionesConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class HistorialEstadoInscripcionesConfiguration
    : IEntityTypeConfiguration<HistorialEstadoInscripciones>
{
    public void Configure(EntityTypeBuilder<HistorialEstadoInscripciones> builder)
    {
        // Tabla SIN clave primaria
        builder.HasNoKey();

        builder.ToTable("historial_estado_inscripciones");

        builder
            .Property(e => e.InscripcionId)
            .HasColumnName("inscripcion_id")
            .IsRequired()
            .HasComment("ID de la inscripción cuyo estado cambió.");

        builder
            .Property(e => e.TipoEstadoInscripcionId)
            .HasColumnName("tipo_estado_inscripcion_id")
            .IsRequired()
            .HasComment("ID del nuevo estado de la inscripción.");

        builder
            .Property(e => e.UsuarioId)
            .HasColumnName("usuario_id")
            .IsRequired(false) // Nullable
            .HasComment("ID del usuario que realizó el cambio (opcional).");

        builder
            .Property(e => e.CreadoEn)
            .HasColumnName("creado_en")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired()
            .HasComment("Fecha y hora del cambio de estado.");

        // RELACIÓN con Inscripcion
        builder
            .HasOne(d => d.Inscripcion)
            .WithMany()
            .HasForeignKey(d => d.InscripcionId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("historial_estado_inscripciones_inscripcion_id_fkey")
            .IsRequired();

        // RELACIÓN con TipoEstadoInscripcion
        builder
            .HasOne(d => d.TipoEstadoInscripcion)
            .WithMany()
            .HasForeignKey(d => d.TipoEstadoInscripcionId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("historial_estado_inscripciones_tipo_estado_inscripcion_id_fkey")
            .IsRequired();

        // RELACIÓN con Usuario
        builder
            .HasOne(d => d.Usuario)
            .WithMany()
            .HasForeignKey(d => d.UsuarioId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("historial_estado_inscripciones_usuario_id_fkey");

        // ÍNDICES
        builder
            .HasIndex(e => e.InscripcionId)
            .HasDatabaseName("IX_historial_inscripciones_inscripcion_id");

        builder.HasIndex(e => e.CreadoEn).HasDatabaseName("IX_historial_inscripciones_creado_en");

        builder
            .HasIndex(e => new { e.InscripcionId, e.CreadoEn })
            .HasDatabaseName("IX_historial_inscripciones_inscripcion_fecha")
            .IsDescending(false, true);
    }
}
