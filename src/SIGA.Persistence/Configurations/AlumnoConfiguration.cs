using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class AlumnoConfiguration : IEntityTypeConfiguration<Alumno>
{
    public void Configure(EntityTypeBuilder<Alumno> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureRelationships(builder);
    }

    private static void ConfigureTable(EntityTypeBuilder<Alumno> builder)
    {
        builder.ToTable(
            "alumnos",
            tb => tb.HasComment("Registro principal de alumnos aceptados de preinscripciones")
        );

        builder.HasKey(e => e.Id).HasName("pk_alumnos");
    }

    private static void ConfigureProperties(EntityTypeBuilder<Alumno> builder)
    {
        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("ID único autoincremental.")
            .UseIdentityAlwaysColumn();

        builder
            .Property(e => e.Uuid)
            .HasColumnName("uuid")
            .HasDefaultValueSql("gen_random_uuid()")
            .HasComment("UUID4 único para identificación universal.");

        builder
            .Property(e => e.TipoDocumentoId)
            .HasColumnName("tipo_documento_id")
            .HasComment("ID del tipo de documento (FK a tipos_documento.id).");

        builder
            .Property(e => e.EstadoAlumnoId)
            .HasColumnName("estado_alumno_id")
            .HasComment("ID del estado actual (FK a estados_alumno.id).");

        builder
            .Property(e => e.NumDocumento)
            .HasColumnName("num_documento")
            .HasMaxLength(50)
            .IsRequired()
            .IsUnicode(false)
            .HasComment("Número de documento único.");

        builder
            .Property(e => e.Apellido)
            .HasColumnName("apellido")
            .HasMaxLength(100)
            .IsRequired()
            .IsUnicode(false)
            .HasComment("Apellido(s) del alumno.");

        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(100)
            .IsRequired()
            .IsUnicode(false)
            .HasComment("Nombre(s) del alumno.");

        builder
            .Property(e => e.FechaNacimiento)
            .HasColumnName("fecha_nacimiento")
            .HasColumnType("date")
            .HasComment("Fecha de nacimiento del alumno.");

        builder
            .Property(e => e.Sexo)
            .HasColumnName("sexo")
            .HasMaxLength(1)
            .IsUnicode(false)
            .HasComment("Sexo: M - Masculino, F - Femenino, O - Otro.");

        builder
            .Property(e => e.Email)
            .HasColumnName("email")
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasComment("Correo electrónico del alumno.");

        builder
            .Property(e => e.Telefono)
            .HasColumnName("telefono")
            .HasMaxLength(20)
            .IsUnicode(false)
            .HasComment("Número de teléfono.");

        builder
            .Property(e => e.Domicilio)
            .HasColumnName("domicilio")
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasComment("Dirección de residencia.");

        builder
            .Property(e => e.CodigoPostal)
            .HasColumnName("codigo_postal")
            .HasMaxLength(10)
            .IsUnicode(false)
            .HasComment("Código postal.");

        builder
            .Property(e => e.Ciudad)
            .HasColumnName("ciudad")
            .HasMaxLength(100)
            .IsUnicode(false)
            .HasComment("Ciudad de residencia.");

        builder
            .Property(e => e.Provincia)
            .HasColumnName("provincia")
            .HasMaxLength(100)
            .IsUnicode(false)
            .HasComment("Provincia/Estado de residencia.");

        builder
            .Property(e => e.Pais)
            .HasColumnName("pais")
            .HasMaxLength(100)
            .IsUnicode(false)
            .HasComment("País de residencia.");

        builder
            .Property(e => e.CiudadNacimiento)
            .HasColumnName("ciudad_nacimiento")
            .HasMaxLength(100)
            .IsUnicode(false)
            .HasComment("Ciudad de nacimiento.");

        builder
            .Property(e => e.Colegio)
            .HasColumnName("colegio")
            .HasMaxLength(200)
            .IsUnicode(false)
            .HasComment("Colegio o institución de procedencia.");

        builder
            .Property(e => e.Profesion)
            .HasColumnName("profesion")
            .HasMaxLength(100)
            .IsUnicode(false)
            .HasComment("Profesión u ocupación.");

        builder
            .Property(e => e.LugarTrabajo)
            .HasColumnName("lugar_trabajo")
            .HasMaxLength(200)
            .IsUnicode(false)
            .HasComment("Lugar de trabajo.");

        builder
            .Property(e => e.NumeroSocio)
            .HasColumnName("numero_socio")
            .HasMaxLength(20)
            .IsUnicode(false)
            .HasComment("Número de socio.");

        builder
            .Property(e => e.EsSocio)
            .HasColumnName("es_socio")
            .HasMaxLength(1)
            .IsUnicode(false)
            .HasComment("Indicador de socio: S - Sí, N - No.");

        builder
            .Property(e => e.Activo)
            .HasColumnName("activo")
            .HasDefaultValue(true)
            .HasComment("Estado activo/inactivo del registro.");

        builder
            .Property(e => e.CreadoEn)
            .HasColumnName("creado_en")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("Fecha y hora de creación.");

        builder
            .Property(e => e.ActualizadoEn)
            .HasColumnName("actualizado_en")
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

        builder
            .HasIndex(e => new { e.Apellido, e.Nombre })
            .HasDatabaseName("ix_alumnos_nombre_completo");

        builder.HasIndex(e => e.Apellido).HasDatabaseName("ix_alumnos_apellido");

        builder.HasIndex(e => e.Nombre).HasDatabaseName("ix_alumnos_nombre");

        builder.HasIndex(e => e.TipoDocumentoId).HasDatabaseName("ix_alumnos_tipo_documento");

        builder.HasIndex(e => e.EstadoAlumnoId).HasDatabaseName("ix_alumnos_estado_alumno");

        // Índices de filtro
        builder.HasIndex(e => e.Activo).HasDatabaseName("ix_alumnos_activo");

        builder.HasIndex(e => e.FechaNacimiento).HasDatabaseName("ix_alumnos_fecha_nacimiento");
    }

    private static void ConfigureRelationships(EntityTypeBuilder<Alumno> builder)
    {
        builder
            .HasOne(e => e.TipoDocumento)
            .WithMany()
            .HasForeignKey(e => e.TipoDocumentoId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_alumnos_tipo_documento");

        builder
            .HasOne(e => e.EstadoAlumno)
            .WithMany()
            .HasForeignKey(e => e.EstadoAlumnoId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_alumnos_estado_alumno");
    }
}
