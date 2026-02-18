using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities.Core;

namespace SIGA.Infrastructure.Data.Configurations;

public class DocenteConfiguration : IEntityTypeConfiguration<Docente>
{
    public void Configure(EntityTypeBuilder<Docente> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureRelationships(builder);
        // No hay seeds para Docente
    }

    private static void ConfigureTable(EntityTypeBuilder<Docente> builder)
    {
        builder.ToTable(
            "docentes",
            "siga",
            tb =>
                tb.HasComment(
                    "Registro de docentes y profesionales que dictan propuestas académicas"
                )
        );

        builder.HasKey(e => e.Id).HasName("pk_docente");
    }

    private static void ConfigureProperties(EntityTypeBuilder<Docente> builder)
    {
        // ID - PostgreSQL usa serial/identity
        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .UseIdentityAlwaysColumn()
            .HasComment("Identificador único del docente.");

        // Datos personales básicos
        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Nombre(s) del docente.");

        builder
            .Property(e => e.Apellido)
            .HasColumnName("apellido")
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Apellido(s) del docente.");

        builder
            .Property(e => e.Dni)
            .HasColumnName("dni")
            .HasMaxLength(20)
            .IsRequired()
            .HasColumnType("varchar(20)")
            .HasComment("Documento Nacional de Identidad del docente.");

        // Información profesional
        builder
            .Property(e => e.Profesion)
            .HasColumnName("profesion")
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Profesión o título principal del docente.");

        builder
            .Property(e => e.Especialidad)
            .HasColumnName("especialidad")
            .HasMaxLength(200)
            .HasColumnType("varchar(200)")
            .HasComment("Especialidad o área de expertise del docente.");

        builder
            .Property(e => e.Biografia)
            .HasColumnName("biografia")
            .HasColumnType("text")
            .HasComment("Biografía o resumen curricular del docente.");

        // Contacto
        builder
            .Property(e => e.Telefono)
            .HasColumnName("telefono")
            .HasMaxLength(20)
            .IsRequired()
            .HasColumnType("varchar(20)")
            .HasComment("Número de teléfono de contacto.");

        builder
            .Property(e => e.Email)
            .HasColumnName("email")
            .HasMaxLength(255)
            .IsRequired()
            .HasColumnType("varchar(255)")
            .HasComment("Correo electrónico del docente.");

        builder
            .Property(e => e.Linkedin)
            .HasColumnName("linkedin")
            .HasMaxLength(500)
            .HasColumnType("varchar(500)")
            .HasComment("URL del perfil de LinkedIn u otra red profesional.");

        // Auditoría
        builder
            .Property(e => e.Estado)
            .HasColumnName("estado")
            .HasDefaultValue(true)
            .IsRequired()
            .HasColumnType("boolean")
            .HasComment("Indica si el docente está activo en el sistema.");

        builder
            .Property(e => e.CreadoEn)
            .HasColumnName("creado_en")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("timestamp with time zone")
            .HasComment("Fecha y hora de creación del registro.");

        builder
            .Property(e => e.ActualizadoEn)
            .HasColumnName("actualizado_en")
            .HasColumnType("timestamp with time zone")
            .HasComment("Fecha y hora de la última actualización del registro.");
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Docente> builder)
    {
        // Índices únicos
        builder.HasIndex(e => e.Dni).IsUnique().HasDatabaseName("uk_docentes_dni");

        builder.HasIndex(e => e.Email).IsUnique().HasDatabaseName("uk_docentes_email");

        // Índices para búsqueda por nombre completo
        builder
            .HasIndex(e => new { e.Apellido, e.Nombre })
            .HasDatabaseName("ix_docentes_apellido_nombre");

        builder.HasIndex(e => e.Apellido).HasDatabaseName("ix_docentes_apellido");

        builder.HasIndex(e => e.Nombre).HasDatabaseName("ix_docentes_nombre");

        // Índices para búsqueda profesional
        builder.HasIndex(e => e.Profesion).HasDatabaseName("ix_docentes_profesion");

        builder
            .HasIndex(e => e.Especialidad)
            .HasDatabaseName("ix_docentes_especialidad")
            .HasFilter("especialidad IS NOT NULL");

        // Índice de filtro para activos
        builder
            .HasIndex(e => e.Estado)
            .HasDatabaseName("ix_docentes_estado")
            .HasFilter("estado = true");

        // Índice compuesto para búsquedas comunes
        builder
            .HasIndex(e => new { e.Apellido, e.Profesion })
            .HasDatabaseName("ix_docentes_apellido_profesion");
    }

    private static void ConfigureRelationships(EntityTypeBuilder<Docente> builder)
    {
        // Relación con PropuestaDocente (tabla intermedia)
        builder
            .HasMany(e => e.PropuestaDocentes)
            .WithOne(pd => pd.Docente)
            .HasForeignKey(pd => pd.DocenteId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_docentes_propuesta_docentes");
    }
}
