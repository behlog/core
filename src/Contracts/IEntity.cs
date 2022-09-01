namespace Behlog.Core;

public interface IEntity<TId> {

    TId Id  { get; }
}
