using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class AlumnoConfiguration : IEntityTypeConfiguration<Alumno>
{
    public void Configure(EntityTypeBuilder<Alumno> builder)
    {
        builder.HasKey(e => e.Id).HasName("alumnos_pkey");

        builder.ToTable(
            "alumnos",
            tb => tb.HasComment("Registro principal de alumnos aceptado de preinscripciones")
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
            .Property(e => e.TipoDocumentoId)
            .HasColumnName("tipo_documento_id") // Corregido typo: "tipo_docuemento_id"
            .IsRequired()
            .HasComment("ID del tipo de identificación del alumno (FK a tipos_documento.id)."); // Corregido referencia

        builder
            .Property(e => e.EstadoAlumnoId)
            .HasColumnName("estado_alumno_id")
            .IsRequired()
            .HasComment("ID del estado actual (FK a estados_alumno.id).");

        builder
            .Property(e => e.NumDocumento) // Cambiado de NumDocumento
            .HasColumnName("num_documento") // Cambiado de num_documento
            .HasMaxLength(50)
            .IsRequired()
            .IsUnicode()
            .HasComment("Número de identificación única.");

        builder
            .Property(e => e.Apellido)
            .HasColumnName("apellido")
            .HasMaxLength(100)
            .IsRequired()
            .IsUnicode()
            .HasComment("Apellido(s) del alumno.");

        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(100)
            .IsRequired()
            .IsUnicode()
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
            .IsUnicode()
            .HasComment("Sexo: M - Masculino, F - Femenino, O - Otro.");

        builder
            .Property(e => e.Email)
            .HasColumnName("email")
            .HasMaxLength(255)
            .IsUnicode()
            .HasComment("Correo electrónico del alumno.");

        builder
            .Property(e => e.Telefono)
            .HasColumnName("telefono")
            .HasMaxLength(50)
            .IsUnicode()
            .HasComment("Número de teléfono del alumno.");

        builder
            .Property(e => e.Domicilio)
            .HasColumnName("domicilio")
            .HasMaxLength(255)
            .IsUnicode()
            .HasComment("Dirección de residencia.");

        builder
            .Property(e => e.CodigoPostal)
            .HasColumnName("codigo_postal")
            .HasMaxLength(20)
            .IsUnicode()
            .HasComment("Código postal de la dirección.");

        builder
            .Property(e => e.Ciudad)
            .HasColumnName("ciudad")
            .HasMaxLength(100)
            .IsUnicode()
            .HasComment("Ciudad de residencia.");

        builder
            .Property(e => e.Provincia)
            .HasColumnName("provincia")
            .HasMaxLength(100)
            .IsUnicode()
            .HasComment("Provincia/Estado de residencia.");

        builder
            .Property(e => e.Pais)
            .HasColumnName("pais")
            .HasMaxLength(100)
            .IsUnicode()
            .HasComment("País de residencia.");

        builder
            .Property(e => e.CiudadNacimiento)
            .HasColumnName("ciudad_nacimiento")
            .HasMaxLength(100)
            .IsUnicode()
            .HasComment("Ciudad de nacimiento.");

        builder
            .Property(e => e.Colegio)
            .HasColumnName("colegio")
            .HasMaxLength(200)
            .IsUnicode()
            .HasComment("Colegio o institución de procedencia.");

        builder
            .Property(e => e.Profesion)
            .HasColumnName("profesion")
            .HasMaxLength(200)
            .IsUnicode()
            .HasComment("Profesión u ocupación del alumno.");

        builder
            .Property(e => e.LugarTrabajo)
            .HasColumnName("lugar_trabajo")
            .HasMaxLength(200)
            .IsUnicode()
            .HasComment("Lugar de trabajo del alumno.");

        builder
            .Property(e => e.NumeroSocio)
            .HasColumnName("numero_socio")
            .HasMaxLength(50)
            .IsUnicode()
            .HasComment("Número de socio si corresponde.");

        builder
            .Property(e => e.EsSocio)
            .HasColumnName("es_socio")
            .HasMaxLength(1)
            .IsUnicode()
            .HasComment("Indicador de socio: S - Sí, N - No.");

        builder
            .Property(e => e.Estado)
            .HasColumnName("estado")
            .HasDefaultValue(true)
            .HasComment("Estado activo/inactivo del registro.");

        builder
            .Property(e => e.CreadoEn)
            .HasColumnName("creado_en")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("Fecha y hora de creación del registro.");

        builder
            .Property(e => e.ActualizadoEn)
            .HasColumnName("actualizado_en")
            .HasComment("Fecha y hora de última actualización.");

        // Configuración de índices
        builder.HasIndex(e => e.Uuid).IsUnique().HasDatabaseName("idx_alumnos_uuid");
        builder.HasIndex(e => e.NumDocumento).IsUnique().HasDatabaseName("idx_alumnos_num_documento");
        builder.HasIndex(e => e.Email).IsUnique().HasDatabaseName("idx_alumnos_email");
        builder
            .HasIndex(e => new { e.Apellido, e.Nombre })
            .HasDatabaseName("idx_alumnos_nombre_completo");
        builder.HasIndex(e => e.TipoDocumentoId).HasDatabaseName("idx_alumnos_tipo_documento");
        builder.HasIndex(e => e.EstadoAlumnoId).HasDatabaseName("idx_alumnos_estado_alumno");

        // Configuración de relaciones
        builder
            .HasOne(e => e.TipoDocumento)
            .WithMany()
            .HasForeignKey(e => e.TipoDocumentoId)
            .HasConstraintName("fk_alumnos_tipo_documento")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(e => e.EstadoAlumno)
            .WithMany()
            .HasForeignKey(e => e.EstadoAlumnoId)
            .HasConstraintName("fk_alumnos_estado_alumno")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
