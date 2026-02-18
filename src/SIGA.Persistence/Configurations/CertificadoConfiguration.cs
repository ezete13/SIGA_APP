using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities.Core;

namespace SIGA.Infrastructure.Data.Configurations;

public class CertificadoConfiguration : IEntityTypeConfiguration<Certificado>
{
    public void Configure(EntityTypeBuilder<Certificado> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureRelationships(builder);
        ConfigureQueryFilters(builder);
        // No hay seeds para Certificado
    }

    private static void ConfigureTable(EntityTypeBuilder<Certificado> builder)
    {
        builder.ToTable(
            "certificados",
            "siga",
            tb => tb.HasComment("Registro de certificados emitidos para alumnos.")
        );

        builder.HasKey(e => e.Id).HasName("pk_certificado");
    }

    private static void ConfigureProperties(EntityTypeBuilder<Certificado> builder)
    {
        // ID - PostgreSQL usa serial/identity
        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .UseIdentityAlwaysColumn()
            .HasComment("ID único autoincremental del certificado.");

        // UUID - PostgreSQL usa gen_random_uuid()
        builder
            .Property(e => e.Uuid)
            .HasColumnName("uuid")
            .HasDefaultValueSql("gen_random_uuid()")
            .IsRequired()
            .HasColumnType("uuid")
            .HasComment("UUID único para identificación pública del certificado.");

        // Token
        builder
            .Property(e => e.Token)
            .HasColumnName("token")
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Token único para verificación del certificado.");

        // Foreign Keys
        builder
            .Property(e => e.InscripcionId)
            .HasColumnName("inscripcion_id")
            .IsRequired()
            .HasComment("ID de la inscripción relacionada (FK a inscripciones.id).");

        builder
            .Property(e => e.AlumnoId)
            .HasColumnName("alumno_id")
            .IsRequired()
            .HasComment("ID del alumno certificado (FK a alumnos.id).");

        builder
            .Property(e => e.CertificadoEstadoId)
            .HasColumnName("certificado_estado_id") // Cambiado para consistencia
            .IsRequired()
            .HasComment("ID del estado del certificado (FK a certificado_estados.id).");

        // Versión
        builder
            .Property(e => e.Version)
            .HasColumnName("version")
            .HasDefaultValue(1)
            .IsRequired()
            .HasColumnType("integer")
            .HasComment("Número de versión del certificado (para reemisiones).");

        builder
            .Property(e => e.EsVersionActual)
            .HasColumnName("es_version_actual")
            .HasDefaultValue(true)
            .IsRequired()
            .HasColumnType("boolean")
            .HasComment("Indica si esta es la versión actual del certificado.");

        // Hash de seguridad
        builder
            .Property(e => e.HashSeguridad)
            .HasColumnName("hash_seguridad")
            .HasMaxLength(256)
            .IsRequired()
            .HasColumnType("varchar(256)")
            .HasComment("Hash de seguridad para validar integridad del certificado.");

        // Contenido del certificado
        builder
            .Property(e => e.TituloCertificado)
            .HasColumnName("titulo_certificado")
            .HasMaxLength(200)
            .IsRequired()
            .HasColumnType("varchar(200)")
            .HasComment("Título oficial del certificado.");

        builder
            .Property(e => e.TextoCertificado)
            .HasColumnName("texto_certificado")
            .HasColumnType("text")
            .HasComment("Texto completo del certificado (puede incluir HTML o Markdown).");

        builder
            .Property(e => e.HorasCertificadas)
            .HasColumnName("horas_certificadas")
            .HasColumnType("integer")
            .HasComment("Número total de horas certificadas.");

        builder
            .Property(e => e.NotaFinal)
            .HasColumnName("nota_final")
            .HasMaxLength(10)
            .HasColumnType("varchar(10)")
            .HasComment("Nota final obtenida (formato según normativa).");

        // Fechas
        builder
            .Property(e => e.FechaInicio)
            .HasColumnName("fecha_inicio")
            .HasColumnType("date")
            .HasComment("Fecha de inicio del curso/certificación.");

        builder
            .Property(e => e.FechaFinalizacion)
            .HasColumnName("fecha_finalizacion")
            .HasColumnType("date")
            .HasComment("Fecha de finalización del curso/certificación.");

        builder
            .Property(e => e.FechaEmision)
            .HasColumnName("fecha_emision")
            .HasColumnType("date")
            .IsRequired()
            .HasComment("Fecha de emisión del certificado.");

        // Validación
        builder
            .Property(e => e.UsuarioId)
            .HasColumnName("usuario_id") // Simplificado
            .HasColumnType("integer")
            .HasComment("ID del usuario que emitió/validó el certificado (FK a usuarios.id).");

        builder
            .Property(e => e.FechaValidacion)
            .HasColumnName("fecha_validacion")
            .HasColumnType("timestamp with time zone")
            .HasComment("Fecha y hora de validación del certificado.");

        builder
            .Property(e => e.IpValidacion)
            .HasColumnName("ip_validacion")
            .HasMaxLength(45)
            .HasColumnType("varchar(45)")
            .HasComment("Dirección IP desde donde se validó el certificado.");

        // Verificación y almacenamiento
        builder
            .Property(e => e.UrlVerificacion)
            .HasColumnName("url_verificacion")
            .HasMaxLength(500)
            .HasColumnType("varchar(500)")
            .HasComment("URL única para verificación pública del certificado.");

        builder
            .Property(e => e.RutaAlmacenamientoPdf)
            .HasColumnName("ruta_almacenamiento_pdf")
            .HasMaxLength(500)
            .HasColumnType("varchar(500)")
            .HasComment("Ruta del archivo PDF generado (si aplica).");

        // Revocación
        builder
            .Property(e => e.FechaRevocacion)
            .HasColumnName("fecha_revocacion")
            .HasColumnType("timestamp with time zone")
            .HasComment("Fecha y hora de revocación del certificado.");

        builder
            .Property(e => e.MotivoRevocacion)
            .HasColumnName("motivo_revocacion")
            .HasMaxLength(500)
            .HasColumnType("varchar(500)")
            .HasComment("Motivo de la revocación del certificado.");

        // Auditoría
        builder
            .Property(e => e.Activo)
            .HasColumnName("activo") // Cambiado de "estado" a "activo" para consistencia
            .HasDefaultValue(true)
            .IsRequired()
            .HasColumnType("boolean")
            .HasComment("Indica si el registro del certificado está activo.");

        builder
            .Property(e => e.CreadoEn)
            .HasColumnName("creado_en")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired()
            .HasColumnType("timestamp with time zone")
            .HasComment("Fecha y hora de creación del registro.");

        builder
            .Property(e => e.ActualizadoEn)
            .HasColumnName("actualizado_en")
            .HasColumnType("timestamp with time zone")
            .HasComment("Fecha y hora de última actualización.");
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Certificado> builder)
    {
        // Índices únicos
        builder.HasIndex(e => e.Uuid).IsUnique().HasDatabaseName("uk_certificados_uuid");

        builder.HasIndex(e => e.Token).IsUnique().HasDatabaseName("uk_certificados_token");

        builder
            .HasIndex(e => e.HashSeguridad)
            .IsUnique()
            .HasDatabaseName("uk_certificados_hash_seguridad");

        builder
            .HasIndex(e => e.UrlVerificacion)
            .IsUnique()
            .HasDatabaseName("uk_certificados_url_verificacion")
            .HasFilter("url_verificacion IS NOT NULL");

        // Índice único para versiones (evita duplicados de versión por alumno/inscripción)
        builder
            .HasIndex(e => new
            {
                e.AlumnoId,
                e.InscripcionId,
                e.Version,
            })
            .IsUnique()
            .HasDatabaseName("uk_certificados_alumno_inscripcion_version");

        // Índices compuestos para búsquedas frecuentes
        builder
            .HasIndex(e => new { e.AlumnoId, e.EsVersionActual })
            .HasDatabaseName("ix_certificados_alumno_version_actual");

        builder
            .HasIndex(e => new { e.InscripcionId, e.EsVersionActual })
            .HasDatabaseName("ix_certificados_inscripcion_version_actual");

        builder
            .HasIndex(e => new { e.FechaInicio, e.FechaFinalizacion })
            .HasDatabaseName("ix_certificados_rango_fechas");

        // Índices simples
        builder.HasIndex(e => e.AlumnoId).HasDatabaseName("ix_certificados_alumno");

        builder.HasIndex(e => e.InscripcionId).HasDatabaseName("ix_certificados_inscripcion");

        builder.HasIndex(e => e.CertificadoEstadoId).HasDatabaseName("ix_certificados_estado");

        builder.HasIndex(e => e.UsuarioId).HasDatabaseName("ix_certificados_usuario");

        builder.HasIndex(e => e.FechaEmision).HasDatabaseName("ix_certificados_fecha_emision");

        builder.HasIndex(e => e.TituloCertificado).HasDatabaseName("ix_certificados_titulo");

        builder.HasIndex(e => e.EsVersionActual).HasDatabaseName("ix_certificados_version_actual");

        // Índices con filtro
        builder
            .HasIndex(e => e.Activo)
            .HasDatabaseName("ix_certificados_activo")
            .HasFilter("activo = true");

        builder
            .HasIndex(e => e.FechaRevocacion)
            .HasDatabaseName("ix_certificados_fecha_revocacion")
            .HasFilter("fecha_revocacion IS NOT NULL");
    }

    private static void ConfigureRelationships(EntityTypeBuilder<Certificado> builder)
    {
        // Relación con Alumno
        builder
            .HasOne(e => e.Alumno)
            .WithMany(a => a.Certificados)
            .HasForeignKey(e => e.AlumnoId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_certificados_alumno");

        // Relación con Inscripcion
        builder
            .HasOne(e => e.Inscripcion)
            .WithMany(i => i.Certificados) // Asumiendo que Inscripcion tiene colección de Certificados
            .HasForeignKey(e => e.InscripcionId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_certificados_inscripcion");

        // Relación con CertificadoEstado
        builder
            .HasOne(e => e.CertificadoEstado)
            .WithMany(ce => ce.Certificados) // Asumiendo que CertificadoEstado tiene colección de Certificados
            .HasForeignKey(e => e.CertificadoEstadoId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_certificados_estado");
    }

    private static void ConfigureQueryFilters(EntityTypeBuilder<Certificado> builder)
    {
        // Filtro global para excluir registros inactivos
        builder.HasQueryFilter(e => e.Activo);
    }
}
