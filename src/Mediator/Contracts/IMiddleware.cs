namespace Behlog.Core;

public delegate Task<TResponse> HandleMessageDelegate<in TMessage, TResponse>(
    TMessage message, 
    CancellationToken cancellationToken);

public interface IMiddleware<TMessage, TResponse> where TMessage : IMessage<TResponse>
{
    Task<TResponse> RunAsync(
        TMessage message,
        CancellationToken cancellationToken, 
        HandleMessageDelegate<TMessage, TResponse> next);
}