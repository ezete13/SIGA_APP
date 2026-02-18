using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGA.Domain.Entities.Catalog.Dynamic;

namespace SIGA.Infrastructure.Data.Configurations;

public class UnidadConfiguration : IEntityTypeConfiguration<Unidad>
{
    public void Configure(EntityTypeBuilder<Unidad> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureRelationships(builder);
        ConfigureSeeds(builder);
    }

    private static void ConfigureTable(EntityTypeBuilder<Unidad> builder)
    {
        builder.ToTable(
            "unidades",
            "siga",
            tb =>
                tb.HasComment(
                    "Unidades académicas y administrativas (sedes, facultades, escuelas, institutos)"
                )
        );

        builder.HasKey(e => e.Id).HasName("pk_unidad");
    }

    private static void ConfigureProperties(EntityTypeBuilder<Unidad> builder)
    {
        builder
            .Property(e => e.Id)
            .HasColumnName("id")
            .UseIdentityColumn()
            .HasComment("Identificador único de la unidad");

        builder
            .Property(e => e.Codigo)
            .HasColumnName("codigo")
            .HasMaxLength(50)
            .IsRequired()
            .HasComment("Código único de la unidad (UCCSJ, FCEE, FCM, etc.)");

        builder
            .Property(e => e.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(200)
            .IsRequired()
            .HasComment("Nombre completo de la unidad académica");

        builder
            .Property(e => e.NombreCorto)
            .HasColumnName("nombre_corto")
            .HasMaxLength(100)
            .IsRequired()
            .HasComment("Nombre abreviado o de uso común de la unidad");

        builder
            .Property(e => e.Siglas)
            .HasColumnName("siglas")
            .HasMaxLength(20)
            .IsRequired()
            .HasComment("Siglas identificadoras de la unidad");

        builder
            .Property(e => e.Descripcion)
            .HasColumnName("descripcion")
            .HasMaxLength(500)
            .IsRequired(false)
            .HasComment("Descripción adicional de la unidad");

        builder
            .Property(e => e.ColorPrincipal)
            .HasColumnName("color_principal")
            .HasMaxLength(20)
            .IsRequired(false)
            .HasComment("Color principal en formato hexadecimal para identificación visual");

        builder
            .Property(e => e.ColorSecundario)
            .HasColumnName("color_secundario")
            .HasMaxLength(20)
            .IsRequired(false)
            .HasComment("Color secundario en formato hexadecimal para identificación visual");

        builder
            .Property(e => e.Direccion)
            .HasColumnName("direccion")
            .HasMaxLength(255)
            .IsRequired(false)
            .HasComment("Dirección física de la unidad");

        builder
            .Property(e => e.Telefono)
            .HasColumnName("telefono")
            .HasMaxLength(50)
            .IsRequired(false)
            .HasComment("Teléfono de contacto de la unidad");

        builder
            .Property(e => e.Email)
            .HasColumnName("email")
            .HasMaxLength(100)
            .IsRequired(false)
            .HasComment("Correo electrónico de contacto de la unidad");

        builder
            .Property(e => e.Activo)
            .HasColumnName("activo")
            .HasDefaultValue(true)
            .IsRequired()
            .HasComment("Indica si la unidad está activa en el sistema");
    }

    private static void ConfigureIndexes(EntityTypeBuilder<Unidad> builder)
    {
        builder.HasIndex(e => e.Codigo).HasDatabaseName("ix_unidades_codigo").IsUnique();

        builder.HasIndex(e => e.Siglas).HasDatabaseName("ix_unidades_siglas").IsUnique();

        builder.HasIndex(e => e.Nombre).HasDatabaseName("ix_unidades_nombre");

        builder.HasIndex(e => e.NombreCorto).HasDatabaseName("ix_unidades_nombre_corto");

        builder
            .HasIndex(e => e.Activo)
            .HasDatabaseName("ix_unidades_activo")
            .HasFilter("activo = true");
    }

    private static void ConfigureRelationships(EntityTypeBuilder<Unidad> builder)
    {
        builder
            .HasMany(e => e.Autoridades)
            .WithOne(i => i.Unidad)
            .HasForeignKey(i => i.UnidadId)
            .HasConstraintName("fk_unidades_autoridades")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(e => e.Propuestas)
            .WithOne(i => i.Unidad)
            .HasForeignKey(i => i.UnidadId)
            .HasConstraintName("fk_unidades_propuestas")
            .OnDelete(DeleteBehavior.Restrict);
    }

    private static void ConfigureSeeds(EntityTypeBuilder<Unidad> builder)
    {
        builder.HasData(
            // Sedes principales
            new Unidad
            {
                Id = 1,
                Codigo = "UCCSJ",
                Nombre = "San Juan - Universidad Católica de Cuyo",
                NombreCorto = "UCCuyoSJ",
                Siglas = "UCCSJ",
                ColorPrincipal = "#064a31",
                ColorSecundario = "#7d1b1c",
                Direccion = "Av. Ignacio de la Roza 1516 Oeste, J5400 Rivadavia, San Juan",
                Telefono = "+54 264 4292300",
                Email = "secretariaacademica@uccuyo.edu.ar",
                Descripcion = "",
                Activo = true,
            },
            new Unidad
            {
                Id = 2,
                Codigo = "UCCSL",
                Nombre = "San Luis - Universidad Católica de Cuyo",
                NombreCorto = "UCCuyoSL",
                Siglas = "UCCSL",
                ColorPrincipal = "#064a31",
                ColorSecundario = "#7d1b1c",
                Direccion = "Felipe Velázquez 471, D5700 San Luis",
                Telefono = "+54 266 4423572",
                Email = "sec.extension@uccuyosl.edu.ar",
                Descripcion = "",
                Activo = true,
            },
            new Unidad
            {
                Id = 3,
                Codigo = "UCCMZ",
                Nombre = "Mendoza - Universidad Católica de Cuyo",
                NombreCorto = "UCCuyoMZ",
                Siglas = "UCCMZ",
                ColorPrincipal = "#064a31",
                ColorSecundario = "#7d1b1c",
                Direccion = "Ruta Provincial 50, M5529 Rodeo del Medio, Mendoza",
                Telefono = "+54 261 4951120",
                Email = "enologia@uccuyo.edu.ar",
                Descripcion = "",
                Activo = true,
            },
            // Facultades San Juan
            new Unidad
            {
                Id = 4,
                Codigo = "FCEE",
                Nombre = "Facultad de Ciencias Económicas",
                NombreCorto = "Ciencias Económicas",
                Siglas = "FCEE",
                ColorPrincipal = "#1B3B82",
                ColorSecundario = "#4A90E2",
                Direccion = "Av. Ignacio de la Roza 1516 Oeste, J5400 Rivadavia, San Juan",
                Telefono = "+54 264 4292323",
                Email = "fcee@uccuyo.edu.ar",
                Descripcion = "",
                Activo = true,
            },
            new Unidad
            {
                Id = 5,
                Codigo = "FDCS",
                Nombre = "Facultad de Derecho y Ciencias Sociales",
                NombreCorto = "Derecho y Cs. Sociales",
                Siglas = "FDCS",
                ColorPrincipal = "#691D18",
                ColorSecundario = "#795548",
                Direccion = "Av. Ignacio de la Roza 1516 Oeste, J5400 Rivadavia, San Juan",
                Telefono = "+54 264 4292335",
                Email = "fdcs@uccuyo.edu.ar",
                Descripcion = "",
                Activo = true,
            },
            new Unidad
            {
                Id = 6,
                Codigo = "FCM",
                Nombre = "Facultad de Ciencias Médicas",
                NombreCorto = "Ciencias Médicas",
                Siglas = "FCM",
                ColorPrincipal = "#436600",
                ColorSecundario = "#4CAF50",
                Direccion = "Av. Ignacio de la Roza 1516 Oeste, J5400 Rivadavia, San Juan",
                Telefono = "+54 264 4292361",
                Email = "fcm@uccuyo.edu.ar",
                Descripcion = "",
                Activo = true,
            },
            new Unidad
            {
                Id = 7,
                Codigo = "FFYH",
                Nombre = "Facultad de Filosofía y Humanidades",
                NombreCorto = "Filosofía y Humanidades",
                Siglas = "FFYH",
                ColorPrincipal = "#BF2C22",
                ColorSecundario = "#F44336",
                Direccion = "Av. Ignacio de la Roza 1516 Oeste, J5400 Rivadavia, San Juan",
                Telefono = "+54 264 4292344",
                Email = "ffyh@uccuyo.edu.ar",
                Descripcion = "",
                Activo = true,
            },
            new Unidad
            {
                Id = 8,
                Codigo = "FCQT",
                Nombre = "Facultad de Ciencias Químicas y Tecnológicas",
                NombreCorto = "Cs. Químicas y Tecnológicas",
                Siglas = "FCQT",
                ColorPrincipal = "#00858A",
                ColorSecundario = "#00BCD4",
                Direccion = "Av. Ignacio de la Roza 1516 Oeste, J5400 Rivadavia, San Juan",
                Telefono = "+54 264 4292357",
                Email = "fcqt@uccuyo.edu.ar",
                Descripcion = "",
                Activo = true,
            },
            new Unidad
            {
                Id = 9,
                Codigo = "ISFDSM",
                Nombre = "Instituto Superior Santa María",
                NombreCorto = "Santa María",
                Siglas = "ISFDSM",
                ColorPrincipal = "#8286D5",
                ColorSecundario = "#9C27B0",
                Direccion = "Av. Ignacio de la Roza 1516 Oeste, J5400 Rivadavia, San Juan",
                Telefono = "+54 264 4292300",
                Email = "isfdsm@uccuyo.edu.ar",
                Descripcion = "",
                Activo = true,
            },
            new Unidad
            {
                Id = 10,
                Codigo = "FE",
                Nombre = "Facultad de Educación",
                NombreCorto = "Educación",
                Siglas = "FE",
                ColorPrincipal = "#E7117E",
                ColorSecundario = "#E91E63",
                Direccion = "Av. Ignacio de la Roza 1516 Oeste, J5400 Rivadavia, San Juan",
                Telefono = "+54 264 4292347",
                Email = "fe@uccuyo.edu.ar",
                Descripcion = "",
                Activo = true,
            },
            new Unidad
            {
                Id = 11,
                Codigo = "ES",
                Nombre = "Escuela de Seguridad",
                NombreCorto = "Seguridad",
                Siglas = "ES",
                ColorPrincipal = "#021233",
                ColorSecundario = "#2196F3",
                Direccion = "Av. Ignacio de la Roza 1516 Oeste, J5400 Rivadavia, San Juan",
                Telefono = "+54 264 4231534",
                Email = "es@uccuyo.edu.ar",
                Descripcion = "",
                Activo = true,
            },
            new Unidad
            {
                Id = 12,
                Codigo = "ECRP",
                Nombre = "Escuela de Cultura Religiosa y Pastoral",
                NombreCorto = "Cultura Religiosa",
                Siglas = "ECRP",
                ColorPrincipal = "#034A31",
                ColorSecundario = "#4CAF50",
                Direccion = "Av. Ignacio de la Roza 1516 Oeste, J5400 Rivadavia, San Juan",
                Telefono = "+54 264 4292329",
                Email = "ecrp@uccuyo.edu.ar",
                Descripcion = "",
                Activo = true,
            },
            // San Luis
            new Unidad
            {
                Id = 13,
                Codigo = "FCV",
                Nombre = "Facultad de Ciencias Veterinarias",
                NombreCorto = "Ciencias Veterinarias",
                Siglas = "FCV",
                ColorPrincipal = "#5107B4",
                ColorSecundario = "#7C4DFF",
                Direccion = "Felipe Velázquez 471, D5700 San Luis",
                Telefono = "+54 266 4423572",
                Email = "fcv@uccuyosl.edu.ar",
                Descripcion = "",
                Activo = true,
            },
            // Mendoza
            new Unidad
            {
                Id = 14,
                Codigo = "FDBEYCA",
                Nombre = "Facultad de Enología y Alimentación",
                NombreCorto = "Enología y Alimentación",
                Siglas = "FDBEYCA",
                ColorPrincipal = "#CA1F32",
                ColorSecundario = "#FF5252",
                Direccion = "Ruta Provincial 50, M5529 Rodeo del Medio, Mendoza",
                Telefono = "+54 261 4951120",
                Email = "enologia@uccuyo.edu.ar",
                Descripcion = "",
                Activo = true,
            }
        );
    }
}
