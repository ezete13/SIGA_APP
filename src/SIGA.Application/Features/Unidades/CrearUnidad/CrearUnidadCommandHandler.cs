using Microsoft.EntityFrameworkCore;
using SIGA.Application.Common.Exceptions;
using SIGA.Application.Common.Interfaces;
using SIGA.Domain.Entities;

namespace SIGA.Application.Features.Unidades.CrearUnidad;

public class CrearUnidadCommandHandler : IUseCaseHandler<CrearUnidadCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTime;

    public CrearUnidadCommandHandler(IApplicationDbContext context, IDateTimeService dateTime)
    {
        _context = context;
        _dateTime = dateTime;
    }

    public async Task<int> Handle(CrearUnidadCommand request, CancellationToken cancellationToken)
    {
        // Validación adicional de reglas de negocio
        await ValidateBusinessRules(request, cancellationToken);

        // Crear la entidad
        var unidad = new Unidades
        {
            Codigo = request.Codigo.Trim(),
            Nombre = request.Nombre.Trim(),
            NombreCorto = request.NombreCorto.Trim(),
            Siglas = request.Siglas.Trim().ToUpper(),
            SedeId = request.SedeId,
            ColorPrincipal = request.ColorPrincipal?.Trim() ?? "#064a31",
            ColorSecundario = request.ColorSecundario?.Trim() ?? "#7d1b1c",
            Direccion = request.Direccion?.Trim(),
            Telefono = request.Telefono?.Trim(),
            Email = request.Email?.Trim().ToLower(),
            Estado = true,
            CreadoEn = _dateTime.Now,
            ActualizadoEn = _dateTime.Now,
        };

        // Agregar al contexto
        _context.Unidades.Add(unidad);

        // Guardar cambios
        await _context.SaveChangesAsync(cancellationToken);

        // Publicar evento de dominio si usas eventos
        // await _mediator.Publish(new UnidadCreadaEvent(unidad.Id), cancellationToken);

        return unidad.Id;
    }

    private async Task ValidateBusinessRules(
        CrearUnidadCommand request,
        CancellationToken cancellationToken
    )
    {
        // 1. Validar límite de unidades por sede (si aplica)
        var unidadesEnSede = await _context.Unidades.CountAsync(
            u => u.SedeId == request.SedeId && u.Estado == true,
            cancellationToken
        );

        // Ejemplo: Máximo 50 unidades por sede
        const int maxUnidadesPorSede = 50;
        if (unidadesEnSede >= maxUnidadesPorSede)
        {
            throw new BusinessRuleException(
                $"La sede ha alcanzado el límite máximo de {maxUnidadesPorSede} unidades activas"
            );
        }

        // 2. Validar que la sede tenga capacidad para más unidades
        var sede = await _context.Sedes.FirstOrDefaultAsync(
            s => s.Id == request.SedeId,
            cancellationToken
        );

        if (sede == null)
        {
            throw new NotFoundException($"Sede con ID {request.SedeId} no encontrada");
        }

        // 3. Validar formato específico del código (si aplica)
        // Ejemplo: El código debe empezar con "UNI-"
        if (!request.Codigo.StartsWith("UNI-", StringComparison.OrdinalIgnoreCase))
        {
            throw new BusinessRuleException("El código de unidad debe comenzar con 'UNI-'");
        }
    }
}
