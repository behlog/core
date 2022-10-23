namespace Behlog.Core;

public class BehlogMessageProcessor<TMessage> : IBehlogMessageProcessor<TMessage>
    where TMessage : IBehlogMessage
{
    private readonly IEnumerable<IBehlogMessageHandler<TMessage>> _messageHandlers;
    private readonly IEnumerable<IBehlogMiddleware<TMessage>> _middlewares;
    
    public BehlogMessageProcessor(IBehlogServiceFactory serviceFactory)
    {
        _messageHandlers = (IEnumerable<IBehlogMessageHandler<TMessage>>)
            serviceFactory.GetInstance(typeof(IEnumerable<IBehlogMessageHandler<TMessage>>));

        _middlewares = (IEnumerable<IBehlogMiddleware<TMessage>>)
            serviceFactory.GetInstance(typeof(IEnumerable<IBehlogMiddleware<TMessage>>));
    }
    
    public Task HandleAsync(TMessage message, CancellationToken cancellationToken) 
        => RunMiddleware(message, HandleMessageAsync, cancellationToken);

    private async Task HandleMessageAsync(TMessage message, CancellationToken cancellationToken)
    {
        var type = typeof(TMessage);

        if (!_messageHandlers.Any())
        {
            throw new ArgumentException($"No handler of signature {typeof(IBehlogMessageHandler<,>).Name} was found for {typeof(TMessage).Name}", typeof(TMessage).FullName);
        }

        if (typeof(IBehlogEvent).IsAssignableFrom(type))
        {
            var tasks = _messageHandlers.Select(_ => _.HandleAsync(message, cancellationToken));
            foreach (var t in tasks) await t;

            return;
        }

        if (typeof(IBehlogCommand).IsAssignableFrom(type))
        {
            await _messageHandlers.Single().HandleAsync(message, cancellationToken);
            return;
        }
        
        throw new ArgumentException($"{typeof(TMessage).Name} is not a known type of {typeof(IBehlogMessage<>).Name}" + 
                                        $" - Query, Command or Event", typeof(TMessage).FullName);
    }

    private Task RunMiddleware(
        TMessage message, 
        HandleMessageDelegate<TMessage> handleMessageDelegate,
        CancellationToken cancellationToken)
    {
        HandleMessageDelegate<TMessage> next = null;
        next = _middlewares.Reverse().Aggregate(handleMessageDelegate, (messageDelegate, middleware) =>
            ((req, ct) => middleware.RunAsync(req, ct, messageDelegate)));

        return next.Invoke(message, cancellationToken);
    }
    
}