using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities.Core;

namespace SIGA.Infrastructure.Data.Configurations;

public class AutoridadConfiguration : IEntityTypeConfiguration<Autoridad>
{
    public void Configure(EntityTypeBuilder<Autoridad> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureRelationships(builder);
        // No hay seeds para Autoridad
    }

    private static void ConfigureTable(EntityTypeBuilder<Autoridad> builder)
    {
        builder.ToTable(
            "autoridades",
            "siga",
            tb => tb.HasComment("Registro de autoridades académicas que firman certificados")
        );

        builder.HasKey(e => e.Id).HasName("pk_autoridad");
    }

    private static void ConfigureProperties(EntityTypeBuilder<Autoridad> builder)
    {
        // ID - PostgreSQL usa serial/identity
        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .UseIdentityAlwaysColumn()
            .HasComment("Identificador único de la autoridad.");

        // Foreign Keys
        builder
            .Property(e => e.UnidadId)
            .HasColumnName("unidad_id")
            .IsRequired()
            .HasComment("ID de la unidad académica a la que pertenece (FK a unidades.id).");

        builder
            .Property(e => e.PeriodoLectivoId)
            .HasColumnName("periodo_lectivo_id")
            .IsRequired()
            .HasComment(
                "ID del período lectivo en el que ejerce el cargo (FK a periodos_lectivos.id)."
            );

        // Datos personales
        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Nombre(s) de la autoridad.");

        builder
            .Property(e => e.Apellido)
            .HasColumnName("apellido")
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Apellido(s) de la autoridad.");

        builder
            .Property(e => e.Cargo)
            .HasColumnName("cargo")
            .HasMaxLength(200)
            .IsRequired()
            .HasColumnType("varchar(200)")
            .HasComment("Cargo o posición que ocupa (Rector, Decano, Secretario, etc.).");

        // Imagen de firma
        builder
            .Property(e => e.FirmaImg)
            .HasColumnName("firma_img")
            .HasMaxLength(500)
            .IsRequired()
            .HasColumnType("varchar(500)")
            .HasComment("Ruta o URL de la imagen de la firma escaneada.");

        // Auditoría
        builder
            .Property(e => e.Activo)
            .HasColumnName("activo")
            .HasDefaultValue(true)
            .IsRequired()
            .HasColumnType("boolean")
            .HasComment("Indica si la autoridad está activa en el sistema.");

        builder
            .Property(e => e.CreadoEn)
            .HasColumnName("creado_en")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired()
            .HasColumnType("timestamp with time zone")
            .HasComment("Fecha y hora de creación del registro.");

        builder
            .Property(e => e.ActualizadoEn)
            .HasColumnName("actualizado_en")
            .HasColumnType("timestamp with time zone")
            .HasComment("Fecha y hora de la última actualización del registro.");
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Autoridad> builder)
    {
        // Índices compuestos para búsquedas comunes
        builder
            .HasIndex(e => new { e.UnidadId, e.PeriodoLectivoId })
            .HasDatabaseName("ix_autoridades_unidad_periodo");

        builder
            .HasIndex(e => new { e.Apellido, e.Nombre })
            .HasDatabaseName("ix_autoridades_apellido_nombre");

        // Índices individuales
        builder.HasIndex(e => e.UnidadId).HasDatabaseName("ix_autoridades_unidad");

        builder.HasIndex(e => e.PeriodoLectivoId).HasDatabaseName("ix_autoridades_periodo_lectivo");

        builder.HasIndex(e => e.Apellido).HasDatabaseName("ix_autoridades_apellido");

        builder.HasIndex(e => e.Nombre).HasDatabaseName("ix_autoridades_nombre");

        builder.HasIndex(e => e.Cargo).HasDatabaseName("ix_autoridades_cargo");

        // Índice de filtro para activos
        builder
            .HasIndex(e => e.Activo)
            .HasDatabaseName("ix_autoridades_activo")
            .HasFilter("activo = true");

        // Índice único para evitar duplicados de la misma autoridad en el mismo período y unidad
        builder
            .HasIndex(e => new
            {
                e.UnidadId,
                e.PeriodoLectivoId,
                e.Apellido,
                e.Nombre,
                e.Cargo,
            })
            .IsUnique()
            .HasDatabaseName("uk_autoridades_unidad_periodo_persona_cargo");
    }

    private static void ConfigureRelationships(EntityTypeBuilder<Autoridad> builder)
    {
        // Relación con Unidad
        builder
            .HasOne(e => e.Unidad)
            .WithMany(u => u.Autoridades)
            .HasForeignKey(e => e.UnidadId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_autoridades_unidad");

        // Relación con PeriodoLectivo
        builder
            .HasOne(e => e.PeriodoLectivo)
            .WithMany(p => p.Autoridades)
            .HasForeignKey(e => e.PeriodoLectivoId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("fk_autoridades_periodo_lectivo");
    }
}
