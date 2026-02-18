using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities.Catalog.Static;

namespace SIGA.Infrastructure.Data.Configurations;

public class CertificadoEstadoConfiguration : IEntityTypeConfiguration<CertificadoEstado>
{
    public void Configure(EntityTypeBuilder<CertificadoEstado> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureRelationships(builder);
        ConfigureSeeds(builder);
    }

    private static void ConfigureTable(EntityTypeBuilder<CertificadoEstado> builder)
    {
        builder.ToTable(
            "certificado_estados",
            "siga",
            tb => tb.HasComment("Registro principal de estados de certificados")
        );

        builder.HasKey(e => e.Id).HasName("pk_certificado_estado");
    }

    private static void ConfigureProperties(EntityTypeBuilder<CertificadoEstado> builder)
    {
        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .UseIdentityColumn()
            .HasComment("Identificador único del estado (corresponde al valor del enum).");

        builder
            .Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(50)
            .IsRequired()
            .HasComment("Código único del estado");

        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(100)
            .IsRequired()
            .HasComment("Nombre descriptivo del estado para mostrar en UI.");

        builder
            .Property(e => e.Descripcion)
            .HasColumnName("descripcion")
            .HasMaxLength(500)
            .IsRequired(false)
            .HasComment("Descripción detallada del significado del estado.");

        builder
            .Property(e => e.Activo)
            .HasColumnName("activo")
            .HasDefaultValue(true)
            .IsRequired()
            .HasComment("Indica si el estado está disponible");
    }

    private static void ConfigureIndexes(EntityTypeBuilder<CertificadoEstado> builder)
    {
        builder.HasIndex(e => e.Codigo).HasDatabaseName("ix_estados_certificado_codigo").IsUnique();

        builder.HasIndex(e => e.Nombre).HasDatabaseName("ix_estados_certificado_nombre");

        builder
            .HasIndex(e => e.Activo)
            .HasDatabaseName("ix_estados_certificado_activo")
            .HasFilter("activo = true");
    }

    private static void ConfigureRelationships(EntityTypeBuilder<CertificadoEstado> builder)
    {
        builder
            .HasMany(e => e.Certificados)
            .WithOne(i => i.CertificadoEstado)
            .HasForeignKey(i => i.CertificadoEstadoId)
            .HasConstraintName("fk_estados_certificado_certificados")
            .OnDelete(DeleteBehavior.Restrict);
    }

    private static void ConfigureSeeds(EntityTypeBuilder<CertificadoEstado> builder)
    {
        // Seed data for enum values
        builder.HasData(
            new CertificadoEstado
            {
                Id = 1,
                Codigo = "NOG",
                Nombre = "No Generable",
                Descripcion =
                    "Estado inicial: el alumno aún no cumple requisitos. El certificado no puede generarse, editarse ni eliminarse.",
                Activo = true,
            },
            new CertificadoEstado
            {
                Id = 2,
                Codigo = "PEN",
                Nombre = "Pendiente",
                Descripcion =
                    "El alumno cumple requisitos. El certificado puede generarse pero aún no existe emitido. No permite edición.",
                Activo = true,
            },
            new CertificadoEstado
            {
                Id = 3,
                Codigo = "GEN",
                Nombre = "Generado",
                Descripcion =
                    "El certificado fue emitido y registrado. Solo puede modificarse mediante versionado y no puede eliminarse.",
                Activo = true,
            },
            new CertificadoEstado
            {
                Id = 4,
                Codigo = "APR",
                Nombre = "Aprobado",
                Descripcion =
                    "Certificado validado institucionalmente. No puede modificarse ni eliminarse y es plenamente oficial.",
                Activo = true,
            },
            new CertificadoEstado
            {
                Id = 5,
                Codigo = "INH",
                Nombre = "Inhabilitado",
                Descripcion =
                    "Certificado temporalmente no válido por revisión o inconsistencias. No puede editarse ni eliminarse. El QR refleja no validez.",
                Activo = false,
            },
            new CertificadoEstado
            {
                Id = 6,
                Codigo = "REV",
                Nombre = "Revocado",
                Descripcion =
                    "Certificado invalidado definitivamente. No puede modificarse ni eliminarse. El QR indica revocación y no validez.",
                Activo = false,
            }
        );
    }
}
