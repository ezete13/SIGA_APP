using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities.Core;

namespace SIGA.Infrastructure.Data.Configurations;

public class PropuestaConfiguration : IEntityTypeConfiguration<Propuesta>
{
    public void Configure(EntityTypeBuilder<Propuesta> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureRelationships(builder);
        ConfigureQueryFilters(builder);
        // No hay seeds para Propuesta (son datos dinámicos)
    }

    private static void ConfigureTable(EntityTypeBuilder<Propuesta> builder)
    {
        builder.ToTable(
            "propuestas",
            "siga",
            tb =>
                tb.HasComment(
                    "Registro de propuestas académicas (carreras, cursos, talleres, etc.)"
                )
        );

        builder.HasKey(e => e.Id).HasName("pk_propuesta");
    }

    private static void ConfigureProperties(EntityTypeBuilder<Propuesta> builder)
    {
        // ID - PostgreSQL usa serial/identity
        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .UseIdentityAlwaysColumn()
            .HasComment("Identificador único de la propuesta.");

        // Foreign Keys
        builder
            .Property(e => e.UnidadId)
            .HasColumnName("unidad_id")
            .IsRequired()
            .HasColumnType("integer")
            .HasComment("ID de la unidad académica (FK a unidades.id).");

        builder
            .Property(e => e.ModalidadId)
            .HasColumnName("modalidad_id")
            .IsRequired()
            .HasColumnType("integer")
            .HasComment("ID de la modalidad de cursado (FK a modalidades.id).");

        builder
            .Property(e => e.TipoPropuestaId)
            .HasColumnName("tipo_propuesta_id")
            .IsRequired()
            .HasColumnType("integer")
            .HasComment("ID del tipo de propuesta (FK a tipos_propuesta.id).");

        builder
            .Property(e => e.PeriodoLectivoId)
            .HasColumnName("periodo_lectivo_id")
            .IsRequired()
            .HasColumnType("integer")
            .HasComment("ID del período lectivo (FK a periodos_lectivos.id).");

        builder
            .Property(e => e.EstadoPropuestaId)
            .HasColumnName("estado_propuesta_id")
            .IsRequired()
            .HasColumnType("integer")
            .HasComment("ID del estado de la propuesta (FK a propuesta_estados.id).");

        builder
            .Property(e => e.UsuarioId)
            .HasColumnName("usuario_id")
            .IsRequired()
            .HasColumnType("integer")
            .HasComment("ID del usuario creador/responsable (FK a usuarios.id).");

        // Datos básicos
        builder
            .Property(e => e.Titulo)
            .HasColumnName("titulo")
            .HasMaxLength(500)
            .IsRequired()
            .HasColumnType("varchar(500)")
            .HasComment("Título completo de la propuesta académica.");

        builder
            .Property(e => e.Anio)
            .HasColumnName("anio")
            .IsRequired()
            .HasColumnType("integer")
            .HasComment("Año académico de la propuesta.");

        builder
            .Property(e => e.Edicion)
            .HasColumnName("edicion")
            .HasColumnType("integer")
            .HasComment("Número de edición (para cursos que se repiten).");

        // Fechas
        builder
            .Property(e => e.FechaInicio)
            .HasColumnName("fecha_inicio")
            .IsRequired()
            .HasColumnType("date")
            .HasComment("Fecha de inicio de la propuesta.");

        builder
            .Property(e => e.FechaFin)
            .HasColumnName("fecha_fin")
            .IsRequired()
            .HasColumnType("date")
            .HasComment("Fecha de finalización de la propuesta.");

        // Cupos y capacidad
        builder
            .Property(e => e.MaximoAlumnos)
            .HasColumnName("maximo_alumnos")
            .IsRequired()
            .HasColumnType("integer")
            .HasComment("Cupo máximo de alumnos permitidos.");

        builder
            .Property(e => e.CuposDisponibles)
            .HasColumnName("cupos_disponibles")
            .IsRequired()
            .HasColumnType("integer")
            .HasComment("Cupos disponibles actualmente.");

        builder
            .Property(e => e.CantidadHoras)
            .HasColumnName("cantidad_horas")
            .IsRequired()
            .HasColumnType("integer")
            .HasComment("Carga horaria total de la propuesta.");

        // Información económica
        builder
            .Property(e => e.ImporteBase)
            .HasColumnName("importe_base")
            .HasColumnType("decimal(18,2)")
            .HasComment("Importe base o valor de la propuesta.");

        builder
            .Property(e => e.Cuotas)
            .HasColumnName("cuotas")
            .HasColumnType("integer")
            .HasComment("Cantidad de cuotas (si aplica).");

        builder
            .Property(e => e.ConceptoPago)
            .HasColumnName("concepto_pago")
            .HasMaxLength(255)
            .HasColumnType("varchar(255)")
            .HasComment("Concepto para pago / facturación.");

        // Información de contacto y logística
        builder
            .Property(e => e.EmailEncargado)
            .HasColumnName("email_encargado")
            .HasMaxLength(255)
            .HasColumnType("varchar(255)")
            .HasComment("Email del encargado o coordinador.");

        builder
            .Property(e => e.LugarRealizacion)
            .HasColumnName("lugar_realizacion")
            .HasMaxLength(500)
            .HasColumnType("varchar(500)")
            .HasComment("Lugar físico donde se realiza la propuesta.");

        builder
            .Property(e => e.ContactoInfo)
            .HasColumnName("contacto_info")
            .HasMaxLength(1000)
            .HasColumnType("varchar(1000)")
            .HasComment("Información adicional de contacto.");

        builder
            .Property(e => e.PagosInfo)
            .HasColumnName("pagos_info")
            .HasMaxLength(1000)
            .HasColumnType("varchar(1000)")
            .HasComment("Información sobre métodos de pago.");

        // Documentos
        builder
            .Property(e => e.PlanEstudioPdf)
            .HasColumnName("plan_estudio_pdf")
            .HasMaxLength(500)
            .HasColumnType("varchar(500)")
            .HasComment("URL o ruta del PDF del plan de estudio.");

        // Flags y configuraciones web
        builder
            .Property(e => e.Estado)
            .HasColumnName("estado")
            .HasDefaultValue(true)
            .HasColumnType("boolean")
            .HasComment("Indica si la propuesta está activa en el sistema.");

        builder
            .Property(e => e.WebVisible)
            .HasColumnName("web_visible")
            .HasDefaultValue(false)
            .IsRequired()
            .HasColumnType("boolean")
            .HasComment("Indica si la propuesta es visible en el sitio web.");

        builder
            .Property(e => e.PermiteInscripcionesWeb)
            .HasColumnName("permite_inscripciones_web")
            .HasDefaultValue(false)
            .IsRequired()
            .HasColumnType("boolean")
            .HasComment("Indica si se permiten inscripciones a través de la web.");

        // Auditoría
        builder
            .Property(e => e.CreadoEn)
            .HasColumnName("creado_en")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("timestamp with time zone")
            .HasComment("Fecha y hora de creación de la propuesta.");

        builder
            .Property(e => e.ActualizadoEn)
            .HasColumnName("actualizado_en")
            .HasColumnType("timestamp with time zone")
            .HasComment("Fecha y hora de la última actualización.");
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Propuesta> builder)
    {
        // Índices para búsqueda por título
        builder.HasIndex(e => e.Titulo).HasDatabaseName("ix_propuestas_titulo");

        // Índices compuestos para búsquedas frecuentes
        builder
            .HasIndex(e => new { e.UnidadId, e.PeriodoLectivoId })
            .HasDatabaseName("ix_propuestas_unidad_periodo");

        builder
            .HasIndex(e => new { e.TipoPropuestaId, e.Anio })
            .HasDatabaseName("ix_propuestas_tipo_anio");

        builder
            .HasIndex(e => new { e.ModalidadId, e.EstadoPropuestaId })
            .HasDatabaseName("ix_propuestas_modalidad_estado");

        // Índices para FKs individuales
        builder.HasIndex(e => e.UnidadId).HasDatabaseName("ix_propuestas_unidad");

        builder.HasIndex(e => e.ModalidadId).HasDatabaseName("ix_propuestas_modalidad");

        builder.HasIndex(e => e.TipoPropuestaId).HasDatabaseName("ix_propuestas_tipo");

        builder.HasIndex(e => e.PeriodoLectivoId).HasDatabaseName("ix_propuestas_periodo");

        builder.HasIndex(e => e.EstadoPropuestaId).HasDatabaseName("ix_propuestas_estado");

        builder.HasIndex(e => e.UsuarioId).HasDatabaseName("ix_propuestas_usuario");

        // Índices para filtrado web
        builder
            .HasIndex(e => new { e.WebVisible, e.PermiteInscripcionesWeb })
            .HasDatabaseName("ix_propuestas_web_flags");

        builder
            .HasIndex(e => e.WebVisible)
            .HasDatabaseName("ix_propuestas_web_visible")
            .HasFilter("web_visible = true");

        builder
            .HasIndex(e => e.PermiteInscripcionesWeb)
            .HasDatabaseName("ix_propuestas_permite_inscripciones")
            .HasFilter("permite_inscripciones_web = true");

        // Índices para fechas
        builder
            .HasIndex(e => new { e.FechaInicio, e.FechaFin })
            .HasDatabaseName("ix_propuestas_rango_fechas");

        builder.HasIndex(e => e.FechaInicio).HasDatabaseName("ix_propuestas_fecha_inicio");

        builder.HasIndex(e => e.FechaFin).HasDatabaseName("ix_propuestas_fecha_fin");

        // Índices para disponibilidad de cupos
        builder
            .HasIndex(e => e.CuposDisponibles)
            .HasDatabaseName("ix_propuestas_cupos_disponibles");

        // Índice de filtro para activas
        builder
            .HasIndex(e => e.Estado)
            .HasDatabaseName("ix_propuestas_estado_sistema")
            .HasFilter("estado = true");
    }

    private static void ConfigureRelationships(EntityTypeBuilder<Propuesta> builder)
    {
        // Relación con Unidad
        builder
            .HasOne(e => e.Unidad)
            .WithMany(u => u.Propuestas)
            .HasForeignKey(e => e.UnidadId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_propuestas_unidad");

        // Relación con Modalidad
        builder
            .HasOne(e => e.Modalidad)
            .WithMany(m => m.Propuestas)
            .HasForeignKey(e => e.ModalidadId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_propuestas_modalidad");

        // Relación con TipoPropuesta
        builder
            .HasOne(e => e.TipoPropuesta)
            .WithMany(tp => tp.Propuestas)
            .HasForeignKey(e => e.TipoPropuestaId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_propuestas_tipo");

        // Relación con PeriodoLectivo
        builder
            .HasOne(e => e.PeriodoLectivo)
            .WithMany(pl => pl.Propuestas)
            .HasForeignKey(e => e.PeriodoLectivoId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_propuestas_periodo");

        // Relación con PropuestaEstado
        builder
            .HasOne(e => e.PropuestaEstado)
            .WithMany(pe => pe.Propuestas)
            .HasForeignKey(e => e.EstadoPropuestaId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_propuestas_estado");

        // Relación con PropuestaWeb (uno a uno)
        builder
            .HasOne(e => e.PropuestaWeb)
            .WithOne(pw => pw.Propuesta)
            .HasForeignKey<PropuestaWeb>(pw => pw.PropuestaId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_propuestas_web");

        // Relación con Preinscripciones
        builder
            .HasMany(e => e.Preinscripciones)
            .WithOne(p => p.Propuesta)
            .HasForeignKey(p => p.PropuestaId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_propuestas_preinscripciones");

        // Relación con Inscripciones
        builder
            .HasMany(e => e.Inscripciones)
            .WithOne(i => i.Propuesta)
            .HasForeignKey(i => i.PropuestaId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_propuestas_inscripciones");

        // Relación con PropuestaDocentes
        builder
            .HasMany(e => e.PropuestaDocentes)
            .WithOne(pd => pd.Propuesta)
            .HasForeignKey(pd => pd.PropuestaId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_propuestas_docentes");

        // Relación con Temario (PropuestaContenidos)
        builder
            .HasMany(e => e.PropuestaContenidos)
            .WithOne(t => t.Propuesta)
            .HasForeignKey(t => t.PropuestaId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_propuestas_contenidos");
    }

    private static void ConfigureQueryFilters(EntityTypeBuilder<Propuesta> builder)
    {
        // Filtro global para excluir propuestas inactivas
        // Nota: Comentado porque en administración puede necesitar ver inactivas
        // builder.HasQueryFilter(e => e.Estado == true);
    }
}
