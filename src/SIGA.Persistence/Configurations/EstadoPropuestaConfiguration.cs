// SIGA.Persistence/Configurations/TiposEstadoPropuestaConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class EstadoPropuestaConfiguration : IEntityTypeConfiguration<EstadoPropuesta>
{
    public void Configure(EntityTypeBuilder<EstadoPropuesta> builder)
    {
        builder.HasKey(e => e.Id).HasName("estados_propuesta_pkey");

        builder.ToTable(
            "estados_propuesta",
            tb => tb.HasComment("Catálogo de estados posibles para las propuestas académicas.")
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
            .HasComment("Nombre del estado. Ej: Borrador, Publicada, Archivada.");

        builder
            .Property(e => e.Descripcion)
            .HasColumnName("descripcion")
            .IsRequired(false)
            .HasComment("Descripción del tipo de estado.");

        builder
            .Property(e => e.Activo)
            .HasColumnName("activo")
            .HasDefaultValue(true)
            .IsRequired()
            .HasComment("Estado activo/inactivo (true=activo, false=inactivo).");

        builder
            .HasMany(t => t.Propuesta)
            .WithOne(p => p.EstadoPropuesta)
            .HasForeignKey(p => p.EstadoPropuestaId)
            .OnDelete(DeleteBehavior.Restrict);

        // ÍNDICES
        builder.HasIndex(e => e.Codigo).IsUnique().HasDatabaseName("estados_propuesta_codigo_key");

        builder.HasIndex(e => e.Estado).HasDatabaseName("IX_tipos_estado_propuesta_estado");

        builder.HasIndex(e => e.Nombre).HasDatabaseName("IX_tipos_estado_propuesta_nombre");
    }
}
