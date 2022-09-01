using System;

namespace Behlog.Core;

public interface IDomainEvent 
{
    Guid Id { get; }

    DateTime PublishedDate { get; }

    int Version { get; }
}