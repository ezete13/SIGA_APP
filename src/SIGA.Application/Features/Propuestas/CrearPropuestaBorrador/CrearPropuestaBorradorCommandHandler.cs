using SIGA.Application.Common.Dispatcher.Interfaces;
using SIGA.Domain.Entities.Core;
using SIGA.Persistence;

namespace SIGA.Application.Features.Propuestas.CrearPropuestaBorrador;

public class CrearPropuestaBorradorCommandHandler
    : IUseCaseHandler<CrearPropuestaBorradorCommand, int>
{
    private readonly ApplicationDbContext _dbContext;

    public CrearPropuestaBorradorCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(
        CrearPropuestaBorradorCommand command,
        CancellationToken cancellationToken
    )
    {
        // Usamos el factory method de la entidad Propuesta
        var propuesta = Propuesta.Crear(
            unidadId: command.UnidadId,
            tipoPropuestaId: command.TipoPropuestaId,
            periodoLectivoId: command.PeriodoLectivoId,
            titulo: command.Titulo,
            anio: command.Anio,
            edicion: command.Edicion,
            fechaInicio: command.FechaInicio,
            fechaFin: command.FechaFin,
            maximoAlumnos: command.MaximoAlumnos,
            cantidadHoras: command.CantidadHoras,
            usuarioId: command.UsuarioId,
            modalidadId: command.ModalidadId,
            estadoPropuestaId: command.EstadoPropuestaId,
            importeBase: command.ImporteBase,
            cuotas: command.Cuotas,
            conceptoPago: command.ConceptoPago,
            emailEncargado: command.EmailEncargado,
            planEstudioPdf: command.PlanEstudioPdf,
            lugarRealizacion: command.LugarRealizacion,
            contactoInfo: command.ContactoInfo,
            pagosInfo: command.PagosInfo,
            webVisible: command.WebVisible,
            permiteInscripcionesWeb: command.PermiteInscripcionesWeb
        );

        await _dbContext.Propuestas.AddAsync(propuesta, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return propuesta.Id;
    }
}
