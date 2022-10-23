namespace Behlog.Core;

public interface IBehlogRepository<TEntity, in TId> where TEntity : class
{

    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    void MarkForAdd(TEntity entity);
    
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    void MarkForUpdate(TEntity entity);

    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

    void MarkForDelete(TEntity entity);

    Task<TEntity> FindAsync(TId id);

    Task<IReadOnlyCollection<TEntity>> FindAllAsync(CancellationToken cancellationToken = default);

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}