namespace Behlog.Core;

public interface IBehlogDbContext : IDisposable
{

    void BeginTransaction();
    
    void RollbackTransaction();
    
    void CommitTransaction();

    int SaveChanges();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
    void ExecuteRawCommand(string query, params object[] parameters);
    
    bool EnsureCreated();
    
    void MigrateDb();
    
    Task MigrateDbAsync(CancellationToken cancellationToken = default);
    
}