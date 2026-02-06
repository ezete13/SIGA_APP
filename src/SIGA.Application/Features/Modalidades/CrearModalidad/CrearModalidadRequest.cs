namespace SIGA.Application.Features.Modalidades;

public class CrearModalidadRequest
{
    public required string Codigo { get; set; }
    public required string Nombre { get; set; }
    public string? Descripcion { get; set; }
}
