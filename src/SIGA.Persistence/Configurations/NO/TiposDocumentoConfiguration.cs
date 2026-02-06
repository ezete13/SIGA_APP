// SIGA.Persistence/Configurations/TiposDocumentoConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class TiposDocumentoConfiguration : IEntityTypeConfiguration<TiposDocumento>
{
    public void Configure(EntityTypeBuilder<TiposDocumento> builder)
    {
        builder.HasKey(e => e.Id).HasName("tipos_documento_pkey");

        builder.ToTable(
            "tipos_documento",
            tb =>
                tb.HasComment(
                    "Catálogo de tipos de documentos de identificación. Ej: DNI, Pasaporte, Cédula Extranjera."
                )
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
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(50)
            .IsRequired()
            .HasComment("Nombre del tipo de documento. Ej: DNI, Pasaporte.");

        builder
            .Property(e => e.Descripcion)
            .HasColumnName("descripcion")
            .IsRequired(false)
            .HasComment("Descripción del tipo de documento.");

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

        // RELACIONES INVERSAS
        builder
            .HasMany(t => t.Inscripciones)
            .WithOne(i => i.TipoDocumento)
            .HasForeignKey(i => i.TipoDocumentoId)
            .OnDelete(DeleteBehavior.Restrict);

        // ÍNDICES
        builder.HasIndex(e => e.Codigo).IsUnique().HasDatabaseName("tipos_documento_codigo_key");

        builder.HasIndex(e => e.Estado).HasDatabaseName("IX_tipos_documento_estado");

        builder.HasIndex(e => e.Nombre).HasDatabaseName("IX_tipos_documento_nombre");
    }
}
