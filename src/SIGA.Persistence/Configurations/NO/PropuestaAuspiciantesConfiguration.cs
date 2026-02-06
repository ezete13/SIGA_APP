// SIGA.Persistence/Configurations/PropuestaAuspiciantesConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class PropuestaAuspiciantesConfiguration : IEntityTypeConfiguration<PropuestaAuspiciantes>
{
    public void Configure(EntityTypeBuilder<PropuestaAuspiciantes> builder)
    {
        builder.HasKey(e => e.Id).HasName("propuesta_auspiciantes_pkey");

        builder.ToTable(
            "propuesta_auspiciantes",
            tb =>
                tb.HasComment(
                    "Relación muchos a muchos entre propuestas y auspiciantes, con orden de aparición."
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
            .Property(e => e.AuspicianteId)
            .HasColumnName("auspiciante_id")
            .IsRequired()
            .HasComment("ID de la organización auspiciante (FK a auspiciantes.id).");

        builder
            .Property(e => e.Orden)
            .HasColumnName("orden")
            .HasDefaultValue(0)
            .IsRequired()
            .HasComment("Orden de aparición en la web (para ordenar logos de auspiciantes).");

        // RELACIONES
        builder
            .HasOne(d => d.Propuesta)
            .WithMany(p => p.PropuestaAuspiciantes)
            .HasForeignKey(d => d.PropuestaId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("propuesta_auspiciantes_propuesta_id_fkey")
            .IsRequired();

        builder
            .HasOne(d => d.Auspiciante)
            .WithMany(p => p.PropuestaAuspiciantes)
            .HasForeignKey(d => d.AuspicianteId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("propuesta_auspiciantes_auspiciante_id_fkey")
            .IsRequired();

        // ÍNDICES
        builder
            .HasIndex(e => new { e.PropuestaId, e.AuspicianteId })
            .IsUnique()
            .HasDatabaseName("propuesta_auspiciantes_propuesta_id_auspiciante_id_key");

        builder
            .HasIndex(e => e.PropuestaId)
            .HasDatabaseName("IX_propuesta_auspiciantes_propuesta_id");

        builder
            .HasIndex(e => e.AuspicianteId)
            .HasDatabaseName("IX_propuesta_auspiciantes_auspiciante_id");

        builder.HasIndex(e => e.Orden).HasDatabaseName("IX_propuesta_auspiciantes_orden");
    }
}
