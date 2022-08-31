using System.Collections.Generic;

namespace Behlog.Core;

public interface IValueObject 
{
}

public interface IValueObjectCollection<T> {

    ICollection<T> Items { get; }

    void Add(T item);

    void RemoveAll();
    
}