// SIGA.Persistence/Configurations/SedesConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class SedesConfiguration : IEntityTypeConfiguration<Sedes>
{
    public void Configure(EntityTypeBuilder<Sedes> builder)
    {
        builder.HasKey(e => e.Id).HasName("sedes_pkey");

        builder.ToTable(
            "sedes",
            tb => tb.HasComment("Tabla de sedes de la universidad en el país.")
        );

        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("ID único autoincremental.")
            .UseIdentityColumn();

        builder
            .Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(10)
            .IsRequired()
            .HasComment("Código interno único.");

        builder
            .Property(e => e.Direccion)
            .HasColumnName("direccion")
            .HasMaxLength(255)
            .IsRequired(false)
            .HasComment("Dirección física.");

        builder
            .Property(e => e.Localidad)
            .HasColumnName("localidad")
            .HasMaxLength(255)
            .IsRequired()
            .HasComment("Localidad o ciudad donde se encuentra.");

        builder
            .Property(e => e.Provincia)
            .HasColumnName("provincia")
            .HasMaxLength(255)
            .IsRequired()
            .HasComment("Provincia donde se encuentra ubicada.");

        builder
            .Property(e => e.CodigoPostal)
            .HasColumnName("codigo_postal")
            .HasMaxLength(255)
            .IsRequired(false)
            .HasComment("Código postal.");

        builder
            .Property(e => e.Estado)
            .HasColumnName("estado")
            .HasDefaultValue(true)
            .IsRequired()
            .HasComment("Estado activo/inactivo (true=activa, false=inactiva).");

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

        // ÍNDICES
        builder.HasIndex(e => e.Codigo).IsUnique().HasDatabaseName("sedes_codigo_key");

        builder.HasIndex(e => e.Estado).HasDatabaseName("IX_sedes_estado");

        builder.HasIndex(e => e.Provincia).HasDatabaseName("IX_sedes_provincia");

        builder
            .HasIndex(e => new { e.Localidad, e.Provincia })
            .HasDatabaseName("IX_sedes_localidad_provincia");

        // Propiedad computada para nombre completo (opcional)
        builder
            .Property(e => e.NombreCompleto)
            .HasComputedColumnSql("codigo || ' - ' || localidad || ', ' || provincia", stored: true)
            .HasColumnName("nombre_completo")
            .HasComment("Nombre completo de la sede (computado).");
    }
}
