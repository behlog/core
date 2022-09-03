using System.Collections.Generic;

namespace Behlog.Core;

public interface IAggregateRoot<TId> : IEntity<TId>
{

    int Version { get; }
    
    void When(object @event);
    
    IDomainEvent[] DequeueUncommittedEvents();

    IReadOnlyList<IDomainEvent> GetAllEvents();

    void Enqueue(IDomainEvent @event);

}