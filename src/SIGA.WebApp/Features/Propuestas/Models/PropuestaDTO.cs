namespace SIGA.WebApp.Features.Propuestas.CrearPropuestaBorrador.Models;

public class CrearPropuestaResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public int PropuestaId { get; set; }
}
