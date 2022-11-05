using Behlog.Core.Domain;

namespace Behlog.Core.Models;

/// <summary>
/// Abstract class to keep Metadata for Aggregates.
/// </summary>
/// <typeparam name="TOwnerId"></typeparam>
public abstract class MetaBase<TOwnerId> : ValueObject
{
    public TOwnerId OwnerId { get; protected set; }
    public string MetaKey { get; protected set; }
    public string MetaValue { get; protected set; }
    public string MetaType { get; protected set; }
    public EntityStatus Status { get; protected set; }
    public string Description { get; protected set; }
    public string Category { get; protected set; }
    public int OrderNum { get; protected set; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return OwnerId;
        yield return MetaKey;
        yield return MetaValue;
        yield return MetaType;
        yield return Status;
        yield return Description;
        yield return Category;
        yield return OrderNum;
    }
}