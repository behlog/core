
namespace Behlog.Core;

public interface IEntity<TId> where TId : IIdentity<T>
{

    T Id  { get; }
}