using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities.Core;

namespace SIGA.Infrastructure.Data.Configurations;

public class TemarioConfiguration : IEntityTypeConfiguration<Temario>
{
    public void Configure(EntityTypeBuilder<Temario> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureRelationships(builder);
        // No hay seeds para Temario (son datos dinámicos)
    }

    private static void ConfigureTable(EntityTypeBuilder<Temario> builder)
    {
        builder.ToTable(
            "temarios",
            "siga",
            tb => tb.HasComment("Módulos y contenidos temáticos de las propuestas académicas")
        );

        builder.HasKey(e => e.Id).HasName("pk_temario");
    }

    private static void ConfigureProperties(EntityTypeBuilder<Temario> builder)
    {
        // ID - PostgreSQL usa serial/identity
        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .UseIdentityAlwaysColumn()
            .HasComment("Identificador único del módulo temático.");

        // Foreign Key
        builder
            .Property(e => e.PropuestaId)
            .HasColumnName("propuesta_id")
            .IsRequired()
            .HasColumnType("integer")
            .HasComment("ID de la propuesta académica (FK a propuestas.id).");

        // Contenido del módulo
        builder
            .Property(e => e.TituloModulo)
            .HasColumnName("titulo_modulo")
            .HasMaxLength(500)
            .IsRequired()
            .HasColumnType("varchar(500)")
            .HasComment("Título del módulo o unidad temática.");

        builder
            .Property(e => e.Descripcion)
            .HasColumnName("descripcion")
            .HasColumnType("text")
            .HasComment("Descripción detallada de los contenidos del módulo.");

        // Orden y duración
        builder
            .Property(e => e.Orden)
            .HasColumnName("orden")
            .IsRequired()
            .HasColumnType("integer")
            .HasComment("Número de orden del módulo dentro de la propuesta.");

        builder
            .Property(e => e.Horas)
            .HasColumnName("horas")
            .HasColumnType("integer")
            .HasComment("Cantidad de horas dedicadas a este módulo (si aplica).");
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Temario> builder)
    {
        // Índice único compuesto para evitar duplicados de orden en misma propuesta
        builder
            .HasIndex(e => new { e.PropuestaId, e.Orden })
            .IsUnique()
            .HasDatabaseName("uk_temarios_propuesta_orden");

        // Índice para búsqueda por propuesta (con ordenamiento incluido)
        builder
            .HasIndex(e => new { e.PropuestaId, e.Orden })
            .HasDatabaseName("ix_temarios_propuesta_orden");

        // Índice simple para FK
        builder.HasIndex(e => e.PropuestaId).HasDatabaseName("ix_temarios_propuesta");

        // Índice para búsqueda por título (autocompletado, búsquedas)
        builder.HasIndex(e => e.TituloModulo).HasDatabaseName("ix_temarios_titulo");
    }

    private static void ConfigureRelationships(EntityTypeBuilder<Temario> builder)
    {
        // Relación con Propuesta
        builder
            .HasOne(e => e.Propuesta)
            .WithMany(p => p.PropuestaContenidos)
            .HasForeignKey(e => e.PropuestaId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_temarios_propuesta");
    }
}
