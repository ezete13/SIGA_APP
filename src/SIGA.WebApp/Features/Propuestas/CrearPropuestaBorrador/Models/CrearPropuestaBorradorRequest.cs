namespace SIGA.WebApp.Features.Propuestas.CrearPropuestaBorrador.Models;

public class CrearPropuestaBorradorRequest
{
    public int UnidadId { get; set; }
    public int ModalidadId { get; set; }
    public int TipoPropuestaId { get; set; }
    public int PeriodoLectivoId { get; set; }
    public int EstadoPropuestaId { get; set; }
    public int UsuarioId { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public int Anio { get; set; }
    public int? Edicion { get; set; }
    public DateOnly FechaInicio { get; set; }
    public DateOnly FechaFin { get; set; }
    public int MaximoAlumnos { get; set; }
    public int CantidadHoras { get; set; }
    public decimal? ImporteBase { get; set; }
    public int? Cuotas { get; set; }
    public string? ConceptoPago { get; set; }
    public string? EmailEncargado { get; set; }
    public string? PlanEstudioPdf { get; set; }
    public string? LugarRealizacion { get; set; }
    public string? ContactoInfo { get; set; }
    public string? PagosInfo { get; set; }
    public bool WebVisible { get; set; }
    public bool PermiteInscripcionesWeb { get; set; }
}
