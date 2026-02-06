namespace SIGA.Application.Common.Interfaces;

public interface IUseCaseDispatcher
{
    Task<TResponse> Send<TRequest, TResponse>(
        TRequest request,
        CancellationToken cancellationToken = default
    )
        where TRequest : IUseCase<TResponse>;
}
