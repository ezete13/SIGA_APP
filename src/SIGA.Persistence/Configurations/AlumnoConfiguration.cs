using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities.Core;

namespace SIGA.Infrastructure.Data.Configurations;

public class AlumnoConfiguration : IEntityTypeConfiguration<Alumno>
{
    public void Configure(EntityTypeBuilder<Alumno> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureRelationships(builder);
        // No hay seeds para Alumno
    }

    private static void ConfigureTable(EntityTypeBuilder<Alumno> builder)
    {
        builder.ToTable(
            "alumnos",
            "siga",
            tb => tb.HasComment("Registro principal de alumnos aceptados de preinscripciones")
        );

        builder.HasKey(e => e.Id).HasName("pk_alumno");
    }

    private static void ConfigureProperties(EntityTypeBuilder<Alumno> builder)
    {
        // ID - PostgreSQL usa serial/identity
        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .UseIdentityAlwaysColumn() // PostgreSQL: siempre usa secuencia
            .HasComment("ID único autoincremental.");

        // UUID - PostgreSQL usa gen_random_uuid()
        builder
            .Property(e => e.Uuid)
            .HasColumnName("uuid")
            .HasDefaultValueSql("gen_random_uuid()")
            .IsRequired()
            .HasComment("UUID único para identificación universal.");

        // Foreign Keys
        builder
            .Property(e => e.TipoDocumentoId)
            .HasColumnName("tipo_documento_id")
            .IsRequired()
            .HasComment("ID del tipo de documento (FK a tipos_documento.id).");

        builder
            .Property(e => e.AlumnoEstadoId)
            .HasColumnName("alumno_estado_id")
            .IsRequired()
            .HasComment("ID del estado actual (FK a alumnos_estado.id).");

        // Documento
        builder
            .Property(e => e.NumDocumento)
            .HasColumnName("num_documento")
            .HasMaxLength(50)
            .IsRequired()
            .HasColumnType("varchar(50)")
            .HasComment("Número de documento único.");

        // Datos personales
        builder
            .Property(e => e.Apellido)
            .HasColumnName("apellido")
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Apellido(s) del alumno.");

        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Nombre(s) del alumno.");

        builder
            .Property(e => e.FechaNacimiento)
            .HasColumnName("fecha_nacimiento")
            .HasColumnType("date")
            .IsRequired()
            .HasComment("Fecha de nacimiento del alumno.");

        builder
            .Property(e => e.Sexo)
            .HasColumnName("sexo")
            .HasMaxLength(1)
            .HasColumnType("char(1)")
            .HasComment("Sexo: M - Masculino, F - Femenino, O - Otro.");

        // Contacto
        builder
            .Property(e => e.Email)
            .HasColumnName("email")
            .HasMaxLength(255)
            .IsRequired()
            .HasColumnType("varchar(255)")
            .HasComment("Correo electrónico del alumno.");

        builder
            .Property(e => e.Telefono)
            .HasColumnName("telefono")
            .HasMaxLength(20)
            .HasColumnType("varchar(20)")
            .HasComment("Número de teléfono.");

        // Domicilio
        builder
            .Property(e => e.Domicilio)
            .HasColumnName("domicilio")
            .HasMaxLength(255)
            .HasColumnType("varchar(255)")
            .HasComment("Dirección de residencia.");

        builder
            .Property(e => e.CodigoPostal)
            .HasColumnName("codigo_postal")
            .HasMaxLength(10)
            .HasColumnType("varchar(10)")
            .HasComment("Código postal.");

        builder
            .Property(e => e.Ciudad)
            .HasColumnName("ciudad")
            .HasMaxLength(100)
            .HasColumnType("varchar(100)")
            .HasComment("Ciudad de residencia.");

        builder
            .Property(e => e.Provincia)
            .HasColumnName("provincia")
            .HasMaxLength(100)
            .HasColumnType("varchar(100)")
            .HasComment("Provincia/Estado de residencia.");

        builder
            .Property(e => e.Pais)
            .HasColumnName("pais")
            .HasMaxLength(100)
            .HasColumnType("varchar(100)")
            .HasComment("País de residencia.");

        builder
            .Property(e => e.CiudadNacimiento)
            .HasColumnName("ciudad_nacimiento")
            .HasMaxLength(100)
            .HasColumnType("varchar(100)")
            .HasComment("Ciudad de nacimiento.");

        // Información académica/laboral
        builder
            .Property(e => e.Colegio)
            .HasColumnName("colegio")
            .HasMaxLength(200)
            .HasColumnType("varchar(200)")
            .HasComment("Colegio o institución de procedencia.");

        builder
            .Property(e => e.Profesion)
            .HasColumnName("profesion")
            .HasMaxLength(100)
            .HasColumnType("varchar(100)")
            .HasComment("Profesión u ocupación.");

        builder
            .Property(e => e.LugarTrabajo)
            .HasColumnName("lugar_trabajo")
            .HasMaxLength(200)
            .HasColumnType("varchar(200)")
            .HasComment("Lugar de trabajo.");

        // Información de socio
        builder
            .Property(e => e.NumeroSocio)
            .HasColumnName("numero_socio")
            .HasMaxLength(20)
            .HasColumnType("varchar(20)")
            .HasComment("Número de socio.");

        builder
            .Property(e => e.EsSocio)
            .HasColumnName("es_socio")
            .HasMaxLength(1)
            .HasColumnType("char(1)")
            .HasComment("Indicador de socio: S - Sí, N - No.");

        // Auditoría
        builder
            .Property(e => e.Activo)
            .HasColumnName("activo")
            .HasDefaultValue(true)
            .IsRequired()
            .HasColumnType("boolean")
            .HasComment("Estado activo/inactivo del registro.");

        builder
            .Property(e => e.CreadoEn)
            .HasColumnName("creado_en")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired()
            .HasColumnType("timestamp with time zone")
            .HasComment("Fecha y hora de creación.");

        builder
            .Property(e => e.ActualizadoEn)
            .HasColumnName("actualizado_en")
            .HasColumnType("timestamp with time zone")
            .HasComment("Fecha y hora de última actualización.");
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Alumno> builder)
    {
        // Índices únicos
        builder.HasIndex(e => e.Uuid).IsUnique().HasDatabaseName("uk_alumnos_uuid");

        builder
            .HasIndex(e => e.NumDocumento)
            .IsUnique()
            .HasDatabaseName("uk_alumnos_num_documento");

        builder
            .HasIndex(e => e.Email)
            .IsUnique()
            .HasDatabaseName("uk_alumnos_email")
            .HasFilter("email IS NOT NULL");

        // Índices para búsqueda por nombre completo
        builder
            .HasIndex(e => new { e.Apellido, e.Nombre })
            .HasDatabaseName("ix_alumnos_apellido_nombre");

        builder.HasIndex(e => e.Apellido).HasDatabaseName("ix_alumnos_apellido");

        builder.HasIndex(e => e.Nombre).HasDatabaseName("ix_alumnos_nombre");

        // Índices para FK (mejoran performance de joins)
        builder.HasIndex(e => e.TipoDocumentoId).HasDatabaseName("ix_alumnos_tipo_documento");

        builder.HasIndex(e => e.AlumnoEstadoId).HasDatabaseName("ix_alumnos_estado");

        // Índices de filtro comunes
        builder
            .HasIndex(e => e.Activo)
            .HasDatabaseName("ix_alumnos_activo")
            .HasFilter("activo = true");

        builder.HasIndex(e => e.FechaNacimiento).HasDatabaseName("ix_alumnos_fecha_nacimiento");

        // Índice compuesto útil para búsquedas por tipo y número de documento
        builder
            .HasIndex(e => new { e.TipoDocumentoId, e.NumDocumento })
            .IsUnique()
            .HasDatabaseName("ix_alumnos_tipo_documento_numero");
    }

    private static void ConfigureRelationships(EntityTypeBuilder<Alumno> builder)
    {
        // Relación con TipoDocumento
        builder
            .HasOne(e => e.TipoDocumento)
            .WithMany(t => t.Alumnos)
            .HasForeignKey(e => e.TipoDocumentoId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_alumnos_tipo_documento");

        // Relación con AlumnoEstado
        builder
            .HasOne(e => e.AlumnoEstado)
            .WithMany(e => e.Alumnos)
            .HasForeignKey(e => e.AlumnoEstadoId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_alumnos_estado");

        // Nota: Las relaciones con Certificados, Inscripciones y Preinscripciones
        // se configuran desde esas entidades (configuración inversa)
    }
}
