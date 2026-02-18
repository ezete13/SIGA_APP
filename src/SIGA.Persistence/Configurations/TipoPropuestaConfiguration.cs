using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities.Catalog.Dynamic;

namespace SIGA.Infrastructure.Data.Configurations;

public class TipoPropuestaConfiguration : IEntityTypeConfiguration<TipoPropuesta>
{
    public void Configure(EntityTypeBuilder<TipoPropuesta> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureRelationships(builder);
        ConfigureSeeds(builder);
    }

    private static void ConfigureTable(EntityTypeBuilder<TipoPropuesta> builder)
    {
        builder.ToTable(
            "tipos_propuesta",
            "siga",
            tb =>
                tb.HasComment(
                    "Catálogo de tipos de propuestas académicas (carreras, cursos, talleres, etc.)"
                )
        );

        builder.HasKey(e => e.Id).HasName("pk_tipo_propuesta");
    }

    private static void ConfigureProperties(EntityTypeBuilder<TipoPropuesta> builder)
    {
        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .UseIdentityColumn()
            .HasComment("Identificador único del tipo de propuesta");

        builder
            .Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(50)
            .IsRequired()
            .HasComment("Código único del tipo de propuesta (GR, TC, PG, CS, etc.)");

        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(100)
            .IsRequired()
            .HasComment("Nombre descriptivo del tipo de propuesta para mostrar en UI");

        builder
            .Property(e => e.Descripcion)
            .HasColumnName("descripcion")
            .HasMaxLength(500)
            .IsRequired(false)
            .HasComment("Descripción detallada del tipo de propuesta y su alcance");

        builder
            .Property(e => e.Activo)
            .HasColumnName("activo")
            .HasDefaultValue(true)
            .IsRequired()
            .HasComment("Indica si el tipo de propuesta está disponible para uso");
    }

    private static void ConfigureIndexes(EntityTypeBuilder<TipoPropuesta> builder)
    {
        builder.HasIndex(e => e.Codigo).HasDatabaseName("ix_tipos_propuesta_codigo").IsUnique();

        builder.HasIndex(e => e.Nombre).HasDatabaseName("ix_tipos_propuesta_nombre");

        builder
            .HasIndex(e => e.Activo)
            .HasDatabaseName("ix_tipos_propuesta_activo")
            .HasFilter("activo = true");
    }

    private static void ConfigureRelationships(EntityTypeBuilder<TipoPropuesta> builder)
    {
        builder
            .HasMany(e => e.Propuestas)
            .WithOne(i => i.TipoPropuesta)
            .HasForeignKey(i => i.TipoPropuestaId)
            .HasConstraintName("fk_tipos_propuesta_propuestas")
            .OnDelete(DeleteBehavior.Restrict);
    }

    private static void ConfigureSeeds(EntityTypeBuilder<TipoPropuesta> builder)
    {
        builder.HasData(
            new TipoPropuesta
            {
                Id = 1,
                Codigo = "GR",
                Nombre = "Grado",
                Descripcion =
                    "Carrera de grado, licenciaturas y titulaciones universitarias de nivel superior",
                Activo = true,
            },
            new TipoPropuesta
            {
                Id = 2,
                Codigo = "TC",
                Nombre = "Técnicatura",
                Descripcion = "Formación técnica superior de carácter profesional y especializado",
                Activo = true,
            },
            new TipoPropuesta
            {
                Id = 3,
                Codigo = "PG",
                Nombre = "Postgrado",
                Descripcion =
                    "Estudios de especialización, maestrías y doctorados posteriores al grado",
                Activo = true,
            },
            new TipoPropuesta
            {
                Id = 4,
                Codigo = "CS",
                Nombre = "Curso",
                Descripcion = "Programas de formación específica de duración determinada",
                Activo = true,
            },
            new TipoPropuesta
            {
                Id = 5,
                Codigo = "JR",
                Nombre = "Jornada",
                Descripcion =
                    "Certificación por participación en jornadas académicas, congresos o eventos",
                Activo = true,
            },
            new TipoPropuesta
            {
                Id = 6,
                Codigo = "AC",
                Nombre = "Actualización",
                Descripcion =
                    "Programas destinados a la actualización de conocimientos profesionales",
                Activo = true,
            },
            new TipoPropuesta
            {
                Id = 7,
                Codigo = "SM",
                Nombre = "Seminario",
                Descripcion = "Seminarios académicos de formación intensiva y especializada",
                Activo = true,
            },
            new TipoPropuesta
            {
                Id = 8,
                Codigo = "TL",
                Nombre = "Taller",
                Descripcion = "Talleres prácticos para desarrollo de habilidades específicas",
                Activo = true,
            },
            new TipoPropuesta
            {
                Id = 9,
                Codigo = "CP",
                Nombre = "Capacitación",
                Descripcion = "Programas de capacitación laboral y desarrollo profesional",
                Activo = true,
            },
            new TipoPropuesta
            {
                Id = 10,
                Codigo = "HB",
                Nombre = "Habilitación",
                Descripcion = "Certificación para habilitación profesional en áreas reguladas",
                Activo = true,
            }
        );
    }
}
