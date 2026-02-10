using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class CertificadoConfiguration : IEntityTypeConfiguration<Certificado>
{
    public void Configure(EntityTypeBuilder<Certificado> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureRelationships(builder);
        ConfigureQueryFilters(builder);
    }

    private static void ConfigureTable(EntityTypeBuilder<Certificado> builder)
    {
        builder.ToTable(
            "certificados",
            tb => tb.HasComment("Registro de certificados emitidos para alumnos.")
        );

        builder.HasKey(e => e.Id).HasName("pk_certificados");
    }

    private static void ConfigureProperties(EntityTypeBuilder<Certificado> builder)
    {
        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("ID único autoincremental del certificado.")
            .UseIdentityAlwaysColumn();

        builder
            .Property(e => e.Uuid)
            .HasColumnName("uuid")
            .IsRequired()
            .HasComment("UUID único para identificación pública del certificado.");

        builder
            .Property(e => e.Token)
            .HasColumnName("token")
            .HasMaxLength(100)
            .IsRequired()
            .IsUnicode(false)
            .HasComment("Token único para verificación del certificado.");

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
            .Property(e => e.TipoEstadoCertificadoId)
            .HasColumnName("estado_certificado_id")
            .IsRequired()
            .HasComment("ID del estado del certificado (FK a estados_certificado.id).");

        builder
            .Property(e => e.Version)
            .HasColumnName("version")
            .HasDefaultValue(1)
            .HasComment("Número de versión del certificado (para reemisiones).");

        builder
            .Property(e => e.EsVersionActual)
            .HasColumnName("es_version_actual")
            .HasDefaultValue(true)
            .HasComment("Indica si esta es la versión actual del certificado.");

        builder
            .Property(e => e.HashSeguridad)
            .HasColumnName("hash_seguridad")
            .HasMaxLength(256)
            .IsRequired()
            .IsUnicode(false)
            .HasComment("Hash de seguridad para validar integridad del certificado.");

        builder
            .Property(e => e.TituloCertificado)
            .HasColumnName("titulo_certificado")
            .HasMaxLength(200)
            .IsRequired()
            .IsUnicode(false)
            .HasComment("Título oficial del certificado.");

        builder
            .Property(e => e.TextoCertificado)
            .HasColumnName("texto_certificado")
            .HasColumnType("text")
            .HasComment("Texto completo del certificado (puede incluir HTML o Markdown).");

        builder
            .Property(e => e.HorasCertificadas)
            .HasColumnName("horas_certificadas")
            .IsRequired()
            .HasComment("Número total de horas certificadas.");

        builder
            .Property(e => e.NotaFinal)
            .HasColumnName("nota_final")
            .HasMaxLength(10)
            .IsUnicode(false)
            .HasComment("Nota final obtenida (formato según normativa).");

        builder
            .Property(e => e.FechaInicio)
            .HasColumnName("fecha_inicio")
            .HasColumnType("date")
            .IsRequired()
            .HasComment("Fecha de inicio del curso/certificación.");

        builder
            .Property(e => e.FechaFinalizacion)
            .HasColumnName("fecha_finalizacion")
            .HasColumnType("date")
            .IsRequired()
            .HasComment("Fecha de finalización del curso/certificación.");

        builder
            .Property(e => e.FechaEmision)
            .HasColumnName("fecha_emision")
            .HasColumnType("date")
            .IsRequired()
            .HasComment("Fecha de emisión del certificado.");

        builder
            .Property(e => e.UsuarioEmisionId)
            .HasColumnName("usuario_emision_id")
            .HasComment("ID del usuario que emitió el certificado (FK a usuarios.id).");

        builder
            .Property(e => e.FechaValidacion)
            .HasColumnName("fecha_validacion")
            .HasComment("Fecha y hora de validación del certificado.");

        builder
            .Property(e => e.IpValidacion)
            .HasColumnName("ip_validacion")
            .HasMaxLength(45)
            .IsUnicode(false)
            .HasComment("Dirección IP desde donde se validó el certificado.");

        builder
            .Property(e => e.UrlVerificacion)
            .HasColumnName("url_verificacion")
            .HasMaxLength(500)
            .IsUnicode(false)
            .HasComment("URL única para verificación pública del certificado.");

        builder
            .Property(e => e.RutaAlmacenamientoPdf)
            .HasColumnName("ruta_almacenamiento_pdf")
            .HasMaxLength(500)
            .IsUnicode(false)
            .HasComment("Ruta del archivo PDF generado (si aplica).");

        builder
            .Property(e => e.FechaRevocacion)
            .HasColumnName("fecha_revocacion")
            .HasComment("Fecha y hora de revocación del certificado.");

        builder
            .Property(e => e.MotivoRevocacion)
            .HasColumnName("motivo_revocacion")
            .HasMaxLength(500)
            .IsUnicode(false)
            .HasComment("Motivo de la revocación del certificado.");

        builder
            .Property(e => e.Estado)
            .HasColumnName("estado")
            .HasDefaultValue(true)
            .HasComment("Estado activo/inactivo del registro del certificado.");

        builder
            .Property(e => e.CreadoEn)
            .HasColumnName("creado_en")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("Fecha y hora de creación del registro.");

        builder
            .Property(e => e.ActualizadoEn)
            .HasColumnName("actualizado_en")
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

        // Índices de búsqueda frecuente
        builder
            .HasIndex(e => new { e.AlumnoId, e.EsVersionActual })
            .HasDatabaseName("ix_certificados_alumno_version_actual");

        builder
            .HasIndex(e => new { e.InscripcionId, e.EsVersionActual })
            .HasDatabaseName("ix_certificados_inscripcion_version_actual");

        builder.HasIndex(e => e.FechaEmision).HasDatabaseName("ix_certificados_fecha_emision");

        builder.HasIndex(e => e.TituloCertificado).HasDatabaseName("ix_certificados_titulo");

        // Índices de llaves foráneas
        builder.HasIndex(e => e.AlumnoId).HasDatabaseName("ix_certificados_alumno");

        builder.HasIndex(e => e.InscripcionId).HasDatabaseName("ix_certificados_inscripcion");

        builder.HasIndex(e => e.TipoEstadoCertificadoId).HasDatabaseName("ix_certificados_estado");

        builder
            .HasIndex(e => e.UsuarioEmisionId)
            .HasDatabaseName("ix_certificados_usuario_emision");

        // Índices para filtros comunes
        builder.HasIndex(e => e.Estado).HasDatabaseName("ix_certificados_estado_registro");

        builder
            .HasIndex(e => e.EsVersionActual)
            .HasDatabaseName("ix_certificados_es_version_actual");

        builder
            .HasIndex(e => e.FechaRevocacion)
            .HasDatabaseName("ix_certificados_fecha_revocacion")
            .HasFilter("fecha_revocacion IS NOT NULL");

        // Índice compuesto para consultas de rango de fechas
        builder
            .HasIndex(e => new { e.FechaInicio, e.FechaFinalizacion })
            .HasDatabaseName("ix_certificados_rango_fechas");

        // Índice para búsqueda por versiones de un mismo certificado
        builder
            .HasIndex(e => new
            {
                e.AlumnoId,
                e.InscripcionId,
                e.Version,
            })
            .IsUnique()
            .HasDatabaseName("uk_certificados_alumno_inscripcion_version");
    }

    private static void ConfigureRelationships(EntityTypeBuilder<Certificado> builder)
    {
        builder
            .HasOne(e => e.Alumno)
            .WithMany(e => e.Certificados)
            .HasForeignKey(e => e.AlumnoId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_certificados_alumno");

        builder
            .HasOne(e => e.Inscripcion)
            .WithMany()
            .HasForeignKey(e => e.InscripcionId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_certificados_inscripcion");

        builder
            .HasOne(e => e.EstadoCertificado)
            .WithMany()
            .HasForeignKey(e => e.TipoEstadoCertificadoId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_certificados_estado");

        // Relación con Usuario (si existe la entidad Usuario)
        // Nota: Esta relación es opcional si no existe la entidad Usuario
        /*if (builder.Metadata.ClrType.Assembly.GetType("SIGA.Domain.Entities.Usuario") != null)
        {
            builder
                .HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(e => e.UsuarioEmisionId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_certificados_usuario_emision")
                .IsRequired(false);
        }*/
    }

    private static void ConfigureQueryFilters(EntityTypeBuilder<Certificado> builder)
    {
        // Filtro global para solo obtener registros activos
        builder.HasQueryFilter(e => e.Estado == true);

        // Opcional: Filtro para excluir certificados revocados en algunas consultas
        // builder.HasQueryFilter(e => e.Estado == true && e.FechaRevocacion == null);
    }
}
