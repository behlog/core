namespace Behlog.Core;

public interface IBehlogDbContext : IDisposable
{

    void BeginTransaction();

    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    
    void RollbackTransaction();

    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    
    void CommitTransaction();

    Task CommitTransactionAsync(CancellationToken cancellationToken = default);

    int SaveChanges();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
    void ExecuteRawCommand(string query, params object[] parameters);
    
    bool EnsureCreated();
    
    void MigrateDb();
    
    Task MigrateDbAsync(CancellationToken cancellationToken = default);
    
}