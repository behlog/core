using Behlog.Core.Contracts;

namespace Behlog.Core;

public interface IBehlogWriteStore<TEntity, in TId> where TEntity : IBehlogEntity<TId>
{
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    void MarkForAdd(TEntity entity);
    
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    void MarkForUpdate(TEntity entity);

    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

    void MarkForDelete(TEntity entity);
    
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}