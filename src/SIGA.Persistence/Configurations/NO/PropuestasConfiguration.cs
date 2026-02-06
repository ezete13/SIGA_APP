// SIGA.Persistence/Configurations/PropuestasConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class PropuestasConfiguration : IEntityTypeConfiguration<Propuestas>
{
    public void Configure(EntityTypeBuilder<Propuestas> builder)
    {
        builder.HasKey(e => e.Id).HasName("propuestas_pkey");

        builder.ToTable(
            "propuestas",
            tb =>
                tb.HasComment(
                    "Configuración centralizada de jornadas académicas, cursos, diplomaturas y eventos."
                )
        );

        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("ID único autoincremental de la propuesta. Clave primaria.")
            .UseIdentityColumn();

        // INFORMACIÓN BÁSICA
        builder
            .Property(e => e.Titulo)
            .HasColumnName("titulo")
            .HasMaxLength(255)
            .IsRequired()
            .HasComment("Nombre completo y descriptivo del curso, jornada o evento académico.");

        builder
            .Property(e => e.Edicion)
            .HasColumnName("edicion")
            .HasDefaultValue(1)
            .IsRequired()
            .HasComment("Número de edición de la actividad. Valor por defecto: 1.");

        builder
            .Property(e => e.Anio)
            .HasColumnName("anio")
            .IsRequired()
            .HasComment("Año académico en que se dicta la actividad.");

        // FECHAS Y HORARIOS
        builder
            .Property(e => e.FechaInicio)
            .HasColumnName("fecha_inicio")
            .IsRequired()
            .HasComment("Fecha de inicio formal de la actividad.");

        builder
            .Property(e => e.FechaFin)
            .HasColumnName("fecha_fin")
            .IsRequired()
            .HasComment("Fecha de finalización estimada de la actividad.");

        builder
            .Property(e => e.CantidadHoras)
            .HasColumnName("cantidad_horas")
            .IsRequired()
            .HasComment("Cantidad total de horas de la actividad.");

        // UBICACIÓN Y MODALIDAD
        builder
            .Property(e => e.LugarRealizacion)
            .HasColumnName("lugar_realizacion")
            .HasMaxLength(255)
            .IsRequired(false)
            .HasComment("Lugar físico donde se desarrollará la actividad.");

        // CAPACIDAD
        builder
            .Property(e => e.MaximoAlumnos)
            .HasColumnName("maximo_alumnos")
            .IsRequired()
            .HasComment("Límite máximo de participantes permitidos.");

        builder
            .Property(e => e.CuposDisponibles)
            .HasColumnName("cupos_disponibles")
            .IsRequired()
            .HasComment("Cupos actualmente disponibles.");

        // INFORMACIÓN ECONÓMICA
        builder
            .Property(e => e.ImporteBase)
            .HasColumnName("importe_base")
            .HasPrecision(10, 2)
            .IsRequired()
            .HasComment("Precio base para pago al contado.");

        builder
            .Property(e => e.Cuotas)
            .HasColumnName("cuotas")
            .HasDefaultValue(1)
            .IsRequired()
            .HasComment(
                "Número de cuotas disponibles para pago fraccionado. Activa sistema de pagos."
            );

        builder
            .Property(e => e.ConceptoPago)
            .HasColumnName("concepto_pago")
            .HasMaxLength(50)
            .IsRequired(false)
            .HasComment("Código interno para configuración de pagos.");

        // DOCUMENTACIÓN
        builder
            .Property(e => e.PlanEstudioPdf)
            .HasColumnName("plan_estudio_pdf")
            .HasMaxLength(255)
            .IsRequired(false)
            .HasComment("Ruta o nombre del archivo PDF con el plan de estudios.");

        // CONTACTO
        builder
            .Property(e => e.EmailEncargado)
            .HasColumnName("email_encargado")
            .HasMaxLength(255)
            .IsRequired(false)
            .HasComment("Email del responsable de la propuesta.");

        // ESTADO
        builder
            .Property(e => e.Estado)
            .HasColumnName("estado")
            .HasDefaultValue(true)
            .IsRequired()
            .HasComment("Estado activo/inactivo de la propuesta (true=activa, false=inactiva).");

        // TIMESTAMPS
        builder
            .Property(e => e.CreadoEn)
            .HasColumnName("creado_en")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired(false)
            .HasComment("Fecha y hora de creación del registro.");

        builder
            .Property(e => e.ActualizadoEn)
            .HasColumnName("actualizado_en")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired(false)
            .HasComment("Fecha y hora de última actualización del registro.");

        // CLAVES FORÁNEAS
        builder
            .Property(e => e.UnidadId)
            .HasColumnName("unidad_id")
            .IsRequired()
            .HasComment("ID de la unidad académica organizadora (FK a unidad.id).");

        builder
            .Property(e => e.ModalidadId)
            .HasColumnName("modalidad_id")
            .IsRequired()
            .HasComment("ID de la modalidad de cursado (FK a modalidad.id).");

        builder
            .Property(e => e.PeriodoLectivoId)
            .HasColumnName("periodo_lectivo_id")
            .IsRequired()
            .HasComment("ID del período lectivo institucional (FK a periodo_lectivo.id).");

        builder
            .Property(e => e.TipoPropuestaId)
            .HasColumnName("tipo_propuesta_id")
            .IsRequired()
            .HasComment("ID del tipo de actividad académica (FK a tipo_propuesta.id).");

        builder
            .Property(e => e.TipoEstadoPropuestaId)
            .HasColumnName("tipo_estado_propuesta_id")
            .IsRequired()
            .HasComment("ID del estado actual de la propuesta (FK a tipo_estado_propuesta.id).");

        // RELACIONES
        // Unidad
        builder
            .HasOne(d => d.Unidad)
            .WithMany(p => p.Propuestas)
            .HasForeignKey(d => d.UnidadId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("propuestas_unidad_id_fkey")
            .IsRequired();

        // Modalidad
        builder
            .HasOne(d => d.Modalidad)
            .WithMany(p => p.Propuestas)
            .HasForeignKey(d => d.ModalidadId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("propuestas_modalidad_id_fkey")
            .IsRequired();

        // Periodo Lectivo
        builder
            .HasOne(d => d.PeriodoLectivo)
            .WithMany(p => p.Propuestas)
            .HasForeignKey(d => d.PeriodoLectivoId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("propuestas_periodo_lectivo_id_fkey")
            .IsRequired();

        // Tipo Propuesta
        builder
            .HasOne(d => d.TipoPropuesta)
            .WithMany(p => p.Propuestas)
            .HasForeignKey(d => d.TipoPropuestaId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("propuestas_tipo_propuesta_id_fkey")
            .IsRequired();

        // Tipo Estado Propuesta
        builder
            .HasOne(d => d.TipoEstadoPropuesta)
            .WithMany(p => p.Propuestas)
            .HasForeignKey(d => d.TipoEstadoPropuestaId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("propuestas_tipo_estado_propuesta_id_fkey")
            .IsRequired();

        // RELACIONES INVERSAS
        // Portal (1:1)
        builder
            .HasOne(p => p.Portales)
            .WithOne(port => port.Propuesta)
            .HasForeignKey<Portales>(port => port.PropuestaId);

        // Inscripciones (1:N)
        builder
            .HasMany(p => p.Inscripciones)
            .WithOne(i => i.Propuesta)
            .HasForeignKey(i => i.PropuestaId)
            .OnDelete(DeleteBehavior.Restrict);

        // Docentes (N:N)
        builder
            .HasMany(p => p.PropuestaDocente)
            .WithOne(pd => pd.Propuesta)
            .HasForeignKey(pd => pd.PropuestaId)
            .OnDelete(DeleteBehavior.Cascade);

        // Auspiciantes (N:N)
        builder
            .HasMany(p => p.PropuestaAuspiciantes)
            .WithOne(pa => pa.Propuesta)
            .HasForeignKey(pa => pa.PropuestaId)
            .OnDelete(DeleteBehavior.Cascade);

        // Contactos (1:N)
        builder
            .HasMany(p => p.PropuestaContactos)
            .WithOne(pc => pc.Propuesta)
            .HasForeignKey(pc => pc.PropuestaId)
            .OnDelete(DeleteBehavior.Cascade);

        // Pagos (1:N)
        builder
            .HasMany(p => p.PropuestaPagosInfo)
            .WithOne(ppi => ppi.Propuesta)
            .HasForeignKey(ppi => ppi.PropuestaId)
            .OnDelete(DeleteBehavior.Cascade);

        // Plan de estudio (1:N)
        builder
            .HasMany(p => p.PropuestaPlanModulos)
            .WithOne(ppm => ppm.Propuesta)
            .HasForeignKey(ppm => ppm.PropuestaId)
            .OnDelete(DeleteBehavior.Cascade);

        // Historial de estados (1:N)
        builder
            .HasMany(p => p.HistorialEstadoPropuestas)
            .WithOne(hep => hep.Propuesta)
            .HasForeignKey(hep => hep.PropuestaId)
            .OnDelete(DeleteBehavior.Cascade);

        // ÍNDICES
        builder.HasIndex(e => e.Titulo).HasDatabaseName("IX_propuestas_titulo");

        builder.HasIndex(e => e.Estado).HasDatabaseName("IX_propuestas_estado");

        builder.HasIndex(e => e.FechaInicio).HasDatabaseName("IX_propuestas_fecha_inicio");

        builder.HasIndex(e => e.FechaFin).HasDatabaseName("IX_propuestas_fecha_fin");

        builder.HasIndex(e => e.UnidadId).HasDatabaseName("IX_propuestas_unidad_id");

        builder.HasIndex(e => e.ModalidadId).HasDatabaseName("IX_propuestas_modalidad_id");

        builder
            .HasIndex(e => e.PeriodoLectivoId)
            .HasDatabaseName("IX_propuestas_periodo_lectivo_id");

        builder.HasIndex(e => e.TipoPropuestaId).HasDatabaseName("IX_propuestas_tipo_propuesta_id");

        builder
            .HasIndex(e => e.TipoEstadoPropuestaId)
            .HasDatabaseName("IX_propuestas_tipo_estado_propuesta_id");

        // Índices compuestos para consultas comunes
        builder
            .HasIndex(e => new { e.Estado, e.FechaInicio })
            .HasDatabaseName("IX_propuestas_estado_fecha_inicio")
            .IsDescending(false, true);

        builder
            .HasIndex(e => new
            {
                e.UnidadId,
                e.Estado,
                e.FechaInicio,
            })
            .HasDatabaseName("IX_propuestas_unidad_estado_fecha");

        builder
            .HasIndex(e => new { e.TipoPropuestaId, e.Estado })
            .HasDatabaseName("IX_propuestas_tipo_estado");
    }
}
