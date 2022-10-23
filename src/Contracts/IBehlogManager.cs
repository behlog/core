namespace Behlog.Core;

public interface IBehlogManager
{
    
    Task<TResponse> PublishAsync<TResponse>(
        IBehlogMessage<TResponse> message,
        CancellationToken cancellationToken = default);

    Task PublishAsync(IBehlogMessage message, CancellationToken cancellationToken = default);
}