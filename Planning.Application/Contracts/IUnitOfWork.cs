namespace Planning.Application.Contracts;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void SaveChanges();
}