using Behlog.Core.Contracts;

namespace Behlog.Core;

public interface IBehlogReadStore<TEntity, in TId> where TEntity : IBehlogEntity<TId>
{
    
    Task<TEntity> FindAsync(TId id, CancellationToken cancellationToken = default);


    Task<IReadOnlyCollection<TEntity>> FindAllAsync(CancellationToken cancellationToken = default);
    
    
}