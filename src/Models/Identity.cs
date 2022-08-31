using System;

namespace Behlog.Core;


public interface IIdentity<T> {

    T Value { get; }
}


public abstract class Identity : IEquatable<T> {

    public Identity()
    {
        Value = Guid.NewGuid();
    }

    public Identity(T value) {
        Value = value;
    }

    public T Value { get; }

    public bool Equals(Identity id) {
        if(object.ReferenceEquals(this, id)) return true;
        if(object.ReferenceEquals(null, id)) return false;

        return this.Value.Equals(id.Value);
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Identity);
    }

    public override int GetHashCode()
    {
        return (this.GetType().GetHashCode() * 907) + this.GetHashCode();
    }

    public override string ToString()
    {
        return this.GetType().Name + $"- Id: {this.Value.ToString()}";
    }
}