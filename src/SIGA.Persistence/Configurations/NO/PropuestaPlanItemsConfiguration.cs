// SIGA.Persistence/Configurations/PropuestaPlanItemsConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class PropuestaPlanItemsConfiguration : IEntityTypeConfiguration<PropuestaPlanItems>
{
    public void Configure(EntityTypeBuilder<PropuestaPlanItems> builder)
    {
        builder.HasKey(e => e.Id).HasName("propuesta_plan_items_pkey");

        builder.ToTable(
            "propuesta_plan_items",
            tb =>
                tb.HasComment(
                    "Elementos o temas específicos que componen cada módulo del plan de estudio."
                )
        );

        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("ID único autoincremental.")
            .UseIdentityColumn();

        builder
            .Property(e => e.ModuloId)
            .HasColumnName("modulo_id")
            .IsRequired()
            .HasComment("ID del módulo al que pertenece el item (FK a propuesta_plan_modulos.id).");

        builder
            .Property(e => e.Titulo)
            .HasColumnName("titulo")
            .HasMaxLength(255)
            .IsRequired()
            .HasComment("Título del tema o contenido específico.");

        builder
            .Property(e => e.Detalle)
            .HasColumnName("detalle")
            .IsRequired(false)
            .HasComment("Detalle ampliado del contenido del tema.");

        builder
            .Property(e => e.Orden)
            .HasColumnName("orden")
            .HasDefaultValue(0)
            .IsRequired()
            .HasComment("Orden secuencial del item dentro del módulo.");

        builder
            .Property(e => e.Estado)
            .HasColumnName("estado")
            .HasDefaultValue(true)
            .IsRequired()
            .HasComment("Estado activo/inactivo (true=activo, false=inactivo).");

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

        // RELACIONES
        builder
            .HasOne(d => d.Modulo)
            .WithMany(p => p.PropuestaPlanItems)
            .HasForeignKey(d => d.ModuloId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("propuesta_plan_items_modulo_id_fkey")
            .IsRequired();

        // ÍNDICES
        builder.HasIndex(e => e.ModuloId).HasDatabaseName("IX_propuesta_plan_items_modulo_id");

        builder.HasIndex(e => e.Estado).HasDatabaseName("IX_propuesta_plan_items_estado");

        builder.HasIndex(e => e.Orden).HasDatabaseName("IX_propuesta_plan_items_orden");

        builder
            .HasIndex(e => new { e.ModuloId, e.Orden })
            .IsUnique()
            .HasDatabaseName("UQ_propuesta_plan_items_modulo_orden");
    }
}
