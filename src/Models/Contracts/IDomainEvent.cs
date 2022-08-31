using System;

namespace Behlog.Core;

public interface IDomainEvent 
{
    Guid Id { get; }

    DateTime PublishDate { get; }

    int Version { get; }
}