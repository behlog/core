using System;

namespace Behlog.Core;

public interface IHasMetadata 
{
    DateTime CreatedDate { get; }
    DateTime? LastUpdated { get; }
    string CreatedByUserId { get; }
    string LastUpdatedByUserId { get; }
    string CreatedByIp { get; }
    string LastUpdatedByIp { get; }
}