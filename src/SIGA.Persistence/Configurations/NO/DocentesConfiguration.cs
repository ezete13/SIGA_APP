// SIGA.Persistence/Configurations/DocentesConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class DocentesConfiguration : IEntityTypeConfiguration<Docentes>
{
    public void Configure(EntityTypeBuilder<Docentes> builder)
    {
        builder.HasKey(e => e.Id).HasName("docentes_pkey");

        builder.ToTable(
            "docentes",
            tb =>
                tb.HasComment(
                    "Registro de docentes, disertantes y profesores que participan en las propuestas académicas."
                )
        );

        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("ID único autoincremental.")
            .UseIdentityColumn();

        builder
            .Property(e => e.Dni)
            .HasColumnName("dni")
            .HasMaxLength(20)
            .IsRequired()
            .HasComment("Documento Nacional de Identidad (único).");

        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(255)
            .IsRequired()
            .HasComment("Nombre(s) del docente.");

        builder
            .Property(e => e.Apellido)
            .HasColumnName("apellido")
            .HasMaxLength(255)
            .IsRequired()
            .HasComment("Apellido(s) del docente.");

        builder
            .Property(e => e.Email)
            .HasColumnName("email")
            .HasMaxLength(255)
            .IsRequired()
            .HasComment("Correo electrónico (único).");

        builder
            .Property(e => e.Telefono)
            .HasColumnName("telefono")
            .HasMaxLength(30)
            .IsRequired(false) // Nullable
            .HasComment("Teléfono de contacto.");

        builder
            .Property(e => e.Profesion)
            .HasColumnName("profesion")
            .HasMaxLength(255)
            .IsRequired(false) // Nullable
            .HasComment("Título profesional o formación principal.");

        builder
            .Property(e => e.Especialidad)
            .HasColumnName("especialidad")
            .HasMaxLength(100)
            .IsRequired(false) // Nullable
            .HasComment("Especialización o área de expertise.");

        builder
            .Property(e => e.Biografia)
            .HasColumnName("biografia")
            .IsRequired(false) // Nullable
            .HasComment("Resumen curricular y trayectoria profesional.");

        builder
            .Property(e => e.Linkedin)
            .HasColumnName("linkedin")
            .HasMaxLength(255)
            .IsRequired(false) // Nullable
            .HasComment("URL del perfil de LinkedIn (opcional).");

        builder
            .Property(e => e.Estado)
            .HasColumnName("estado")
            .HasDefaultValue(true)
            .IsRequired(false) // Nullable
            .HasComment("Estado activo/inactivo (true=activo, false=inactivo).");

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

        // ÍNDICES UNICOS
        builder.HasIndex(e => e.Dni).IsUnique().HasDatabaseName("docentes_dni_key");

        builder.HasIndex(e => e.Email).IsUnique().HasDatabaseName("docentes_email_key");

        // ÍNDICES para búsquedas comunes
        builder
            .HasIndex(e => new { e.Apellido, e.Nombre })
            .HasDatabaseName("IX_docentes_apellido_nombre");

        builder.HasIndex(e => e.Estado).HasDatabaseName("IX_docentes_estado");

        builder
            .HasIndex(e => e.Especialidad)
            .HasDatabaseName("IX_docentes_especialidad")
            .HasFilter("especialidad IS NOT NULL");

        // Índice para búsqueda por nombre completo
        builder
            .HasIndex(e => new
            {
                e.Nombre,
                e.Apellido,
                e.Dni,
            })
            .HasDatabaseName("IX_docentes_busqueda_completa");

        // Propiedad computada para nombre completo (opcional)
        builder
            .Property(e => e.NombreCompleto)
            .HasComputedColumnSql("nombre || ' ' || apellido", stored: true)
            .HasColumnName("nombre_completo")
            .HasComment("Nombre completo del docente (computado).");
    }
}
