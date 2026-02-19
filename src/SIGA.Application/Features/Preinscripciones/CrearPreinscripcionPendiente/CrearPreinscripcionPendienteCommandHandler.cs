using SIGA.Application.Common.Dispatcher.Interfaces;
using SIGA.Domain.Entities.Core;
using SIGA.Persistence;

namespace SIGA.Application.Features.Preinscripciones.CrearPreinscripcionPendiente;

public class CrearPreinscripcionPendienteCommandHandler
    : IUseCaseHandler<CrearPreinscripcionPendienteCommand, Guid>
{
    private readonly ApplicationDbContext _dbContext;

    public CrearPreinscripcionPendienteCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(
        CrearPreinscripcionPendienteCommand command,
        CancellationToken cancellationToken
    )
    {
        var preinscripcion = Preinscripcion.Crear(
            command.PropuestaId,
            command.TipoDocumentoId,
            command.Documento,
            command.Apellido,
            command.Nombre,
            command.Email
        );

        await _dbContext.AddAsync(preinscripcion, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return preinscripcion.Uuid;
    }
}
