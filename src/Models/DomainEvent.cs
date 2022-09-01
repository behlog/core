using System;

namespace Behlog.Core;

public class DomainEvent : IDomainEvent
{
    public DomainEvent()
    {
        EventId = Guid.NewGuid();
    }

    public Guid EventId { get; }

    public DateTime EventPublishedDate { get; }

    public int Version { get; }
}