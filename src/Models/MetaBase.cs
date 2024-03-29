using Behlog.Core.Domain;

namespace Behlog.Core.Models;

/// <summary>
/// Abstract class to keep Metadata for Aggregates.
/// </summary>
/// <typeparam name="TOwnerId"></typeparam>
public abstract class MetaBase<TOwnerId> : ValueObject
{
    protected MetaBase()
    {
    }

    protected MetaBase(
        TOwnerId ownerId, string metaKey, string? title,
        string? metaValue, string? metaType, Guid? langId, 
        string? description = null, string? category = null,
        int orderNum = 1)
    {
        OwnerId = ownerId;
        MetaKey = metaKey;
        Title = title;
        MetaValue = metaValue;
        MetaType = metaType;
        Description = description;
        Category = category;
        OrderNum = orderNum;
        Status = EntityStatus.Enabled;
        LangId = langId;
    }
    
    public long Id { get; protected set; }
    public TOwnerId OwnerId { get; protected set; }
    public string? Title { get; protected set; }
    public string MetaKey { get; protected set; }
    public string? MetaValue { get; protected set; }
    public string? MetaType { get; protected set; }
    public EntityStatus Status { get; protected set; }
    public Guid? LangId { get; protected set; }
    public string? Description { get; protected set; }
    public string? Category { get; protected set; }
    public int OrderNum { get; protected set; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return MetaKey;
        yield return OwnerId;
        yield return MetaValue!;
        yield return MetaType!;
        yield return Status;
        yield return Description;
        yield return Category;
        yield return OrderNum;
    }
}