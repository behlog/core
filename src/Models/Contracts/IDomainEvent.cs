using System;

namespace Behlog.Core;

public interface IDomainEvent : IEvent
{
    Guid EventId { get; }

    DateTime EventPublishedDate { get; }

    int Version { get; }
}