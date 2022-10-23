namespace Behlog.Core;

public interface IBehlogMessageHandler<in TMessage> where TMessage : IBehlogMessage
{
    Task HandleAsync(TMessage message, CancellationToken cancellationToken);
    
}

public interface IBehlogMessageHandler<in TMessage, TResponse> where TMessage : IBehlogMessage<TResponse> 
{
    
    Task<TResponse> HandleAsync(TMessage message, CancellationToken cancellationToken);
}
