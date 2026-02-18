using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities.Core;

namespace SIGA.Infrastructure.Data.Configurations;

public class PropuestaWebConfiguration : IEntityTypeConfiguration<PropuestaWeb>
{
    public void Configure(EntityTypeBuilder<PropuestaWeb> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureRelationships(builder);
        ConfigureQueryFilters(builder);
        // No hay seeds para PropuestaWeb
    }

    private static void ConfigureTable(EntityTypeBuilder<PropuestaWeb> builder)
    {
        builder.ToTable(
            "propuestas_web",
            "siga",
            tb => tb.HasComment("Landing pages y contenido web para propuestas académicas")
        );

        builder.HasKey(e => e.Id).HasName("pk_propuesta_web");
    }

    private static void ConfigureProperties(EntityTypeBuilder<PropuestaWeb> builder)
    {
        // ID - PostgreSQL usa serial/identity
        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .UseIdentityAlwaysColumn()
            .HasComment("Identificador único de la landing page.");

        // Foreign Key
        builder
            .Property(e => e.PropuestaId)
            .HasColumnName("propuesta_id")
            .IsRequired()
            .HasColumnType("integer")
            .HasComment("ID de la propuesta académica asociada (FK a propuestas.id).");

        // Títulos y URLs
        builder
            .Property(e => e.TituloWeb)
            .HasColumnName("titulo_web")
            .HasMaxLength(200)
            .HasColumnType("varchar(200)")
            .HasComment("Título de la landing page (puede diferir del título académico).");

        builder
            .Property(e => e.Slug)
            .HasColumnName("slug")
            .HasMaxLength(200)
            .IsRequired()
            .HasColumnType("varchar(200)")
            .HasComment("Identificador URL amigable único para la landing page.");

        builder
            .Property(e => e.BannerImg)
            .HasColumnName("banner_img")
            .HasMaxLength(500)
            .HasColumnType("varchar(500)")
            .HasComment("URL de la imagen de banner para la landing page.");

        // Contenido principal (campos largos)
        builder
            .Property(e => e.AcercaDe)
            .HasColumnName("acerca_de")
            .HasColumnType("text")
            .HasComment("Descripción general de la propuesta para la web.");

        builder
            .Property(e => e.PerfilEstudiante)
            .HasColumnName("perfil_estudiante")
            .HasColumnType("text")
            .HasComment("Descripción del perfil del estudiante ideal.");

        builder
            .Property(e => e.Requisitos)
            .HasColumnName("requisitos")
            .HasColumnType("text")
            .HasComment("Requisitos de inscripción y cursado.");

        builder
            .Property(e => e.Destinatarios)
            .HasColumnName("destinatarios")
            .HasColumnType("text")
            .HasComment("Público objetivo al que está dirigida la propuesta.");

        builder
            .Property(e => e.Fundamentacion)
            .HasColumnName("fundamentacion")
            .HasColumnType("text")
            .HasComment("Fundamentación académica y pedagógica.");

        // Metadatos y SEO
        builder
            .Property(e => e.Etiquetas)
            .HasColumnName("etiquetas")
            .HasMaxLength(500)
            .HasColumnType("varchar(500)")
            .HasComment("Etiquetas para categorización (pueden ser JSON o CSV).");

        builder
            .Property(e => e.MetaOgTitle)
            .HasColumnName("meta_og_title")
            .HasMaxLength(200)
            .HasColumnType("varchar(200)")
            .HasComment("Título para Open Graph (compartir en redes).");

        builder
            .Property(e => e.MetaOgImage)
            .HasColumnName("meta_og_image")
            .HasMaxLength(500)
            .HasColumnType("varchar(500)")
            .HasComment("Imagen para Open Graph (compartir en redes).");

        builder
            .Property(e => e.MetaDescription)
            .HasColumnName("meta_description")
            .HasMaxLength(500)
            .HasColumnType("varchar(500)")
            .HasComment("Meta descripción para SEO.");

        builder
            .Property(e => e.MetaKeywords)
            .HasColumnName("meta_keywords")
            .HasMaxLength(500)
            .HasColumnType("varchar(500)")
            .HasComment("Meta keywords para SEO.");

        // Configuración y estadísticas
        builder
            .Property(e => e.PermiteInscripciones)
            .HasColumnName("permite_inscripciones")
            .HasDefaultValue(true)
            .HasColumnType("boolean")
            .HasComment("Indica si la landing page permite inscripciones online.");

        builder
            .Property(e => e.Visitas)
            .HasColumnName("visitas")
            .HasDefaultValue(0)
            .HasColumnType("integer")
            .HasComment("Contador de visitas a la landing page.");

        // Auditoría
        builder
            .Property(e => e.Estado)
            .HasColumnName("estado")
            .HasDefaultValue(true)
            .HasColumnType("boolean")
            .HasComment("Indica si la landing page está publicada/activa.");

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

    private static void ConfigureIndexes(EntityTypeBuilder<PropuestaWeb> builder)
    {
        // Índices únicos
        builder
            .HasIndex(e => e.PropuestaId)
            .IsUnique()
            .HasDatabaseName("uk_propuestas_web_propuesta");

        builder.HasIndex(e => e.Slug).IsUnique().HasDatabaseName("uk_propuestas_web_slug");

        // Índices para búsqueda
        builder.HasIndex(e => e.TituloWeb).HasDatabaseName("ix_propuestas_web_titulo");

        builder.HasIndex(e => e.Etiquetas).HasDatabaseName("ix_propuestas_web_etiquetas");

        // Índices compuestos para filtrado
        builder
            .HasIndex(e => new { e.Estado, e.PermiteInscripciones })
            .HasDatabaseName("ix_propuestas_web_estado_inscripciones");

        // Índices de filtro
        builder
            .HasIndex(e => e.Estado)
            .HasDatabaseName("ix_propuestas_web_estado")
            .HasFilter("estado = true");

        builder
            .HasIndex(e => e.PermiteInscripciones)
            .HasDatabaseName("ix_propuestas_web_permite_inscripciones")
            .HasFilter("permite_inscripciones = true");

        // Índice para ordenamiento por visitas (populares)
        builder.HasIndex(e => e.Visitas).HasDatabaseName("ix_propuestas_web_visitas");
    }

    private static void ConfigureRelationships(EntityTypeBuilder<PropuestaWeb> builder)
    {
        // Relación uno a uno con Propuesta
        builder
            .HasOne(e => e.Propuesta)
            .WithOne(p => p.PropuestaWeb)
            .HasForeignKey<PropuestaWeb>(e => e.PropuestaId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_propuestas_web_propuesta");
    }

    private static void ConfigureQueryFilters(EntityTypeBuilder<PropuestaWeb> builder)
    {
        // Filtro global para excluir landing pages no publicadas
        // Nota: Comentado porque puede no ser deseable en todos los casos (ej. admin)
        // builder.HasQueryFilter(e => e.Estado == true);
    }
}
