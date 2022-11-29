using Behlog.Extensions;

namespace Behlog.Core.Models;

public abstract class ListResult<TId, TResult> where TResult : class
{
    private readonly Dictionary<TId, TResult> _dictionary;

    public ListResult()
    {
        _dictionary = new();
    }


    public TResult this[TId index]
    {
        get => _dictionary[index];
        set => _dictionary[index] = value;
    }
    

    public void Add(TId key, TResult item)
    {
        item.ThrowExceptionIfArgumentIsNull(nameof(item));
        _dictionary.Add(key, item);
    }
    
}