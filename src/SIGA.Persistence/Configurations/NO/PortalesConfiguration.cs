// SIGA.Persistence/Configurations/PortalesConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class PortalesConfiguration : IEntityTypeConfiguration<Portales>
{
    public void Configure(EntityTypeBuilder<Portales> builder)
    {
        builder.HasKey(e => e.Id).HasName("portales_pkey");

        builder.ToTable(
            "portales",
            tb =>
                tb.HasComment(
                    "Contenido y configuración específica para la publicación web de cada propuesta académica. Incluye información promocional, SEO y datos para llenar las páginas web."
                )
        );

        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("ID único autoincremental.")
            .UseIdentityColumn();

        builder
            .Property(e => e.PropuestaId)
            .HasColumnName("propuesta_id")
            .IsRequired()
            .HasComment(
                "ID de la propuesta académica asociada (FK a propuestas.id). Relación 1:1."
            );

        builder
            .Property(e => e.Slug)
            .HasColumnName("slug")
            .HasMaxLength(100)
            .IsRequired()
            .HasComment(
                "URL amigable única para el portal web. Formato: nombre-curso-año. Ej: diplomatura-ortodoncia-2024."
            );

        builder
            .Property(e => e.TituloWeb)
            .HasColumnName("titulo_web")
            .HasMaxLength(255)
            .IsRequired()
            .HasComment(
                "Título optimizado para la web, puede ser más atractivo o descriptivo que el título académico oficial."
            );

        // CONTENIDO PROMOCIONAL
        builder
            .Property(e => e.AcercaDe)
            .HasColumnName("acerca_de")
            .IsRequired(false)
            .HasComment(
                "Descripción general y atractiva del curso (200-500 caracteres). Objetivos principales y beneficios."
            );

        builder
            .Property(e => e.Fundamentacion)
            .HasColumnName("fundamentacion")
            .IsRequired(false)
            .HasComment(
                "Argumentos y razones por las que estudiar este curso (200-500 caracteres). Beneficios y valor agregado."
            );

        builder
            .Property(e => e.Destinatarios)
            .HasColumnName("destinatarios")
            .IsRequired(false)
            .HasComment(
                "Público objetivo específico para el que está destinado el curso (100-300 caracteres)."
            );

        builder
            .Property(e => e.Requisitos)
            .HasColumnName("requisitos")
            .IsRequired(false)
            .HasComment("Requisitos de admisión y participación (100-300 caracteres).");

        builder
            .Property(e => e.PerfilEstudiante)
            .HasColumnName("perfil_estudiante")
            .IsRequired(false)
            .HasComment("Descripción del perfil ideal del participante (100-300 caracteres).");

        // SEO
        builder
            .Property(e => e.MetaDescription)
            .HasColumnName("meta_description")
            .HasMaxLength(500)
            .IsRequired(false)
            .HasComment(
                "Meta descripción para motores de búsqueda (SEO) - ideal 150-160 caracteres."
            );

        builder
            .Property(e => e.MetaKeywords)
            .HasColumnName("meta_keywords")
            .IsRequired(false)
            .HasComment(
                "Palabras clave para SEO separadas por coma - máximo 10-15 palabras clave relevantes."
            );

        builder
            .Property(e => e.MetaOgTitle)
            .HasColumnName("meta_og_title")
            .HasMaxLength(255)
            .IsRequired(false)
            .HasComment(
                "Título optimizado para compartir en redes sociales (Open Graph) - máximo 60 caracteres."
            );

        // MEDIOS
        builder
            .Property(e => e.BannerImg)
            .HasColumnName("banner_img")
            .HasMaxLength(500)
            .IsRequired(false)
            .HasComment(
                "URL o ruta de la imagen de cabecera/banner principal del portal web (recomendado 1200x400px)."
            );

        builder
            .Property(e => e.MetaOgImage)
            .HasColumnName("meta_og_image")
            .HasMaxLength(500)
            .IsRequired(false)
            .HasComment(
                "Imagen optimizada para compartir en redes sociales (Open Graph) - recomendado 1200x630px."
            );

        // CONFIGURACIÓN
        builder
            .Property(e => e.Estado)
            .HasColumnName("estado")
            .HasDefaultValue(true)
            .IsRequired()
            .HasComment(
                "Estado de publicación del portal (true=publicado visible en web, false=no publicado)."
            );

        builder
            .Property(e => e.PermiteInscripciones)
            .HasColumnName("permite_inscripciones")
            .HasDefaultValue(true)
            .IsRequired();

        builder
            .Property(e => e.Etiquetas)
            .HasColumnName("etiquetas")
            .IsRequired(false)
            .HasComment(
                "Etiquetas o tags separados por coma para búsqueda interna y categorización. Ej: salud, tecnología, educación."
            );

        builder
            .Property(e => e.Visitas)
            .HasColumnName("visitas")
            .HasDefaultValue(0)
            .IsRequired()
            .HasComment("Contador de visitas al portal web para análisis de tráfico.");

        // TIMESTAMPS
        builder
            .Property(e => e.CreadoEn)
            .HasColumnName("creado_en")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired(false)
            .HasComment("Fecha y hora de creación del registro del portal.");

        builder
            .Property(e => e.ActualizadoEn)
            .HasColumnName("actualizado_en")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired(false)
            .HasComment("Fecha y hora de última actualización del contenido del portal.");

        // RELACIONES
        builder
            .HasOne(d => d.Propuesta)
            .WithOne(p => p.Portales)
            .HasForeignKey<Portales>(d => d.PropuestaId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("portales_propuesta_id_fkey")
            .IsRequired();

        // ÍNDICES
        builder
            .HasIndex(e => e.PropuestaId)
            .IsUnique()
            .HasDatabaseName("portales_propuesta_id_key");

        builder.HasIndex(e => e.Slug).IsUnique().HasDatabaseName("portales_slug_key");

        builder.HasIndex(e => e.Estado).HasDatabaseName("IX_portales_estado");

        builder
            .HasIndex(e => e.PermiteInscripciones)
            .HasDatabaseName("IX_portales_permite_inscripciones");

        builder
            .HasIndex(e => new { e.Estado, e.PermiteInscripciones })
            .HasDatabaseName("IX_portales_estado_inscripciones");
    }
}
