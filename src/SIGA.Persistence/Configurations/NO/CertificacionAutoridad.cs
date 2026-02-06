using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class CertificacionAutoridadConfiguration : IEntityTypeConfiguration<CertificacionAutoridad>
{
    public void Configure(EntityTypeBuilder<CertificacionAutoridad> builder)
    {
        builder.HasKey(e => e.Id).HasName("certificacion_autoridad_pkey");

        builder.ToTable(
            "certificacion_autoridad",
            tb =>
                tb.HasComment(
                    "Relación muchos a muchos entre certificaciones y autoridades que las firman. Define el orden de firma."
                )
        );

        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("ID único autoincremental.")
            .UseIdentityColumn();

        builder
            .Property(e => e.CertificacionId)
            .HasColumnName("certificacion_id")
            .IsRequired()
            .HasComment("ID de la certificación (FK a certificacion.id).");

        builder
            .Property(e => e.AutoridadId)
            .HasColumnName("autoridad_id")
            .IsRequired()
            .HasComment("ID de la autoridad que firma (FK a autoridad.id).");

        builder
            .Property(e => e.Orden)
            .HasColumnName("orden")
            .HasDefaultValue(0)
            .IsRequired()
            .HasComment("Orden de firma (0=primero, 1=segundo, etc.).");

        builder
            .Property(e => e.CreadoEn)
            .HasColumnName("creado_en")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired(false) // Nullable
            .HasComment("Fecha y hora de creación del registro.");

        // RELACIÓN con Certificacion
        builder
            .HasOne(d => d.Certificacion)
            .WithMany(p => p.CertificacionAutoridad)
            .HasForeignKey(d => d.CertificacionId)
            .OnDelete(DeleteBehavior.Cascade) // Si eliminas certificación, elimina esta relación
            .HasConstraintName("certificacion_autoridad_certificacion_id_fkey")
            .IsRequired();

        // RELACIÓN con Autoridad
        builder
            .HasOne(d => d.Autoridad)
            .WithMany(p => p.CertificacionAutoridad)
            .HasForeignKey(d => d.AutoridadId)
            .OnDelete(DeleteBehavior.Restrict) // No eliminar autoridad si tiene certificaciones
            .HasConstraintName("certificacion_autoridad_autoridad_id_fkey")
            .IsRequired();

        // ÍNDICES
        builder
            .HasIndex(e => e.CertificacionId)
            .HasDatabaseName("IX_certificacion_autoridad_certificacion_id");

        builder
            .HasIndex(e => e.AutoridadId)
            .HasDatabaseName("IX_certificacion_autoridad_autoridad_id");

        builder.HasIndex(e => e.Orden).HasDatabaseName("IX_certificacion_autoridad_orden");

        // Índice UNICO para evitar duplicados (una autoridad no puede firmar 2 veces la misma certificación)
        builder
            .HasIndex(e => new { e.CertificacionId, e.AutoridadId })
            .IsUnique()
            .HasDatabaseName("UQ_certificacion_autoridad_certificacion_autoridad");

        // Índice para orden dentro de cada certificación
        builder
            .HasIndex(e => new { e.CertificacionId, e.Orden })
            .IsUnique() // Un orden único por certificación
            .HasDatabaseName("UQ_certificacion_autoridad_certificacion_orden");
    }
}
