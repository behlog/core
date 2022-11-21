namespace Behlog.Core;

public interface IBehlogMediator
{
    
    Task<TResponse> PublishAsync<TResponse>(
        IBehlogMessage<TResponse> message, CancellationToken cancellationToken = default);

    Task PublishAsync(
        IBehlogMessage message, CancellationToken cancellationToken = default);

    Task<IEnumerable<TResponse>> PublishAsync<TResponse>(
        IEnumerable<IBehlogMessage<TResponse>> messages, CancellationToken cancellationToken = default);


    Task PublishAsync(
        IEnumerable<IBehlogMessage> messages, CancellationToken cancellationToken = default);
}