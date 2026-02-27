namespace SIGA.WebApp.Features.Unidades.Models;

public class UnidadDetalleResponse
{
    public int Id { get; set; }

    public required string Codigo { get; set; }

    public required string Nombre { get; set; }

    public required string? Descripcion { get; set; }

    public bool Activo { get; set; } = true;

    public required string NombreCorto { get; set; }

    public required string Siglas { get; set; }

    public string? ColorPrincipal { get; set; }

    public string? ColorSecundario { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }
}
