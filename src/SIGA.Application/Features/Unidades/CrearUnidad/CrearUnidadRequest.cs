namespace SIGA.Application.Features.Unidades;

public class CrearUnidadRequest
{
    public required string Codigo { get; set; }
    public required string Nombre { get; set; }
    public string? Descripcion { get; set; }
}
