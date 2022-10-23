namespace Behlog.Core;

public delegate Task<TResponse> HandleMessageDelegate<in TMessage, TResponse>(
    TMessage message, 
    CancellationToken cancellationToken);

public delegate Task HandleMessageDelegate<in TMessage>(
    TMessage message,
    CancellationToken cancellationToken);

public interface IBehlogMiddleware<TMessage, TResponse> where TMessage : IBehlogMessage<TResponse>
{
    Task<TResponse> RunAsync(
        TMessage message,
        CancellationToken cancellationToken, 
        HandleMessageDelegate<TMessage, TResponse> next);
}

public interface IBehlogMiddleware<TMessage> where TMessage : IBehlogMessage
{
    Task RunAsync(
        TMessage message,
        CancellationToken cancellationToken, 
        HandleMessageDelegate<TMessage> next);
}