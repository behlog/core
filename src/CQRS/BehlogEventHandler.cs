namespace Behlog.Core;

public abstract class BehlogEventHandler<TEvent> 
    : IBehlogEventHandler<TEvent> where TEvent : IBehlogEvent
{
    public async Task HandleAsync(
        TEvent message,
        CancellationToken cancellationToken)
    {
        await HandleEventAsync(message, cancellationToken);
    }

    protected abstract Task HandleEventAsync(
        TEvent @event,
        CancellationToken cancellationToken);
}
