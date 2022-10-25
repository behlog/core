using Behlog.Core.Contracts;

namespace Behlog.Core.Domain;

public abstract class BehlogEntity<TId> : IBehlogEntity<TId>
{
    public BehlogEntity()
    {
    }
    
    public TId Id { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not IBehlogEntity<TId>)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        if (this.GetType() != obj.GetType())
            return false;

        BehlogEntity<TId> _obj = (BehlogEntity<TId>)obj;
        
        return EqualityComparer<TId>.Default.Equals(_obj.Id, this.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode() ^ 31;
    }
    
    public static bool operator ==(BehlogEntity<TId> left, BehlogEntity<TId> right)
        => left?.Equals(right) ?? Equals(right, null);

    public static bool operator !=(BehlogEntity<TId> left, BehlogEntity<TId> right)
        => !(left == right);
}