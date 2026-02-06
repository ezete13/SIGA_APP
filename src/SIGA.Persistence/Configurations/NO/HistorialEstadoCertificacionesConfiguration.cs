// SIGA.Persistence/Configurations/HistorialEstadoCertificacionesConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class HistorialEstadoCertificacionesConfiguration
    : IEntityTypeConfiguration<HistorialEstadoCertificaciones>
{
    public void Configure(EntityTypeBuilder<HistorialEstadoCertificaciones> builder)
    {
        // Tabla SIN clave primaria (historial de solo lectura)
        builder.HasNoKey();

        builder.ToTable("historial_estado_certificaciones");

        builder
            .Property(e => e.CertificacionId)
            .HasColumnName("certificacion_id")
            .IsRequired()
            .HasComment("ID de la certificación cuyo estado cambió.");

        builder
            .Property(e => e.TipoEstadoCertificadoId)
            .HasColumnName("tipo_estado_certificado_id")
            .IsRequired()
            .HasComment("ID del nuevo estado de la certificación.");

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

        // RELACIÓN con Certificacion
        builder
            .HasOne(d => d.Certificacion)
            .WithMany()
            .HasForeignKey(d => d.CertificacionId)
            .OnDelete(DeleteBehavior.Cascade) // Si eliminas certificación, elimina su historial
            .HasConstraintName("historial_estado_certificaciones_certificacion_id_fkey")
            .IsRequired();

        // RELACIÓN con TipoEstadoCertificado
        builder
            .HasOne(d => d.TipoEstadoCertificado)
            .WithMany()
            .HasForeignKey(d => d.TipoEstadoCertificadoId)
            .OnDelete(DeleteBehavior.Restrict) // No eliminar estado si está en historial
            .HasConstraintName("historial_estado_certificacione_tipo_estado_certificado_id_fkey")
            .IsRequired();

        // RELACIÓN con Usuario
        builder
            .HasOne(d => d.Usuario)
            .WithMany()
            .HasForeignKey(d => d.UsuarioId)
            .OnDelete(DeleteBehavior.SetNull) // Si eliminas usuario, mantén historial
            .HasConstraintName("historial_estado_certificaciones_usuario_id_fkey");

        // ÍNDICES para consultas eficientes
        builder
            .HasIndex(e => e.CertificacionId)
            .HasDatabaseName("IX_historial_certificaciones_certificacion_id");

        builder.HasIndex(e => e.CreadoEn).HasDatabaseName("IX_historial_certificaciones_creado_en");

        builder
            .HasIndex(e => new { e.CertificacionId, e.CreadoEn })
            .HasDatabaseName("IX_historial_certificaciones_certificacion_fecha")
            .IsDescending(false, true); // Ordenado por fecha descendente
    }
}
