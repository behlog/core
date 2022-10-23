using System;

namespace Behlog.Core;

public abstract class Identity<T> : IEquatable<T> {

    public Identity()
    {
        Value = default;
    }

    public Identity(T value) {
        Value = value;
    }

    public T Value { get; }

    protected bool Equals(Identity<T> id) {
        return EqualityComparer<T>.Default.Equals(Value, id.Value);
    }

    public bool Equals(T? other)
    {
        if (other is null && Value is not null) return false;
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        if (other.GetType() != this.GetType()) return false;
        
        return Value != null && Value.Equals(other);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Identity<T>)obj);
    }

    public override int GetHashCode()
    {
        return EqualityComparer<T>.Default.GetHashCode(Value);
    }

    public override string ToString()
    {
        return this.GetType().Name + $"- Id: {this.Value.ToString()}";
    }
}