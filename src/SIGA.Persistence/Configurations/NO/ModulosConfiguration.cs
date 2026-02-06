// SIGA.Persistence/Configurations/ModulosConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class ModulosConfiguration : IEntityTypeConfiguration<Modulos>
{
    public void Configure(EntityTypeBuilder<Modulos> builder)
    {
        builder.HasKey(e => e.Id).HasName("modulos_pkey");

        builder.ToTable(
            "modulos",
            tb =>
                tb.HasComment("Módulos o unidades temáticas que componen una propuesta académica.")
        );

        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("ID único autoincremental.")
            .UseIdentityColumn();

        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(100)
            .IsRequired()
            .HasComment("Nombre del módulo.");

        builder
            .Property(e => e.Orden)
            .HasColumnName("orden")
            .HasDefaultValue(0)
            .IsRequired()
            .HasComment("Orden de presentación del módulo dentro de la propuesta.");

        builder
            .Property(e => e.Descripcion)
            .HasColumnName("descripcion")
            .IsRequired(false) // Nullable
            .HasComment("Descripción detallada del contenido del módulo.");

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

        // ÍNDICE UNICO
        builder.HasIndex(e => e.Nombre).IsUnique().HasDatabaseName("modulos_nombre_key");

        // ÍNDICES adicionales
        builder.HasIndex(e => e.Orden).HasDatabaseName("IX_modulos_orden");

        builder.HasIndex(e => e.Estado).HasDatabaseName("IX_modulos_estado");

        // Relación con PropuestaPlanModulos (si existe)
        // builder.HasMany(m => m.PropuestaPlanModulos)
        //     .WithOne(ppm => ppm.Modulo)
        //     .HasForeignKey(ppm => ppm.ModuloId)
        //     .OnDelete(DeleteBehavior.Restrict);
    }
}
