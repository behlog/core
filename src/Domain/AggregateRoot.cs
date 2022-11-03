using Behlog.Core.Contracts;

namespace Behlog.Core.Domain;

public class AggregateRoot<TId> : BehlogEntity<TId>, IAggregateRoot<TId>
{
    protected readonly Queue<IBehlogEvent> _uncommittedEvents;
    
    public int Version { get; }
    

    public AggregateRoot()
    {
        Version = 1;
        _uncommittedEvents = new();
    }
    
    public IBehlogEvent[] DequeueUncommittedEvents()
    {
        var result = _uncommittedEvents.ToArray();
        _uncommittedEvents.Clear();
        return result;
    }

    public IReadOnlyList<IBehlogEvent> GetAllEvents()
    {
        return _uncommittedEvents.ToList();
    }

    public void Enqueue(IBehlogEvent @event)
    {
        _uncommittedEvents.Enqueue(@event);
    }
}