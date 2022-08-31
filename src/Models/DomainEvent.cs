using System;

namespace Behlog.Core;

public class DomainEvent : IDomainEvent
{
    public DomainEvent()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; }

    public DateTime PublishedDate { get; }

    public int Version { get; }
}