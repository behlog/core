using System.Collections.Generic;

namespace Behlog.Core;

public class AggregateRoot<TId> : IAggregateRoot<TId>
{
    private readonly IMediator _mediator;

    public AggregateRoot(IMediator mediator)
    {
        _mediator = mediator;
        Version = 1;
    }
    
    public TId Id { get; protected set; } = default!;

    protected readonly Queue<IDomainEvent> _uncommittedEvents;

    protected AggregateRoot(int version = 1)
    {
        _uncommittedEvents = new();
        Version = version;
    }

    public int Version { get; }

    public void When(object @event)
    {
        
    }

    public IDomainEvent[] DequeueUncommittedEvents()
    {
        var dequeuedEvents = _uncommittedEvents.ToArray();
        _uncommittedEvents.Clear();
        return dequeuedEvents;
    }

    public IReadOnlyList<IDomainEvent> GetAllEvents()
    {
        return _uncommittedEvents.ToList();
    }

    public void Enqueue(IDomainEvent @event)
    {
        _uncommittedEvents.Enqueue(@event);
    }
   
}