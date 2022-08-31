namespace Behlog.Core;

public interface IAggregateRoot<TId> : IEntity<TId> where TId: IIdentity<T> 
{

}