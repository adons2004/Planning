namespace Planning.Domain.Contracts;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void SaveChanges();
}