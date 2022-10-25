namespace Behlog.Core.Contracts;

public interface IBehlogEntity<TId>
{
    
    TId Id { get; }
}