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

    Task ExecuteRawCommandAsync(
        string query, object[] parameters, CancellationToken cancellationToken = default);
    
    bool EnsureCreated();

    Task<bool> EnsureCreatedAsync(CancellationToken cancellationToken = default);
    
    void MigrateDb();
    
    Task MigrateDbAsync(CancellationToken cancellationToken = default);

    bool CheckDatabaseExist();

}