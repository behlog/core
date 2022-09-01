using System;

namespace Behlog.Core;

public interface IDomainEvent 
{
    Guid EventId { get; }

    DateTime EventPublishedDate { get; }

    int Version { get; }
}