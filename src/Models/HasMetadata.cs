using System;

namespace Behlog.Core;

public abstract class HasMetadata 
{
    public DateTime CreateDate { get; }
    public DateTime? LastUpdated { get; }
    public string CreatedByUserId { get; }
    public string LastUpdatedByUserId { get; }
    public string CreatedByIp { get; }
    public string LastUpdatedByIp { get; }
}