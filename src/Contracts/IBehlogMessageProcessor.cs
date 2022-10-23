namespace Behlog.Core;

public interface IBehlogMessageProcessor<in TMessage, TResponse>
    where TMessage : IBehlogMessage<TResponse>
{
    Task<TResponse> HandleAsync(TMessage message, CancellationToken cancellationToken);
}

public interface IBehlogMessageProcessor<in TMessage> where TMessage : IBehlogMessage
{

    Task HandleAsync(TMessage message, CancellationToken cancellationToken);
}