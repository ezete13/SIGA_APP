using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities;

namespace SIGA.Persistence.Configurations;

public class AuspicianteConfiguration : IEntityTypeConfiguration<Auspiciante>
{
    public void Configure(EntityTypeBuilder<Auspiciante> builder)
    {
        builder.HasKey(e => e.Id).HasName("auspiciantes_pkey");

        builder.ToTable(
            "auspiciantes",
            tb =>
                tb.HasComment(
                    "Registro de organizaciones, empresas e instituciones que auspician propuestas académicas."
                )
        );

        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("ID único autoincremental.")
            .UseIdentityColumn();

        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(255)
            .IsRequired()
            .HasComment("Nombre de la organización auspiciante.");

        builder
            .Property(e => e.LogoImg)
            .HasColumnName("logo")
            .HasMaxLength(500)
            .IsRequired()
            .HasComment("URL o ruta del archivo del logo institucional (opcional).");

        builder
            .Property(e => e.SitioWeb)
            .HasColumnName("sitio_web")
            .HasMaxLength(255)
            .IsRequired()
            .HasComment("Sitio web oficial de la organización (opcional).");

        builder.HasIndex(e => e.Nombre).HasDatabaseName("IX_auspiciantes_nombre");
    }
}
