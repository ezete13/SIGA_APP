using SIGA.Application.Common.Dispatcher.Interfaces;

namespace SIGA.Application.Features.Preinscripciones.CrearPreinscripcionPendiente;

public record CrearPreinscripcionPendienteCommand(
    int PropuestaId,
    int TipoDocumentoId,
    string Documento,
    string Apellido,
    string Nombre,
    string Email
) : IUseCase<Guid>;
