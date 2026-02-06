// SIGA.Persistence/Configurations/InscripcionesConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class InscripcionesConfiguration : IEntityTypeConfiguration<Inscripciones>
{
    public void Configure(EntityTypeBuilder<Inscripciones> builder)
    {
        builder.HasKey(e => e.Id).HasName("inscripciones_pkey");

        builder.ToTable(
            "inscripciones",
            tb =>
                tb.HasComment(
                    "Inscripciones a propuestas académicas o eventos. Contiene los datos personales, de contacto y estado actual de cada inscripto."
                )
        );

        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("ID único autoincremental.")
            .UseIdentityColumn();

        // DATOS PERSONALES
        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(100)
            .IsRequired()
            .HasComment("Nombre del inscripto.");

        builder
            .Property(e => e.Apellido)
            .HasColumnName("apellido")
            .HasMaxLength(150)
            .IsRequired()
            .HasComment("Apellido del inscripto.");

        builder
            .Property(e => e.ApellidoNombre)
            .HasColumnName("apellido_nombre")
            .HasMaxLength(250)
            .HasComputedColumnSql("apellido || ', ' || nombre", stored: true)
            .HasComment("Apellido y nombre concatenados (derivado).");

        builder
            .Property(e => e.Sexo)
            .HasColumnName("sexo")
            .HasMaxLength(2)
            .IsRequired(false) // Nullable
            .HasComment("Sexo (M: Masculino, F: Femenino, O: Otro).");

        builder
            .Property(e => e.FechaNacimiento)
            .HasColumnName("fecha_nacimiento")
            .IsRequired(false) // Nullable
            .HasComment("Fecha de nacimiento.");

        builder
            .Property(e => e.Edad)
            .HasColumnName("edad")
            .HasComputedColumnSql(
                "DATE_PART('year', AGE(CURRENT_DATE, fecha_nacimiento))",
                stored: true
            )
            .HasComment("Edad calculada.");

        // DOCUMENTACIÓN
        builder
            .Property(e => e.TipoDocumentoId)
            .HasColumnName("tipo_documento_id")
            .IsRequired(false) // Nullable
            .HasComment("ID del tipo de documento (FK a tipo_documento.id).");

        builder
            .Property(e => e.Documento)
            .HasColumnName("documento")
            .HasMaxLength(20)
            .IsRequired()
            .HasComment("Número de documento del inscripto.");

        // CONTACTO
        builder
            .Property(e => e.Email)
            .HasColumnName("email")
            .HasMaxLength(100)
            .IsRequired()
            .HasComment("Email de contacto.");

        builder
            .Property(e => e.Telefono)
            .HasColumnName("telefono")
            .HasMaxLength(30)
            .IsRequired(false) // Nullable
            .HasComment("Teléfono de contacto.");

        // DOMICILIO
        builder
            .Property(e => e.Domicilio)
            .HasColumnName("domicilio")
            .HasMaxLength(200)
            .IsRequired(false) // Nullable
            .HasComment("Domicilio particular.");

        builder
            .Property(e => e.Ciudad)
            .HasColumnName("ciudad")
            .HasMaxLength(150)
            .IsRequired(false) // Nullable
            .HasComment("Ciudad de residencia.");

        builder
            .Property(e => e.Provincia)
            .HasColumnName("provincia")
            .HasMaxLength(150)
            .IsRequired(false) // Nullable
            .HasComment("Provincia de residencia.");

        builder
            .Property(e => e.Pais)
            .HasColumnName("pais")
            .HasMaxLength(150)
            .IsRequired(false) // Nullable
            .HasComment("País de residencia.");

        builder
            .Property(e => e.CodigoPostal)
            .HasColumnName("codigo_postal")
            .HasMaxLength(15)
            .IsRequired(false) // Nullable
            .HasComment("Código postal.");

        builder
            .Property(e => e.CiudadNacimiento)
            .HasColumnName("ciudad_nacimiento")
            .HasMaxLength(150)
            .IsRequired(false) // Nullable
            .HasComment("Ciudad de nacimiento.");

        // DATOS ACADÉMICOS/PROFESIONALES
        builder
            .Property(e => e.Profesion)
            .HasColumnName("profesion")
            .HasMaxLength(100)
            .IsRequired(false) // Nullable
            .HasComment("Profesión u ocupación.");

        builder
            .Property(e => e.LugarTrabajo)
            .HasColumnName("lugar_trabajo")
            .HasMaxLength(150)
            .IsRequired(false) // Nullable
            .HasComment("Lugar de trabajo actual.");

        builder
            .Property(e => e.Colegio)
            .HasColumnName("colegio")
            .HasMaxLength(100)
            .IsRequired(false) // Nullable
            .HasComment("Colegio o institución de procedencia.");

        // INFORMACIÓN SOCIO
        builder
            .Property(e => e.EsSocio)
            .HasColumnName("es_socio")
            .HasDefaultValue(false)
            .IsRequired()
            .HasComment("Indica si es socio (true=sí, false=no).");

        builder
            .Property(e => e.NumeroSocio)
            .HasColumnName("numero_socio")
            .HasMaxLength(25)
            .IsRequired(false) // Nullable
            .HasComment("Número de socio institucional.");

        // RELACIÓN CON PROPUESTA
        builder
            .Property(e => e.PropuestaId)
            .HasColumnName("propuesta_id")
            .IsRequired()
            .HasComment("ID de la propuesta a la que se inscribe (FK a propuesta.id).");

        builder
            .Property(e => e.ModalidadId)
            .HasColumnName("modalidad_id")
            .IsRequired(false) // Nullable
            .HasComment("ID de la modalidad elegida (FK a modalidad.id).");

        // ESTADO Y PAGOS
        builder
            .Property(e => e.TipoEstadoInscripcionId)
            .HasColumnName("tipo_estado_inscripcion_id")
            .IsRequired()
            .HasComment(
                "ID del estado actual de la inscripción (FK a tipo_estado_inscripcion.id)."
            );

        builder
            .Property(e => e.Baja)
            .HasColumnName("baja")
            .HasDefaultValue(false)
            .IsRequired()
            .HasComment("Indica si la inscripción está dada de baja (true=baja, false=activa).");

        builder
            .Property(e => e.FechaBaja)
            .HasColumnName("fecha_baja")
            .HasColumnType("timestamp without time zone")
            .IsRequired(false) // Nullable
            .HasComment("Fecha de baja de la inscripción.");

        builder
            .Property(e => e.PagoMercadopago)
            .HasColumnName("pago_mercadopago")
            .HasDefaultValue(false)
            .IsRequired()
            .HasComment("Indica si el pago se realizó por MercadoPago.");

        builder
            .Property(e => e.CodigoConcepto)
            .HasColumnName("codigo_concepto")
            .IsRequired(false) // Nullable
            .HasComment("Código de concepto para pagos.");

        // FECHAS DEL SISTEMA
        builder
            .Property(e => e.FechaInscripcion)
            .HasColumnName("fecha_inscripcion")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired()
            .HasComment("Fecha y hora de la inscripción.");

        builder
            .Property(e => e.CreadoEn)
            .HasColumnName("creado_en")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired(false) // Nullable
            .HasComment("Fecha y hora de creación del registro.");

        builder
            .Property(e => e.ActualizadoEn)
            .HasColumnName("actualizado_en")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired(false) // Nullable
            .HasComment("Fecha y hora de última actualización del registro.");

        // RELACIONES
        // Propuesta
        builder
            .HasOne(d => d.Propuesta)
            .WithMany(p => p.Inscripciones)
            .HasForeignKey(d => d.PropuestaId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("inscripciones_propuesta_id_fkey")
            .IsRequired();

        // Modalidad
        builder
            .HasOne(d => d.Modalidad)
            .WithMany(p => p.Inscripciones)
            .HasForeignKey(d => d.ModalidadId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("inscripciones_modalidad_id_fkey");

        // Tipo Documento
        builder
            .HasOne(d => d.TipoDocumento)
            .WithMany(p => p.Inscripciones)
            .HasForeignKey(d => d.TipoDocumentoId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("inscripciones_tipo_documento_id_fkey");

        // Tipo Estado Inscripción
        builder
            .HasOne(d => d.TipoEstadoInscripcion)
            .WithMany(p => p.Inscripciones)
            .HasForeignKey(d => d.TipoEstadoInscripcionId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("inscripciones_tipo_estado_inscripcion_id_fkey")
            .IsRequired();

        // Relación inversa con Certificaciones
        builder
            .HasMany(i => i.Certificaciones)
            .WithOne(c => c.Inscripcion)
            .HasForeignKey(c => c.InscripcionId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relación inversa con HistorialEstadoInscripciones
        builder
            .HasMany(i => i.HistorialEstadoInscripciones)
            .WithOne(h => h.Inscripcion)
            .HasForeignKey(h => h.InscripcionId)
            .OnDelete(DeleteBehavior.Cascade);

        // ÍNDICES
        // Índice único para documento dentro de una propuesta (no puede inscribirse 2 veces)
        builder
            .HasIndex(e => new { e.PropuestaId, e.Documento })
            .IsUnique()
            .HasDatabaseName("UQ_inscripciones_propuesta_documento")
            .HasFilter("baja = false"); // Solo para inscripciones activas

        // Índice para búsqueda por email
        builder.HasIndex(e => e.Email).HasDatabaseName("IX_inscripciones_email");

        // Índice para búsqueda por documento
        builder.HasIndex(e => e.Documento).HasDatabaseName("IX_inscripciones_documento");

        // Índice para búsqueda por estado
        builder
            .HasIndex(e => e.TipoEstadoInscripcionId)
            .HasDatabaseName("IX_inscripciones_estado");

        // Índice para búsqueda por propuesta
        builder.HasIndex(e => e.PropuestaId).HasDatabaseName("IX_inscripciones_propuesta_id");

        // Índice para búsqueda por fecha de inscripción
        builder
            .HasIndex(e => e.FechaInscripcion)
            .HasDatabaseName("IX_inscripciones_fecha_inscripcion")
            .IsDescending(true);

        // Índice para búsqueda por baja
        builder.HasIndex(e => e.Baja).HasDatabaseName("IX_inscripciones_baja");

        // Índice compuesto para reportes
        builder
            .HasIndex(e => new
            {
                e.PropuestaId,
                e.Baja,
                e.FechaInscripcion,
            })
            .HasDatabaseName("IX_inscripciones_propuesta_baja_fecha");

        // CHECK CONSTRAINTS (si se soportan)
        // builder.HasCheckConstraint("CK_inscripciones_sexo", "sexo IN ('M', 'F', 'O')");
        // builder.HasCheckConstraint("CK_inscripciones_email", "email ~* '^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$'");
    }
}
