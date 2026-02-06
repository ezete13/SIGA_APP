namespace SIGA.Application.Common.Interfaces;

public interface IUseCaseHandler<TRequest, TResponse>
    where TRequest : IUseCase<TResponse>
{
    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}
