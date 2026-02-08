using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class CertificadoConfiguration : IEntityTypeConfiguration<Certificado>
{
    public void Configure(EntityTypeBuilder<Certificado> builder)
    {
        builder.HasKey(e => e.Id).HasName("certificados_pkey");

        builder.ToTable(
            "certificados",
            tb =>
                tb.HasComment(
                    "Registro principal de certificados emitidos con control de versiones."
                )
        );

        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("ID único autoincremental.")
            .UseIdentityColumn();

        builder
            .Property(e => e.Uuid)
            .HasColumnName("uuid")
            .HasDefaultValueSql("gen_random_uuid()")
            .IsRequired()
            .HasComment("UUID4 único para identificación universal.");

        builder
            .Property(e => e.Token)
            .HasColumnName("token")
            .HasMaxLength(100)
            .IsRequired()
            .HasComment("Token único para validación y acceso público.");

        builder
            .Property(e => e.InscripcionId)
            .HasColumnName("inscripcion_id")
            .IsRequired()
            .HasComment("ID de la inscripción certificada (FK a inscripcion.id).");

        builder
            .Property(e => e.TipoEstadoCertificadoId)
            .HasColumnName("tipo_estado_certificado_id")
            .IsRequired()
            .HasComment("ID del estado del certificado (FK a tipo_estado_certificado.id).");

        builder
            .Property(e => e.Version)
            .HasColumnName("version")
            .HasDefaultValue(1)
            .IsRequired()
            .HasComment("Número de versión del certificado.");

        builder
            .Property(e => e.EsVersionActual)
            .HasColumnName("es_version_actual")
            .HasDefaultValue(true)
            .IsRequired()
            .HasComment("Indica si esta es la versión actual del certificado.");

        builder
            .Property(e => e.HashSeguridad)
            .HasColumnName("hash_seguridad")
            .HasMaxLength(256)
            .IsRequired()
            .HasComment("Hash de seguridad que se regenera en cada versión.");

        builder
            .Property(e => e.TituloCertificado)
            .HasColumnName("titulo_certificado")
            .HasMaxLength(200)
            .IsRequired()
            .HasComment("Título del certificado.");

        builder
            .Property(e => e.TextoCertificado)
            .HasColumnName("texto_certificado")
            .HasColumnType("text")
            .HasComment("Texto completo del certificado.");

        builder
            .Property(e => e.HorasCertificadas)
            .HasColumnName("horas_certificadas")
            .IsRequired()
            .HasComment("Número de horas certificadas.");

        builder
            .Property(e => e.NotaFinal)
            .HasColumnName("nota_final")
            .HasMaxLength(50)
            .HasComment("Nota final del estudiante.");

        builder
            .Property(e => e.FechaInicio)
            .HasColumnName("fecha_inicio")
            .IsRequired()
            .HasComment("Fecha de inicio del curso para el certificado.");

        builder
            .Property(e => e.FechaFinalizacion)
            .HasColumnName("fecha_finalizacion")
            .IsRequired()
            .HasComment("Fecha de finalización del curso para el certificado.");

        builder
            .Property(e => e.FechaEmision)
            .HasColumnName("fecha_emision")
            .IsRequired()
            .HasComment("Fecha de emisión del certificado.");

        builder
            .Property(e => e.UsuarioEmisionId)
            .HasColumnName("usuario_emision_id")
            .HasComment("ID del usuario que emitió el certificado.");

        builder
            .Property(e => e.FechaValidacion)
            .HasColumnName("fecha_validacion")
            .HasColumnType("timestamp without time zone")
            .HasComment("Fecha y hora de validación del certificado.");

        builder
            .Property(e => e.IpValidacion)
            .HasColumnName("ip_validacion")
            .HasMaxLength(50)
            .HasComment("Dirección IP desde donde se validó el certificado.");

        builder
            .Property(e => e.UrlVerificacion)
            .HasColumnName("url_verificacion")
            .HasMaxLength(500)
            .HasComment("URL pública para verificar el certificado.");

        builder
            .Property(e => e.RutaAlmacenamientoPdf)
            .HasColumnName("url_descarga_pdf")
            .HasMaxLength(500)
            .HasComment("URL para descargar el PDF del certificado.");

        builder
            .Property(e => e.FechaRevocacion)
            .HasColumnName("fecha_revocacion")
            .HasColumnType("timestamp without time zone")
            .HasComment("Fecha y hora de revocación del certificado.");

        builder
            .Property(e => e.MotivoRevocacion)
            .HasColumnName("motivo_revocacion")
            .HasMaxLength(500)
            .HasComment("Motivo de revocación o inhabilitación.");

        builder
            .Property(e => e.RutaAlmacenamientoPdf)
            .HasColumnName("ruta_almacenamiento_pdf")
            .HasMaxLength(500)
            .HasComment("Ruta interna de almacenamiento del archivo PDF.");

        builder
            .Property(e => e.Estado)
            .HasColumnName("estado")
            .HasDefaultValue(true)
            .IsRequired()
            .HasComment("Estado activo/inactivo del registro (true=activo, false=inactivo).");

        builder
            .Property(e => e.CreadoEn)
            .HasColumnName("creado_en")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired()
            .HasComment("Fecha y hora de creación del registro.");

        builder
            .Property(e => e.ActualizadoEn)
            .HasColumnName("actualizado_en")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired(false)
            .HasComment("Fecha y hora de última actualización del registro.");

        // ÍNDICES ÚNICOS
        builder
            .HasIndex(e => e.Uuid)
            .IsUnique()
            .HasDatabaseName("certificados_uuid_key")
            .HasFilter(null);

        builder
            .HasIndex(e => e.Token)
            .IsUnique()
            .HasDatabaseName("certificados_token_key")
            .HasFilter(null);

        builder
            .HasIndex(e => new { e.InscripcionId, e.Version })
            .IsUnique()
            .HasDatabaseName("certificados_inscripcion_version_key")
            .HasComment("Garantiza que no haya versiones duplicadas por inscripción.");

        // ÍNDICES para consultas comunes
        builder.HasIndex(e => e.InscripcionId).HasDatabaseName("IX_certificados_inscripcion_id");

        builder
            .HasIndex(e => e.TipoEstadoCertificadoId)
            .HasDatabaseName("IX_certificados_tipo_estado_certificado_id");

        builder
            .HasIndex(e => e.EsVersionActual)
            .HasDatabaseName("IX_certificados_es_version_actual")
            .HasFilter("es_version_actual = true");

        builder.HasIndex(e => e.FechaEmision).HasDatabaseName("IX_certificados_fecha_emision");

        builder
            .HasIndex(e => new { e.Estado, e.EsVersionActual })
            .HasDatabaseName("IX_certificados_estado_version_actual")
            .HasFilter("estado = true AND es_version_actual = true");

        builder.HasIndex(e => e.HashSeguridad).HasDatabaseName("IX_certificados_hash_seguridad");

        // RELACIÓN con Inscripcion
        builder
            .HasOne(d => d.Inscripcion)
            .WithMany(p => p.Certificados)
            .HasForeignKey(d => d.InscripcionId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("certificados_inscripcion_id_fkey")
            .IsRequired();

        // RELACIÓN con TipoEstadoCertificado
        builder
            .HasOne(d => d.TipoEstadoCertificado)
            .WithMany(p => p.Certificados)
            .HasForeignKey(d => d.TipoEstadoCertificadoId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("certificados_tipo_estado_certificado_id_fkey")
            .IsRequired();

        // RELACIÓN con CertificadoVersiones (historial)
        builder
            .HasMany(c => c.CertificadoVersiones)
            .WithOne(cv => cv.Certificado)
            .HasForeignKey(cv => cv.CertificadoId)
            .OnDelete(DeleteBehavior.Cascade);

        // RELACIÓN con CertificacionAutoridad
        builder
            .HasMany(c => c.CertificadoAutoridades)
            .WithOne(ca => ca.Certificado)
            .HasForeignKey(ca => ca.CertificadoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
