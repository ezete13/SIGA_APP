// SIGA.Persistence/Configurations/PropuestaPlanModulosConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class PropuestaPlanModulosConfiguration : IEntityTypeConfiguration<PropuestaPlanModulos>
{
    public void Configure(EntityTypeBuilder<PropuestaPlanModulos> builder)
    {
        builder.HasKey(e => e.Id).HasName("propuesta_plan_modulos_pkey");

        builder.ToTable(
            "propuesta_plan_modulos",
            tb =>
                tb.HasComment(
                    "Módulos o unidades temáticas que componen el plan de estudio de una propuesta académica."
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
                "ID de la propuesta académica a la que pertenece el módulo (FK a propuestas.id)."
            );

        builder
            .Property(e => e.Titulo)
            .HasColumnName("titulo")
            .HasMaxLength(255)
            .IsRequired()
            .HasComment("Título descriptivo del módulo temático.");

        builder
            .Property(e => e.Descripcion)
            .HasColumnName("descripcion")
            .IsRequired(false)
            .HasComment("Descripción detallada del contenido del módulo.");

        builder
            .Property(e => e.Orden)
            .HasColumnName("orden")
            .HasDefaultValue(0)
            .IsRequired()
            .HasComment("Orden secuencial del módulo dentro del plan de estudio.");

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
            .HasOne(d => d.Propuesta)
            .WithMany(p => p.PropuestaPlanModulos)
            .HasForeignKey(d => d.PropuestaId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("propuesta_plan_modulos_propuesta_id_fkey")
            .IsRequired();

        // Relación con Items (si existe navegación)
        // builder.HasMany(m => m.PropuestaPlanItems)
        //     .WithOne(i => i.Modulo)
        //     .HasForeignKey(i => i.ModuloId)
        //     .OnDelete(DeleteBehavior.Cascade);

        // ÍNDICES
        builder
            .HasIndex(e => e.PropuestaId)
            .HasDatabaseName("IX_propuesta_plan_modulos_propuesta_id");

        builder.HasIndex(e => e.Estado).HasDatabaseName("IX_propuesta_plan_modulos_estado");

        builder.HasIndex(e => e.Orden).HasDatabaseName("IX_propuesta_plan_modulos_orden");

        builder
            .HasIndex(e => new { e.PropuestaId, e.Orden })
            .IsUnique()
            .HasDatabaseName("UQ_propuesta_plan_modulos_propuesta_orden");
    }
}
