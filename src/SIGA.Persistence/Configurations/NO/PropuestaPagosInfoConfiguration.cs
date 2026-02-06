// SIGA.Persistence/Configurations/PropuestaPagosInfoConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class PropuestaPagosInfoConfiguration : IEntityTypeConfiguration<PropuestaPagosInfo>
{
    public void Configure(EntityTypeBuilder<PropuestaPagosInfo> builder)
    {
        builder.HasKey(e => e.Id).HasName("propuesta_pagos_info_pkey");

        builder.ToTable(
            "propuesta_pagos_info",
            tb =>
                tb.HasComment(
                    "Opciones y modalidades de pago disponibles para cada propuesta académica."
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
            .HasComment("ID de la propuesta académica (FK a propuestas.id).");

        builder
            .Property(e => e.Concepto)
            .HasColumnName("concepto")
            .HasMaxLength(100)
            .IsRequired()
            .HasComment(
                "Concepto o descripción de la opción de pago. Ej: Contado, 3 cuotas, Promo especial."
            );

        builder
            .Property(e => e.Importe)
            .HasColumnName("importe")
            .HasPrecision(10, 2)
            .IsRequired()
            .HasComment("Importe total o valor de la cuota según corresponda.");

        builder
            .Property(e => e.Cuotas)
            .HasColumnName("cuotas")
            .IsRequired(false)
            .HasComment("Número de cuotas (NULL para pago contado).");

        builder
            .Property(e => e.Observaciones)
            .HasColumnName("observaciones")
            .IsRequired(false)
            .HasComment("Observaciones adicionales sobre la modalidad de pago.");

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

        // RELACIONES
        builder
            .HasOne(d => d.Propuesta)
            .WithMany(p => p.PropuestaPagosInfo)
            .HasForeignKey(d => d.PropuestaId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("propuesta_pagos_info_propuesta_id_fkey")
            .IsRequired();

        // ÍNDICES
        builder
            .HasIndex(e => e.PropuestaId)
            .HasDatabaseName("IX_propuesta_pagos_info_propuesta_id");

        builder.HasIndex(e => e.Estado).HasDatabaseName("IX_propuesta_pagos_info_estado");

        builder.HasIndex(e => e.Concepto).HasDatabaseName("IX_propuesta_pagos_info_concepto");
    }
}
