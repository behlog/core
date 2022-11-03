namespace Behlog.Core.Contracts;

public interface IAggregateRoot<TId> : IBehlogEntity<TId>
{
    int Version { get; }
    
    IBehlogEvent[] DequeueUncommittedEvents();
    
    IReadOnlyList<IBehlogEvent> GetAllEvents();

    void Enqueue(IBehlogEvent @event);
}