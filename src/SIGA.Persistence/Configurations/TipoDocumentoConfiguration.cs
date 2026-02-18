using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities.Catalog.Static;

namespace SIGA.Infrastructure.Data.Configurations;

public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumento>
{
    public void Configure(EntityTypeBuilder<TipoDocumento> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureRelationships(builder);
        ConfigureSeeds(builder);
    }

    private static void ConfigureTable(EntityTypeBuilder<TipoDocumento> builder)
    {
        builder.ToTable(
            "tipos_documento",
            "siga",
            tb => tb.HasComment("Catálogo de tipos de documento disponibles en el sistema")
        );

        builder.HasKey(e => e.Id).HasName("pk_tipo_documento");
    }

    private static void ConfigureProperties(EntityTypeBuilder<TipoDocumento> builder)
    {
        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .UseIdentityColumn()
            .HasComment("Identificador único del tipo de documento");

        builder
            .Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(50)
            .IsRequired()
            .HasComment("Código único del tipo de documento (DNI, PAS, CI, etc.)");

        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(100)
            .IsRequired()
            .HasComment("Nombre descriptivo del tipo de documento para mostrar en UI");

        builder
            .Property(e => e.Descripcion)
            .HasColumnName("descripcion")
            .HasMaxLength(255)
            .IsRequired(false)
            .HasComment("Descripción detallada del tipo de documento");

        builder
            .Property(e => e.Activo)
            .HasColumnName("activo")
            .HasDefaultValue(true)
            .IsRequired()
            .HasComment("Indica si el tipo de documento está disponible para uso");
    }

    private static void ConfigureIndexes(EntityTypeBuilder<TipoDocumento> builder)
    {
        builder.HasIndex(e => e.Codigo).HasDatabaseName("ix_tipos_documento_codigo").IsUnique();

        builder.HasIndex(e => e.Nombre).HasDatabaseName("ix_tipos_documento_nombre");

        builder
            .HasIndex(e => e.Activo)
            .HasDatabaseName("ix_tipos_documento_activo")
            .HasFilter("activo = true");
    }

    private static void ConfigureRelationships(EntityTypeBuilder<TipoDocumento> builder)
    {
        // Relación con Alumnos
        builder
            .HasMany(e => e.Alumnos)
            .WithOne(i => i.TipoDocumento)
            .HasForeignKey(i => i.TipoDocumentoId)
            .HasConstraintName("fk_tipos_documento_alumnos")
            .OnDelete(DeleteBehavior.Restrict);

        // Relación con Preinscripciones
        builder
            .HasMany(e => e.Preinscripciones)
            .WithOne(i => i.TipoDocumento)
            .HasForeignKey(i => i.TipoDocumentoId)
            .HasConstraintName("fk_tipos_documento_preinscripciones")
            .OnDelete(DeleteBehavior.Restrict);
    }

    private static void ConfigureSeeds(EntityTypeBuilder<TipoDocumento> builder)
    {
        // Seed data for initial document types
        builder.HasData(
            new TipoDocumento
            {
                Id = 1,
                Codigo = "DNI",
                Nombre = "DNI",
                Descripcion = "Documento Nacional de Identidad Argentino",
                Activo = true,
            },
            new TipoDocumento
            {
                Id = 2,
                Codigo = "PAS",
                Nombre = "Pasaporte",
                Descripcion = "Pasaporte para extranjeros",
                Activo = true,
            },
            new TipoDocumento
            {
                Id = 3,
                Codigo = "CI",
                Nombre = "Cédula",
                Descripcion = "Cédula de identidad extranjera",
                Activo = true,
            }
        );
    }
}
