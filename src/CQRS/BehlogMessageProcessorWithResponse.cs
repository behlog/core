namespace Behlog.Core;

public class BehlogMessageProcessor<TMessage, TResponse> : 
    IBehlogMessageProcessor<TMessage, TResponse> where TMessage : IBehlogMessage<TResponse>
{
    private readonly IEnumerable<IBehlogMessageHandler<TMessage, TResponse>> _messageHandlers;
    private readonly IEnumerable<IBehlogMiddleware<TMessage, TResponse>> _middlewares;

    public BehlogMessageProcessor(IBehlogServiceFactory serviceFactory)
    {
        _messageHandlers = (IEnumerable<IBehlogMessageHandler<TMessage, TResponse>>)
            serviceFactory.GetInstance(typeof(IEnumerable<IBehlogMessageHandler<TMessage, TResponse>>));

        _middlewares = (IEnumerable<IBehlogMiddleware<TMessage, TResponse>>)
            serviceFactory.GetInstance(typeof(IEnumerable<IBehlogMiddleware<TMessage, TResponse>>));
    }

    public Task<TResponse> HandleAsync(
        TMessage message, 
        CancellationToken cancellationToken)
    {
        return RunMiddleware(message, HandleMessageAsync, cancellationToken);
    }

    private async Task<TResponse> HandleMessageAsync(
        TMessage messageObject, 
        CancellationToken cancellationToken)
    {
        var type = typeof(TMessage);

        if (!_messageHandlers.Any())
        {
            throw new ArgumentException($"No handler of signature {typeof(IBehlogMessageHandler<,>).Name} was found for {typeof(TMessage).Name}", typeof(TMessage).FullName);
        }

        if (typeof(IBehlogEvent).IsAssignableFrom(type))
        {
            var tasks = _messageHandlers.Select(r => r.HandleAsync(messageObject, cancellationToken));
            var result = default(TResponse);

            foreach (var task in tasks)
            {
                result = await task;
            }

            return result;
        }

        if (typeof(IBehlogQuery<TResponse>).IsAssignableFrom(type) || typeof(IBehlogCommand).IsAssignableFrom(type))
        {
            return await _messageHandlers.Single().HandleAsync(messageObject, cancellationToken);
        }

        throw new ArgumentException($"{typeof(TMessage).Name} is not a known type of {typeof(IBehlogMessage<>).Name} - Query, Command or Event", typeof(TMessage).FullName);
    }

    private Task<TResponse> RunMiddleware(
        TMessage message, 
        HandleMessageDelegate<TMessage, TResponse> handleMessageHandlerCall, 
        CancellationToken cancellationToken)
    {
        HandleMessageDelegate<TMessage, TResponse> next = null;

        next = _middlewares.Reverse().Aggregate(handleMessageHandlerCall, (messageDelegate, middleware) =>
            ((req, ct) => middleware.RunAsync(req, ct, messageDelegate)));

        return next.Invoke(message, cancellationToken);
    }
}