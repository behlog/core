
namespace Behlog.Core;

public class AggregateRoot<TId> : AggregateRoot, IAggregateRoot<TId> where TId : notnull
{

    public AggregateRoot() : base(version: 1)
    {
        
    }
    
    public TId Id { get; protected set; } = default!;
   
}